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
    void OnMouseDown(){
        Debug.Log ("**** onmousedown scriptScene ");
        /// GameObject.Find (NOMBRE_TEJO).GetComponent<Transform>().position += Vector3.right * 10;
        GetComponent<Transform>().position = Vector3.right * 30;
        //OnMouseDrag();
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
     
    } 
}
