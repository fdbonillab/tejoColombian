using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptExitGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void salirJuego(){
         Debug.Log ("**** boton salir juego saliendo keydown 1");
            Collision.salirJuego();
    }
}
