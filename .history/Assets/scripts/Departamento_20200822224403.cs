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
}
