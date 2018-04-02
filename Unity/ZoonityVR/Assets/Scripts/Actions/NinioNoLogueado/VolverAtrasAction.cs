using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolverAtrasAction : MonoBehaviour, Action
{

    public void Execute()
    {
        GameManager.ninioNoLogueado_Facade.VolverAtras();
    }

}
