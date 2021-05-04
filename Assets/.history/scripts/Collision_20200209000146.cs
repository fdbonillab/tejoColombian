﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using com.shephertz.app42.gaming.multiplayer.client;  
using com.shephertz.app42.gaming.multiplayer.client.events;  
using com.shephertz.app42.gaming.multiplayer.client.command;  
using com.shephertz.app42.gaming.multiplayer.client.listener;  
using SimpleJSON;

/**
se agrego un quadpiso para sostener el tejo cuando cae al final de cada juego y
asi evitar el bug que no deja hacer el lance del cpu , el bug es por que cuando cae
queda dentro de la distancia un poco mas lejos de la distancia permitida q es 2
*/
public class Collision : MonoBehaviour
{
    Vector3 posicionInicialTejo = new Vector3(-8.28f,-1.975775f,0);
    //Vector3 posicionInicialTejoCPU = new Vector3(-7.13f,-1.975775f,0);
    Vector3 posicionInicialTejoCPU = new Vector3(-8.28f,-1.975775f,0);
    string NOMBRE_TEJO = "tejoAnim1";
    string NOMBRE_TEJO_CPU = "tejoAnimCPU";
    string NOMBRE_TEJO_GUIA = "tejoVistaSup800b";
    string NOMBRE_PLAYER = "player1a";
    string NOMBRE_CPU = "lanzadorCPU";
    string NOMBRE_ARCILLA = "arcillaTejo800";
    string NOMBRE_MECHA_1 = "arcillaMecha1";
    string NOMBRE_MECHA_BOCIN = "arcillaMechaBocin";
    string NOMBRE_MECHA_3 = "arcillaMecha3";
    string NOMBRE_QUAD_PISO = "QuadPiso";
    string NOMBRE_CENTRO_BOCIN = "centroBocin";
    public static string NOMBRE_SCENE_PRINCIPAL = "sceneGameI2f";//// cambiar cada vez q se cree otra version de escena principal
    public static string NOMBRE_SCENE_HIGHSCORES = "tablaScores2";
    public static string NAME_PREF_USERNAME = "username";
    public static string NAME_PREF_USERNAME_ANTERIOR = "";
    string TEXT_SCORE_PLAYER = "textScorePlayer";
    string TEXT_SCORE_PLAYER2 = "textScorePlayer2";

    string TEXT_SCORE_CPU = "textScoreCPU";
    string TEXT_SCORE_CPU2 = "textScoreCPU2";
    string TEXT_SCORE_TO_WIN = "textScoreToWin";

    string TEXT_WINNER = "TextWinner";
    string TEXT_SCORE_MECHA = "textScoreMecha";
    string TEXT_SCORE_MECHA2 = "textScoreMecha2";
    string TEXT_TURNO = "TextTurno";
    public static string TEXT_NICK = "textNick";
    public static string TEXT_DEBUG = "textDebug";
    string TEXT_CONTADOR_TURNOS = "textTurnos";
    string BUTTON_NEW_GAME = "ButtonNewGame";
    public static string BUTTON_HIGHSCORES = "ButtonHighScores";
    //// algun dia pasara las constantes a una sola clase
    public static string NAME_CANVAS = "Canvas";
    string BOOL_TEJO_EN_AIRE = "tejoEnAire";
    string BOOL_ACTIVAR_LANCE = "activarLance";
    string BOOL_ACTIVAR_LANCE_CPU = "activarLanceCPU";
    string BOOL_FIN_LANCE = "finLance";
    string BOOL_FIN_LANCE_CPU = "finLanceCPU";
    string BOOL_NUEVO_INTENTO = "nuevoIntento";
    string LABEL_SCORE_PLAYER = "score Player : ";
    string LABEL_SCORE_CPU = "score CPU : ";
    string LABEL_CONTADOR_TURNOS = "turnos : ";
    string LABEL_NICK = "Nickname : ";
    string NAME_HIGHSCORES = "highscores";
    static int LEVEL_1 = 1;
    
    static int scoreCPU = 0; 
    static int scorePlayer = 0;
    int PUNTAJE_BOCIN = 6;
    int PUNTAJE_MECHA = 3;
    int PUNTAJE_MANO = 1;
    int PUNTAJE_OBJETIVO_27 = 27;
    static int PUNTAJE_OBJETIVO_10 = 10;
    int PUNTAJE_OBJETIVO_5 = 5;
    bool activadoLanceCPU = false;
    bool activadoLancePlayer = false;
    bool mostrandoCPU = false;
    static bool finDeJuego = false;
    static int turno =  0;
    int lanceDE = 0;
    static int incremento = 0;
    int TURNO_PLAYER = 0;
    int TURNO_CPU = 1;
    int rank = 100;
    static int turnosPlayer = 1;
    static int turnosCPU = 0;
    int scoreWin;
    static int contadorTurnos = 0;
    static float distanciaABocinPlayer = 1000;
    static float distanciaABocinCPU = 1000;
    float MAX_DISTANCE = 1000;
    static float tiempo = 0;
    static int LIMITE_RESUMENES = 400;/// en 450 muere por threhold 
    WarpClient myWarpClient;
    listenerWarp listener;
    float fuerzaEnemyWarp = 0;
	string nameEnemyWarp = "";
    bool yaHayRespuestaParaRanking = false;
    Vector3 DIS_PARA_3PUNTOS_MECHA = new Vector3(-1.3f, -0.3f, 0.0f);
    Vector3 DIS_PARA_6PUNTOS_BOCIN = new Vector3(-1.9f, -0.6f, 0.0f);
    Vector3 DIS_PARA_6PUNTOS_BOCIN2 = new Vector3(-1.9f,-0.5f,0.0f);

     static int stateLanzando = Animator.StringToHash("Base Layer.lanzando");		
    static int stateIdle = Animator.StringToHash("Base Layer.idle");		
    static int stateReposo = Animator.StringToHash("Base Layer.reposo");		
    static int stateTejoEnAire = Animator.StringToHash("Base Layer.tejoEnAire");
    static string username;
    List<Resultado> lstResultados;
    ManagerConsultaScoresJson managerConsulta;
    ManagerConsultaHighScores managerConsultaHighScores;
    
