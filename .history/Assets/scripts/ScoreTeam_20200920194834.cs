using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScoreTeams
{
    public string nameTeam;
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
}
