using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using com.shephertz.app42.paas.sdk.csharp;    
using com.shephertz.app42.paas.sdk.csharp.game; 
public class ManagerScores : App42CallBack
{
    string gameName = "tejonivel110puntos"; ///se tiene q configurar el juego ademas de la app, y pueden haber varios juegos por app 
    string  userName = "Nick";  
    double gameScore = 3500;  
    ScoreBoardService scoreBoardService;
        
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
        Debug.Log ("**** en start de managerscores");
        App42Log.SetDebug(true);        //Print output in your editor console  
        App42API.Initialize(apiKey,secretKey);  
        scoreBoardService = App42API.BuildScoreBoardService();
    }

    // Update is called once per frame
    void Update()
    {
          
       
    }
    public void salvarScore(double elGameScore){
          Debug.Log ("**** salvando score  en app42 appwarp");
          if( scoreBoardService == null ){
             Start();
          }
          if(scoreBoardService != null ){
              scoreBoardService.SaveUserScore(gameName, userName, gameScore, new ManagerScores());  
          } else {
              Debug.Log ("**** scoreboardservices es null ");
          }
    }
     public void OnSuccess(object response)  
            {  
                App42Log.Console("**** succes app42 ");  
                Game game = (Game) response;       
                App42Log.Console("gameName is " + game.GetName());   
                for(int i = 0;i<game.GetScoreList().Count;i++)  
                {  
                    App42Log.Console("userName is : " + game.GetScoreList()[i].GetUserName());  
                    App42Log.Console("score is : " + game.GetScoreList()[i].GetValue());  
                    App42Log.Console("scoreId is : " + game.GetScoreList()[i].GetScoreId());  
                }  
            }  
        
            public void OnException(Exception e)  
            {  
                App42Log.Console("**** failure fallo app42 Exception : " + e);  
            }  
  
}
