using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;


public class scriptClickEquipo : MonoBehaviour
{
    public void elegirEquipo(){
         Debug.Log ("**** eligiendo equipo ");
         Transform transform =  GetComponent<Transform>().gameObject.parent.FindChild("Child Name");
    }
}
