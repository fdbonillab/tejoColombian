using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;


public class scriptSelectorEquipo : MonoBehaviour
{
    public Transform prefabButton;
    public SpriteAtlas atlasDepartamentos;
    string NAME_OBJ_BUTTON_ARRIBA = "ButtonArriba";
    string NAME_OBJ_BUTTON_ABAJO = "ButtonAbajo";
    string NAME_OBJ_BUTTON_OK = "ButtonOK";
    string NAME_CANVAS = "Canvas";
    List<Departamento> lstDepartamentos;
    List<Resultado> lstResultados;
    List<Button> lstButtonsTeamns;
    public static string NAME_AMAZONAS = "Amazonas"; 
    public static string NAME_ANTIOQUIA = "Antioquia";
    public static string NAME_ARAUCA = "Arauca";
    public static string NAME_ATLANTICO = "Atlántico";
    public static string NAME_BOGOTA = "Bogotá";
    public static string NAME_BOLIVAR = "Bolívar";
    public static string NAME_BOYACA = "Boyacá";
    public static string NAME_CALDAS = "Caldas";
    public static string NAME_CAQUETA = "Caquetá";
    public static string NAME_CASANARE = "Casanare";
    public static string NAME_CAUCA = "Cauca";
    public static string NAME_CESAR = "Cesar";
    public static string NAME_CHOCO = "Chocó";
    public static string NAME_CORDOBA = "Córdoba";
    public static string NAME_CUNDINAMARCA = "Cundinamarca";
    public static string NAME_GUAINIA = "Guainía";
    public static string NAME_GUAVIARE = "Guaviare";
    public static string NAME_GUAJIRA = "Guajira";
    public static string NAME_MAGDALENA = "Magdalena";
    public static string NAME_META = "Meta";
    public static string NAME_NARINO = "Nariño";
    public static string NAME_NORTE_SANTANDER = "Norte de Santander";
    public static string NAME_PUTUMAYO = "Putumayo";
    public static string NAME_QUINDIO = "Quindío";
    public static string NAME_RISARALDA = "Risaralda";
    public static string NAME_SANTANDER = "Santander";
    public static string NAME_SUCRE = "Sucre";
    public static string NAME_TOLIMA = "Tolima";
    public static string NAME_VALLE_CAUCA = "Valle del Cauca";
    public static string NAME_VAUPES = "Vaupés";
    public static string NAME_VICHADA = "Vichada";

public static string NAME_IMG_BANDERA_BOGOTA = "100px-Flag_of_Bogotá.svg";
public static string NAME_IMG_BANDERA_GUAJIRA = "100px-Flag_of_La_Guajira.svg";
public static string NAME_IMG_BANDERA_MAGDALENA = "100px-Flag_of_Magdalena.svg";
public static string NAME_IMG_BANDERA_META = "100px-Flag_of_Meta.svg";
public static string NAME_IMG_BANDERA_NARINO = "100px-Flag_of_Nariño.svg";
public static string NAME_IMG_BANDERA_NORTE_SANTANDER = "100px-Flag_of_Norte_de_Santander.svg";
public static string NAME_IMG_BANDERA_PUTUMAYO = "100px-Flag_of_Putumayo.svg";
public static string NAME_IMG_BANDERA_QUINDIO = "100px-Flag_of_Quindío.svg";
public static string NAME_IMG_BANDERA_RISARALDA = "100px-Flag_of_Risaralda.svg";
public static string NAME_IMG_BANDERA_SANTANDER = "100px-Flag_of_Santander_(Colombia).svg";
public static string NAME_IMG_BANDERA_TOLIMA = "100px-Flag_of_Tolima.svg";
public static string NAME_IMG_BANDERA_VALLE_CAUCA = "100px-Flag_of_Valle_del_Cauca.svg";
public static string NAME_IMG_BANDERA_VAUPES = "100px-Flag_of_Vaupés.svg";
public static string NAME_IMG_BANDERA_VICHADA = "100px-Flag_of_Vichada.svg";
public static string NAME_IMG_BANDERA_ARAUCA = "150px-Flag_of_Arauca.svg";
public static string NAME_IMG_BANDERA_ATLANTICO = "150px-Flag_of_Atlántico.svg";
public static string NAME_IMG_BANDERA_BOLIVAR = "150px-Flag_of_Bolívar_(Colombia).svg";
public static string NAME_IMG_BANDERA_CALDAS = "150px-Flag_of_Caldas.svg";
public static string NAME_IMG_BANDERA_CAQUETA = "150px-Flag_of_Caquetá.svg";
public static string NAME_IMG_BANDERA_CASANARE = "150px-Flag_of_Casanare.svg";
public static string NAME_IMG_BANDERA_CAUCA = "150px-Flag_of_Cauca.svg";
public static string NAME_IMG_BANDERA_CESAR = "150px-Flag_of_Cesar.svg";
public static string NAME_IMG_BANDERA_CHOCO = "150px-Flag_of_Chocó.svg";
public static string NAME_IMG_BANDERA_CORDOBA = "150px-Flag_of_Córdoba.svg";
public static string NAME_IMG_BANDERA_GUAINIA = "150px-Flag_of_Guainía.svg";
public static string NAME_IMG_BANDERA_GUAVIARE = "150px-Flag_of_Guaviare.svg";
public static string NAME_IMG_BANDERA_HUILA = "150px-Flag_of_Huila.svg";
public static string NAME_IMG_BANDERA_AMAZONAS = "Flag_of_Amazonas_(Colombia).svg";
public static string NAME_IMG_BANDERA_ANTIOQUIA = "Flag_of_Antioquia_Department.svg";
public static string NAME_IMG_BANDERA_BOYACA = "Flag_of_Boyacá_Department.svg";
public static string NAME_IMG_BANDERA_CUNDINAMARCA = "Flag_of_Cundinamarca.svg";
public static string NAME_IMG_BANDERA_SAN_ANDRES = "Flag_of_San_Andrés_y_Providencia.svg";
public static string NAME_IMG_BANDERA_SUCRE = "Flag_of_Sucre_(Colombia).svg";

public static string NAME_PREF_TEAM = "PREF_TEAM";
public static string NAME_TEXT_ESCOGE_EQUIPO = "TextEscogerEquipo";

