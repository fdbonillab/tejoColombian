using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using com.shephertz.app42.paas.sdk.csharp;
using com.shephertz.app42.paas.sdk.csharp.user;    

public class ManagerUser : App42CallBack
{
    
    public static string apiKey = "5e8c1c2c90dafb1b4024609fa2af2189cb21f02726e5cb8dbd7365dd2e14f879";
	public static string secretKey = "4326a27aa58806934875fb472e762dbe060309151e32c83ab9e85c8be9278bde";
    public static UserService userService;
    public static string INPUT_NICK = "InputNickName";
    public static string INPUT_PASSWORD = "InputPassword";
    public static string INPUT_CONFIRM_PASSWORD = "InputConfirmPassw";
    public static string INPUT_CORREO = "InputCorreo";
    public static string TEXT_MENSAJE_VALIDACION = "TextMensajeValidacion";
    // Start is called before the first frame update
    static void Start()
    {
        App42Log.SetDebug(true);        //Print output in your editor console  
        App42API.Initialize(apiKey,secretKey);  
        userService = App42API.BuildUserService(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void crearUsuario(){
          if( userService == null ){
              Start();
          }
          InputField inputNick = GameObject.Find(INPUT_NICK).GetComponent<InputField>();
          InputField inputPassword = GameObject.Find(INPUT_PASSWORD).GetComponent<InputField>();
          InputField inputCorreo = GameObject.Find(INPUT_CORREO).GetComponent<InputField>();
          String userName = inputNick.text;///"Nick";  
          String pwd = inputPassword.text ;///"********";  
          String emailId = inputCorreo.text;//"nick@shephertz.com";     
          userService.CreateUser(userName, pwd, emailId,new ManagerUser());  
    }
    public void OnSuccess(object response)  
        {  
            User user = (User) response;  
            /* This will create user in App42 cloud and will return User object */    
            App42Log.Console("userName is " + user.GetUserName());  
            App42Log.Console("emailId is " + user.GetEmail());   
        }  

          private string remplazarUserNameEnPreferences(){
                   string userNameAnterior = null; 
                   string usernameEnPreference = PlayerPrefs.GetString(NAME_PREF_USERNAME);
                    if(  usernameEnPreference != null && !usernameEnPreference.Equals("")){
                        username = usernameEnPreference;
                        userNameAnterior = usernameEnPreference;
                        PlayerPrefs.SetString(NAME_PREF_USERNAME, username);
                        Debug.Log ("**** username existe preference --"+username+"--");
                    } else {
                            username = System.DateTime.UtcNow.Ticks.ToString();
                            username = username.Substring(username.Length-4);   
                            username = "guest"+username;
                            PlayerPrefs.SetString(NAME_PREF_USERNAME, username);
                    }
                    return username;
            }
        public void OnException(Exception e)  
        {  
            App42Log.Console("Exception : " + e);  
        } 
}
