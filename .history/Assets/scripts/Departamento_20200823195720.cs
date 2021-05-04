using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Departamento
{
    string nombre;
    string nombreBandera;
    int indiceSprite;
    public Departamento( string elNombre, int elIndiceSprite ){
        nombre = elNombre; indiceSprite = elIndiceSprite;
    }
    public Departamento( string elNombre, int elIndiceSprite, string elNombreBandera ){
        nombre = elNombre; indiceSprite = elIndiceSprite; nombreBandera = elNombreBandera;
    }
    public string getNombre(){
        return nombre;
    }
    public string getNombreImagen(){
        return nombreBandera;
    }
}
