using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scriptCrearUsuario : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
  
    // Update is called once per frame
    void Update()
    {
        
    }
    public void crearUsuario(){
         if( validarContrasena()){
             ManagerUser.crearUsuario();
         }
    }
    /** todo: si lo logra crear el usuario entonces sobreescribe el mejor puntaje que tenga con el nombre de usuario q creo
    */
    private bool validarContrasena(){
        InputField inputPassword = GameObject.Find(ManagerUser.INPUT_PASSWORD).GetComponent<InputField>();
        InputField inputConfirmPassword = GameObject.Find(ManagerUser.INPUT_CONFIRM_PASSWORD).GetComponent<InputField>();
        Text textMensajeValidacion =  GameObject.Find(ManagerUser.TEXT_MENSAJE_VALIDACION).GetComponent<Text>(); 
        if( ! inputPassword.text.Equals(inputConfirmPassword.text)){
            textMensajeValidacion.text = "No corresponden el correo y la confirmacion";
            return false;
        }
        return true;
    }
 
}
