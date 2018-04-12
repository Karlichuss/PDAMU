using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NinioLogueado_Facade : MonoBehaviour
{
    #region SalirArea
    /// <summary>
    /// Se carga la escena Lobby donde el usuario puede volver a entrar a un área si quiere.
    /// </summary>
    public void SalirArea()
    {
        CargarLobby();
    }

    /// <summary>
    /// Se hace un cambioi de escena a Lobby.
    /// </summary>
    private void CargarLobby()
    {
        SceneManager.LoadScene("Lobby");
    }
    #endregion
    #region EntrarArea
    /// <summary>
    /// El jugador ha elegido un camino del lobby y se carga la escena correspondiente al camino.
    /// </summary>
    /// <param name="scene">Scena a cargar.</param>
    public void EntrarArea(String scene)
    {
        CargarArea(scene);
    }

    /// <summary>
    /// Se carga la escena con nombre que recive por parámetro.
    /// </summary>
    /// <param name="scene">Scena a cargar.</param>
    private void CargarArea(String scene)
    {
        SceneManager.LoadScene(scene);
    }
    #endregion
    #region SalirZoo
    /// <summary>
    /// El usuario elige salir del zoo, luego se carga la escena primaria del juego.
    /// </summary>
    public void SalirZoo()
    {
        CargarEscenaMenuPrincipal();
    }

    /// <summary>
    /// Se carga la escena principal.
    /// </summary>
    private void CargarEscenaMenuPrincipal()
    {
        SceneManager.LoadScene("PrincipalMenu");
    }
    #endregion
    #region CerrarSesión
    /// <summary>
    /// El usuario a elegido cerrar la sesión desde el menu de pausa en el lobby o el area, 
    /// esto le lleva a la pantalla incial de la aplicación.
    /// </summary>
    public void CerrarSesion()
    {
        CargarEscenaMenuPrincipal();
    }
    #endregion
    #region ActivarSonido
    /// <summary>
    /// Cambia el icono de sonido y las letras. Se activa el volumen en la aplicación.
    /// </summary>
    public void ActivarSonido(Image sonidoSi, Image sonidoNo, Text texto)
    {
        sonidoSi.gameObject.SetActive(true);
        sonidoNo.gameObject.SetActive(false);
        texto.text = "";
        //ActivarSonido grobal de la aplicación
    }
    #endregion
    #region DesactivarSonido
    /// <summary>
    /// Cambia el icono de sonido y las letras. Se activa el volumen en la aplicación.
    /// </summary>
    public void DesactivarSonido(Image sonidoSi, Image sonidoNo, Text texto)
    {
        sonidoSi.gameObject.SetActive(false);
        sonidoNo.gameObject.SetActive(true);
        texto.text = "";
        //DesactivarSonido grobal de la aplicación
    }
    #endregion
    #region CargarMenú
    /// <summary>
    /// Se activa el menú de pausa justo delante de la vista del jugador.
    /// </summary>
    /// <param name="jugador"> Jugador del que obtenemos la posición.</param>
    /// <param name="menu"> Menú pausa que tenemos que posicionar.</param>
    /// <remarks>
    /// Aparece menú, Bloquea movimiento del jugador.
    /// </remarks>
    public void CargarMenu(GameObject jugador, GameObject menu)
    {
        menu.SetActive(true);
        menu.transform.position = jugador.transform.position;
        //Determinar la distancia a la que va a salir el menu de la vista del jugador.

        BloquearMovimiento(jugador);
    }

    /// <summary>
    /// Mientras el usuario esta en el menú pausa no se puede desplazar en ningun sentido.
    /// </summary>
    /// <param name="jugador"> Jugador al que bloquear el movimiento.</param>
    private void BloquearMovimiento(GameObject jugador)
    {
        GameManager.movimiento = false;
    }
    #endregion
    #region Reanudar
    /// <summary>
    /// El usuario ha pulsado reanudar en el botón del menu pausa.
    /// </summary>
    /// <param name="jugador"> Jugador al que le damos movimiento.</param>
    /// <param name="menu"> Menú que debe desaparecer.</param>
    /// <remarks>
    /// Desaparece el menú y se le devuelve la opción de moverse al jugador.
    /// </remarks>
    public void Reanudar(GameObject jugador, GameObject menu)
    {
        menu.SetActive(false);
        DesbloquearMovimiento(jugador);
    }

    /// <summary>
    /// Una vez el jugador sale del menú pausa, este debe poder moverse en cualquier dirección.
    /// </summary>
    /// <param name="jugador"> Jugador al que desbloquear el movimiento.</param>
    private void DesbloquearMovimiento(GameObject jugador)
    {
        GameManager.movimiento = true;
    }
    #endregion
    #region AlmacenarObjeto
    /// <summary>
    /// Este evento es lanzado cuando el usuario hace click sobre un objeto interactivo.
    /// </summary>
    /// <remarks>
    /// Se incrementa el contador, se desactiva el objeto en pantalla.
    /// </remarks>
    /// <param name="objeto">Objeto sobre el que el usario a hecho click.</param>
    /// <param name="contador">GameObject que muestra cuantos objetos hay.</param>
    public void AlmacenarObjeto(GameObject objeto, Text contador)
    {
        objeto.SetActive(false);
        contador.gameObject.SetActive(true);
        if (contador.text == string.Empty)
        {
            contador.text = "0";
        }
        contador.text = String.Format("{0}", (Int32.Parse(contador.text) + 1));
    }
    #endregion
    #region DarObjetos
    /// <summary>
    /// Este evento es lanzado cuando el usuario hace click sobre un objeto que pueda recibir objetos.
    /// </summary>
    /// <remarks>
    /// Se pone el contador a cero.
    /// </remarks>
    /// <param name="contador">GameObject que muestra cuantos objetos hay.</param>
    public void DarObjetos(Text contador)
    {
        contador.text = string.Empty;
        contador.gameObject.SetActive(false);
    }
    #endregion
    #region SeguirConversación
    /// <summary>
    /// Este evento es lanzado cuando el usuario hace click sobre el boton Siguiente 
    /// </summary>
    /// <param name="conversacion"></param>
    /// <param name="posicion"></param>
    /// <param name="dialogo"></param>
    public void SeguirConversacion(List<string> conversacion, int posicion, Text dialogo)
    {
        if (posicion < conversacion.Capacity)
        {
            dialogo.text = conversacion[posicion];
        }
    }
    #endregion
    #region Empezar Conversación
    /// <summary>
    /// Si un NPC tiene hover y el niño hace clic sobre el comienza la conversación.
    /// </summary>
    /// <remarks>
    /// Se bloquea el movimiento del jugador y se carga el primer bloque de texto.
    /// </remarks>
    /// <param name="conversacion">Conversación completa del NPC</param>
    /// <param name="dialogo">Texto que va a mostrar el bloque de diálogo</param>
    /// <param name="jugador">Avatar del niño</param>
    public void EmpezarConversacion(List<string> conversacion, Text dialogo, GameObject jugador)
    {
        dialogo.gameObject.SetActive(true);
        dialogo.text = conversacion[0];
        BloquearMovimiento(jugador);
    }
    #endregion
    #region CerrarConversación
    /// <summary>
    /// Cuando se han cargado ya todos los bloques de dialogo, el último ofrece la opción de cerrar el dialogo
    /// </summary>
    /// <param name="dialogo">Texto que va a mostrar el bloque de diálogo</param>
    /// <param name="jugador">Avatar del niño</param>
    public void CerrarConversacion(GameObject jugador, Text dialogo)
    {
        dialogo.gameObject.SetActive(false);
        DesbloquearMovimiento(jugador);
    }
    #endregion
}

