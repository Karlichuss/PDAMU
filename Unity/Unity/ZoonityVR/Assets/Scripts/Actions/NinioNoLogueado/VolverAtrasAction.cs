using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class VolverAtrasAction : MonoBehaviour, IAction
{
    

    public void Execute()
    {
        GameManager.ninioNoLogueado_Facade.VolverAtras();
    }



}
