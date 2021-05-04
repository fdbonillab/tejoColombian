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
}