    int ID_TEAM_AMAZONAS = 1; 
    int ID_TEAM_ANTIOQUIA = 2;
    int ID_TEAM_ARAUCA = 3;
    int ID_TEAM_ATLANTICO = 4;
    int ID_TEAM_BOGOTA = 5;
    int ID_TEAM_BOLIVAR = 6;
    int ID_TEAM_BOYACA = 7;
    int ID_TEAM_CALDAS = 8;
    int ID_TEAM_CAQUETA = 9;
    int ID_TEAM_CASANARE = 10;
    int ID_TEAM_CAUCA = 11;
    int ID_TEAM_CESAR = 12;
    int ID_TEAM_CHOCO = 13;
    int ID_TEAM_CORDOBA = 14;
    int ID_TEAM_CUNDINAMARCA = 15;
    int ID_TEAM_GUAINIA = 16;
    int ID_TEAM_GUAVIARE = 17;
    int ID_TEAM_GUAJIRA = 18;
    int ID_TEAM_MAGDALENA = 19;
    int ID_TEAM_META = 20;
    int ID_TEAM_NARINO = 21;
    int ID_TEAM_NORTE_SANTANDER = 22;
    int ID_TEAM_PUTUMAYO = 23;
    int ID_TEAM_QUINDIO = 24;
    int ID_TEAM_RISARALDA = 25;
    int ID_TEAM_SANTANDER = 26;
    int ID_TEAM_SUCRE = 27;
    int ID_TEAM_TOLIMA = 28;
    int ID_TEAM_VALLE_CAUCA = 29;
    int ID_TEAM_VAUPES = 30;
    int ID_TEAM_VICHADA = 31;

/****
**
Arauca.svg Arauca 	7 	
Atlántico.svg Atlántico 
Bogotá.svg Bogotá 	1 	
Bolívar (Colombia).svg B
Boyacá Department.svg Bo
Caldas.svg Caldas 	27 	
Caquetá.svg Caquetá 	
Casanare.svg Casanare 	
Cauca.svg Cauca 	41 	
Cesar.svg Cesar 	25 	
Chocó.svg Chocó 	31 	
Córdoba.svg Córdoba 	
Cundinamarca.svg Cundina
Guainía.svg Guainía 	
Guaviare.svg Guaviare 	
Huila.svg Huila 	37 	
La Guajira.svg La Guajir
Magdalena.svg Magdalena 
Meta.svg Meta 	29 	Vill
Nariño.svg Nariño 	64 	
Norte de Santander.svg N
Putumayo.svg Putumayo 	
Quindío.svg Quindío 	
Risaralda.svg Risaralda 
San Andrés y Providencia
Santander Department.svg
Sucre (Colombia).svg Suc
Tolima.svg Tolima 	47 	
Valle del Cauca.svg Vall
Vaupés.svg Vaupés 	3 	
Vichada.svg Vichada 	


**/


