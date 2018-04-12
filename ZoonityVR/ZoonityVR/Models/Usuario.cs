using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZoonityVR.Models
{
    public class Usuario
    {
        public string Nombre { get; set; }
        public bool GallineroAreaCompletado { get; set; }
        public bool ElefanteAreaCompletado { get; set; }
        public bool GirafaAreaCompletado { get; set; }
        public bool LeonesAreaCompletado { get; set; }
        public bool CocodrilosAreaCompletado { get; set; }
        public bool SimiosAreaCompletado { get; set; }
        public bool FocasAreaCompletado { get; set; }
        public bool DelfinesAreaCompletado { get; set; }
    }
}