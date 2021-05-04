using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using com.shephertz.app42.paas.sdk.csharp;    
using com.shephertz.app42.paas.sdk.csharp.customcode;  
using SimpleJSON;

public class ManagerCustomCode : App42CallBack   
    {  
        
        String nameCustomCode = "consultarScores";  
        String NAME_TUPLA = "countScores8";
        String NAME_NICK = "nick";
        String NAME_PUNTAJE_OBJETIVO = "puntajeObjetivo";
        String NAME_SCORE = "score";
        String NAME_TURNOS = "turnos";
        String NAME_DEVICE_MODEL = "deviceModel";
        String NAME_DEVICE_NAME = "deviceName";
        List<Resultado> lstResultados;
        bool esPC = (Application.platform == RuntimePlatform.Android);
        //JSONClass  jsonBody;  
        CustomCodeService customCodeService ;   
        public void ejecutarCustomCode(){
            //jsonBody = new JSONClass ();  
            JSONObject jsonBody = new JSONObject();
            jsonBody.Add("Company", "Shephertz");  
            App42Log.SetDebug(true);        //Print output in your editor console  
            App42API.Initialize(ManagerScoresJson.apiKey, ManagerScoresJson.secretKey);  
            customCodeService = App42API.BuildCustomCodeService();   
            customCodeService.RunJavaCode(nameCustomCode, jsonBody, new ManagerCustomCode());   
        }
        public List<Resultado> getListResultados(){
            return lstResultados;
        }
        public void OnSuccess(object response)  
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
                     Resultado resultado = new Resultado(nick, nivel, objetivo, score, turnos , esPC);
                     lstResultados.Add(resultado);
                     App42Log.Console(" custom code values score turnos "+nick+" "+score+" "+turnos );
                     //Resultado(string unNick, int unNivel, int unObjetivo, int unScore, int unTurnos ){
                 }
            }
            App42Log.Console("custom code Success : " + response);  
        }  
      
        public void OnException(Exception e)  
        {  
            App42Log.Console("custom code Exception : " + e);  
        }  
    }  