    // Start is called before the first frame update
    //// traje la carpeta y el prefab, las referencias quedaron dañadas, sigue buscar el boton de arriba para la posicion inicial y empezar desde ahi
    void Start()
    {
        float desfase = 10;
        Vector3 posBotonArriba = GameObject.Find (NAME_OBJ_BUTTON_ARRIBA).gameObject.GetComponent<RectTransform>().position;
        Vector3 posBotonAbajo = GameObject.Find (NAME_OBJ_BUTTON_ABAJO).gameObject.GetComponent<RectTransform>().position;
        GameObject objCanvas = GameObject.Find (NAME_CANVAS);
        GameObject buttonCreado;
        float diff = posBotonAbajo.x - posBotonArriba.x;
        float quintaParte = diff/5;
        float heighScreen = Screen.height;
        float widthScreen = Screen.width;
        float anchoBoton =  GameObject.Find (NAME_OBJ_BUTTON_ARRIBA).gameObject.GetComponent<RectTransform>().rect.width+40;
        float altoBoton =  GameObject.Find (NAME_OBJ_BUTTON_ARRIBA).gameObject.GetComponent<RectTransform>().rect.height+180;
        float desfaseY = -100;
        float desfaseX = -150;
        float factorEscala = 0.8f;
        Transform transfButton = null;
        llenarListaDepartamentos();
        transfButton = GameObject.Find (NAME_OBJ_BUTTON_ARRIBA).gameObject.GetComponent<RectTransform>();
        lstButtonsTeamns = new List<Button>();
        int AnchoPantallasPequeñas = 1600;/// antes era 1280 pero mi xiaomi no se vio bien
        if(  widthScreen <= 1600) {
            Debug.Log ("**** cambiando size button ");
            GameObject.Find (NAME_OBJ_BUTTON_ARRIBA).gameObject.GetComponent<RectTransform>().localScale = 
            transform.localScale = new Vector3(transfButton.localScale.x*factorEscala, transfButton.localScale.y*factorEscala, transfButton.localScale.z);
            anchoBoton = anchoBoton * factorEscala*0.8f;
            altoBoton = altoBoton * factorEscala*0.8f;
        }
        int indice = 0;
        string teamEnPreference = PlayerPrefs.GetString(NAME_PREF_TEAM);
        ///// 20210302 en esta parte reseteo la preferencia de equipo para poder hacer pruebas como si fuera la primera vez q se usa la aplicacion
        /////////////////////
        teamEnPreference = null;
        PlayerPrefs.SetString( NAME_PREF_TEAM, null );
        /////////////////////
        Debug.Log (" team en preferences "+teamEnPreference);
        if( teamEnPreference == null || teamEnPreference.Equals("") ){
            for( int j = 0; j < 5; j++){
                for( int i = 0;i< 6; i++){
                        float posX = desfaseX+(i*anchoBoton); float posY = (heighScreen/2)+desfaseY+(-j*altoBoton);
                        Debug.Log ("**** iterando  para crear botones selector "+posBotonArriba.x+" quinta parte  "+quintaParte+" heighScreen "+heighScreen+" widthScreen "+widthScreen+" posX "+posX+" posY "+posY);
                        Vector3 newPos = new Vector3( posX, posY, posBotonArriba.z);
                        UnityEngine.Object newButtonEquipo = Instantiate(prefabButton, newPos ,Quaternion.identity);
                        //string nameButton = "button_"+j+"_"+i;
                        string nameButton = "button_"+lstDepartamentos[indice].getNombre();
                        string nameTeam = lstDepartamentos[indice].getNombre();
                        newButtonEquipo.name =  nameButton;
                        buttonCreado = GameObject.Find(nameButton);
                        buttonCreado.GetComponent<Transform>().SetParent(objCanvas.GetComponent<Transform>(), false);
                        buttonCreado.GetComponent<Button>().GetComponentInChildren<Text>().text = nameTeam;
                        buttonCreado.GetComponent<Button>().onClick.AddListener(() => ButtonClicked(nameTeam));
                        string nombreImagen = lstDepartamentos[indice].getNombreBandera();
                        Object  objChild = buttonCreado.gameObject.transform.GetChild(1);
                        Debug.Log ("**** name child "+objChild.name);
                        buttonCreado.gameObject.transform.GetChild(1).GetComponent<Image>().sprite = atlasDepartamentos.GetSprite(nombreImagen);  
                        if(  widthScreen <= 1280 ){
                            Debug.Log ("**** widthScreen <  1280");
                            buttonCreado.GetComponent<Transform>().localScale = new Vector3(transfButton.localScale.x*factorEscala, transfButton.localScale.y*factorEscala, transform.localScale.z);
                        } else {
                            buttonCreado.GetComponent<Transform>().localScale = new Vector3(transfButton.localScale.x*factorEscala, transfButton.localScale.y*factorEscala, transform.localScale.z);
                        }
                        indice++;
                        lstButtonsTeamns.Add(buttonCreado.GetComponent<Button>());
                        buttonCreado.gameObject.SetActive( true );
                        //_ImgTransform.SetAnchor(AnchorPresets.TopRight,-10,-10);
                        ///_ImgTransform.SetAnchor(AnchorPresets.TopRight,-10,-10);
                        //newRemote.name = sender;
                        //string nameHover =  sender.Substring(sender.Length-4);
                        //newHover.name = nameHover;
                        //remote = GameObject.Find(sender);
                        //hover =  GameObject.Find(nameHover);
                        //newButtonEquipo.GetComponent<TextMesh>().text = "guest"+nameHover;
                }
            }
        } else {
            factorEscala = 5f;
            Vector3 newPos = new Vector3( 0, 0, posBotonArriba.z);
            UnityEngine.Object newButtonEquipo = Instantiate(prefabButton, newPos ,Quaternion.identity);
            //string nameButton = "button_"+j+"_"+i;
            string nameButton = "button_"+teamEnPreference;
            string nameTeam = teamEnPreference;
            newButtonEquipo.name =  nameButton;
            buttonCreado = GameObject.Find(nameButton);
            buttonCreado.GetComponent<Transform>().SetParent(objCanvas.GetComponent<Transform>(), false);
            buttonCreado.GetComponent<Button>().GetComponentInChildren<Text>().text = nameTeam;
            transfButton = GameObject.Find (NAME_OBJ_BUTTON_ARRIBA).gameObject.GetComponent<RectTransform>();
            buttonCreado.gameObject.transform.GetChild(1).GetComponent<Image>().sprite = atlasDepartamentos.GetSprite(getImageTeamByName(teamEnPreference));
            if(  widthScreen <= 1280 ){
                buttonCreado.GetComponent<Transform>().localScale = new Vector3(transfButton.localScale.x*factorEscala, transfButton.localScale.y*factorEscala, transform.localScale.z);
            }
            buttonCreado.GetComponent<Transform>().localScale = new Vector3(transfButton.localScale.x*factorEscala, transfButton.localScale.y*factorEscala, transform.localScale.z);
            buttonCreado.GetComponent<Button>().interactable = false;
            Vector3 pos = buttonCreado.transform.position;
            pos.x = widthScreen*0.65f;
            pos.y = heighScreen/2;
            buttonCreado.GetComponent<Button>().transform.position = pos;
            //TextEscogerEquipo
            GameObject.Find (NAME_TEXT_ESCOGE_EQUIPO).gameObject.SetActive( false );
            Button buttonOK = GameObject.Find (NAME_CANVAS).GetComponent<Transform>().Find(NAME_OBJ_BUTTON_OK).GetComponent<Button>();
            buttonOK.gameObject.SetActive(true);
            buttonOK.GetComponent<Transform>().SetParent(objCanvas.GetComponent<Transform>(), false);
            int m_IndexNumber = buttonOK.GetComponent<Transform>().GetSiblingIndex();
            Debug.Log (" index number par button = " + m_IndexNumber);
            m_IndexNumber++;
            buttonOK.GetComponent<Transform>().SetSiblingIndex(m_IndexNumber);
            //buttonCreado.gameObject.SetActive( true );
        }
    }
    void ButtonClicked(string nameTeam )
    {
        Debug.Log ("Button clicked = " + nameTeam);
        escogerPrefEquipo( nameTeam );
        ocultarEquipos( nameTeam );
        Button buttonOK = GameObject.Find (NAME_CANVAS).GetComponent<Transform>().Find(NAME_OBJ_BUTTON_OK).GetComponent<Button>();
        buttonOK.gameObject.SetActive(true);
        int m_IndexNumber = buttonOK.GetComponent<Transform>().GetSiblingIndex();
        Debug.Log ("*** en buttonClicked index number par button = " + m_IndexNumber);
        //// se pone 100 para dejarlo de ultimas lejos y aparentemente no hay error por dejar un indice muy lejos de los existentes
        m_IndexNumber+=100;
        buttonOK.GetComponent<Transform>().SetSiblingIndex(m_IndexNumber);
    }
    private void escogerPrefEquipo( string nameTeam ){
        string teamEnPreference = PlayerPrefs.GetString(NAME_PREF_TEAM);
        Debug.Log (" team en preferences "+teamEnPreference);
        if( teamEnPreference == null || teamEnPreference.Equals("")){
             PlayerPrefs.SetString( NAME_PREF_TEAM,nameTeam );
        }
    }
    private void ocultarEquipos( string nameTeam ){
        float factorEscala = 5f;
        foreach( Button elBoton in lstButtonsTeamns){
            if( elBoton.GetComponentInChildren<Text>().text != nameTeam ){
                 elBoton.gameObject.SetActive( false );
            } else {
                 //elBoton.image.rectTransform.sizeDelta = new Vector2(10, 10);
                 //elBoton.GetComponent<RectTransform>().anchorMax = new Vector2(30.0f, 30.0f);
                 //elBoton.GetComponent<RectTransform>().anchorMin = new Vector2(10.0f, 10.0f);
                 Transform transfButton = GameObject.Find (NAME_OBJ_BUTTON_ARRIBA).gameObject.GetComponent<RectTransform>();
                 elBoton.GetComponent<Transform>().localScale = new Vector3(transfButton.localScale.x*factorEscala, transfButton.localScale.y*factorEscala, transform.localScale.z);
                 elBoton.interactable = false;
                 Vector3 pos = elBoton.transform.position;
                 float heighScreen = Screen.height;
                 float widthScreen = Screen.width;
                 pos.x = widthScreen*0.65f;
                 pos.y = heighScreen/2;
                 elBoton.transform.position = pos;
            }
        }
    }
    /// SceneManager.LoadScene(NOMBRE_SCENE_PRINCIPAL, LoadSceneMode.Single);
    private void llenarListaDepartamentos(){
        Departamento elDepartamento = new Departamento(NAME_AMAZONAS,1,NAME_IMG_BANDERA_AMAZONAS);
        lstDepartamentos = new List<Departamento>();
        lstDepartamentos.Add(elDepartamento);
        elDepartamento = new Departamento(NAME_ANTIOQUIA,1,NAME_IMG_BANDERA_ANTIOQUIA);
        lstDepartamentos.Add(elDepartamento);
        elDepartamento = new Departamento(NAME_ARAUCA,2, NAME_IMG_BANDERA_ARAUCA);
        lstDepartamentos.Add(elDepartamento);
        elDepartamento = new Departamento(NAME_ATLANTICO,3, NAME_IMG_BANDERA_ATLANTICO);
        lstDepartamentos.Add(elDepartamento);
        elDepartamento = new Departamento(NAME_BOGOTA,4, NAME_IMG_BANDERA_BOGOTA);
        lstDepartamentos.Add(elDepartamento);
        elDepartamento = new Departamento(NAME_BOLIVAR,5, NAME_IMG_BANDERA_BOLIVAR);
        lstDepartamentos.Add(elDepartamento);
        elDepartamento = new Departamento(NAME_BOYACA,6, NAME_IMG_BANDERA_BOYACA);
        lstDepartamentos.Add(elDepartamento);
        elDepartamento = new Departamento(NAME_CALDAS,7, NAME_IMG_BANDERA_CALDAS);
        lstDepartamentos.Add(elDepartamento);
        elDepartamento = new Departamento(NAME_CAQUETA,8, NAME_IMG_BANDERA_CAQUETA);
        lstDepartamentos.Add(elDepartamento);
        elDepartamento = new Departamento(NAME_CASANARE,9, NAME_IMG_BANDERA_CASANARE);
        lstDepartamentos.Add(elDepartamento);
        elDepartamento = new Departamento(NAME_CAUCA,10, NAME_IMG_BANDERA_CAUCA);
        lstDepartamentos.Add(elDepartamento);
        elDepartamento = new Departamento(NAME_CESAR,11, NAME_IMG_BANDERA_CESAR);
        lstDepartamentos.Add(elDepartamento);
        elDepartamento = new Departamento(NAME_CHOCO,12, NAME_IMG_BANDERA_CHOCO);
        lstDepartamentos.Add(elDepartamento);
        elDepartamento = new Departamento(NAME_CORDOBA,13, NAME_IMG_BANDERA_CORDOBA);
        lstDepartamentos.Add(elDepartamento);
        elDepartamento = new Departamento(NAME_CUNDINAMARCA,14, NAME_IMG_BANDERA_CUNDINAMARCA);
        lstDepartamentos.Add(elDepartamento);
        elDepartamento = new Departamento(NAME_GUAINIA,15, NAME_IMG_BANDERA_GUAINIA);
        lstDepartamentos.Add(elDepartamento);
        elDepartamento = new Departamento(NAME_GUAJIRA,16, NAME_IMG_BANDERA_GUAJIRA);
        lstDepartamentos.Add(elDepartamento);
        elDepartamento = new Departamento(NAME_GUAVIARE,17, NAME_IMG_BANDERA_GUAVIARE);
        lstDepartamentos.Add(elDepartamento);
        elDepartamento = new Departamento(NAME_MAGDALENA,18, NAME_IMG_BANDERA_MAGDALENA);
        lstDepartamentos.Add(elDepartamento);
        elDepartamento = new Departamento(NAME_META,19, NAME_IMG_BANDERA_META);
        lstDepartamentos.Add(elDepartamento);
        elDepartamento = new Departamento(NAME_NARINO,20, NAME_IMG_BANDERA_NARINO);
        lstDepartamentos.Add(elDepartamento);
        elDepartamento = new Departamento(NAME_NORTE_SANTANDER,21, NAME_IMG_BANDERA_NORTE_SANTANDER);
        lstDepartamentos.Add(elDepartamento);
        elDepartamento = new Departamento(NAME_PUTUMAYO,22, NAME_IMG_BANDERA_PUTUMAYO);
        lstDepartamentos.Add(elDepartamento);
        elDepartamento = new Departamento(NAME_QUINDIO,23, NAME_IMG_BANDERA_QUINDIO);
        lstDepartamentos.Add(elDepartamento);
        elDepartamento = new Departamento(NAME_RISARALDA,24, NAME_IMG_BANDERA_RISARALDA);
        lstDepartamentos.Add(elDepartamento);
        elDepartamento = new Departamento(NAME_SANTANDER,25, NAME_IMG_BANDERA_SANTANDER);
        lstDepartamentos.Add(elDepartamento);
        elDepartamento = new Departamento(NAME_SUCRE,26, NAME_IMG_BANDERA_SUCRE);
        lstDepartamentos.Add(elDepartamento);
        elDepartamento = new Departamento(NAME_TOLIMA,27, NAME_IMG_BANDERA_TOLIMA);
        lstDepartamentos.Add(elDepartamento);
        elDepartamento = new Departamento(NAME_VALLE_CAUCA, 28, NAME_IMG_BANDERA_VALLE_CAUCA);
        lstDepartamentos.Add(elDepartamento);
        elDepartamento = new Departamento(NAME_VAUPES, 29 , NAME_IMG_BANDERA_VAUPES);
        lstDepartamentos.Add(elDepartamento);
        elDepartamento = new Departamento(NAME_VICHADA, 30, NAME_IMG_BANDERA_VICHADA);
        lstDepartamentos.Add(elDepartamento);
    }
    //// 20210304 inutil tratar de traer las banderas en la pantalla cuando se escoge si departamentos o clubes de futbol porque en ese momento todavia
    //// no se han construido  las listas porque esas pantallas todavia no se han llamado
    public string getImageTeamByName(string nameTeam ){
        Debug.Log ("***  getImageTeamByName lstDepartamentos == null " +(lstDepartamentos == null));
        if( lstDepartamentos != null ){
            foreach(Departamento elDepartamento in lstDepartamentos ){
                if( elDepartamento.getNombre().Equals(nameTeam)){
                    return elDepartamento.getNombreBandera();
                }
            }
        }
        return null;
    }
    public List<Departamento> getListDepartamentos(){
        return lstDepartamentos;
    }
    /*public string getNameImgByNameDepartamento(string _nameTeam){
        for( Departamento _dep in lstede){

        }
    }*/
    // Update is called once per frame
    void Update()
    {
        
    }
    void elegirEquipo(){
         Debug.Log ("**** eligiendo equipo ");
    }
}
