using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
////
using UnityEngine.UI;
using UnityEngine.U2D;


public class HighScoreTable:MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    string NAME_HIGHSCORE_ENTRY_CONTAINER = "highScoreEntryContainer";
    string NAME_HIGHSCORE_ENTRY_TEMPLATE = "highScoreEntryTemplate";
    string NAME_HIGHSCORE_SCROLLVIEW = "ScrollView";
    string NAME_HIGHSCORE_SCROLLVIEW_VIEWPORT = "Viewport";
    /// scrollview viewport content
    string NAME_HIGHSCORE_TABLE =  "highScoreTable";
    string NAME_HIGHSCORE_SCROLLVIEW_CONTENT =  "Content";

    string NAME_TEXT_POSICION = "textPosicion";
    string NAME_TEXT_DEPARTAMENTO = "textDepartamento";
    string NAME_IMG_TEAM_ESCUDO = "ImageTeam";
    string NAME_TEXT_PUNTOS = "textPuntos";
    string NAME_TEXT_INTEGRANTES = "textIntegrantes";
    string NAME_BACKGROUND = "backgroundTemplate";
    string NAME_OBJ_CREAR_BOTONES = "objetoCrearBotones";
    public SpriteAtlas atlasEquiposFutbol;    
    public SpriteAtlas atlasDepartamentos;    
    private List<HighScoreEntry> highScoreEntryList;
    private List<Transform> highScoreEntryTransformList;
    ManagerConsultaScoreTeams managerConsultaScoreTeams;
    bool tablaMostrada = false;
    ScoreTeams unScoreTeams;
    ///20210305 son 32 equipos de momento
    int pagina = 0;
    int rowsPage = 16;
    void Start(){
        managerConsultaScoreTeams = new ManagerConsultaScoreTeams();
        managerConsultaScoreTeams.consultarScores();
    }

    private void Awake1(){
        entryContainer = transform.Find(NAME_HIGHSCORE_ENTRY_CONTAINER);
        entryTemplate = entryContainer.Find(NAME_HIGHSCORE_ENTRY_TEMPLATE);
        Debug.Log ("**** en awake highscores  ");
        highScoreEntryList = new List<HighScoreEntry>{
            new HighScoreEntry{score = 521,nameDepartamento = "AAA"},
            new HighScoreEntry{score = 4521,nameDepartamento = "JON"},
            new HighScoreEntry{score = 5321,nameDepartamento = "BBB"},
            new HighScoreEntry{score = 5221,nameDepartamento = "DEE"}
        };
        highScoreEntryTransformList = new List<Transform>();
        foreach( HighScoreEntry highScoreEntry in highScoreEntryList ){
            CreateHighScoreEntryTransform( highScoreEntry, entryContainer, highScoreEntryTransformList);
        }
        entryTemplate.gameObject.SetActive( false );
    }
    public Vector2 scrollPosition = Vector2.zero;
    void OnGUI(){
        float tableHeight = 10f;/// inicial 3.0f, 10f
        float left = 1f;
        ////// 20210305 q gallo hacerlo con scroll programatico o con el componente scrollview se ve mal entonces toco al estilo de la tabla de highscores de spider hero race
        ////entryContainer = transform.Find(NAME_HIGHSCORE_ENTRY_CONTAINER).Find(NAME_HIGHSCORE_SCROLLVIEW).Find(NAME_HIGHSCORE_SCROLLVIEW_VIEWPORT).Find(NAME_HIGHSCORE_SCROLLVIEW_CONTENT);//transform.Find(NAME_HIGHSCORE_ENTRY_CONTAINER);
        entryContainer = transform.Find(NAME_HIGHSCORE_ENTRY_CONTAINER);
         /// scrollview viewport content
        entryTemplate = entryContainer.Find(NAME_HIGHSCORE_ENTRY_TEMPLATE);
        //Transform transfTable =  entryContainer = GameObject.Find(NAME_HIGHSCORE_TABLE).GetComponent<Transform>();
        //RectTransform tableRectTransform = transfTable.GetComponent<RectTransform>();
        //tableRectTransform.anchoredPosition = new Vector2(1,1);
        //RectTransformExtensions.SetLeft( tableRectTransform, left );
        Debug.Log ("**** en update  highscores  ");
        Debug.Log ("**** entryContainer == null "+(entryContainer == null)+" entryTemplate == null "+(entryTemplate == null ));
        int sizeListPrincipal = 0;
        int desde = (pagina)*rowsPage;
        int hasta = (pagina+1)*rowsPage;
        if( unScoreTeams == null &&  managerConsultaScoreTeams.getScoreTeams() != null ){
            unScoreTeams = managerConsultaScoreTeams.getScoreTeams();
            sizeListPrincipal = unScoreTeams.getHighScoreTeamList().Count;
        }
        ScoreTeams subLstTeams = new ScoreTeams();
        Debug.Log ("**** subLstTeams == null "+( subLstTeams == null ));
      
        Debug.Log ("**** desde "+desde+" hasta "+hasta);
        Debug.Log ("**** pagina "+pagina);
       
        if( unScoreTeams != null ){
            if(  hasta >= sizeListPrincipal ){
                hasta = sizeListPrincipal-1;
            }
            subLstTeams.setLstTeams(unScoreTeams.getHighScoreTeamList().GetRange( desde ,  hasta ));
        }
        
        highScoreEntryList = ScoresTeams2HighScoreEntry(subLstTeams);
        highScoreEntryTransformList = new List<Transform>();
        if(  !tablaMostrada && highScoreEntryList.Count > 0 ){
            Vector2 nativeSize = new Vector2(800, 480);
            float factorScreenX = ((float)Screen.width / (float)nativeSize.x);
            float factorScreenY = ((float)Screen.height / (float)nativeSize.y);
            // An absolute-positioned example: We make a scrollview that has a really large client
            // rect and put it in a small rect on the screen.
            ///780 ajusta casi en horizontal
            GUI.BeginScrollView(new Rect(10, 10, 460*factorScreenX, 780*factorScreenY), scrollPosition,//// x antes era 790
                        new Rect(0, 0, 100*factorScreenX, 200*factorScreenY )); /// el x era 1000 antes

             foreach( HighScoreEntry highScoreEntry in highScoreEntryList ){
                CreateHighScoreEntryTransform( highScoreEntry, entryContainer, highScoreEntryTransformList);
             }
             entryTemplate.gameObject.SetActive( false );
             tablaMostrada = true;
             GUI.EndScrollView();
        }
    }
  
    private List<HighScoreEntry> ScoresTeams2HighScoreEntry( ScoreTeams elScoreTeams){
        List<HighScoreEntry> lsthighScores = new List<HighScoreEntry>();
        if( elScoreTeams != null && elScoreTeams.getHighScoreTeamList() != null && elScoreTeams.getHighScoreTeamList().Count > 0){
            foreach( Team elTeam in elScoreTeams.getHighScoreTeamList()){
                int sumaPuntosTeam = 0;
                foreach( Integrante elIntegrante in elTeam.getIntegrantesList()){
                    sumaPuntosTeam += elIntegrante.getScore();
                }
                HighScoreEntry elHighScore = new HighScoreEntry();
                elHighScore.nameDepartamento = elTeam.getName();
                elHighScore.score = sumaPuntosTeam;
                elHighScore.numUsuarios = elTeam.getIntegrantesList().Count;
                lsthighScores.Add(elHighScore);
            }
        }
        SortedDictionary<float, HighScoreEntry> mapPuntajes = new SortedDictionary<float, HighScoreEntry>();
        foreach(HighScoreEntry  elTeamPuntaje in lsthighScores ){
            if( mapPuntajes.ContainsKey(elTeamPuntaje.score) ){
                mapPuntajes[ elTeamPuntaje.score+0.1f ] = elTeamPuntaje;
            } else {
                mapPuntajes[ elTeamPuntaje.score ] = elTeamPuntaje;
            }
        }
        List<HighScoreEntry> lstResultados = new List<HighScoreEntry>();
        List<HighScoreEntry> lstResultadosReverse = new List<HighScoreEntry>();
        foreach(HighScoreEntry resultado in mapPuntajes.Values){
             lstResultados.Add(resultado);
        }
        for(int i = lstResultados.Count-1;i >=0 ;i--){
            lstResultadosReverse.Add(lstResultados[i]);
        }
        return lstResultadosReverse;
    }
    public void nextPage(){
        pagina ++;
        int paginaMaxima = (unScoreTeams.getHighScoreTeamList().Count-1)/rowsPage;
        if( pagina > paginaMaxima){
            pagina = paginaMaxima;
        }
        Debug.Log ("**** nextpage pagina "+pagina);
    }
    public void previosPage(){
        pagina--;
        if( pagina < 0){
            pagina = 0;
        }
        Debug.Log ("**** previouspage pagina "+pagina);
    }
    private void CreateHighScoreEntryTransform(HighScoreEntry highScoreEntry, Transform container, List<Transform> listTransform){
        float templateHeight = 1.9f;/// inicial 3.0f
        float offsetArriba = 13f;// inicial 9f, luego 13f, luego 13
        float factorEscala = 0.8f;
        float offsetIzquierda = -3f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(offsetIzquierda,(-templateHeight*listTransform.Count)+offsetArriba);
        entryTransform.localScale = new Vector3(entryTransform.localScale.x*factorEscala, entryTransform.localScale.y*factorEscala, transform.localScale.z);
        entryTransform.gameObject.SetActive(true);
        int rank = listTransform.Count + 1;
        string rankString = rank.ToString();
        Debug.Log ("**** rankString  "+rankString);
       
        entryTransform.Find(NAME_TEXT_POSICION).GetComponent<Text>().text = rankString;
        entryTransform.Find(NAME_TEXT_PUNTOS).GetComponent<Text>().text = highScoreEntry.score.ToString();
        entryTransform.Find(NAME_TEXT_DEPARTAMENTO).GetComponent<Text>().text = highScoreEntry.nameDepartamento;
        entryTransform.Find(NAME_IMG_TEAM_ESCUDO).GetComponent<Image>().sprite = buscarImgTeam(highScoreEntry.nameDepartamento);
        entryTransform.Find(NAME_TEXT_INTEGRANTES).GetComponent<Text>().text = ""+highScoreEntry.numUsuarios;
        entryTransform.Find(NAME_BACKGROUND).gameObject.SetActive( rank % 2 == 1);
        listTransform.Add(entryTransform);
    }
    private Sprite buscarImgTeam(string _nameTeam){
        ////scriptTejo script = GameObject.Find ("tejoVistaSup800b").GetComponent<scriptTejo>();
        scriptSelectorEquipo _script = GameObject.Find (NAME_OBJ_CREAR_BOTONES).GetComponent<scriptSelectorEquipo>();
        scriptSelectorEquipoFutbol _scriptFutbol = GameObject.Find (NAME_OBJ_CREAR_BOTONES).GetComponent<scriptSelectorEquipoFutbol>();
        _script.llenarListaDepartamentos();
        _scriptFutbol.llenarListaEquiposFutbol();
        string _nameImgTeamDepartmentos = _script.getImageTeamByName(_nameTeam);
        string _nameImgTeamFutbol = _scriptFutbol.getImageTeamByName(_nameTeam);
        Sprite _sprite = atlasEquiposFutbol.GetSprite(_nameImgTeamFutbol);  
        if( _sprite == null ){
            _sprite =  atlasDepartamentos.GetSprite(_nameImgTeamDepartmentos);  
        }
        Debug.Log ("**** buscarImgTeam  _sprite == null  "+(_sprite == null )+" name "+_nameTeam);
        return _sprite;
    }
    private class HighScoreEntry{
        public int score;
        public string nameDepartamento;

        public int numUsuarios;

    }
}
