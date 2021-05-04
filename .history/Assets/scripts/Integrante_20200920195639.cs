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
    public void setName( int elName){
        name = elName;
    }
    public getName(){
        return name;
    }
    public getScore(){
        return score;
    }
}
