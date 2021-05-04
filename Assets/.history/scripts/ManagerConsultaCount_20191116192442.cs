using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using com.shephertz.app42.paas.sdk.csharp;    
using com.shephertz.app42.paas.sdk.csharp.game; 
using com.shephertz.app42.paas.sdk.csharp;    
using com.shephertz.app42.paas.sdk.csharp.storage;  

public class ManagerConsultaCount : App42CallBack
{
    string gameName = "tejonivel110puntos"; ///se tiene q configurar el juego ademas de la app, y pueden haber varios juegos por app 
    string  userName = "Nick";  
    double gameScore = 3500;  
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
    String collectionName = "resultado";   
    String employeeJSON =  "{\"name\":\"Nick\",\"age\":30,\"phone\":\"xxx-xxx-xxx\"}";   
    int max = 100;  
    int offset = 0;  
    int contadorRegistros = 0;   
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
    
    public void consultarCount(){
          Debug.Log ("**** consultando count en app42 appwarp storageService");
          if( storageService == null ){
             Start();
          }
          if(storageService != null ){
              //storageService.FindAllDocumentsCount(dbName, collectionName, new UnityCallBack());   
              //storageService.FindAllDocuments(dbName, collectionName, new ManagerConsultaScoresJson() );
              if( contadorRegistros == 0){
                  //storageService.FindAllDocumentsCount(dbName, collectionName, new ManagerConsultaCount()); 
              }
                 
          } else {
              Debug.Log ("**** storageService es null ");
          }
    }
    public int getCount(){
        App42Log.Console("**** pidiendo get count ");
        if( contadorRegistros > 0 ){
             App42Log.Console("**** not null en get count ");
        }
        return contadorRegistros;
    }
      public void OnSuccess(object response)  
            {  
                App42Log.Console("**** succes consulta count app42 storageService max "+max);  
                Storage storage = (Storage) response;  
                /*
                App42Log.Console("TotalRecords : " + storage.GetTotalRecords());  
                if (storage.GetTotalRecords() != null ){
                    contadorRegistros = storage.GetTotalRecords();
                }*/
               
                //loadScores = gam
            }  
        
            public void OnException(Exception e)  
            {  
                App42Log.Console("**** failure fallo app42  count storageService Exception : " + e);  
            }  
  
}
