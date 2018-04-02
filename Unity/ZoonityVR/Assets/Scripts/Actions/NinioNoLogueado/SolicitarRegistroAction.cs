using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolicitarRegistroAction : MonoBehaviour, Action
{
    public void Execute()
    {
        GameManager.ninioNoLogueado_Facade.SolicitarRegistro();
    }
}
