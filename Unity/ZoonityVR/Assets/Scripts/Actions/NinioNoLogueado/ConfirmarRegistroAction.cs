using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmarRegistroAction : MonoBehaviour, Action
{
    Text nombre;
    GameObject error;

    public ConfirmarRegistroAction(Text nombre, GameObject error)
    {
        this.nombre = nombre;
        this.error = error;
    }

    public void Execute()
    {
        GameManager.ninioNoLogueado_Facade.ConfirmarRegistro(nombre, error);
    }
}
