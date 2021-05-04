using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using com.shephertz.app42.paas.sdk.csharp;    
using com.shephertz.app42.paas.sdk.csharp.game; 
using com.shephertz.app42.paas.sdk.csharp.storage;  
using SimpleJSON;

public class ManagerConsultaScoreTeams : App42CallBack
{
    string gameName = "tejonivel110puntos"; ///se tiene q configurar el juego ademas de la app, y pueden haber varios juegos por app 
    string  userName = "Nick";  
    double gameScore = 3500;  
    String NAME_TUPLA = "highscore";
    String NAME_NICK = "nick";
    String NAME_PUNTAJE_OBJETIVO = "puntajeObjetivo";
    String NAME_SCORE = "score";
    String NAME_TURNOS = "turnos";
    String NAME_DEVICE_MODEL = "deviceModel";
    String NAME_DEVICE_NAME = "deviceName";
    String NAME_FECHA_CREACION = "fechaCreacion";
    //ScoreBoardService scoreBoardService;
    StorageService storageService;   
    static List<Resultado> lstResultados;

    static ScoreTeams elScoreTeams;
        
    /// estos son los keys de spider que ya se que funcionan 
    /*public string apiKey = "39a0365d03a56bfdad1a6854dfdd2ab28ff92114e44fd39ba321f1fb72f2eff5";
	public string secretKey = "90c1da8c7d4b3cc61760346b10771d6cdf5d3b9746bfd593c8cade27bc716ed5";
    */

    //// estos son creados especificamente para el tejo
    public string apiKey = "5e8c1c2c90dafb1b4024609fa2af2189cb21f02726e5cb8dbd7365dd2e14f879";
	public string secretKey = "4326a27aa58806934875fb472e762dbe060309151e32c83ab9e85c8be9278bde";

    
    String dbName = "puntajes";  
    //String collectionName = "highscore";   
    string docId = "5f68f0bfe4b0b0de7dbc5605";
    String employeeJSON =  "{\"name\":\"Nick\",\"age\":30,\"phone\":\"xxx-xxx-xxx\"}";   
    static int max = 100;  
    static int offset = 0;  
    static int contadorRegistros = 0;   
    bool esPC = false;
    // Start is called before the first frame update
    void Start()
    {  
        Debug.Log ("**** en start de managerscoresjson ");
        App42Log.SetDebug(true);        //Print output in your editor console  
        App42API.Initialize(apiKey,secretKey);  
        //scoreBoardService = App42API.BuildScoreBoardService();""
        storageService = App42API.BuildStorageService(); 
        esPC = (Application.platform != RuntimePlatform.Android);
    }
    void testMockJson(){
        string jsonResultado = "{\"puntajeObjetivo\":10,\"nick\":\"guest3982\",\"turnos\":5,\"score\":17,\"nivel\":1}";
        Debug.Log ("***** json para test "+jsonResultado);
        Resultado resTest =  JsonUtility.FromJson<Resultado>(jsonResultado);
        Debug.Log ("***** restTest "+resTest.getNick());
    }
    // Update is called once per frame
    void Update()
    {
          
       
    }
    
