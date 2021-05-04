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
    string NAME_CANVAS = "Canvas";
    List<Departamento> lstDepartamentos;
    List<Resultado> lstResultados;
    string NAME_AMAZONAS = "Amazonas"; 
    string NAME_ANTIOQUIA = "Antioquia";
    string NAME_ARAUCA = "Arauca";
    string NAME_ATLANTICO = "Atlántico";
    string NAME_BOGOTA = "Bogotá";
    string NAME_BOLIVAR = "Bolívar";
    string NAME_BOYACA = "Boyacá";
    string NAME_CALDAS = "Caldas";
    string NAME_CAQUETA = "Caquetá";
    string NAME_CASANARE = "Casanare";
    string NAME_CAUCA = "Cauca";
    string NAME_CESAR = "Cesar";
    string NAME_CHOCO = "Chocó";
    string NAME_CORDOBA = "Córdoba";
    string NAME_CUNDINAMARCA = "Cundinamarca";
    string NAME_GUAINIA = "Guainía";
    string NAME_GUAVIARE = "Guaviare";
    string NAME_GUAJIRA = "Guajira";
    string NAME_MAGDALENA = "Magdalena";
    string NAME_META = "Meta";
    string NAME_NARINO = "Nariño";
    string NAME_NORTE_SANTANDER = "Norte de Santander";
    string NAME_PUTUMAYO = "Putumayo";
    string NAME_QUINDIO = "Quindío";
    string NAME_RISARALDA = "Risaralda";
    string NAME_SANTANDER = "Santander";
    string NAME_SUCRE = "Sucre";
    string NAME_TOLIMA = "Tolima";
    string NAME_VALLE_CAUCA = "Valle del Cauca";
    string NAME_VAUPES = "Vaupés";
    string NAME_VICHADA = "Vichada";

