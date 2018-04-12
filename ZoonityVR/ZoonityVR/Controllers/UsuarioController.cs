using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ZoonityVR.Models;

namespace ZoonityVR.Controllers
{
    public class UsuarioController : ApiController
    {
        Usuario[] usuarios = new Usuario[]
        {
            new Usuario{Nombre = "Laura" , GallineroAreaCompletado = false, ElefanteAreaCompletado = false, GirafaAreaCompletado = false, LeonesAreaCompletado = false, CocodrilosAreaCompletado = false, SimiosAreaCompletado = false, FocasAreaCompletado = false, DelfinesAreaCompletado = false },
            new Usuario{Nombre = "Carlos" , GallineroAreaCompletado = false, ElefanteAreaCompletado = false, GirafaAreaCompletado = false, LeonesAreaCompletado = false, CocodrilosAreaCompletado = false, SimiosAreaCompletado = false, FocasAreaCompletado = false, DelfinesAreaCompletado = false }
        };

        // URI: /api/usuarios
        public IEnumerable<Usuario> GetAllUsuarios()
        {
            return usuarios;
        }

        // URI: /api/usuarios/nombre
        public IHttpActionResult GetUsuario(string nombre)
        {
            var usuario = usuarios.FirstOrDefault((u) => u.Nombre == nombre);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

    }
}
