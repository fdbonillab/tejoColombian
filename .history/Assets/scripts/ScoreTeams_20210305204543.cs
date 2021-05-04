using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]

public class ScoreTeams
{
    //// los miembros tienen que ser public para que funcione el parseador tojson
    public  List<Team> highScoreTeamList;
    public void setLstTeams( List<Team> losLstTeams){
        highScoreTeamList = losLstTeams;
    }
    public List<Team>  getHighScoreTeamList(){
        return highScoreTeamList;
    }
    public List<Team> getSubList(int inicio, int fin){
        return highScoreTeamList.GetRange(0,4);
    }
}