string NAME_IMG_BANDERA_BOGOTA = "100px-Flag_of_Bogotá.svg";
string NAME_IMG_BANDERA_GUAJIRA = "100px-Flag_of_La_Guajira.svg";
string NAME_IMG_BANDERA_MAGDALENA = "100px-Flag_of_Magdalena.svg";
string NAME_IMG_BANDERA_META = "100px-Flag_of_Meta.svg";
string NAME_IMG_BANDERA_NARINO = "100px-Flag_of_Nariño.svg";
string NAME_IMG_BANDERA_NORTE_SANTANDER = "100px-Flag_of_Norte_de_Santander.svg";
string NAME_IMG_BANDERA_PUTUMAYO = "100px-Flag_of_Putumayo.svg";
string NAME_IMG_BANDERA_QUINDIO = "100px-Flag_of_Quindío.svg";
string NAME_IMG_BANDERA_RISARALDA = "100px-Flag_of_Risaralda.svg";
string NAME_IMG_BANDERA_SANTANDER = "100px-Flag_of_Santander_(Colombia).svg";
string NAME_IMG_BANDERA_TOLIMA = "100px-Flag_of_Tolima.svg";
string NAME_IMG_BANDERA_VALLE_CAUCA = "100px-Flag_of_Valle_del_Cauca.svg";
string NAME_IMG_BANDERA_VAUPES = "100px-Flag_of_Vaupés.svg";
string NAME_IMG_BANDERA_VICHADA = "100px-Flag_of_Vichada.svg";
string NAME_IMG_BANDERA_ARAUCA = "150px-Flag_of_Arauca.svg";
string NAME_IMG_BANDERA_ATLANTICO = "150px-Flag_of_Atlántico.svg";
string NAME_IMG_BANDERA_BOLIVAR = "150px-Flag_of_Bolívar_(Colombia).svg";
string NAME_IMG_BANDERA_CALDAS = "150px-Flag_of_Caldas.svg";
string NAME_IMG_BANDERA_CAQUETA = "150px-Flag_of_Caquetá.svg";
string NAME_IMG_BANDERA_CASANARE = "150px-Flag_of_Casanare.svg";
string NAME_IMG_BANDERA_CAUCA = "150px-Flag_of_Cauca.svg";
string NAME_IMG_BANDERA_CESAR = "150px-Flag_of_Cesar.svg";
string NAME_IMG_BANDERA_CHOCO = "150px-Flag_of_Chocó.svg";
string NAME_IMG_BANDERA_CORDOBA = "150px-Flag_of_Córdoba.svg";
string NAME_IMG_BANDERA_GUAINIA = "150px-Flag_of_Guainía.svg";
string NAME_IMG_BANDERA_GUAVIARE = "150px-Flag_of_Guaviare.svg";
string NAME_IMG_BANDERA_HUILA = "150px-Flag_of_Huila.svg";
string NAME_IMG_BANDERA_AMAZONAS = "Flag_of_Amazonas_(Colombia).svg";
string NAME_IMG_BANDERA_ANTIOQUIA = "Flag_of_Antioquia_Department.svg";
string NAME_IMG_BANDERA_BOYACA = "Flag_of_Boyacá_Department.svg";
string NAME_IMG_BANDERA_CUNDINAMARCA = "Flag_of_Cundinamarca.svg";
string NAME_IMG_BANDERA_SAN_ANDRES = "Flag_of_San_Andrés_y_Providencia.svg";
string NAME_IMG_BANDERA_SUCRE = "Flag_of_Sucre_(Colombia).svg";

    int ID_TEAM_AMAZONAS = 1; 
    string ID_TEAM_ANTIOQUIA = 2;
    string ID_TEAM_ARAUCA = 3;
    string ID_TEAM_ATLANTICO = 4;
    string ID_TEAM_BOGOTA = 5;
    string ID_TEAM_BOLIVAR = 6;
    string ID_TEAM_BOYACA = 7;
    string ID_TEAM_CALDAS = 8;
    string ID_TEAM_CAQUETA = 9;
    string ID_TEAM_CASANARE = 10;
    string ID_TEAM_CAUCA = 11;
    string ID_TEAM_CESAR = 12;
    string ID_TEAM_CHOCO = 13;
    string ID_TEAM_CORDOBA = 14;
    string ID_TEAM_CUNDINAMARCA = 15;
    string ID_TEAM_GUAINIA = 16;
    string ID_TEAM_GUAVIARE = 17;
    string ID_TEAM_GUAJIRA = 18;
    string ID_TEAM_MAGDALENA = 19;
    string ID_TEAM_META = 20;
    string ID_TEAM_NARINO = 21;
    string ID_TEAM_NORTE_SANTANDER = 22;
    string ID_TEAM_PUTUMAYO = 23;
    string ID_TEAM_QUINDIO = 24;
    string ID_TEAM_RISARALDA = 25;
    string ID_TEAM_SANTANDER = 26;
    string ID_TEAM_SUCRE = 27;
    string ID_TEAM_TOLIMA = 28;
    string ID_TEAM_VALLE_CAUCA = 29;
    string ID_TEAM_VAUPES = 30;
    string ID_TEAM_VICHADA = 31;

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
        if(  widthScreen <= 1280) {
            Debug.Log ("**** cambiando size button ");
            transfButton = GameObject.Find (NAME_OBJ_BUTTON_ARRIBA).gameObject.GetComponent<RectTransform>();
            GameObject.Find (NAME_OBJ_BUTTON_ARRIBA).gameObject.GetComponent<RectTransform>().localScale = 
            transform.localScale = new Vector3(transfButton.localScale.x*factorEscala, transfButton.localScale.y*factorEscala, transfButton.localScale.z);
            anchoBoton = anchoBoton * factorEscala*0.8f;
            altoBoton = altoBoton * factorEscala*0.8f;
        }
        int indice = 0;
        for( int j = 0; j < 5; j++){
            for( int i = 0;i< 6; i++){
                    float posX = desfaseX+(i*anchoBoton); float posY = (heighScreen/2)+desfaseY+(-j*altoBoton);
                    Debug.Log ("**** iterando  para crear botones selector "+posBotonArriba.x+" quinta parte  "+quintaParte+" heighScreen "+heighScreen+" posX "+posX+" posY "+posY);
                    Vector3 newPos = new Vector3( posX, posY, posBotonArriba.z);
                    UnityEngine.Object newButtonEquipo = Instantiate(prefabButton, newPos ,Quaternion.identity);
                    string name = "button_"+j+"_"+i;
                    newButtonEquipo.name =  name;
                    buttonCreado = GameObject.Find(name);
                    buttonCreado.GetComponent<Transform>().SetParent(objCanvas.GetComponent<Transform>(), false);
                    buttonCreado.GetComponent<Button>().GetComponentInChildren<Text>().text = lstDepartamentos[indice].getNombre();
                    string nombreImagen = lstDepartamentos[indice].getNombreBandera();
                    Object  objChild = buttonCreado.gameObject.transform.GetChild(1);
                    Debug.Log ("**** name child "+objChild.name);
                    buttonCreado.gameObject.transform.GetChild(1).GetComponent<Image>().sprite = atlasDepartamentos.GetSprite(nombreImagen);
                    if(  widthScreen <= 1280 ){
                        buttonCreado.GetComponent<Transform>().localScale =  transform.localScale = new Vector3(transfButton.localScale.x*factorEscala, transfButton.localScale.y*factorEscala, transform.localScale.z);
                    }
                    indice++;
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
    }
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
    // Update is called once per frame
    void Update()
    {
        
    }

}