    static Resultado ultimoResultado;
    bool esPC = (Application.platform != RuntimePlatform.Android);
    /// estos son los keys de spider que ya se que funcionan 
    /*public string apiKey = "39a0365d03a56bfdad1a6854dfdd2ab28ff92114e44fd39ba321f1fb72f2eff5";
	public string secretKey = "90c1da8c7d4b3cc61760346b10771d6cdf5d3b9746bfd593c8cade27bc716ed5";
    */

    //// estos son creados especificamente para el tejo
    public string apiKey = "5e8c1c2c90dafb1b4024609fa2af2189cb21f02726e5cb8dbd7365dd2e14f879";
	public string secretKey = "4326a27aa58806934875fb472e762dbe060309151e32c83ab9e85c8be9278bde";
    // Start is called before the first frame update
    void Start()
    {
        Text  textToWin =  GameObject.Find(TEXT_SCORE_TO_WIN).GetComponent<Text>();
        scoreWin = PUNTAJE_OBJETIVO_10;
        textToWin.text = textToWin.text+" "+scoreWin;
        Debug.Log ("**** en start de escena "+scoreWin);
        Text textScoreMecha = GameObject.Find(TEXT_SCORE_MECHA).GetComponent<Text>();
        textScoreMecha.text = "-";
        managerConsulta = new ManagerConsultaScoresJson();
        managerConsultaHighScores = new ManagerConsultaHighScores();
        managerConsultaHighScores.consultarScores();
        //managerConsulta.consultarScores();
        lstResultados = managerConsulta.getLstResultados();
        WarpClient.initialize( apiKey, secretKey); 
		myWarpClient = WarpClient.GetInstance();  
		listener = new listenerWarp();
		myWarpClient.AddConnectionRequestListener( listener ); 
		//myGame.GetInstance().AddChatRequestListener(listen);
		//myWarpClient.AddUpdateRequestListener(listener);///parece que no se necesita aun
		myWarpClient.AddLobbyRequestListener(listener);
		myWarpClient.AddNotificationListener(listener);
		myWarpClient.AddRoomRequestListener(listener);
		myWarpClient.AddZoneRequestListener(listener);
		username = System.DateTime.UtcNow.Ticks.ToString();
		username = username.Substring(username.Length-4);   
		username = "guest"+username;
		Debug.Log ("**** username local "+username);
        Text textNick = GameObject.Find(TEXT_NICK).GetComponent<Text>();
        textNick.text = LABEL_NICK+userNameFromPreferences();
		myWarpClient.Connect(username);   
        mostrarRankingConNick();
        //testToJson();
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D rbTejo = GetComponent<Rigidbody2D>();
        Transform transformTejo = GetComponent<Transform>();
        float distancia = Vector2.Distance( transformTejo.position, posicionInicialTejo);
        Transform transformPiso = GameObject.Find(NOMBRE_QUAD_PISO).GetComponent<Transform>();
        Text textTurno = GameObject.Find(TEXT_TURNO).GetComponent<Text>();
        string nameParent = transformTejo.name;
        Debug.Log ("**** magnitude  "+rbTejo.velocity.magnitude+" posicion "+transformTejo.position+" distancia "+distancia+
        " turnos player "+turnosPlayer+" turnos cpu "+turnosCPU+" incremento "+incremento+
        " name parent tejo "+nameParent+" turno "+turno+" finDejuego "+finDeJuego);
        incremento++;
        tiempo += Time.deltaTime;
        float DISTANCIA_PERMITIDA = 2;
        Debug.Log ("**** tiempo "+tiempo+" modulo tiempo%1 "+tiempo%1);
        if( !yaHayRespuestaParaRanking && lstResultados == null ){
            mostrarRankingConNick();
            if( lstResultados != null ){
                yaHayRespuestaParaRanking = true;
            }
        }
        if ( !finDeJuego  ){
             if( ( (rbTejo.velocity.magnitude < 1 && distancia > DISTANCIA_PERMITIDA ) || transformTejo.position.y < transformPiso.position.y) ){
                //Invoke("nuevoIntento",1);//activarLanceCPU
                //// analisis: si lo q hace el cambio de turno es el contador de turnos se deberia dejar al final del lance el incremento que seria la colision
                //// al final del lance
                /// otra idea con el name parent y la colision reciente
                //// si el parent es tejo player entonces sigue el turno de la cpy si entonces es turno del player
                if( turno != TURNO_CPU && nameParent.Equals(NOMBRE_TEJO) && turnosPlayer > turnosCPU){
                    Debug.Log ("**** entrando para dar turno cpu ");
                    Invoke("activarLanceCPU",0.2f);// estaba en 0.1f
                    //activadoLanceCPU = true;
                    turno = TURNO_CPU;
                    textTurno.text = "TURNO CPU";
                } else if( turno != TURNO_PLAYER && nameParent.Equals(NOMBRE_TEJO_CPU) && turnosPlayer == turnosCPU ){
                    /// la colision esta tomando la colision para el cpu antes que la logica de nuevo intento arranque
                    Debug.Log ("**** entrando para dar turno player ");
                    if(!finDeJuego){/// redudante con la condicion de afuera?
                          Invoke("nuevoIntento",1f); 
                        ///activadoLancePlayer = true;
                        turno = TURNO_PLAYER;//// se va cambiar a nuevointento para ver si resuelve in bug q suma los aciertos de la cpu al player
                        textTurno.text = "TURNO PLAYER";
                        //validarGanoPlayer();
                    }
                }
                validarGanoPlayer();
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape)){
             Debug.Log ("**** saliendo keydown 1");
            //// si le da salir por lo menos ver hasta donde llego, cuantos turnos duro y que puntaje hizo
            ManagerScoresJson managerScoreJson = new ManagerScoresJson();
            string json = JsonUtility.ToJson(ultimoResultado);
            managerScoreJson.salvarScore(json);
            agregarResultadoEnHighScores(ultimoResultado);
            Debug.Log ("**** saliendo keydown 2");
                     {
             if (Application.platform == RuntimePlatform.Android)
             {
                 AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
                 activity.Call<bool>("moveTaskToBack", true);
             }
             else
             {
                 Application.Quit();
             }
         }
        } 
        ///// bloque para detectar input touch para mejorar usabilidad de indicador flecha
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Debug.Log ("**** touch detectado  ");
            // Move the cube if the screen has the finger moving.
            Vector2 pos = touch.position;
            //pos.x = (pos.x - width) / width;
            GameObject.Find (scriptTejo.NOMBRE_TEJO_GUIA).GetComponent<Transform>().position = pos;
        }
 			  
    }
    Resultado crearResultadoDePrueba(){
        
    }
    private void remplazarResultadosAnterioresConNuevoNick( List<Resultado> lstResultados ){
        string usernameEnPreference = PlayerPrefs.GetString(NAME_PREF_USERNAME);
        string usernameEnPreferenceAnterior = PlayerPrefs.GetString(NAME_PREF_USERNAME_ANTERIOR);
        foreach( Resultado unResultado in lstResultados){
                if( unResultado.getNick().Equals(usernameEnPreferenceAnterior)){
                    unResultado.setNick(usernameEnPreference);
                }
        }
    }
    private void agregarResultadoEnHighScores(Resultado elResultado){
        ManagerScoresJson managerScoreJson = new ManagerScoresJson();
        List<Resultado> lstResultadosHigh = managerConsultaHighScores.getListResultados();
        //// este seria el punto para remplazar los resultados viejos del usuario del numero generado por el nombre que escogio
        remplazarResultadosAnterioresConNuevoNick(lstResultadosHigh);
        Debug.Log ("**** 1 salvar resultado en highscores count  "+lstResultadosHigh.Count);
        Debug.Log ("**** es pc elResultado "+elResultado.getEsPC() );
        JSONArray paraArray = new JSONArray();
        int indice = 0;
        if( lstResultadosHigh != null){
            Debug.Log ("****  lstResultadosHigh not null");
            //lstResultadosHigh.Add(elResultado);
            remplazarMejorScore( lstResultadosHigh, elResultado );
            lstResultadosHigh = filtrarMejorResultadoPorUsuario(lstResultadosHigh);
            foreach( Resultado unResultado in lstResultadosHigh){
                string jsonRes = JsonUtility.ToJson(unResultado);
                //JSONObject jsonObject = JSONObject.Parse(jsonRes);
                JSONNode jsonNode = JSONObject.Parse(jsonRes);
                paraArray.Add(jsonNode);
                indice++;
                if( indice > LIMITE_RESUMENES){
                    break;
                }
            }
            //string json = JsonUtility.ToJson(ultimoResultado);
            JSONObject jsonObj = new JSONObject();
            //jsonObj.put("name", this.nodeService.getProperty(obj, ContentModel.PROP_NAME));
            jsonObj[NAME_HIGHSCORES] =  paraArray ;
            jsonObj["test33"] =  "test44" ;
            //jsonObj.put("test1", "Success");
            //jsonObj.put("test2", paraArray );
            string jsonObjeto = JsonUtility.ToJson(jsonObj);
            string jsonObjeto2 = jsonObj.ToString();
            managerScoreJson.salvarScore2(jsonObjeto2);
            Debug.Log ("**** 2 salvar resultado en highscores "+jsonObjeto2);
        }
    }
     public static List<Resultado> filtrarMejorResultadoPorUsuario(List<Resultado> unoslstResultados ){
        SortedDictionary<float, Resultado> mapPuntajes = new SortedDictionary<float, Resultado>();
        float criterioDesempate = 0;
        foreach(Resultado resultado in unoslstResultados){
            criterioDesempate = (float)(resultado.getScore())/(float)(resultado.getTurnos()+1);
            if( resultado.getScore() > resultado.getObjetivo()){
                criterioDesempate = criterioDesempate*5f;
            }
            if( resultado.getTurnos() == 0 ){
                criterioDesempate = criterioDesempate*0.1f;
            }
            Debug.Log ("**** map nick "+resultado.getNick()+" score "+resultado.getScore()+" turnos "+resultado.getTurnos());
            if( ! mapPuntajes.ContainsKey(criterioDesempate)){
                mapPuntajes[ criterioDesempate ] = resultado;
            } else {
                criterioDesempate+=Random.Range(0.0000f, 0.1f);
                Debug.Log ("**** criterio desempate "+criterioDesempate+" score "+resultado.getScore()+" turnos "+resultado.getTurnos()+" nick "+resultado.getNick());
                mapPuntajes[ criterioDesempate ] = resultado;
            }
        }
        Debug.Log ("**** 1 map count "+mapPuntajes.Count);
        ///SortedDictionary<int, Resultado> mapPuntajesReverse = mapPuntajes.Reverse();
        List<Resultado> lstResultados = new List<Resultado>();
        List<Resultado> lstResultadosReverse = new List<Resultado>();
        foreach(Resultado resultado in mapPuntajes.Values){
            Debug.Log ("**** map nick 2 "+resultado.getNick());
            if( !contieneCombinacionUsuarioNivelObjetivo( lstResultados,resultado)){
                lstResultados.Add(resultado);
            }
        }
        Debug.Log ("**** 2  map count "+lstResultados.Count);
        for(int i = lstResultados.Count-1;i >=0 ;i--){
            lstResultadosReverse.Add(lstResultados[i]);
        }
        Debug.Log ("**** 3  map count "+lstResultadosReverse.Count);
        return lstResultadosReverse;
    }
    public static bool contieneCombinacionUsuarioNivelObjetivo(SortedDictionary<int, Resultado> unMapPuntajes, Resultado unResultado){
        foreach(Resultado elResultado in unMapPuntajes.Values){
            if( elResultado.getNick().Equals(unResultado.getNick()) && elResultado.getNivel() == unResultado.getNivel() && elResultado.getObjetivo() == unResultado.getObjetivo()){
                return true;
            }
        }
        return false;
    }
    public static bool contieneCombinacionUsuarioNivelObjetivo( List<Resultado> unLstPuntajes, Resultado unResultado){
        foreach(Resultado elResultado in unLstPuntajes ){
            if( elResultado.getNick().Equals(unResultado.getNick()) && elResultado.getNivel() == unResultado.getNivel() && elResultado.getObjetivo() == unResultado.getObjetivo()){
                return true;
            }
        }
        return false;
    }
     private void remplazarMejorScore(List<Resultado> lstResultados, Resultado elResultado){
            bool resultadoAgregado = false;
            bool esMayorOIgual = false;
            foreach(Resultado unResultado in lstResultados ){
                 Debug.Log ("**** lstResultados en remplazarMejorScore  hight "+lstResultados.Count);
                if( unResultado.nick.Equals(elResultado.nick) && elResultado.getNivel() == unResultado.getNivel() &&
                   elResultado.getObjetivo() == unResultado.getObjetivo() && unResultado.getScore() < elResultado.getScore() && 
                   unResultado.getTurnos() <= elResultado.getTurnos() )
                { 
                    Debug.Log ("**** remplazando mejore score ");
                    lstResultados.Add(elResultado);
                     Debug.Log ("**** remplazando mejore score count "+lstResultados.Count);
                    lstResultados.Remove(unResultado);
                     Debug.Log ("**** remplazando mejore score count "+lstResultados.Count);
                    resultadoAgregado = true;
                    break;
                } else if ( unResultado.nick.Equals(elResultado.nick) && elResultado.getNivel() == unResultado.getNivel() &&
                   elResultado.getObjetivo() == unResultado.getObjetivo() && unResultado.getScore() >= elResultado.getScore() && 
                   unResultado.getTurnos() == elResultado.getTurnos()){
                       esMayorOIgual = true;
                }
            }
            if( !resultadoAgregado && !esMayorOIgual){
                Debug.Log ("**** no se remplazo mejore score ");
                lstResultados.Add(elResultado);
            }
        }
    public static void salirJuego(){
         Debug.Log ("**** boton salir juego saliendo keydown 1");
            //// si le da salir por lo menos ver hasta donde llego, cuantos turnos duro y que puntaje hizo
            ManagerScoresJson managerScoreJson = new ManagerScoresJson();
            bool esPC = false;
            esPC = (Application.platform != RuntimePlatform.Android);
            if( ultimoResultado == null ){
                ultimoResultado = new Resultado( username, LEVEL_1, PUNTAJE_OBJETIVO_10, 0, 0 , esPC);    
            }
            if( ultimoResultado != null ){
                ultimoResultado.setDeviceName(SystemInfo.deviceName);
                ultimoResultado.setDeviceModel(SystemInfo.deviceModel);
                ultimoResultado.setEsPC(esPC);
                Debug.Log ("**** device model "+ SystemInfo.deviceModel+" devicename "+SystemInfo.deviceName+" es pc "+esPC );
                string json = JsonUtility.ToJson(ultimoResultado);
                managerScoreJson.salvarScore(json); 
            }
            Debug.Log ("**** boton salir juego saliendo keydown 2");
             if (Application.platform == RuntimePlatform.Android)
             {
                 AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
                 activity.Call<bool>("moveTaskToBack", true);
             }
             else
             {
                 Application.Quit();
             }
    }
    void testToJson(){
         Resultado toResultado = new Resultado(1, 10, scorePlayer, 5, esPC);
         string json = JsonUtility.ToJson(toResultado);
         Debug.Log ("**** json test  "+json);
    }
    bool validarGanoPlayer(){
        Debug.Log ("**** en validar gano player turnosPlayer "+turnosPlayer+" turnosCPU "+turnosCPU+" turno "+turno);
        Text textWinner = GameObject.Find(TEXT_WINNER).GetComponent<Text>();
        username = userNameFromPreferences();
        if( scorePlayer != scoreCPU && scorePlayer > scoreWin && turnosPlayer == turnosCPU && turno == TURNO_PLAYER && !finDeJuego){
                textWinner.text = "Player WIN";
                finJuego();
                ManagerScores managerScore = new ManagerScores();
                managerScore.salvarScore(1.5f);
                Debug.Log ("**** username  "+username);
                ManagerScoresJson managerScoreJson = new ManagerScoresJson();
                Resultado toResultado = new Resultado(username,LEVEL_1, PUNTAJE_OBJETIVO_10, scorePlayer, contadorTurnos, esPC );
                string json = JsonUtility.ToJson(toResultado);
                managerScoreJson.salvarScore(json);
                return true;
        } else {
            ultimoResultado = new Resultado(username,LEVEL_1,PUNTAJE_OBJETIVO_10,scorePlayer,contadorTurnos, esPC );
        }
        return false;
    }
    private string userNameFromPreferences(){
           string usernameEnPreference = PlayerPrefs.GetString(NAME_PREF_USERNAME);
            if(  usernameEnPreference != null && !usernameEnPreference.Equals("")){
                username = usernameEnPreference;
                Debug.Log ("**** username existe preference --"+username+"--");
            } else {
                    username = System.DateTime.UtcNow.Ticks.ToString();
                    username = username.Substring(username.Length-4);   
                    username = "guest"+username;
                    PlayerPrefs.SetString(NAME_PREF_USERNAME, username);
            }
            return username;
    }
    void finJuego(){
        Debug.Log ("**** finjuego ");
        SpriteRenderer spriteCPU = GameObject.Find (NOMBRE_CPU).gameObject.GetComponent<SpriteRenderer>();
        spriteCPU.sortingOrder = 0;
        SpriteRenderer spritePlayer = GameObject.Find (NOMBRE_PLAYER).gameObject.GetComponent<SpriteRenderer>();
        spritePlayer.sortingOrder = 0;
        //Button buttonNewGame = GameObject.Find(BUTTON_NEW_GAME).GetComponent<Button>();
        Button buttonNewGame = GameObject.Find (NAME_CANVAS).GetComponent<Transform>().Find(BUTTON_NEW_GAME).GetComponent<Button>();
        buttonNewGame.gameObject.SetActive(true);
        Button buttonHighScores = GameObject.Find (NAME_CANVAS).GetComponent<Transform>().Find(BUTTON_HIGHSCORES).GetComponent<Button>();
        buttonHighScores.gameObject.SetActive(true);
        finDeJuego = true;
        Rigidbody2D rbTejo = GameObject.Find (NOMBRE_TEJO).GetComponent<Rigidbody2D>();
        rbTejo.bodyType = RigidbodyType2D.Kinematic;
        rbTejo.velocity = Vector3.zero;
        Vector3 dis = new Vector3(-1.9f,-0.5f,0.0f);//// dis para 3 puntos si esta en la misma posicion del tejo inicial
        //// o 6 si se mueve un poco adelante como desde la posicion de pruebas
        int maxVel = 0;
        scriptLanceTejo script = GameObject.Find (NOMBRE_CPU).GetComponent<scriptLanceTejo>();
        script.copiarValores(dis, maxVel, NOMBRE_TEJO );
        GameObject.Find (NOMBRE_TEJO).GetComponent<Transform>().position = posicionInicialTejo;
        //Text textWinner = GameObject.Find(TEXT_WINNER).GetComponent<Text>();
        //textWinner.text = "CPU WIN";
        //botonStart.gameObject.SetActive(true); 
    }
    public void  nuevoJuego(){
        //// se carga nuevamente la escena porque la forma en q se estaba haciendo con codigo reseteando manual
        ////mente esta dando muchos problemas, ademas me sirve para ir revisando para cuando vaya hacer un transicion
        //// del menu o algo asi
        //// estas variables son estaticas y quedan igual aunque se cargue la escena otra vez
        turnosPlayer = 1;
        turnosCPU = 0;
        scorePlayer = 0; 
        scoreCPU = 0;
        contadorTurnos = 0;
        turno = TURNO_PLAYER;/// a ver si esto resuelve el bug de que no arranca la cpu para el segundo juego
        finDeJuego = false;
        Debug.Log ("**** entrando a nuevo juego ");
        mostrarRankingConNick();
        SceneManager.LoadScene(NOMBRE_SCENE_PRINCIPAL, LoadSceneMode.Single);
    }
   
    public void nuevoJuegoOld(){
        Debug.Log ("**** nuevo juego ");
        /* SpriteRenderer spriteCPU = GameObject.Find (NOMBRE_CPU).gameObject.GetComponent<SpriteRenderer>();
        spriteCPU.sortingOrder = 0;
        SpriteRenderer spritePlayer = GameObject.Find (NOMBRE_PLAYER).gameObject.GetComponent<SpriteRenderer>();
        spritePlayer.sortingOrder = 3;
        GameObject.Find (NOMBRE_TEJO).GetComponent<Transform>().position = posicionInicialTejo;
        Rigidbody2D rbTejo = GameObject.Find (NOMBRE_TEJO).GetComponent<Rigidbody2D>();
        rbTejo.bodyType = RigidbodyType2D.Kinematic;
        rbTejo.velocity = Vector3.zero;*/
        //// para ver si esto arregla el bug con el turno de la cpu cuando empieza un nuevo juego
        GameObject.Find (NOMBRE_TEJO_CPU).GetComponent<Transform>().position = posicionInicialTejoCPU;
        Text textScorePlayer = GameObject.Find(TEXT_SCORE_PLAYER).GetComponent<Text>();
        Text textScoreCPU = GameObject.Find(TEXT_SCORE_CPU).GetComponent<Text>();
        textScorePlayer.text = LABEL_SCORE_PLAYER+0; 
        textScoreCPU.text = LABEL_SCORE_CPU+0;
        turnosPlayer = 1;
        turnosCPU = 0;
        scorePlayer = 0;
        scoreCPU = 0;
        finDeJuego = false;
        nuevoIntento();
        Button buttonNewGame = GameObject.Find (NAME_CANVAS).GetComponent<Transform>().Find(BUTTON_NEW_GAME).GetComponent<Button>();
        buttonNewGame.gameObject.SetActive(false);
        Button buttonHighScores = GameObject.Find (NAME_CANVAS).GetComponent<Transform>().Find(BUTTON_HIGHSCORES).GetComponent<Button>();
        buttonHighScores.gameObject.SetActive(false);
        Text textWinner = GameObject.Find(TEXT_WINNER).GetComponent<Text>();
        textWinner.text = "";
    }
      void OnCollisionEnter2D(Collision2D collision)
    {
        bool puntajeActualizado = false;
        Transform transformTejo = GetComponent<Transform>();
        Rigidbody2D rigidBodyTejo = GetComponent<Rigidbody2D>();
        string nameParent = transformTejo.name;
        Debug.Log ("**** colision detectada "+collision.gameObject.name+" turno "+turno+" "+nameParent);
        Debug.Log ("**** con lancede ");
        Text textScorePlayer = GameObject.Find(TEXT_SCORE_PLAYER).GetComponent<Text>();
        Text textScoreCPU = GameObject.Find(TEXT_SCORE_CPU).GetComponent<Text>();
        Text textScoreMecha = GameObject.Find(TEXT_SCORE_MECHA).GetComponent<Text>();
        Text textContadorTurnos = GameObject.Find(TEXT_CONTADOR_TURNOS).GetComponent<Text>();
        Text textWinner = GameObject.Find(TEXT_WINNER).GetComponent<Text>();
        if(  collision.gameObject.name.Equals(NOMBRE_ARCILLA) || collision.gameObject.name.Equals("QuadPiso")
        || collision.gameObject.name.Equals("QuadPared") && GameObject.Find (NOMBRE_PLAYER) != null ){
             Animator animPlayer = GameObject.Find (NOMBRE_PLAYER).GetComponent<Animator>();
             animPlayer.SetBool(BOOL_ACTIVAR_LANCE,false);/// se desactiva el lance
             ///aki ya q parece q si se espera un segundo a q lo tome el invoke, parece que el ciclo
             /// de la animacion se alcanza tan rapido q lo ejecuta dos veces
             //Invoke("nuevoIntento",1); /// se mueve al update
        }
        if(  collision.gameObject.name.Equals(NOMBRE_MECHA_1)|| collision.gameObject.name.Equals(NOMBRE_MECHA_3) ){
            //// si no funciona con lanceDE tocaria hacer un objeto de tejo nuevo solo para usar con la CPU
            
            if( nameParent.Equals(NOMBRE_TEJO)){
                Debug.Log ("**** sumando mecha para player "+scorePlayer+"+"+PUNTAJE_MECHA+" "+nameParent);
                scorePlayer+=PUNTAJE_MECHA;
                textScorePlayer.text = LABEL_SCORE_PLAYER+scorePlayer;
                textScoreMecha.text = "+3 Mecha";
            } else if( nameParent.Equals(NOMBRE_TEJO_CPU) ){
                Debug.Log ("**** sumando mecha para cpu "+scoreCPU+"+"+PUNTAJE_MECHA+" "+nameParent);
                scoreCPU+=PUNTAJE_MECHA;
                textScoreCPU.text = LABEL_SCORE_CPU+scoreCPU;
                textScoreMecha.text = "+3 Mecha";
                
            }
            /// se lleva el tejo a la posicion inicial para evitar que detecte otra colision y se asigna el siguiente turno q es del player 
            //reposicionarTejo();
            desactivarColliderMechas();
            relentizarTejo();
            reposicionarTejo();
            puntajeActualizado = true;
        } else 
        if(  collision.gameObject.name.Equals(NOMBRE_MECHA_BOCIN) ){
            if( nameParent.Equals(NOMBRE_TEJO) ){
                Debug.Log ("**** sumando bocin para player "+scorePlayer+"+"+PUNTAJE_BOCIN+" "+nameParent);
                scorePlayer+=PUNTAJE_BOCIN;
                textScorePlayer.text = LABEL_SCORE_PLAYER+scorePlayer;
                textScoreMecha.text = "+6 Moñona";
               
            } else if( nameParent.Equals(NOMBRE_TEJO_CPU) ){
                Debug.Log ("**** sumando bocin para cpu "+scoreCPU+"+"+PUNTAJE_BOCIN+" "+nameParent);
                scoreCPU+=PUNTAJE_BOCIN;
                textScoreCPU.text = LABEL_SCORE_CPU+scoreCPU;
                textScoreMecha.text = "+6 Moñona";
            }
            /// se lleva el tejo a la posicion inicial para evitar que detecte otra colision y se asigna el siguiente turno q es del player 
            //reposicionarTejo();
            desactivarColliderMechas();
            relentizarTejo();
            reposicionarTejo();
            puntajeActualizado = true;
        } else if ( rigidBodyTejo.velocity.magnitude > 0.5 ){
            Transform transfCentroBocin = GameObject.Find( NOMBRE_CENTRO_BOCIN ).GetComponent<Transform>();
            ContactPoint2D contact = collision.contacts[0];
            Vector3 pos = contact.point;
            float distanciaABocin = Vector3.Distance(pos,transfCentroBocin.position);
            if( nameParent.Equals(NOMBRE_TEJO) && !collision.gameObject.name.Equals(NOMBRE_TEJO_CPU)){
                distanciaABocinPlayer = distanciaABocin;
            } else if ( nameParent.Equals(NOMBRE_TEJO_CPU) && !collision.gameObject.name.Equals(NOMBRE_TEJO )){
                distanciaABocinCPU = distanciaABocin;
                if ( distanciaABocinCPU < MAX_DISTANCE && distanciaABocinPlayer < MAX_DISTANCE ){
                     if( distanciaABocinPlayer < distanciaABocinCPU ){
                        Debug.Log ("**** sumando para player "+scorePlayer+"+"+PUNTAJE_MANO+" "+nameParent+" con "+collision.gameObject.name+" distanciaplayer "+distanciaABocinPlayer+" distanciaCPU "+distanciaABocinCPU);
                        scorePlayer+=PUNTAJE_MANO;
                        textScorePlayer.text = LABEL_SCORE_PLAYER+scorePlayer;
                        textScoreMecha.text = "+1 mano";
                    } else if ( distanciaABocinCPU < distanciaABocinPlayer ){
                            Debug.Log ("**** sumando para cpu "+scorePlayer+"+"+PUNTAJE_MANO+" "+nameParent+" con "+collision.gameObject.name+" distanciaplayer "+distanciaABocinPlayer+" distanciaCPU "+distanciaABocinCPU);
                            scoreCPU+=PUNTAJE_MANO;
                            textScoreCPU.text = LABEL_SCORE_CPU+scoreCPU;
                            textScoreMecha.text = "+1 mano";
                    }
                    puntajeActualizado = true;
                }
            }
        }
        if( puntajeActualizado && nameParent.Equals(NOMBRE_TEJO_CPU)){
            contadorTurnos++;
            textContadorTurnos.text = LABEL_CONTADOR_TURNOS+contadorTurnos;
            Debug.Log ("**** contador turnos  "+contadorTurnos);
        }
        if( (scoreCPU > scoreWin ) && !finDeJuego ){
            /// esta logica ha traido varios problemas, pero ni modo , si la cpu gana debe revisarse de inmediato
            ///la logica para ganar del player que es el que empieza turno deberia ser validada cuando empieza su turno, tal vez en update
            if( scoreCPU > scoreWin &&  scoreCPU > scorePlayer){
                textWinner.text = "CPU WIN";
                finJuego();
                Debug.Log ("**** pasando por aki cpu win cpu "+scoreCPU+" player "+scorePlayer);
            } else if( scoreCPU == scorePlayer){
                textWinner.text = "EMPATE";
                finJuego();
            }
        }
        Debug.Log ("**** scorePlayer "+scorePlayer);
        //reposicionarTejo();
        /*foreach (ContactPoint contact in collision.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.white);
        }
        if (collision.relativeVelocity.magnitude > 2)
            audioSource.Play();*/
        //// codigo para sumar turnos de algun al lado luego de la colison al final del lance de algun lado
        //// pero pueden haber muchas colisiones y se descontrola el incremento de turnos
        /*if( turno == TURNO_PLAYER ){
            turnosPlayer++;
        } else {
            sumarTurnosParaCPU();
        }*/   
    }
    void sumarTurnosParaCPU(){
        if(  turnosCPU < turnosPlayer){
             turnosCPU++; 
        }
    }
    bool verificarEsLanzamientoPlayer(){
        SpriteRenderer spritePlayer = GameObject.Find (NOMBRE_PLAYER).gameObject.GetComponent<SpriteRenderer>();
        if (spritePlayer.sortingOrder == 3  ){
            return true;
        }
        return false;
    }
    void reposicionarTejo(){
        /// posicion del tejo cpu un poco adelante para evitar colisiones (-7.13f, -1.975775f, 0)
        //// pero como se supone q ya no hay colision se va dejar justo en el mismo lugar del tejo player
        ////ademas esta posicion sirve para probar puntajes de 6 o bocin ya que los datos q 
        //// se tienen quemados para la posicion igual a la del tejo del player dan 3 puntos o mecha
        //// entonces es util cuando se quiera probar con buntaje de 6/bocin
        /// Vector3 posicionInicialTejo = new Vector3(-8.28f,-1.975775f,0);
        Vector3 posicionEspera = new Vector3(10.04f,-1.975775f, 0f);
        //GameObject.Find (NOMBRE_TEJO).GetComponent<Transform>().position += Vector3.forward * 10;
        GetComponent<Transform>().position = posicionEspera;//+= Vector3.left * 10;
        //transform.position += Vector3.forward * Time.deltaTime;
        Rigidbody2D rbTejo = GameObject.Find (NOMBRE_TEJO).GetComponent<Rigidbody2D>();
        //rbTejo.bodyType = RigidbodyType2D.Kinematic;
        //rbTejo.velocity = Vector3.zero;
    }
    void desactivarColliderTejo(){
         GameObject.Find (NOMBRE_TEJO).GetComponent<BoxCollider2D>().enabled = false;
         /// otra idea seria desactivar todas las mechas y activarlas nuevamente para que el tejo se siga viendo sobre la arcilla mientras empieza el otro turno
         //// mientras tanto 
         GameObject.Find (NOMBRE_TEJO).GetComponent<Transform>().position += Vector3.right * 10;
    }
    void desactivarColliderMechas(){
         GameObject.Find (NOMBRE_MECHA_1).GetComponent<PolygonCollider2D>().enabled = false;
         GameObject.Find (NOMBRE_MECHA_3).GetComponent<PolygonCollider2D>().enabled = false;
         GameObject.Find (NOMBRE_MECHA_BOCIN).GetComponent<PolygonCollider2D>().enabled = false; 
    }
    void relentizarTejo(){
        Rigidbody2D rbTejo = GameObject.Find (NOMBRE_TEJO).GetComponent<Rigidbody2D>();
        //rbTejo.bodyType = RigidbodyType2D.Kinematic;
        rbTejo.velocity = Vector3.zero;
    }
    void activarColliderMechas(){
         GameObject.Find (NOMBRE_MECHA_1).GetComponent<PolygonCollider2D>().enabled = true;
         GameObject.Find (NOMBRE_MECHA_3).GetComponent<PolygonCollider2D>().enabled = true;
         GameObject.Find (NOMBRE_MECHA_BOCIN).GetComponent<PolygonCollider2D>().enabled = true;
    }
    void nuevoIntento(){
        Debug.Log ("**** en nuevoIntento turnos player "+turnosPlayer);
        if(finDeJuego){
            return;
        }
        ///turno = TURNO_PLAYER;/// se trajo del update para ver si resuelve un bug, genero otro bug peor
        activarColliderMechas();
        SpriteRenderer spriteCPU = GameObject.Find (NOMBRE_CPU).gameObject.GetComponent<SpriteRenderer>();
        spriteCPU.sortingOrder = 0;
        SpriteRenderer spritePlayer = GameObject.Find (NOMBRE_PLAYER).gameObject.GetComponent<SpriteRenderer>();
        spritePlayer.sortingOrder = 3;
        Quaternion target = Quaternion.Euler(0, 0, -40);
        Animator animTejo = GameObject.Find (NOMBRE_TEJO).GetComponent<Animator>();
        GameObject.Find (NOMBRE_TEJO).GetComponent<Transform>().position = posicionInicialTejo;
        Animator animPlayer = GameObject.Find (NOMBRE_PLAYER).GetComponent<Animator>();
        AnimatorStateInfo currentBaseStateTejo = animTejo.GetCurrentAnimatorStateInfo(0);
        AnimatorStateInfo currentBaseStatePlayer = animPlayer.GetCurrentAnimatorStateInfo(0);
        Rigidbody2D rbTejo = GameObject.Find (NOMBRE_TEJO).GetComponent<Rigidbody2D>();
        Transform transformTejo =  GameObject.Find (NOMBRE_TEJO).GetComponent<Transform>();
        rbTejo.bodyType = RigidbodyType2D.Kinematic;
        rbTejo.velocity = Vector3.zero;
        //rbTejo.angularVelocity = 0;
        float smooth = 4f;
        //rbTejo.Sleep();
        transformTejo.rotation = Quaternion.Slerp(transformTejo.rotation, target,  Time.deltaTime * smooth);
        animTejo.SetBool(BOOL_TEJO_EN_AIRE,false);
        ///animPlayer.SetBool(BOOL_ACTIVAR_LANCE,false); /// se pone false en el oncollision
        animPlayer.SetBool(BOOL_FIN_LANCE,true);
        animPlayer.SetBool(BOOL_NUEVO_INTENTO,true);
        
        /// preparando para que el nuevo intento de la cpu se pueda
        Animator animCPU = GameObject.Find (NOMBRE_CPU).GetComponent<Animator>();
        animCPU.SetBool(BOOL_ACTIVAR_LANCE_CPU,false);///
        animCPU.SetBool(BOOL_NUEVO_INTENTO,true); 
        scriptTejo script = GameObject.Find ("tejoVistaSup800b").GetComponent<scriptTejo>();
        script.setCanDrag(true);
        GameObject.Find ( NOMBRE_TEJO_GUIA ).GetComponent<Collider2D>().enabled = true;
        Text textScoreMecha = GameObject.Find(TEXT_SCORE_MECHA).GetComponent<Text>();
        textScoreMecha.text = "";
        turnosPlayer++;/// se va mover al final luego q se cumpla la colision
        lanceDE = TURNO_PLAYER;
        Debug.Log ("**** en fin nuevoIntento turnos player "+turnosPlayer); 
    }
    void activarLanceCPU(){
        Debug.Log ("**** en activarLanceCPU ");
        //GameObject.Find (NOMBRE_PLAYER).gameObject.SetActive(false);
        //GameObject.Find (NOMBRE_CPU).SetActive(true);
        activarColliderMechas();
        SpriteRenderer spriteCPU = GameObject.Find (NOMBRE_CPU).gameObject.GetComponent<SpriteRenderer>();
        spriteCPU.sortingOrder = 3;
        SpriteRenderer spritePlayer = GameObject.Find (NOMBRE_PLAYER).gameObject.GetComponent<SpriteRenderer>();
        spritePlayer.sortingOrder = 0;
        GameObject.Find (NOMBRE_TEJO_CPU).GetComponent<Transform>().position = posicionInicialTejoCPU;
        Animator animCPU = GameObject.Find (NOMBRE_CPU).GetComponent<Animator>();
       
        scriptLanceTejo script = GameObject.Find (NOMBRE_CPU).GetComponent<scriptLanceTejo>();
        Vector3 dis = DIS_PARA_3PUNTOS_MECHA;//DIS_PARA_6PUNTOS_BOCIN;
        
        int maxVel = 15;///normalmente es 15, voy a poner 10 a ver si da 3 puntos
        maxVel = Mathf.RoundToInt(Random.Range(10.0f, 15.0f));
        Rigidbody2D rbTejo = GameObject.Find (NOMBRE_TEJO_CPU).GetComponent<Rigidbody2D>();
        rbTejo.bodyType = RigidbodyType2D.Kinematic;
        Debug.Log ("**** maxvel de lancecpu "+maxVel);
        script.copiarValores(dis, maxVel, NOMBRE_TEJO_CPU );
        //Invoke("nuevoIntento",1);
        /// se deja la activacion del lance despues de la copia de los valores para ver si los toma y no hace un lance con 0s
        animCPU.SetBool(BOOL_ACTIVAR_LANCE_CPU,true);/// 
        animCPU.SetBool(BOOL_FIN_LANCE_CPU,true);///
        //// se va pasar este codigo al final de lance q seria en la logica de la colision
        if(  turnosCPU < turnosPlayer){
             turnosCPU++; 
        }
        lanceDE = TURNO_CPU;
        //Invoke("ejecutarLanceCPU",1);
    }
    void ejecutarLanceCPU(){
        Animator animCPU = GameObject.Find (NOMBRE_CPU).GetComponent<Animator>();
        /// se deja la activacion del lance despues de la copia de los valores para ver si los toma y no hace un lance con 0s
        animCPU.SetBool(BOOL_ACTIVAR_LANCE_CPU,true);/// 
        animCPU.SetBool(BOOL_FIN_LANCE_CPU,true);/// 
    }
    public void onBytes(byte[] msg)
		{	
			int numParametros = 1;
			float[] data_f = new float[1];
			char[] data_c = new char[(msg.Length - (sizeof(float)*numParametros))/sizeof(char)];
			
			System.Buffer.BlockCopy(msg,0,data_f,0,sizeof(float)*numParametros);
			System.Buffer.BlockCopy(msg,sizeof(float)*numParametros,data_c,0,msg.Length - (sizeof(float)*numParametros));
			
			string sender = new string(data_c);
			Debug.Log ("**** onbytes "+sender);
			if(sender != username)
			{
				fuerzaEnemyWarp = data_f[0];
				nameEnemyWarp = sender;
				GameObject remote;
				remote = GameObject.Find(sender);
				if(remote == null)
				{
					//Object newRemote = Instantiate(remotePrefab, new Vector3(data_f[0],data_f[1],data_f[2]) ,Quaternion.identity);
					//newRemote.name = sender;
				}
				else
				{
					//RemoteThirdPersonSmooth rtps = remote.GetComponent<RemoteThirdPersonSmooth>();
					//rtps.SetTransform(new Vector3(data_f[0],data_f[1],data_f[2]),new Vector3(data_f[3],data_f[4],data_f[5]),new Vector3(data_f[6],data_f[7],data_f[8]));
				}		
			}
		}
		public void onMsgChat(string msg)
		{	
            
        }
        public string getUserName(){
            return username;
        }
        void mostrarRankingConNick(){
            Text textNick = GameObject.Find(Collision.TEXT_NICK).GetComponent<Text>();
            lstResultados = managerConsulta.getLstResultados();
            Debug.Log ("**** revisando ranking");
            if( lstResultados != null ){
                Debug.Log ("**** iterando resultados ");
                lstResultados = loadScores.filtrarMejorResultadoPorUsuario(lstResultados);
                int count = 1;
                //yaHayRespuestaParaRanking = true;
                string elUserName = userNameFromPreferences();
                foreach(Resultado resultado in lstResultados ){
                    if( resultado.getNick().Equals(elUserName)){
                        rank = count; 
                    }
                    count++;
                }
                Debug.Log ("**** rank encontrado "+rank);
                textNick.text = LABEL_NICK+username+" rank # "+rank;
                //textNick.text =" rank # "+rank;
            }
        }
    string getActualEstado( AnimatorStateInfo currentBaseState){
        if( currentBaseState.nameHash == stateLanzando){
            return "lanzando";
        }
        if( currentBaseState.nameHash == stateReposo  ){
            return "reposo";
        }
        if( currentBaseState.nameHash == stateIdle  ){
            return "idle";
        }
        return null;
    }
}
