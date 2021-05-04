using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scriptHighScores : MonoBehaviour
{
    string NOMBRE_SCENE_REGISTRO = "registro2";///antes era registro
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void cambiarAEscenaHighScores(){
        SceneManager.LoadScene(Collision.NOMBRE_SCENE_HIGHSCORES, LoadSceneMode.Single);
    }
    public void cambiarAEscenaRegistro(){
        SceneManager.LoadScene(NOMBRE_SCENE_REGISTRO, LoadSceneMode.Single);
    }
    public void cambiarAEscenaPrincipal(){
        SceneManager.LoadScene(NOMBRE_SCENE_REGISTRO, LoadSceneMode.Single);
    }
    public void crearUsuario(){
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
