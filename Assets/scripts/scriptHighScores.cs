using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scriptHighScores : MonoBehaviour
{
    public static string NOMBRE_SCENE_REGISTRO = "registro2"; ///  se cambia de registro a registro2 y despues registro3
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public  void cambiarAEscenaHighScores(){
        SceneManager.LoadScene(Collision.NOMBRE_SCENE_HIGHSCORES, LoadSceneMode.Single);
    }
    public  void cambiarAEscenaHighScoresTeams(){
        SceneManager.LoadScene(Collision.NOMBRE_SCENE_HIGHSCORES_TEAMS, LoadSceneMode.Single);
    }
    public  void cambiarAEscenaRegistro(){
         Debug.Log ("**** cambiando a escena registro ");
        SceneManager.LoadScene( NOMBRE_SCENE_REGISTRO, LoadSceneMode.Single);
    }
    public  void cambiarAEscenaPrincipal(){
        SceneManager.LoadScene( Collision.NOMBRE_SCENE_PRINCIPAL, LoadSceneMode.Single);
    }
    public void crearUsuario(){
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
