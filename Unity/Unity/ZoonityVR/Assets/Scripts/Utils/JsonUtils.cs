using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class JsonUtils
{

    static public PrincipalMenu DeserializePrincipalMenu()
    {
        PrincipalMenu registrar;
        string ruta = "/Text/es/RegistrarseMenu.json";
        string json = "";
        string rutaJson = Application.streamingAssetsPath + ruta;

        json = File.ReadAllText(rutaJson);
        registrar = (PrincipalMenu)JsonUtility.FromJson(json, typeof(PrincipalMenu));
        return registrar;
    }

    static public IniciarSesionMenu DeserializeIniciarSesionMenu()
    {
        IniciarSesionMenu registrar;
        string ruta = "/Text/es/IniciarSesionMenu.json";
        string json = "";
        string rutaJson = Application.streamingAssetsPath + ruta;

        json = File.ReadAllText(rutaJson);
        registrar = (IniciarSesionMenu)JsonUtility.FromJson(json, typeof(IniciarSesionMenu));
        return registrar;
    }

    static public RegistrarseMenu DeserializeRegistrarseMenu()
    {
        RegistrarseMenu registrar;
        string ruta = "/Text/es/PrincipalMenu.json";
        string json = "";
        string rutaJson = Application.streamingAssetsPath + ruta;

        json = File.ReadAllText(rutaJson);
        registrar = (RegistrarseMenu)JsonUtility.FromJson(json, typeof(RegistrarseMenu));
        return registrar;
    }

    [Serializable]
    public class PrincipalMenu
    {
        public string titulo;
        public string iniciarSesionButton;
        public string registrarseButton;
    }

    [Serializable]
    public class IniciarSesionMenu
    {
        public string titulo;
        public string placeHolder;
        public string iniciarSesionButton;
        public string vacio;
        public string nombreIncorrecto;
    }

    [Serializable]
    public class RegistrarseMenu
    {
        public string titulo;
        public string placeHolder;
        public string registrarseButton;
        public string vacio;
        public string nombreIncorrecto;
    }
}
