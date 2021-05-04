using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using com.shephertz.app42.paas.sdk.csharp.user;   
public class loadScores : MonoBehaviour
{
    private GUIStyle guiStyle = new GUIStyle(); //create a new variable
    // Start is called before the first frame update
    string[] titulos = {"rank","nick","nivel","objetivo","puntos","turnos"}; 
    static List<Resultado> lstResultados;
    static List<User> lstResultadosUsers;
    List<Resultado> lstResultadosSinFiltrar;
    ManagerConsultaScoresJson managerConsulta;
    ManagerConsultaCount managerConsultaCount;
    ManagerCustomCode managerCustomCode;
    ManagerConsultaHighScores managerConsultaHighScores;
    ManagerConsultaUsers managerConsultaUsers;

    bool listaMostrada = false;
    int contCambiosLista = 0;
    float tiempo = 0;
    bool esPC = (Application.platform != RuntimePlatform.Android);
    void Start()
    {
          ///GUI.Label(new Rect(50, 50, 200, 30), "Name : ");
            managerConsulta = new ManagerConsultaScoresJson();
            managerConsultaCount = new ManagerConsultaCount();
            managerCustomCode = new ManagerCustomCode();
            managerConsultaHighScores = new ManagerConsultaHighScores();
            managerConsultaUsers = new  ManagerConsultaUsers();
            managerConsultaHighScores.consultarScores();
            managerConsultaUsers.consultarUsuarios();
            //managerConsultaCount.consultarCount();
            //managerConsulta.consultarScores();
            //lstResultados = managerConsulta.getLstResultados();
    }

    // Update is called once per frame
    void Update()
    {
        Text textDebug = null;
        if( textDebug != null ){
            textDebug = GameObject.Find(Collision.TEXT_DEBUG).GetComponent<Text>();
        }
        //textDebug.text = ""+Time.fixedTime+" "+tiempo;
        if( lstResultados == null ){
            //lstResultados = managerConsulta.getLstResultados();
            //mostrarRankingConNick();
        } 
        if( tiempo > 20 ){///antes estaba en 2 segundos
            tiempo = 0;
            calcularHighScores();
            ejecutarCustomCode();
        }
    }
   void OnGUI2(){
       //testHighScores();
       //Debug.Log ("**** ongui load scores");
        tiempo += Time.deltaTime;
        Debug.Log ("**** fixedTime ongui2 "+Time.fixedTime+" "+(int)(Time.fixedTime*10));
        Text textDebug = null;
        if( textDebug != null ){
            textDebug = GameObject.Find(Collision.TEXT_DEBUG).GetComponent<Text>();
        }
        if( tiempo > 2 ){
            //tiempo = 0;
            //calcularHighScores();
        }
        string strMostrar= "";
        strMostrar = ""+Time.fixedTime+" "+tiempo;
        if( lstResultadosSinFiltrar != null){
            strMostrar+=" "+lstResultadosSinFiltrar.Count;
        }
        if( textDebug != null ){
            textDebug.text = strMostrar;
        }
        //testContains();
        if( Time.fixedTime  < 40f && (Time.fixedTime) % 2 < 0.05){
            Debug.Log ("**** fixedTime mod "+Time.fixedTime);
            //calcularHighScores();
        }
        mostrarHighScores(); 
       //mostrarRankingConNick();
    }
     // The position on of the scrolling viewport
    public Vector2 scrollPosition = Vector2.zero;

