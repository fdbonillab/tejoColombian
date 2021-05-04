using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptLanceTejo : MonoBehaviour
{
     string nombreTejo = "tejoAnim1";
     string BOOL_TEJO_EN_AIRE = "tejoEnAire";
     string NOMBRE_TEJO_GUIA = "tejoVistaSup800b";
     string tejoALanzar; 

     Rigidbody2D rbTejo;
     float maxVel;
     static int stateTejoEnAire = Animator.StringToHash("Base Layer.tejoEnAire");
     Vector3 dis;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //// lanzarTejo no se ejecuta desde un metodo o clase si no desde el final de una animacion, como animaciones concatenadas
    ///
    void lanzarTejo(){
            scriptTejo script = GameObject.Find (NOMBRE_TEJO_GUIA).GetComponent<scriptTejo>();
            //script.setCanDrag(true);
         	if(  GameObject.Find (nombreTejo) != null && !script.isCanDrag()){
                /*if( dis.magnitude ==  0){ // codigo para forzar un lance de prueba en caso que los datos del lance queden 0 porque se sobrescriban o algo
                     dis = new Vector3(-1.9f,-0.5f,0.0f);
                     maxVel = 10;
                }*/
                Debug.Log ("**** en scriptLanceTejo.lanzando dis magnitude "+dis.magnitude+" maxVel "+maxVel+" time "+System.DateTime.Now);
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
            }
    }
    public void copiarValores(Vector3 elDis, float elMaxVel){
        dis = elDis;maxVel = elMaxVel;
        Debug.Log ("**** en scriptLanceTejo.copiando dis magnitude "+dis.magnitude+" dis vector "+elDis+" time "+System.DateTime.Now);
    }
  
}
