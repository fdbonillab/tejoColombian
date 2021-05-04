using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptNewGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void newGame(){
        Collision script = GameObject.Find ("tejoAnim1").GetComponent<Collision>();
        script.nuevoJuego();
    }
    public void salirJuego(){
        /* Debug.Log ("**** boton salir juego saliendo keydown 1");
            //// si le da salir por lo menos ver hasta donde llego, cuantos turnos duro y que puntaje hizo
            ManagerScoresJson managerScoreJson = new ManagerScoresJson();
            string json = JsonUtility.ToJson(ultimoResultado);
            managerScoreJson.salvarScore(json);
            Debug.Log ("**** boton salir juego saliendo keydown 2");
             if (Application.platform == RuntimePlatform.Android)
             {
                 AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
                 activity.Call<bool>("moveTaskToBack", true);
             }
             else
             {
                 Application.Quit();
             }*/
    }
}
