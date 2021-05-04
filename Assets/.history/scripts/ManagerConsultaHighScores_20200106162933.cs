using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using com.shephertz.app42.paas.sdk.csharp;    
using com.shephertz.app42.paas.sdk.csharp.game; 
using com.shephertz.app42.paas.sdk.csharp.storage;  
using SimpleJSON;

public class ManagerConsultaHighScores : App42CallBack
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
    //ScoreBoardService scoreBoardService;
    StorageService storageService;   
    static List<Resultado> lstResultados;
        
    /// estos son los keys de spider que ya se que funcionan 
    /*public string apiKey = "39a0365d03a56bfdad1a6854dfdd2ab28ff92114e44fd39ba321f1fb72f2eff5";
	public string secretKey = "90c1da8c7d4b3cc61760346b10771d6cdf5d3b9746bfd593c8cade27bc716ed5";
    */

    //// estos son creados especificamente para el tejo
    public string apiKey = "5e8c1c2c90dafb1b4024609fa2af2189cb21f02726e5cb8dbd7365dd2e14f879";
	public string secretKey = "4326a27aa58806934875fb472e762dbe060309151e32c83ab9e85c8be9278bde";

    
    String dbName = "puntajes";  
    String collectionName = "highscore";   
    String employeeJSON =  "{\"name\":\"Nick\",\"age\":30,\"phone\":\"xxx-xxx-xxx\"}";   
    static int max = 100;  
    static int offset = 0;  
    static int contadorRegistros = 0;   
    // Start is called before the first frame update
    void Start()
    {  
        Debug.Log ("**** en start de managerscoresjson ");
        App42Log.SetDebug(true);        //Print output in your editor console  
        App42API.Initialize(apiKey,secretKey);  
        //scoreBoardService = App42API.BuildScoreBoardService();""
        storageService = App42API.BuildStorageService();
        
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
          Debug.Log ("**** consultando high scores en app42 appwarp storageService");
          if( storageService == null ){
             Start();
          }
          if(storageService != null ){
              //storageService.FindAllDocumentsCount(dbName, collectionName, new UnityCallBack());   
              //storageService.FindAllDocuments(dbName, collectionName, new ManagerConsultaScoresJson() );
              storageService.FindAllDocuments(dbName,collectionName, new ManagerConsultaHighScores() );
                 
          } else {
              Debug.Log ("**** storageService es null ");
          }
    }
    public void setContadorRegistros( int elContadorRegistros){
        contadorRegistros = elContadorRegistros;
    }
    public List<Resultado> getLstResultados(){
        if( lstResultados != null ){
            App42Log.Console("**** pidiendo get resultados count "+lstResultados.Count+" contregistros "+contadorRegistros);
        }
        if( lstResultados != null && lstResultados.Count == contadorRegistros ){
             App42Log.Console("**** resultados not null en get ");
        }
        return lstResultados;
    }
      public void OnSuccess(object response)  
            {  
                App42Log.Console("**** succes consulta high scores app42 storageService max "+max);  
                Storage storage = (Storage) response;  
                //JSONObject  objecti = (JSONObject )response;/// invalid cast  
                //App42Log.Console(" objeti isObject "+objecti.IsObject );
                bool seAgregoLista = false;
                if( storage.GetJsonDocList() != null ){
                     IList<Storage.JSONDocument> jsonDocList = storage.GetJsonDocList();  
                    if( lstResultados == null ){
                        lstResultados = new List<Resultado>();
                    } 
                    App42Log.Console("**** succes consulta high scores app42 storageService count "+jsonDocList.Count);
                    for(int i=0;i <jsonDocList.Count;i++)  
                    {     
                        App42Log.Console("objectId is " + jsonDocList[i].GetDocId());  
                        string jsonDoc = String.Copy(jsonDocList[i].GetJsonDoc());
                        App42Log.Console("jsonDoc is "+jsonDoc);  
                        Resultado resultado = JsonUtility.FromJson<Resultado>(jsonDoc);
                        //JSONNode jsonNode =  JSONObject.Parse(objecti[NAME_TUPLA ]);
                        JSONNode jsonNode =  JSONObject.Parse(jsonDoc);
                         foreach (JSONNode objNode in jsonNode) {
                            App42Log.Console(" custom high code array isObject "+objNode.IsObject );
                            App42Log.Console(" custom high code array isArray "+objNode.IsArray );
                            JSONObject  objecResult = objNode.AsObject;
                            foreach (JSONNode jSONNode1 in objNode) {
                                //String  nick = objNode.AsString;
                                App42Log.Console(" iterando valores higt "); 
                                 int nivel = 1;
                                String nick = jsonNode[NAME_NICK];
                                int score = jsonNode[NAME_SCORE];
                                int turnos = jsonNode[NAME_TURNOS];
                                int objetivo = 10;
                                String nameDevice = jsonNode[NAME_DEVICE_NAME];
                                String nameModel = jsonNode[NAME_DEVICE_MODEL ];
                                Resultado resultado = new Resultado(nick, nivel, objetivo, score, turnos);
                                lstResultados.Add(resultado);
                                App42Log.Console(" custom code high values score turnos "+nick+" "+score+" "+turnos );
                            }
                         }
                      
                        Debug.Log ("**** lstResultados en manager hight "+lstResultados.Count);
                    }
                    if( seAgregoLista){
                         offset+=50;
                         max+=50;
                    }  
                } else {
                    if( offset >= 100 ){
                        contadorRegistros = lstResultados.Count;
                    }
                }
               
                //loadScores = gam
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
                     Resultado resultado = new Resultado(nick, nivel, objetivo, score, turnos);
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
