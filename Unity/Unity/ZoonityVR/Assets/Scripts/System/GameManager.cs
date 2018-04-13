using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    // Instancia de la fachada NinioNoLogueado_Facade
    public static NinioNoLogueado_Facade ninioNoLogueado_Facade = new NinioNoLogueado_Facade();
    // Instancia de la fachada NinioLogueado_Facade
    public static NinioLogueado_Facade ninioLogueado_Facade = new NinioLogueado_Facade();
    // Instancia de la fachada NPC_Facade
    public static NPC_Facade npc_Facade = new NPC_Facade();

    // Determina si el jugador en este momento se mueve o no
    public static bool movimiento;

    // Nombre del jugador a recordar
    public static string nombreJugador;
    // Clave del PlayerPref que recuerda el nombre del jugador
    public const string NOMBRE_JUGADOR = "NOMBRE";
    // Constante con la URL de la Web API que devuelve el nombre en caso de que exista, sino, una cadena vacia
    public const string WEB_API_GET_JUGADOR = "http://{0}/ZoonityVR/api/ZoonityVR/GetPlayerName?name={1}";
}
