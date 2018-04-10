using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolicitarInicioSesionAction : MonoBehaviour, IAction
{
    public void Execute()
    {
        GameManager.ninioNoLogueado_Facade.SolicitarInicioSesion();
    }
}
