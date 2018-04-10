using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SolicitarRecordarSesionAction : MonoBehaviour, IAction
{
    Toggle recordar;
    Text nombre;

    public SolicitarRecordarSesionAction(Toggle recordar, Text nombre)
    {
        this.recordar = recordar;
        this.nombre = nombre;
    }

    public void Execute()
    {
        GameManager.ninioNoLogueado_Facade.SolicitarRecordarSesion(recordar, nombre);
    }
}
