using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmarInicioSesionAction : MonoBehaviour, IAction
{
    Text nombre;
    GameObject error;

    public ConfirmarInicioSesionAction(Text nombre, GameObject error)
    {
        this.nombre = nombre;
        this.error = error;
    }

    public void Execute()
    {
        GameManager.ninioNoLogueado_Facade.ConfirmarInicioSesion(nombre, error);
    }
}
