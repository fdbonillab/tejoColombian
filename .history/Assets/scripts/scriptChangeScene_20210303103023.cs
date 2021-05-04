using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;
using UnityEngine.SceneManagement;

public class scriptChangeScene : MonoBehaviour
{
    public void changeScene(){
         Debug.Log ("**** eligiendo equipo ");
         PlayerPrefs.SetString(Collision.NAME_PREF_NEW_GAME,"true");
         SceneManager.LoadScene(Collision.NOMBRE_SCENE_PRINCIPAL, LoadSceneMode.Single);
         //Collision script = GameObject.Find ("tejoAnim1").GetComponent<Collision>();
         //script.nuevoJuego();
    }
    public void changeSceneDepartamentos(){
         Debug.Log ("**** eligiendo equipo hacia departamentos ");
         PlayerPrefs.SetString(Collision.NAME_PREF_NEW_GAME,"true");
         SceneManager.LoadScene(Collision.NOMBRE_SCENE_PRINCIPAL, LoadSceneMode.Single);
         //Collision script = GameObject.Find ("tejoAnim1").GetComponent<Collision>();
         //script.nuevoJuego();
    }
}
