using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface NinioLogueadoFacadeDelegate {

    void SalirArea();
    void EntrarArea();
    void SalirZoo();
    void CerrarSesion();
    void AcrivarSonido();
    void DesactivarSonido();
    void CargarMenu();
    void Reanudar();
    void Caminar();
    void AlmacenarObjeto();
    void Saltar();
    void DarObjetos();
    void SeguirConversacion();
    void EmpezarConversación();
    void CerrarConversacion();
    void MirarAnimalObjeto();
    void DejarDeMirarAnimalObjeto();
}
