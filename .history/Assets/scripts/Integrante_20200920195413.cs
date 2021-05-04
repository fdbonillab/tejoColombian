using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Integrante
{
    private List<HighScoreEntry> highScoreEntryList;
    
    public Team(int unNivel, int unObjetivo, int unScore, int unTurnos, bool unEsPC ){
        nivel = unNivel; puntajeObjetivo = unObjetivo; score = unScore; turnos = unTurnos;
        esPC = unEsPC;
        //fechaCreacion = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        //fechaCreacion = System.DateTime.Now.ToString("dd");
    }
}
