﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scriptHighScores : MonoBehaviour
{
    public static string NOMBRE_SCENE_REGISTRO = "registro";
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public static void cambiarAEscenaHighScores(){
        SceneManager.LoadScene(Collision.NOMBRE_SCENE_HIGHSCORES, LoadSceneMode.Single);
    }
    public static void cambiarAEscenaRegistro(){
        SceneManager.LoadScene( NOMBRE_SCENE_REGISTRO, LoadSceneMode.Single);
    }
    public static void cambiarAEscenaPrincipal(){
        SceneManager.LoadScene( Collision.NOMBRE_SCENE_PRINCIPAL, LoadSceneMode.Single);
    }
    public void crearUsuario(){
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
