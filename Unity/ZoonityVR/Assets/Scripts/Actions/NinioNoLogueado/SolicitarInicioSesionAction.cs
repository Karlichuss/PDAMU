using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolicitarInicioSesionAction : MonoBehaviour, Action
{
    public void Execute()
    {
        GameManager.ninioNoLogueado_Facade.SolicitarInicioSesion();
    }
}
