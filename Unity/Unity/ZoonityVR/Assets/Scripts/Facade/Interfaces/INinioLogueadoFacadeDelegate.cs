using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface INinioLogueadoFacadeDelegate {

    void SalirArea();
    void EntrarArea(String scene);
    void SalirZoo();
    void CerrarSesion();
    void ActivarSonido(Image sonidoSi, Image sonidoNo, Text texto);
    void DesactivarSonido(Image sonidoSi, Image sonidoNo, Text texto);
    void CargarMenu(GameObject jugador, GameObject menu);
    void Reanudar(GameObject jugador, GameObject menu);
    void Caminar();
    void AlmacenarObjeto(GameObject objeto, Text contador);
    void Saltar();
    void DarObjetos(Text contador);
    void EmpezarConversacion(List<String> conversacion, Text dialogo, GameObject jugador);
    void SeguirConversacion(List<String> conversacion, int posicion, Text dialogo);
    void CerrarConversacion(GameObject jugador, Text dialogo);
    void MirarAnimalObjeto();
    void DejarDeMirarAnimalObjeto();
}
