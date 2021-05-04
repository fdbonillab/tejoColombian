using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using com.shephertz.app42.paas.sdk.csharp;    
using com.shephertz.app42.paas.sdk.csharp.user;   
public class ManagerConsultaUsers : App42CallBack{
        int max = 1;  
        int offset = 0 ;  
        UserService userService;
        private void iniciar(){
            App42Log.SetDebug(true);        //Print output in your editor console  
            App42API.Initialize("API_KEY","SECRET_KEY");  
            UserService userService = App42API.BuildUserService();  
            userService.GetAllUsers(max,offset,new ManagerConsultaUsers());
        }
        
        public void consultarUsuarios(){
            Debug.Log ("**** consultando scores en app42 appwarp storageService");
            if( userService == null ){
                iniciar();
            }
            if(userService != null ){
                //storageService.FindAllDocumentsCount(dbName, collectionName, new UnityCallBack());   
                //storageService.FindAllDocuments(dbName, collectionName, new ManagerConsultaScoresJson() );
                userService.GetAllUsers(max,offset,new ManagerConsultaUsers());
                    
            } else {
                Debug.Log ("**** userService es null ");
            }
        }

        public void OnSuccess(object response)  
        {  
            IList<User> user = (IList<User>) response;       
            for(int i = 0; i < user.Count; i++)   
            {  
                App42Log.Console("userName is " + user[i].GetUserName());  
                App42Log.Console("emailId is " + user[i].GetEmail());  
            }        
        }  
        public void OnException(Exception e)  
        {  
            App42Log.Console("Exception : " + e);  
        }  
}