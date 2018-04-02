using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NinioNoLogueado_Facade : MonoBehaviour, NinioNoLogueadoFacadeDelegate
{
    #region AbrirFormularioLogin
    /// <summary>
    /// El usuario ha decidido pulsar el boton de iniciar sesión y se debe cargar la escena del 
    /// formulario de inicio de sesión.
    /// </summary>
    public void SolicitarInicioSesion()
    {
        MostrarFormularioInicioSesion();
    }
    /// <summary>
    /// Carga la escena que contiene el formulario de logueo.
    /// </summary>
    public void MostrarFormularioInicioSesion()
    {
        SceneManager.LoadScene("Login");
    }
    #endregion
    #region AbrirLobby
    /// <summary>
    /// Carga la escena lobby.
    /// </summary>
    public void CargarLobby()
    {
        SceneManager.LoadScene("Lobby");
    }
    #endregion
    #region AbrirFormularioRegistro
    /// <summary>
    /// El usuario inicia el proceso de cambio de escena. Ha pulsado el boton registrarse del menú principal.
    /// </summary>
    public void SolicitarRegistro()
    {
        MostrarFormularioRegistro();
    }
    /// <summary>
    /// Carga la escena que contiene el formulario de Registro.
    /// </summary>
    public void MostrarFormularioRegistro()
    {
        SceneManager.LoadScene("Registro");
    }
    #endregion
    #region AbrirMenuPrincipal
    /// <summary>
    /// El usuario puede volver atras desde la escena de registro de usuario o de inicio de sesión.
    /// Aquí comienza el proceso.
    /// </summary>
    public void VolverAtras()
    {
        CargarMenuPrincipal();
    }
    /// <summary>
    /// Carga la escena que contiene el boton de iniciar sesión o registrarse.
    /// </summary>
    public void CargarMenuPrincipal()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
    #endregion
    #region ProcesoLogin
    // Boleano que indica si es valido o no el nombre escrito por el usuario
    bool valido = false;
    /// <summary>
    /// Comienza el proceso de logueo que el usuario ha iniciado.
    /// </summary>
    /// <param name="nombre">Referencia al campo de texto que rellena el usuario con su nombre-nick.</param>
    /// <param name="error">Texto que indica un error en rojo o se oculta si este no existe.</param>
    public void ConfirmarInicioSesion(Text nombre, GameObject error)
    {
        EnviarFormularioInicioSesion(nombre, error);
    }
    /// <summary>
    /// Proceso de Logueo con el oportuno control de errores.
    /// </summary>
    /// <param name="nombre">Referencia al campo de texto que rellena el usuario con su nombre-nick.</param>
    /// <param name="error">Texto que indica un error en rojo o se oculta si este no existe.</param>
    public void EnviarFormularioInicioSesion(Text nombre, GameObject error)
    {
        /// Reseteamos el campo de errores.
        OcultarError(error);
        /// Se comprueba que el nombre no esta vacio. Si esta vacio se muestra el mensaje de error en la pantalla,
        /// sino se intenta iniciar sesión.
        if (string.IsNullOrEmpty(nombre.text))
        {
            MostrarError(error, "error");
        }
        else
        {
            OcultarError(error);
            if (ValidarContenidoInicioSesion(nombre))
            {
                CargarLobby();
            }
            else
            {
                MostrarError(error, "Error");
            }
        }
    }

    /// <summary>
    /// Inicia la corutina que determinara si el nombre que el usuario ha escrito existe o no.
    /// </summary>
    /// <param name="nombre">Nombre-nick que ha introducido el usuario.</param>
    /// <returns></returns>
    private bool ValidarContenidoInicioSesion(Text nombre)
    {
        StartCoroutine(ComprobarInicioSesion(nombre));

        return valido;
    }

    /// <summary>
    /// Corutina que hace una consulta a la web API para saber si existe o no un usuario con el nombre indicado.
    /// </summary>
    /// <param name="nombre">Nombre-nick que ha introducido el usuario.</param>
    /// <returns>Devuelve el control a Unity.</returns>
    /// <remarks>
    /// Si el nombre-nick existe en la Web API se indica en "valido" que si existe sino se indica que no.
    /// </remarks>
    IEnumerator ComprobarInicioSesion(Text nombre)
    {
        // Preparamos la petición a la WebAPI
        using (UnityWebRequest www = UnityWebRequest.Get(
            Uri.EscapeUriString(string.Format(GameManager.WEB_API_GET_JUGADOR, nombre.text))))
        {
            // Hace la petición a la WebAPI
            yield return www.SendWebRequest();
            string result = www.downloadHandler.text;

            // Si no existe el usuario
            if (result.Equals("\"\""))
            {
                valido = false;
            }
            // Si existe el usuario
            else if (result.Length > 0)
            {
                valido = true;
            }
        }
    }
    #endregion
    #region ProcesoRegistro
    // Boleano que indica si es valido o no el nombre escrito por el usuario
    bool registroValido = false;
    /// <summary>
    /// El usuario ha iniciado el proceso de registro.
    /// </summary>
    /// <param name="nombre">Referencia al campo de texto que rellena el usuario con el nombre-nick que desea utilizar.</param>
    /// <param name="error">Texto que indica un error en rojo o se oculta si este no existe.</param>
    public void ConfirmarRegistro(Text nombre, GameObject error)
    {
        EnviarFormularioRegistro(nombre, error);
    }
    /// <summary>
    /// Proceso de registro con el oportuno control de errores.
    /// </summary>
    /// <param name="nombre">Referencia al campo de texto que rellena el usuario con el nombre-nick que desea utilizar.</param>
    /// <param name="error">Texto que indica un error en rojo o se oculta si este no existe.</param>
    public void EnviarFormularioRegistro(Text nombre, GameObject error)
    {
        /// Reseteamos el campo de errores.
        OcultarError(error);
        /// Se comprueba que el nombre no esta vacio. Si esta vacio se muestra el mensaje de error en la pantalla,
        /// sino se intenta iniciar sesión.
        if (string.IsNullOrEmpty(nombre.text))
        {
            MostrarError(error, "error");
        }
        else
        {
            OcultarError(error);
            if (ValidarContenidoRegistro(nombre))
            {
                CargarLobby();
            }
            else
            {
                MostrarError(error, "Error");
            }
        }
    }

    /// <summary>
    /// Inicia la corutina que determinara si el nombre que el usuario ha escrito existe o no.
    /// </summary>
    /// <param name="nombre">Nombre-nick que ha introducido el usuario.</param>
    /// <returns></returns>
    private bool ValidarContenidoRegistro(Text nombre)
    {
        StartCoroutine(ComprobarRegistro(nombre));

        return registroValido;
    }

    /// <summary>
    /// Corutina que hace una consulta a la web API para saber si existe o no un usuario con el nombre indicado.
    /// </summary>
    /// <param name="nombre">Nombre-nick que ha introducido el usuario.</param>
    /// <returns>Devuelve el control a Unity.</returns>
    /// <remarks>
    /// Si el nombre-nick existe en la Web API se indica en "registroValido" que si existe sino se indica que no para proceder con la insercioón del
    /// nuevo usuario en la Web API.
    /// </remarks>
    IEnumerator ComprobarRegistro(Text nombre)
    {
        // Preparamos la petición a la WebAPI
        using (UnityWebRequest www = UnityWebRequest.Get(
            Uri.EscapeUriString(string.Format(GameManager.WEB_API_GET_JUGADOR, nombre.text))))
        {
            // Hace la petición a la WebAPI
            yield return www.SendWebRequest();
            string result = www.downloadHandler.text;

            // Si no existe el usuario
            if (result.Equals("\"\""))
            {
                registroValido = false;
            }
            // Si existe el usuario
            else if (result.Length > 0)
            {
                registroValido = true;
            }
        }
    }
    #endregion
    #region ControlErrores
    /// <summary>
    /// Modifica el texto en la escena y lo hace visible.
    /// </summary>
    /// <param name="mensaje">Mensaje a mostrar en el texto.</param>
    /// <param name="error">Mensaje de error que se muestra en rojo.</param>
    private void MostrarError(GameObject error, string mensaje)
    {
        error.GetComponentInChildren<Text>().text = mensaje;
        error.SetActive(true);
    }

    /// <summary>
    /// Oculta el posible error mostrado.
    /// </summary>
    /// <param name="error">Mensaje de error que se muestra en rojo.</param>
    private void OcultarError(GameObject error)
    {
        error.SetActive(false);
    }
    #endregion
    #region RecordarNombreNick
    /// <summary>
    /// Se comprueba si el usuario quiere almacenar la contrasenia o no y se hace.
    /// </summary>
    /// <param name="nombre">Referencia al campo de texto que rellena el usuario con su nombre-nick.</param>
    /// <param name="recordar">Referencia al elemento que el usuario puede activar 
    /// o desactivar para indicar si quiere o no que el juego almacene su nombre-nick</param>
    public void SolicitarRecordarSesion(Toggle recordar, Text nombre)
    {
        RecordarNombre(recordar, nombre);
    }
    /// <summary>
    /// Si el jugador le dio a recordar su nombre-nick lo almacenamos en el playerPref sino se olvida.
    /// Este método se ejecuta cuando el usuario hace click en el boton "Iniciar sesión".
    /// </summary>
    /// <param name="nombre">Referencia al campo de texto que rellena el usuario con su nombre-nick.</param>
    /// <param name="recordar">Referencia al elemento que el usuario puede activar 
    /// o desactivar para indicar si quiere o no que el juego almacene su nombre-nick</param>
    public void RecordarNombre(Toggle recordar, Text nombre)
    {
        if (!recordar.isOn)
        {
            ActualizarPlayerPref(string.Empty);
        }
        else
        {
            ActualizarPlayerPref(nombre.text);
        }
    }

    /// <summary>
    /// Actualiza el Playerpref del nombre del jugador.
    /// </summary>
    /// <param name="nombreJugador"> Recibe el nombre del jugador si se marco la casilla recordar sino se queda vacio.</param>
    public void ActualizarPlayerPref(string nombreJugador)
    {
        GameManager.nombreJugaador = nombreJugador;
        PlayerPrefs.SetString(GameManager.NOMBRE_JUGADOR, GameManager.nombreJugaador);
    }
    #endregion
}
