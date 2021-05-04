using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptScene : MonoBehaviour
{
    private float width;
    private float height;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /* if(  GameObject.Find (nombrePlayer) != null ){
                Animator anim = GameObject.Find (nombrePlayer).GetComponent<Animator>();
                AnimatorStateInfo currentBaseState = anim.GetCurrentAnimatorStateInfo(0);
                if( currentBaseState.nameHash == stateReposo){
                    lanzarTejo();
                }
        }*/
        //rotarIndicador(arrayNombresFuerzas[3],90,85);
         // Handle screen touches.
        Debug.Log ("**** update de scriptScene ");
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Debug.Log ("**** touch detectado  ");
            // Move the cube if the screen has the finger moving.
            Vector2 pos = touch.position;
            pos.x = (pos.x - width) / width;
            GameObject.Find (scriptTejo.NOMBRE_TEJO_GUIA).GetComponent<Transform>().position = pos;
        }
    } 
}
