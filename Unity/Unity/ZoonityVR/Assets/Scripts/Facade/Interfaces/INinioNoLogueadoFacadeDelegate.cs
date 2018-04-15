using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface INinioNoLogueadoFacadeDelegate
{
    void SolicitarInicioSesion();
    void ConfirmarInicioSesion(Text nombre, GameObject error);
    void SolicitarRecordarSesion(Toggle recordar, Text nombre);
    void ConfirmarRegistro(Text nombre, GameObject error);
    void SolicitarRegistro();
    void VolverAtras();
}