    public void consultarScores(){
          Debug.Log ("**** consultando high scores teams en app42 appwarp storageService");
          if( storageService == null ){
             Start();
          }
          if(storageService != null ){
              //storageService.FindAllDocumentsCount(dbName, collectionName, new UnityCallBack());   
              //storageService.FindAllDocuments(dbName, collectionName, new ManagerConsultaScoresJson() );
              //storageService.FindAllDocuments(dbName,ManagerScoresJson.collectionNameHighScoresTeams, new ManagerConsultaScoreTeams() );
              storageService.FindDocumentById(dbName,ManagerScoresJson.collectionNameHighScoresTeams,docId, new ManagerConsultaScoreTeams());      
          } else {
              Debug.Log ("**** storageService es null ");
          }
    }
    public void setContadorRegistros( int elContadorRegistros){
        contadorRegistros = elContadorRegistros;
    }
    public ScoreTeams getScoreTeams(){
        if( elScoreTeams != null ){
            App42Log.Console("**** pidiendo get resultados count "+elScoreTeams.getHighScoreTeamList().Count);
        }
        if( elScoreTeams != null && elScoreTeams.Count == contadorRegistros ){
             App42Log.Console("**** resultados not null en get ");
        }
        return lstResultados;
    }
      public void OnSuccess(object response)  
            {  
                App42Log.Console("**** success consulta high scores teams app42 storageService max "+max);  
                Storage storage = (Storage) response; 
                IList<Storage.JSONDocument> jsonDocList = storage.GetJsonDocList();   
                for(int i=0;i <jsonDocList.Count;i++)  
                {     
                    App42Log.Console("objectId is " + jsonDocList[i].GetDocId());  
                    //App42Log.Console("jsonDoc is " + jsonDocList[i].GetJsonDoc());  
                    string jsonDoc = String.Copy( jsonDocList[i].GetJsonDoc());
                    App42Log.Console("jsonDoc is " + jsonDoc );  
                    ScoreTeams elScoreTeams = JsonUtility.FromJson<ScoreTeams>(jsonDoc);
                }    
            }  
        private void remplazarMejorScore(List<Resultado> lstResultados, Resultado elResultado){
            bool resultadoAgregado = false;
            foreach(Resultado unResultado in lstResultados ){
                 Debug.Log ("**** lstResultados en remplazarMejorScore  hight "+lstResultados.Count);
                if( unResultado.nick.Equals(elResultado.nick) && elResultado.getNivel() == unResultado.getNivel() &&
                   elResultado.getObjetivo() == unResultado.getObjetivo() && unResultado.getScore() < elResultado.getScore() && 
                   unResultado.getTurnos() == elResultado.getTurnos() );
                { 
                    lstResultados.Add(elResultado);
                    lstResultados.Remove(unResultado);
                    resultadoAgregado = true;
                }
            }
            if( !resultadoAgregado){
                lstResultados.Add(elResultado);
            }
        }
        public void OnSuccessOld(object response)  
        {  
            //JSONClass  objecti = (JSONClass )response;  
            JSONObject  objecti = (JSONObject )response;  
            App42Log.Console("custom code Success object ");  
            //JSONArray  array = (JSONArray )response;  
            App42Log.Console("custom code Success array object count "+objecti.Count+" keys "+ objecti.Keys );  
            //JObject json = JObject.Parse(str);
            App42Log.Console("custom code objectName is : " + objecti[NAME_TUPLA ]);  
            JSONNode jsonNode =  JSONObject.Parse(objecti[NAME_TUPLA ]);
            App42Log.Console("custom code jsonnode isarray : " + jsonNode.IsArray); 
            if( lstResultados == null ){
                lstResultados = new List<Resultado>();
            }
            foreach (JSONNode objNode in jsonNode) {
                 App42Log.Console(" custom code array isObject "+objNode.IsObject );
                 JSONObject  objecResult = objNode.AsObject;
                 foreach (JSONNode objNodeValues in objecResult) {
                     //String  nick = objNode.AsString;
                     int nivel = 1;
                     String nick = jsonNode[NAME_NICK];
                     int score = jsonNode[NAME_SCORE];
                     int turnos = jsonNode[NAME_TURNOS];
                     int objetivo = 10;
                     String nameDevice = jsonNode[NAME_DEVICE_NAME];
                     String nameModel = jsonNode[NAME_DEVICE_MODEL ];
                     Resultado resultado = new Resultado(nick, nivel, objetivo, score, turnos, esPC );
                     lstResultados.Add(resultado);
                     App42Log.Console(" custom code values score turnos "+nick+" "+score+" "+turnos );
                     //Resultado(string unNick, int unNivel, int unObjetivo, int unScore, int unTurnos ){
                 }
            }
            App42Log.Console("custom code Success : " + response);  
        }  
            public void OnException(Exception e)  
            {  
                App42Log.Console("**** failure fallo app42  storageService Exception : " + e);  
                ///toco esta chambonada por el error de cast con gettotalrecords en el manager count
                if( offset >= 100 ){
                        contadorRegistros = lstResultados.Count;
                    }
            }  
  
}
