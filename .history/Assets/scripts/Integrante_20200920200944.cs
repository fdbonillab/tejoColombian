using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Integrante
{
    string name;
    int score;
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
