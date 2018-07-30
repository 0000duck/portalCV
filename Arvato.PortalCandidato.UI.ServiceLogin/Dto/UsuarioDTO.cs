using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceLogin.Dto
{
    public class UsuarioDTO
    {
        public int personPK { get; set; }
        public string nombreCompleto { get; set; }
        public string categoria { get; set; }
        public string servicio { get; set; }
        public int esCalidad { get; set; }
        public string tipoUsuario { get; set; }
        public int plataformaPk { get; set; }
        public List<int> perfiles { get; set; }
        public string dominio { get; set; }
        public string usuarioNT { get; set; }
        public int servicesPk { get; set; }
        public string idioma { get; set; }
    }

    public enum App
    {
        Excelenzia = 32
        
    }

}