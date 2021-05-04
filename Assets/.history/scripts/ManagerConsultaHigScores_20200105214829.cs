﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using com.shephertz.app42.paas.sdk.csharp;    
using com.shephertz.app42.paas.sdk.csharp.game; 
using com.shephertz.app42.paas.sdk.csharp.storage;  

public class ManagerConsultaHighScores : App42CallBack
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
          Debug.Log ("**** consultando scores en app42 appwarp storageService");
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
                bool seAgregoLista = false;
                if( storage.GetJsonDocList() != null ){
                     IList<Storage.JSONDocument> jsonDocList = storage.GetJsonDocList();  
                    if( lstResultados == null ){
                        lstResultados = new List<Resultado>();
                    } 
                    App42Log.Console("**** succes consulta scores app42 storageService count "+jsonDocList.Count);
                    for(int i=0;i <jsonDocList.Count;i++)  
                    {     
                        App42Log.Console("objectId is " + jsonDocList[i].GetDocId());  
                        string jsonDoc = String.Copy(jsonDocList[i].GetJsonDoc());
                        App42Log.Console("jsonDoc is "+jsonDoc);  
                        Resultado resultado = JsonUtility.FromJson<Resultado>(jsonDoc);
                        if( !lstResultados.Contains(resultado)){
                            Debug.Log ("***** agregando en manager  "+resultado.getNick()+" index "+lstResultados.Count);
                            lstResultados.Add( resultado );
                            seAgregoLista = true;
                        }   else {
                            break;
                        }   
                        Debug.Log ("**** lstResultados en manager "+lstResultados.Count);
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
        
            public void OnException(Exception e)  
            {  
                App42Log.Console("**** failure fallo app42  storageService Exception : " + e);  
                ///toco esta chambonada por el error de cast con gettotalrecords en el manager count
                if( offset >= 100 ){
                        contadorRegistros = lstResultados.Count;
                    }
            }  
  
}
