using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class scriptTejo : MonoBehaviour
{
    public Transform pivot;
    public float springRange;
    Rigidbody2D rb;
    Rigidbody2D rbTejo;
     bool canDrag = true;
    Vector3 dis;
    public float maxVel;/// como es public se fija por administrador, no es proporcional, deberia ser proporcional
    /// a la distancia desde el tejo al centro
    float anguloAnterior;
    string nombreTejo = "tejoAnim1";
    string nombreTejoCPU = "tejoAnimCPU";
    static public string NOMBRE_TEJO_GUIA = "tejoVistaSup800b";
    string NOMBRE_FLECHA_ROJA = "flechaRoja";
    String NOMBRE_FLECHA_AMARILLA = "flechaAmarilla";
    public string ANIMACION_GUIA_MECANICA = "guiaMecanica";
    string nombrePlayer = "player1a";
    string NOMBRE_CPU = "lanzadorCPU";
    string BOOL_ACTIVAR_LANCE = "activarLance";
    string BOOL_TEJO_EN_AIRE = "tejoEnAire";
    string BOOL_START_ANIMAR_GUIA = "startAnimarGuia";
    string BOOL_FIN_ANIMAR_GUIA = "finAnimarGuia";
    string TEXT_SCORE_CPU = "textScoreCPU";
    string TEXT_SCORE_PLAYER = "textScorePlayer";
    string TEXT_SCORE_TO_WIN = "textScoreToWin";

    string TEXT_WINNER = "TextWinner";
    string LABEL_SCORE_PLAYER = "score Player : ";
    string LABEL_SCORE_CPU = "score CPU : ";
    Vector3 POSICION_INICIAL_TEJO_GUIA = new Vector3(-6.42f,-1.05f,0);
    Vector3 DIS_PARA_6PUNTOS_BOCIN = new Vector3(-1.9f, -0.6f, 0.0f);
    ///// la idea con la velocidad de 3 puntos de prueba es para hacer un random para el cpu que varie respecto
    ///// a acertar al la mecha de 3 puntos de abajo de vez en cuando, y a partir de ahi se podria incrementar
    ///// el nivel
    ///// tambien mencionar la idea aki, que la maxvel fija es por pantalla y es de 15 , luego esta podria ser la maxima
    //// y variar respecto a la distancia del tejo indicador a la posicion inicial guia 
    Vector3 DIS_PARA_3PUNTOS_MECHA = new Vector3(-1.3f, -0.3f, 0.0f);
    Vector3 DIS_PARA_PROBAR_MANO = new Vector3(-1.9f, -0.5f, 0.0f);
    float VEL_6_PUNTOS = 15f; 
    string[] arrayNombresFuerzas = {"fuerza1","fuerza2","fuerza3","fuerza4","fuerza5","fuerza6","fuerza7"};
    //	static int derechoState = Animator.StringToHash("Base Layer.levantaBrazoDerecho");		
    static int stateLanzando = Animator.StringToHash("Base Layer.lanzando");		
    static int stateIdle = Animator.StringToHash("Base Layer.idle");		
    static int stateReposo = Animator.StringToHash("Base Layer.reposo");		
    static int stateTejoEnAire = Animator.StringToHash("Base Layer.tejoEnAire");
    public Transform prefabMecha;
    //Vector3 posPrimeraMecha = new Vector3(0.9266953f,0.03f, -7.3f);
    Vector3 posPrimeraMecha = new Vector3(0.92f,0.44f, -8.8f);
    ///0.92 0.44 -8.8
    List<string> lstMechas; 
    private float width;
    private float height;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;    
        if(  GameObject.Find (nombreTejo) != null ){
            rbTejo = GameObject.Find (nombreTejo).GetComponent<Rigidbody2D>();
            rbTejo.bodyType = RigidbodyType2D.Kinematic;
        }
        if(  GameObject.Find (nombreTejoCPU ) != null ){
            BoxCollider2D boxColliderTejoCPU = GameObject.Find (nombreTejoCPU).GetComponent<BoxCollider2D>();
            boxColliderTejoCPU.enabled = false;
            Rigidbody2D  rbTejoCPU = GameObject.Find (nombreTejoCPU).GetComponent<Rigidbody2D>();
            rbTejoCPU.bodyType = RigidbodyType2D.Kinematic;
        }
        foreach(string nameForce in arrayNombresFuerzas){
            if(  GameObject.Find (nameForce) != null ){
                //GameObject.Find (nameForce).gameObject.SetActive(false); 
                //GameObject.Find (nameForce).gameObject.rendered=false; 
                GameObject.Find (nameForce).gameObject.GetComponent<Renderer>().enabled = false;
                //rotarIndicador(nameForce,20,21);
            }
        }
        List<string> lstMechas = new List<string>(); 
        //GameObject.Find (NOMBRE_CPU).gameObject.SetActive(false);
        //Transform tranfLanzadorCPU = GameObject.Find (NOMBRE_CPU).gameObject.GetComponent<Transform>();
        //tranfLanzadorCPU.position = new Vector3(tranfLanzadorCPU.x,tranfLanzadorCPU.y, 0);
        SpriteRenderer sprite = GameObject.Find (NOMBRE_CPU).gameObject.GetComponent<SpriteRenderer>();
        sprite.sortingOrder = 0;
        Text textWinner = GameObject.Find(TEXT_WINNER).GetComponent<Text>();
        textWinner.text = "-";
        Text textScorePlayer = GameObject.Find(TEXT_SCORE_PLAYER).GetComponent<Text>();
        textScorePlayer.text = LABEL_SCORE_PLAYER;
        Text textScoreCPU = GameObject.Find(TEXT_SCORE_CPU).GetComponent<Text>();
        textScoreCPU.text = LABEL_SCORE_CPU;
        SpriteRenderer spriteFlechaAmarilla = GameObject.Find (NOMBRE_FLECHA_AMARILLA).gameObject.GetComponent<SpriteRenderer>();
        spriteFlechaAmarilla.sortingOrder = 0;
        Animator animGuia = GameObject.Find (ANIMACION_GUIA_MECANICA).GetComponent<Animator>();
        animGuia.SetBool(BOOL_START_ANIMAR_GUIA,true);
        Invoke("finAnimacionMecanica",9);
        /*for(int i = 1; i < 4; i++){
             Vector3 pos = new Vector3(posPrimeraMecha.x+i,posPrimeraMecha.y,posPrimeraMecha.z);
             UnityEngine.Object newRemote = Instantiate(prefabMecha, pos ,Quaternion.identity);
             string name = "flecha"+i;
             newRemote.name = name;
             lstMechas.Add(name);
        }*/
        // botonStart.gameObject.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        /* if(  GameObject.Find (nombrePlayer) != null ){
                Animator anim = GameObject.Find (nombrePlayer).GetComponent<Animator>();
                AnimatorStateInfo currentBaseState = anim.GetCurrentAnimatorStateInfo(0);
                if( currentBaseState.nameHash == stateReposo){
                    lanzarTejo();
                }
        }*/
        //rotarIndicador(arrayNombresFuerzas[3],90,85);
         // Handle screen touches.
        Debug.Log ("**** update de scriptTejo ");
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Debug.Log ("**** touch detectado  ");
            // Move the cube if the screen has the finger moving.
            Vector2 pos = touch.position;
            pos.x = (pos.x - width) / width;
            GameObject.Find (NOMBRE_TEJO_GUIA).GetComponent<Transform>().position = pos;
        }
    }
    void OnMouseDown(){
        /// GameObject.Find (NOMBRE_TEJO).GetComponent<Transform>().position += Vector3.right * 10;
        GetComponent<Transform>().position = Vector3.right * 30;
        //OnMouseDrag();
    }
    void OnMouseDrag(){
        if(!canDrag){
            return;
        }
        //var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var pos1 =  Input.mousePosition;
        pos1.z = 10;
       
        Vector3 pos = Camera.main.ScreenToWorldPoint( pos1 );
        //var pos = Input.mousePosition;
        dis = pos - pivot.position;
        dis.z = 0;///estaba en 0
        //Vector3 targetDir = target.position - transform.position;
        //float x = dis.x/
        float arctang = Mathf.Atan(dis.y/dis.x);
        float degreesArcTg =  arctang * Mathf.Rad2Deg;
        float angle = Vector3.Angle( pivot.position, pos);
        Debug.Log ("**** arc tang  "+arctang+" dis x "+dis.x+"  dis y "+dis.y+" arctg degree "+degreesArcTg);
        float angleTest = Vector3.Angle(new Vector3(0,0,0),new Vector3(10,10,0));
        Debug.Log ("**** pos "+pos+" pivot position "+pivot.position+" angle "+angle);
        Debug.Log ("**** angleTest "+angleTest);
        angleTest = Vector3.Angle(new Vector3(0,0,0), dis );
        Debug.Log ("**** angleTest2 "+angleTest);
        if( dis.magnitude > springRange ){
            dis = dis.normalized * springRange;
        } 
        float fraccion = springRange/7;
        SpriteRenderer spriteFlechaRoja = GameObject.Find (NOMBRE_FLECHA_ROJA).gameObject.GetComponent<SpriteRenderer>();
        spriteFlechaRoja.sortingOrder = 0;
        SpriteRenderer spriteFlechaAmarilla = GameObject.Find (NOMBRE_FLECHA_AMARILLA).gameObject.GetComponent<SpriteRenderer>();
        spriteFlechaAmarilla.sortingOrder = 1;
        mostrarIndicador(degreesArcTg, dis);
        Button buttonHighScores = GameObject.Find (Collision.NAME_CANVAS).GetComponent<Transform>().Find(Collision.BUTTON_HIGHSCORES).GetComponent<Button>();
        buttonHighScores.gameObject.SetActive(false);
        /* if(dis.magnitude > 0f || dis.magnitude < fraccion){
             Debug.Log ("**** mostrando a fuerza1 "+ arrayNombresFuerzas[0]);
             string nameForce =  arrayNombresFuerzas[0];
             if(  GameObject.Find (nameForce) != null ){
                //GameObject.Find (nameForce).gameObject.SetActive(true); 
                GameObject.Find (nameForce).gameObject.GetComponent<Renderer>().enabled = true;
                Debug.Log ("**** mostrando fuerza1 ");
             }
        }
         if(dis.magnitude > (fraccion*6) && dis.magnitude < (fraccion*7) ){
              Debug.Log ("**** mostrando a fuerza7 ");
             string nameForce =  arrayNombresFuerzas[6];
             if(  GameObject.Find (nameForce) != null ){
                //GameObject.Find (nameForce).gameObject.SetActive(true); 
                GameObject.Find (nameForce).gameObject.GetComponent<Renderer>().enabled = true;
                Debug.Log ("**** mostrando fuerza7 ");
             }
         }*/
        transform.position = dis + pivot.position;
        Debug.Log ("**** transform.position "+transform.position+" pos  "+pos+" fraccion "+fraccion);
        Debug.Log ("**** dis.magnitude "+dis.magnitude+" springRange  "+springRange);
        //transform.position = pos;
    }
    private void mostrarIndicador(float angulo, Vector3 posicion){
        float fraccion = springRange/7;  
        if(  GameObject.Find ("TextAngulo") != null ){
            GameObject.Find ("TextAngulo").gameObject.GetComponent<Text>().text = ""+angulo;
        } 
        foreach(string nameForce in arrayNombresFuerzas){
            if(  GameObject.Find (nameForce) != null ){
                GameObject.Find (nameForce).gameObject.GetComponent<Renderer>().enabled = false;
                //// para en angulo de la rotacion alrededor del eje z
                float anguloIndicador = GameObject.Find (nameForce).gameObject.GetComponent<Transform>().rotation.eulerAngles.z;
                float anguloSinRotation =  GameObject.Find (nameForce).gameObject.GetComponent<Transform>().eulerAngles.z;
                Debug.Log ("**** rotation  "+anguloIndicador+" angulo "+angulo+" euler sin rotation "+anguloSinRotation);
            }
        }
        if(dis.magnitude > 0f && dis.magnitude < fraccion){
             Debug.Log ("**** mostrando a fuerza1 "+ arrayNombresFuerzas[0]);
             string nameForce =  arrayNombresFuerzas[0];
             rotarIndicador(nameForce,angulo, anguloAnterior, posicion);
        }
        if(dis.magnitude > (fraccion*1) && dis.magnitude < (fraccion*2) ){
              Debug.Log ("**** mostrando a fuerza7 ");
             string nameForce =  arrayNombresFuerzas[1];
             rotarIndicador(nameForce,angulo, anguloAnterior, posicion);
        }
        if(dis.magnitude > (fraccion*2) && dis.magnitude < (fraccion*3) ){
              Debug.Log ("**** mostrando a fuerza7 ");
             string nameForce =  arrayNombresFuerzas[2];
             rotarIndicador(nameForce,angulo, anguloAnterior, posicion);
        }
        if(dis.magnitude > (fraccion*3) && dis.magnitude < (fraccion*4) ){
              Debug.Log ("**** mostrando a fuerza7 ");
             string nameForce =  arrayNombresFuerzas[3];
             rotarIndicador(nameForce,angulo, anguloAnterior, posicion);
        }
        if(dis.magnitude > (fraccion*4) && dis.magnitude < (fraccion*5) ){
              Debug.Log ("**** mostrando a fuerza7 ");
             string nameForce =  arrayNombresFuerzas[4];
             rotarIndicador(nameForce,angulo, anguloAnterior, posicion);
        }
        if(dis.magnitude > (fraccion*5) && dis.magnitude < (fraccion*6) ){
              Debug.Log ("**** mostrando a fuerza7 ");
             string nameForce =  arrayNombresFuerzas[5];
             rotarIndicador(nameForce,angulo, anguloAnterior, posicion);
        }
         if(dis.magnitude > (fraccion*6) && dis.magnitude < (fraccion*7) ){
              Debug.Log ("**** mostrando a fuerza7 ");
             string nameForce =  arrayNombresFuerzas[6];
             rotarIndicador(nameForce,angulo, anguloAnterior, posicion);
        }
        anguloAnterior = angulo;
    }
    /***  // Rotate the cube by converting the angles into a quaternion.
        Quaternion target = Quaternion.Euler(tiltAroundX, 0, tiltAroundZ);

        // Dampen towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime * smooth); */
    void rotarIndicador(string nameForce, float angulo, float anguloAnterior,Vector3 posicionRelativa ){
        float anguloMediaVuelta = 180;
        if(  GameObject.Find (nameForce) != null ){
                //GameObject.Find (nameForce).gameObject.SetActive(true); 
                GameObject.Find (nameForce).gameObject.GetComponent<Renderer>().enabled = true;
                /// tranform es para las fuerza indicador que se quiere rotar
                Transform transform =  GameObject.Find (nameForce).gameObject.GetComponent<Transform>();
                Transform transformFlecha =  GameObject.Find (NOMBRE_FLECHA_AMARILLA).gameObject.GetComponent<Transform>();
                if(  angulo != anguloAnterior ){/// la rotacion no esta funcionando bien
                    //// tocara mirar despues para lograr el mismo efecto de acompañar la rotacion como worms party
                    if( posicionRelativa.x < 0 ){
                        angulo= anguloMediaVuelta + angulo;
                    } else {
                        angulo= angulo;
                    }
                    //GameObject.Find (nameForce).gameObject.GetComponent<Transform>().Rotate(0, 0, angulo, Space.Self);
                    Quaternion target = Quaternion.Euler(0, 0, angulo);
                    Quaternion targetFlecha = Quaternion.Euler(0, 0, angulo-180);
                    float smooth = 3f;
                    Debug.Log ("**** a rotar con quaternion "+angulo+" posicionRelativa "+posicionRelativa);
                    //transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime * smooth); 
                    transformFlecha.rotation = Quaternion.Slerp(transformFlecha.rotation, targetFlecha,  
                        Time.deltaTime * smooth); ;
                }
                Debug.Log ("**** mostrando "+nameForce);
             }
    }
    void OnMouseUp(){
        if(!canDrag)
            return;
        canDrag = false;
        ///rb es el tejo de guia que se lanzaba para las pruebas iniciales pero ya no se lanza para dejarlo
        //// solo como uso de guia
        //rb.bodyType = RigidbodyType2D.Dynamic;
        //rb.velocity = -dis.normalized * maxVel;
        Invoke("resetearPosicion",3);/// el time tiene q ser mas de lo que dure la animacion 
        GameObject.Find (NOMBRE_TEJO_GUIA).GetComponent<Collider2D>().enabled = false;
       // lanzarTejo();
        animarPlayer();
        SpriteRenderer spriteFlechaRoja = GameObject.Find (NOMBRE_FLECHA_ROJA).gameObject.GetComponent<SpriteRenderer>();
        spriteFlechaRoja.sortingOrder = 1;
        SpriteRenderer spriteFlechaAmarilla = GameObject.Find (NOMBRE_FLECHA_AMARILLA).gameObject.GetComponent<SpriteRenderer>();
        spriteFlechaAmarilla.sortingOrder = 0;
    }
    void resetearPosicion(){
        GetComponent<Transform>().position = POSICION_INICIAL_TEJO_GUIA;
    }
    void lanzarTejoNoSeUsa(){
         	if(  GameObject.Find (nombreTejo) != null ){
                Animator anim = GameObject.Find (nombreTejo).GetComponent<Animator>();
                 AnimatorStateInfo currentBaseState = anim.GetCurrentAnimatorStateInfo(0);
                if( currentBaseState.nameHash != stateTejoEnAire){
                    anim.SetBool(BOOL_TEJO_EN_AIRE,true);
                }
                rbTejo = GameObject.Find (nombreTejo).GetComponent<Rigidbody2D>();
                rbTejo.bodyType = RigidbodyType2D.Dynamic;
                rbTejo.velocity = -dis.normalized * maxVel;
                //transFormSpider = GameObject.Find (nombreTejo).GetComponent<Transform>();
                //posicionInicialSpider = transFormSpider.position.y;
                //botonStart.gameObject.SetActive(false); 
            }
    }
    void finAnimacionMecanica(){
        Debug.Log ("**** fin animacion mecanica ");
        Animator animGuia = GameObject.Find (ANIMACION_GUIA_MECANICA).GetComponent<Animator>();
        animGuia.SetBool(BOOL_FIN_ANIMAR_GUIA,true);
        animGuia.SetBool(BOOL_START_ANIMAR_GUIA,false);
    }
    void animarPlayer(){
        Debug.Log ("**** en animar player ");
        if(  GameObject.Find (nombrePlayer) != null ){
                Animator anim = GameObject.Find (nombrePlayer).GetComponent<Animator>();
                AnimatorStateInfo currentBaseState = anim.GetCurrentAnimatorStateInfo(0);
                if( currentBaseState.nameHash != stateLanzando){
                    anim.SetBool(BOOL_ACTIVAR_LANCE,true);
                    scriptLanceTejo script = GameObject.Find (nombrePlayer).GetComponent<scriptLanceTejo>();
                    //// el maxvel es fijo por pantalla tons no me acuerdo si tiene sentido modificarlo por aca
                    /// para pruebas con valores forzados
                    //// el maxvel del player siempre se va por el mismo valor pero deberia irse proporcional
                    //// a la distancia del tejo guia al centro
                    //dis = DIS_PARA_6PUNTOS_BOCIN;
                    //maxVel = VEL_6_PUNTOS;
                    //dis = DIS_PARA_3PUNTOS_MECHA;
                    //maxVel = VEL_6_PUNTOS;
                    //dis = DIS_PARA_3PUNTOS_MECHA;
                    //maxVel = maxVel*0.99f;/// para provocar desacierto muy cerca de la colision
                    script.copiarValores(dis, maxVel, nombreTejo );
                    // void copiarValorDis(Vector3 elDis){
                }
        }
    }
    public void setCanDrag(bool unCanDrag){
        canDrag = unCanDrag;
    }
    public bool isCanDrag(){
        return canDrag;
    }
    void codigoGuia(){
        	/* if(  GameObject.Find (nombreObjetoSpyder) != null ){
                anim = GameObject.Find (nombreObjetoSpyder).GetComponent<Animator>();
                rigidBody = GameObject.Find (nombreObjetoSpyder).GetComponent<Rigidbody>();
                transFormSpider = GameObject.Find (nombreObjetoSpyder).GetComponent<Transform>();
                posicionInicialSpider = transFormSpider.position.y;
            }
            if( anim != null ){
					currentBaseState = anim.GetCurrentAnimatorStateInfo(0);	// set our currentState variable to the current state of the Base Layer (0) of animation
					//Rigidbody rb = GetComponent<Rigidbody>();
					if( currentBaseState.nameHash != derechoState  && (brazoDerecho > brazoIquierdo) ){
						fuerza += fuerzaSubida;
						Debug.Log ("**** activar movimiento brazo derecho, currentBaseState "+currentBaseState);
						anim.SetBool(BOOL_DERECHO_ARRIBA,true);*/
    }
}
