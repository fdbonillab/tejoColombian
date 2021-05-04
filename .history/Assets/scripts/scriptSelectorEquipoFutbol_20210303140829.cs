using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;


public class scriptSelectorEquipoFutbol : MonoBehaviour
{
    public Transform prefabButton;
    public SpriteAtlas atlasEquiposFutbol;
    string NAME_OBJ_BUTTON_ARRIBA = "ButtonArriba";
    string NAME_OBJ_BUTTON_ABAJO = "ButtonAbajo";
    string NAME_OBJ_BUTTON_OK = "ButtonOK";
    string NAME_CANVAS = "Canvas";
    List<Departamento> lstEquiposFutbol;
    List<Resultado> lstResultados;
    List<Button> lstButtonsTeamns;
    public static string NAME_MILLONARIOS = "Millonarios"; 
    public static string NAME_NACIONAL = "Nacional";
    public static string NAME_SANTAFE = "SantaFe";
    public static string NAME_TOLIMA = "Tolima";
    public static string NAME_AMERICA = "America";
 

public static string NAME_IMG_ESCUDO_MILLONARIOS = "millonarios";
public static string NAME_IMG_ESCUDO_NACIONAL = "nacional";
public static string NAME_IMG_ESCUDO_SANTAFE = "santafe";
public static string NAME_IMG_ESCUDO_TOLIMA = "tolima";
public static string NAME_IMG_ESCUDO_AMERICA = "america";
public static string NAME_PREF_TEAM = "PREF_TEAM";
public static string NAME_TEXT_ESCOGE_EQUIPO = "TextEscogerEquipo";

    int ID_TEAM_MILLONARIOS = 1; 
    int ID_TEAM_NACIONAL = 2;
    int ID_TEAM_SANTAFE = 3;
    int ID_TEAM_AMERICA = 4;
    int ID_TEAM_TOLIMA = 5;

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
        llenarListaEquiposFutbol();
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
        //// si no se ha escogido un equipo muestra todas las opciones, si no entonces muestra la opcion q se escogio,
        ///// aki se puede presentar un problema cuando se de la opcion de asociarse a mas de un equipo
        //// 20210303 otro tema qu surgio para acordarme cuando vuelva a dejar este codigo por varios meses
        ///// que pense que la ultima version estaba desactualizada respecto al despliegue pero no era asi loque pasaba era que cuando el equipo ya estaba
        ///// escogido el boton se veia bien del ultimas el de ok, pero cuando aun no se habia escogido equipo el boton de ok se veia retrasado con la mitad del boton
        //// escondido  detras del grupo de banderas
        if( teamEnPreference == null || teamEnPreference.Equals("") ){
            for( int j = 0; j < 5; j++){
                for( int i = 0;i< 6; i++){
                        float posX = desfaseX+(i*anchoBoton); float posY = (heighScreen/2)+desfaseY+(-j*altoBoton);
                        Debug.Log ("**** iterando  para crear botones selector "+posBotonArriba.x+" quinta parte  "+quintaParte+" heighScreen "+heighScreen+" widthScreen "+widthScreen+" posX "+posX+" posY "+posY);
                        Vector3 newPos = new Vector3( posX, posY, posBotonArriba.z);
                        UnityEngine.Object newButtonEquipo = Instantiate(prefabButton, newPos ,Quaternion.identity);
                        //string nameButton = "button_"+j+"_"+i;
                        string nameButton = "button_"+lstEquiposFutbol[indice].getNombre();
                        string nameTeam = lstEquiposFutbol[indice].getNombre();
                        newButtonEquipo.name =  nameButton;
                        buttonCreado = GameObject.Find(nameButton);
                        buttonCreado.GetComponent<Transform>().SetParent(objCanvas.GetComponent<Transform>(), false);
                        buttonCreado.GetComponent<Button>().GetComponentInChildren<Text>().text = nameTeam;
                        buttonCreado.GetComponent<Button>().onClick.AddListener(() => ButtonClicked(nameTeam));
                        string nombreImagen = lstEquiposFutbol[indice].getNombreBandera();
                        Object  objChild = buttonCreado.gameObject.transform.GetChild(1);
                        Debug.Log ("**** name child "+objChild.name);
                        buttonCreado.gameObject.transform.GetChild(1).GetComponent<Image>().sprite = atlasEquiposFutbol.GetSprite(nombreImagen);  
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
            buttonCreado.gameObject.transform.GetChild(1).GetComponent<Image>().sprite = atlasEquiposFutbol.GetSprite(getImageTeamByName(teamEnPreference));
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
        Debug.Log (" index number par button = " + m_IndexNumber);
        m_IndexNumber++;
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
    private void llenarListaEquiposFutbol(){
        Departamento elDepartamento = new Departamento(NAME_MILLONARIOS,1,NAME_IMG_ESCUDO_MILLONARIOS);
        lstEquiposFutbol = new List<Departamento>();
        lstEquiposFutbol.Add(elDepartamento);
        elDepartamento = new Departamento(NAME_NACIONAL,2,NAME_IMG_ESCUDO_NACIONAL);
        lstEquiposFutbol.Add(elDepartamento);
        elDepartamento = new Departamento(NAME_SANTAFE,3, NAME_IMG_ESCUDO_SANTAFE);
        lstEquiposFutbol.Add(elDepartamento);
        elDepartamento = new Departamento(NAME_AMERICA,4, NAME_IMG_ESCUDO_AMERICA);
        lstEquiposFutbol.Add(elDepartamento);
        elDepartamento = new Departamento(NAME_TOLIMA,5, NAME_IMG_ESCUDO_TOLIMA);
        lstEquiposFutbol.Add(elDepartamento);
    }
    private string getImageTeamByName(string nameTeam ){
        foreach(Departamento elDepartamento in lstEquiposFutbol ){
            if( elDepartamento.getNombre().Equals(nameTeam)){
                return elDepartamento.getNombreBandera();
            }
        }
        return null;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void elegirEquipo(){
         Debug.Log ("**** eligiendo equipo ");
    }
}
