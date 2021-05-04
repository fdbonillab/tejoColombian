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
    private void guardarUnResultadoConNuevoUser(){
        int turnosFicti =1;
        bool esPC =  (Application.platform != RuntimePlatform.Android);;
        int bestScoreEnPreference = PlayerPrefs.GetInt(NAME_PREF_BEST_SCORE);
        Resultado toResultado = new Resultado(username,Collision.LEVEL_1, Collision.PUNTAJE_OBJETIVO_10, bestScoreEnPreference, turnosFicti, esPC );
        string json = JsonUtility.ToJson(toResultado);
        managerScoreJson.salvarScore(json);
    }
    public void OnSuccess(object response)  
        {  
            User user = (User) response;  
            /* This will create user in App42 cloud and will return User object */    
            App42Log.Console("userName is " + user.GetUserName());  
            App42Log.Console("emailId is " + user.GetEmail());   
            remplazarUserNameEnPreferences( user.GetUserName());
            new scriptHighScores().cambiarAEscenaPrincipal();
        }  

          private void remplazarUserNameEnPreferences( string nuevoUserName ){
                   string userNameAnterior = null; 
                   string usernameEnPreference = PlayerPrefs.GetString(Collision.NAME_PREF_USERNAME);
                    if(  usernameEnPreference != null && !usernameEnPreference.Equals("")){
                        userNameAnterior = usernameEnPreference;
                        PlayerPrefs.SetString( Collision.NAME_PREF_USERNAME_ANTERIOR , userNameAnterior);
                        PlayerPrefs.SetString( Collision.NAME_PREF_USERNAME , nuevoUserName );
                        Debug.Log ("**** nuevo user name  --"+nuevoUserName+"-- username anterior "+userNameAnterior );
                    } else {
                            PlayerPrefs.SetString(Collision.NAME_PREF_USERNAME,  nuevoUserName );
                    }
            }
        public void OnException(Exception e)  
        {  
            App42Log.Console("Exception : " + e);  
        } 
}