    void OnGUI()
    {
        //// este el funcional de verdad
        Vector2 nativeSize = new Vector2(800, 480);
        int tabHorizontal = 150;
        int tabVertical = 30;
        float factorAdicional = 1.2f;
        float factorScreenX = ((float)Screen.width / (float)nativeSize.x);
        float factorScreenY = ((float)Screen.height / (float)nativeSize.y);
        // An absolute-positioned example: We make a scrollview that has a really large client
        // rect and put it in a small rect on the screen.
        ///780 ajusta casi en horizontal
        scrollPosition = GUI.BeginScrollView(new Rect(10, 10, 780*factorScreenX, 460*factorScreenY), scrollPosition,//// x antes era 790
                       new Rect(0, 0, 1000*factorScreenX, 9020*factorScreenY )); /// el x era 1000 antes

        // Make four buttons - one in each corner. The coordinate system is defined
        // by the last parameter to BeginScrollView.
        tiempo += Time.deltaTime;
        Debug.Log ("**** fixedTime "+Time.fixedTime+" "+(int)(Time.fixedTime*10));
        Text textDebug = null;
        if( textDebug != null ){
            textDebug = GameObject.Find(Collision.TEXT_DEBUG).GetComponent<Text>();
        }
        if( tiempo > 2 ){
            //tiempo = 0;
            //calcularHighScores();
        }
        string strMostrar= "";
        strMostrar = ""+Time.fixedTime+" "+tiempo;
        if( lstResultadosSinFiltrar != null){
            strMostrar+=" "+lstResultadosSinFiltrar.Count;
        }
        if( textDebug != null ){
            textDebug.text = strMostrar;
        }
        //testContains();
        if( Time.fixedTime  < 40f && (Time.fixedTime) % 2 < 0.05){
            Debug.Log ("**** fixedTime mod "+Time.fixedTime);
            //calcularHighScores();
        }
        mostrarHighScores(); 
       //mostrarRankingConNick();
        // End the scroll view that we began above.
        GUI.EndScrollView();
    }
    void OnGUIbkp() ///OnGUIbkp
    {   ///// este es el de backup para pruebas de concepto
        Vector2 nativeSize = new Vector2(800, 480);
        int tabHorizontal = 150;
        int tabVertical = 30;
        float factorAdicional = 1.2f;
        float factorScreenX = ((float)Screen.width / (float)nativeSize.x);
        float factorScreenY = ((float)Screen.height / (float)nativeSize.y);
        // An absolute-positioned example: We make a scrollview that has a really large client
        // rect and put it in a small rect on the screen.
        ///780 ajusta casi en horizontal
        scrollPosition = GUI.BeginScrollView(new Rect(10, 10, 790*factorScreenX, 470*factorScreenY), scrollPosition,
                       new Rect(0, 0, 1000*factorScreenX, 1300*factorScreenY )); 

        // Make four buttons - one in each corner. The coordinate system is defined
        // by the last parameter to BeginScrollView.
        GUI.Button(new Rect(0, 0, 100, 20), "Top-left");
        GUI.Button(new Rect(120, 0, 100, 20), "Top-right");
        GUI.Button(new Rect(0, 180, 100, 20), "Bottom-left");
        GUI.Button(new Rect(120, 180, 100, 20), "Bottom-right");
        GUI.Button(new Rect(0, 400, 100, 20), "Top-left");
        GUI.Button(new Rect(0, 500, 100, 20), "Top-right");
        GUI.Button(new Rect(0, 600, 100, 20), "Bottom-left");
        GUI.Button(new Rect(0, 950, 100, 20), "Bottom-right");
        GUI.Button(new Rect(0, 1700, 100, 20), "Top-left");
        GUI.Button(new Rect(0, 1800, 100, 20), "Top-right");
        GUI.Button(new Rect(0, 1900, 100, 20), "Bottom-left");
        GUI.Button(new Rect(0, 2000, 100, 20), "Bottom-right");
        // End the scroll view that we began above.
        GUI.EndScrollView();
    }
    public void onResponse(List<Resultado> unLstResultados){
        lstResultados = unLstResultados;
    }
    void testContains(){
        List<Resultado> lstResultadosTest = new List<Resultado>();
        Resultado unResultado = new Resultado( "guest4490", 1, 10, 0, 0, esPC );   
        lstResultadosTest.Add( unResultado );
        unResultado = new Resultado( "guest4491", 1, 10, 0, 0 , esPC );   
        lstResultadosTest.Add( unResultado );
        unResultado = new Resultado( "guest4492", 1, 10, 0, 0 , esPC );   
        lstResultadosTest.Add( unResultado );
        Debug.Log ("**** test contains "+lstResultadosTest.Contains(unResultado));
    }
    void testHighScores(){
        int tabHorizontal = 200;
        int tabVertical = 50;
        guiStyle.fontSize = 50; //change the font size
        guiStyle.normal.textColor = Color.green;
        //GUI.Label(new Rect(50, 50, 1000, 1000), "Name : ");
        Rect rect = new Rect(50, 50, 50, 50);
        for(int i = 0; i < titulos.Length;i++){
             GUI.Label(rect,titulos[i],guiStyle );
             rect.x += tabHorizontal;
        }
        rect.y+=tabVertical;
        for( int j = 0; j < 10;j++){
             rect.x = 50;
             for(int i = 0; i < titulos.Length;i++){
                GUI.Label(rect,"test",guiStyle );
                rect.x += tabHorizontal;
             }
             rect.y+=tabVertical;
        }
    }
    /**
    	private Point[][] buscarContornoMayor3( Point[][] contours){
			List<Point[]> goodCandidates = new List<Point[]>();
			double length;
			double area;
			SortedDictionary<double, Point[]> map = new SortedDictionary<double, Point[]>();
				//string s = "test";
				//map[s] = 1;
			foreach (Point[] contour in contours)
			{man
				//length = Cv2.ArcLength(contour, true);
				area = Cv2.ContourArea(contour);
				map[area] = contour;
			}
			//var lastValuePair =  map[map.Keys.Count-1];//map.Values.Last();
			//var lastKeyPair =  map[map.Keys.Count];
			// dict.Keys.First();
			var lastEntry = ultimoEnDictionary(map);
			map.Remove(lastEntry.Key);///el contorno mas grande siempre es el cuadro completo
			for( int i = 0; i < 5; i++){
				lastEntry = ultimoEnDictionary(map);
				if( lastEntry.Value != null ){
					//length = Cv2.ArcLength(lastEntry.Value, true);
					goodCandidates.Add(lastEntry.Value);
					map.Remove(lastEntry.Key);
				}
			}
			return goodCandidates.ToArray(); 
		}
    */
    public static List<Resultado> filtrarMejorResultadoPorUsuario(List<Resultado> unoslstResultados ){
        SortedDictionary<float, Resultado> mapPuntajes = new SortedDictionary<float, Resultado>();
        float criterioDesempate = 0;
         Debug.Log ("**** filtrando mejor resultado ");
        foreach(Resultado resultado in unoslstResultados){
            criterioDesempate = (float)(resultado.getScore())/(float)(resultado.getTurnos()+1);
            if( resultado.getScore() > resultado.getObjetivo()){
                criterioDesempate = criterioDesempate*5f;
            }
            if( resultado.getTurnos() == 0 ){
                criterioDesempate = criterioDesempate*0.1f;
            }
            Debug.Log ("**** map nick "+resultado.getNick()+" score "+resultado.getScore()+" turnos "+resultado.getTurnos()+" fechaCreacion "+resultado.getFechaCreacion());
            if( ! mapPuntajes.ContainsKey(criterioDesempate)){
                mapPuntajes[ criterioDesempate ] = resultado;
            } else {
                criterioDesempate+=UnityEngine.Random.Range(0.0000f, 0.1f);
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
    private int conteoUsuariosUnicos(List<Resultado> unoslstResultados){
         HashSet < string > names = new HashSet < string >();
         foreach( Resultado resultado in unoslstResultados){
             names.Add(resultado.getNick()); 
         }
         return names.Count;
    }
    public void volverJuego(){
         PlayerPrefs.SetString(Collision.NAME_PREF_NEW_GAME,"true");
         ///Ya no es necesario????, se llama al final del metodo nuevo juego
         SceneManager.LoadScene(Collision.NOMBRE_SCENE_PRINCIPAL, LoadSceneMode.Single);
    }
    /*
    private void remplazarResultadosAnterioresConNuevoNick( List<Resultado> lstResultados ){
        string usernameEnPreference = PlayerPrefs.GetString(NAME_PREF_USERNAME);
        string usernameEnPreferenceAnterior = PlayerPrefs.GetString(NAME_PREF_USERNAME_ANTERIOR);
        foreach( Resultado unResultado in lstResultados){
                if( unResultado.getNick().Equals(usernameEnPreferenceAnterior)){
                    unResultado.setNick(usernameEnPreference);
                }
        }
    }*/
    void mostrarRankingConNick(){
         Text textNick = GameObject.Find(Collision.TEXT_NICK).GetComponent<Text>();
         if( lstResultados != null ){
             textNick.text +=" rank # "+1;
         }
    }
    void mostrarLista( List<Resultado> unLstResultados){
        int count = 0;
        foreach( Resultado resultado in  unLstResultados ){
             Debug.Log ("**** mostrando list resultados nick "+resultado.getNick()+" - "+count);
             count++;
        }
    }
    void calcularHighScores(){
       
        /*if( lstResultados == null && managerConsulta.getLstResultados() == null ){
                managerConsulta.setContadorRegistros( managerConsultaCount.getCount());
                managerConsulta.consultarScores();
                asignarResultados();
                Debug.Log ("**** lstResulta es null se llena ");
        } else if( managerConsultaCount.getCount() == 0 ){
            //managerConsultaCount.consultarCount();
            managerConsulta.consultarScores();
        }
        if( lstResultados != null && managerConsulta.getLstResultados().Count > lstResultados.Count ){
            asignarResultados();
        } else if( managerConsulta.getLstResultados() != null && lstResultados == null){
            asignarResultados();
        }*/
        if( lstResultados == null ){
            asignarResultados();
        }
        if( lstResultadosUsers == null ){
            asignarResultadosUsuarios();
        }
    }
    void ejecutarCustomCode(){
        managerCustomCode = new ManagerCustomCode();
        managerCustomCode.ejecutarCustomCode();
    }
    void asignarResultados(){
        Text textDebug = null;
        if( textDebug != null ){
            textDebug = GameObject.Find(Collision.TEXT_DEBUG).GetComponent<Text>();
        }
        //lstResultados = managerConsulta.getLstResultados();
        //lstResultados = managerCustomCode.getListResultados();
        lstResultados = managerConsultaHighScores.getListResultados();
        //lstResultadosSinFiltrar = managerConsulta.getLstResultados();
        contCambiosLista++;
        if( textDebug != null ){
            if( textDebug.text.Equals("-")){
                textDebug.text = "| "+contCambiosLista+" "+Time.fixedTime;
            } else {
                textDebug.text = "- "+contCambiosLista+" "+Time.fixedTime; 
            }
        }
    }
    void asignarResultadosUsuarios(){
        lstResultadosUsers = managerConsultaUsers.getListResultados();
    }
    private void consultarUsuarios(){
        managerConsultaUsers.consultarUsuarios();
    }
    void mostrarHighScores(){
        Rect rect = new Rect(50, 50, 50, 50);
             //Vector2 nativeSize = new Vector2(640, 480);
        Vector2 nativeSize = new Vector2(800, 480);
        int tabHorizontal = 150;/// era 150
        int tabVertical = 30;
        float factorAdicional = 1.2f; 
        int milisAntes = DateTime.UtcNow.Millisecond;
        float factorScreen = ((float)Screen.width / (float)nativeSize.x);
        tabVertical = (int)(tabVertical*factorScreen);
        tabHorizontal = (int)(tabHorizontal*factorScreen);
        //guiStyle.fontSize = 30; //change the font size
        int fontSize = (int)(30.0f *(factorAdicional)* ((float)Screen.width / (float)nativeSize.x));
        Debug.Log ("**** font size scale "+fontSize+" screen "+Screen.width+" factor screen "+factorScreen+" tabVertical "+tabVertical);
        guiStyle.fontSize = fontSize;
        guiStyle.normal.textColor = Color.green;
        //GUI.Label(new Rect(50, 50, 1000, 1000), "Name : ");
       
        for(int i = 0; i < titulos.Length;i++){ 
             GUI.Label(rect,titulos[i],guiStyle );
             if( i == 0){
                 rect.x+= tabHorizontal -130;
             } else {
                 rect.x += tabHorizontal;
             }
        }
        mostrarDiffTiempo( milisAntes, " bloque titulos ");
        rect.y+=tabVertical;
        if( lstResultados != null ){
             Debug.Log ("**** lstResultados not null count "+lstResultados.Count+" listamostrada "+listaMostrada);
             /////mostrarLista(lstResultados);/// no es grafico es de debug log, comentariarlo porque depronto esta afectando el rendimiento
             if( !listaMostrada ){//// resulto que la logica de filtrar mejor resultado era la mas pesada y la que no dejaba mover facil
                  //// la barra del scrollbar
                  lstResultados = filtrarMejorResultadoPorUsuario(lstResultados);
                  agregarUsuariosAResultados();/// no es necesario ordenarlos porque es un capricho machete y ademas genera overload
             } 
            
             Debug.Log ("**** 2 lstResultados not null count "+lstResultados.Count);
            int limiteMostrar = 20;//lstResultados.Count;/// era 8 cuando no habia hecho el scroll
            int count = 0;
            string strResultados = "";
            foreach( Resultado resultado in lstResultados){
                strResultados+=String.Format("{0,-5} {1,-10} {2,-10} {3,-10} {4,-10} {5,5} {6,5}",(count+1),resultado.getNick(),resultado.getNivel().ToString(),resultado.getObjetivo().ToString(),
                resultado.getScore().ToString(),resultado.getTurnos().ToString(), resultado.getFechaCreacion()+"\n");
                count++;
                //rect.y+=(tabVertical+factorScreen);
            }
            Debug.Log ("**** resultados str tabulados \n"+strResultados);
            rect.x = 50;
            GUI.Label(rect,strResultados,guiStyle );
            mostrarDiffTiempo( milisAntes, " bloque lista resultado cambio abril 2 ");
            rect.x = 50;
            rect.y+=((tabVertical+factorScreen)*(lstResultados.Count+35));
            rect.y +=(50+factorScreen);
            GUI.Label(rect,"Usuarios :"+conteoUsuariosUnicos(lstResultados).ToString(),guiStyle );
            listaMostrada = true;
        }
    }
        private void agregarUsuariosAResultados(){
             Debug.Log ("**** en agregar usuarios a resultados ");
            List<Resultado> lstDeResUsuarios = new List<Resultado>();
            if ( lstResultados != null && lstResultadosUsers != null ){
                foreach(User elUser in lstResultadosUsers){
                    Debug.Log ("**** en agregar usuarios a resultados el for ");
                    //username = username.Substring(username.Length-4); 
                    string nick = elUser.GetUserName();int nivel = 1; int objetivo = 10; int score = 0; int turnos = 0; bool esPC = false;
                    if( nick != null && nick.Length >= 11 ){
                        Debug.Log ("**** en agregar usuarios a resultados el for nick "+nick);
                        nick = nick.Substring(0,10);
                    }
                    lstResultados.Add( new Resultado(nick, nivel, objetivo, score, turnos , esPC));      
                }
            }
        }
    	private void mostrarDiffTiempo(int milisAntes, string texto){
			int milisAhora = DateTime.UtcNow.Millisecond;
			int diff = milisAhora-milisAntes;
			if (diff < 0 )diff = (milisAhora+1000)-milisAntes;
			Debug.Log ("**** diff time "+texto+" "+diff+" antes "+milisAntes+" despues "+milisAhora);
		}
}
