using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class Team
{
    //// los miembros tienen que ser public para que funcione el parseador tojson
    public string nameTeam;
    public List<Integrante> integrantesList;
    
    public void setintegrantesList(List<Integrante> losIntegrantes){
        integrantesList = losIntegrantes;
    }
    public  List<Integrante> getIntegrantesList(){
        return integrantesList;
    }
    public void setName( string elName){
        nameTeam = elName;
    }
    public string getName(){
        return nameTeam;
    }
    public bool Contains( Team otherObject){
        if( nameTeam.Equals(otherObject.nameTeam)){
            return true;
        } 
        return false;
    }
}
