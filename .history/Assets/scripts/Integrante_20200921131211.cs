using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Integrante
{
    //// los miembros tienen que ser public para que funcione el parseador tojson
    public string name;
    public int score;
    public void setScore( int elScore){
        score = elScore;
    }
    public void setName( string elName){
        name = elName;
    }
    public string getName(){
        return name;
    }
    public int getScore(){
        return score;
    }
}
