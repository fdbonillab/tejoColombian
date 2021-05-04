using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Resultado 
{
    public string nick;
    public string nickAnterior;
    public int nivel;
    public int puntajeObjetivo;
    public int score;
    public int turnos;
    public string deviceModel;
    public string deviceName;
    public bool esPC;
    public string fechaCreacion;
    
    public Resultado(int unNivel, int unObjetivo, int unScore, int unTurnos, bool unEsPC ){
        nivel = unNivel; puntajeObjetivo = unObjetivo; score = unScore; turnos = unTurnos;
        esPC = unEsPC;
        //fechaCreacion = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        //fechaCreacion = System.DateTime.Now.ToString("dd");
    }
    public Resultado(string unNick, int unNivel, int unObjetivo, int unScore, int unTurnos, bool unEsPC ){
        nick = unNick; nivel = unNivel; puntajeObjetivo = unObjetivo; score = unScore; turnos = unTurnos;
        esPC = unEsPC;
        //fechaCreacion = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        //fechaCreacion = System.DateTime.Now.ToString("dd");
    }
    public void setDeviceName(string elDeviceName){
        deviceName = elDeviceName;
    }
    public void setDeviceModel(string elDeviceModel){
        deviceModel = elDeviceModel;
    }
    public string getNick(){
        return nick;
    }
    public int getNivel(){
        return nivel;
    }
    public int getObjetivo(){
        return puntajeObjetivo;
    }
    public int getScore(){
        return score;
    }
    public int getTurnos(){
        return turnos;
    }
    public bool getEsPC(){
        return esPC;
    }
    public void setEsPC( bool elEsPC ){
        esPC = elEsPC;
    }
    public void setNick(string otroNick){
        nick = otroNick;
    }
    public string getNickAnterior(){
        return nickAnterior;
    }
    public void setNickAnterior( unNickAnterior){
        nickAnterior = unNickAnterior;
    }
    public void setFechaCreacion( string unaFechaCreacion ){
        fechaCreacion = unaFechaCreacion;
    }
    public bool Equals( Resultado other )
    {
        // Would still want to check for null etc. first.
        return (this.nick.Equals(other.nick) && this.getNivel() == other.getNivel() && this.getObjetivo() == other.getObjetivo() && this.getScore() == other.getScore() && this.getTurnos() == other.getTurnos() );
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
