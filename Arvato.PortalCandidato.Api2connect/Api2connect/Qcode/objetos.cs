using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace objetos
{
    partial class usuarioSiop
    {
        public string usuarioNT { get; set; }
        public string nombre { get; set; }
        public string apellido1 { get; set; }
        public string apellido2 { get; set; }
        public string sede { get; set; }
        public string dominio { get; set; }
        public string person_pk { get; set; }
        public string headcount_pk { get; set; }
        public string site_pk { get; set; }
        public string site_lbl { get; set; }
        public string IdRH { get; set; }
        public string servicepk { get; set; }
        public string servicelbl { get; set; }
        public string subproyectpk { get; set; }
        public string subproyectoCodeRH { get; set; }
        public string subproyectolbl { get; set; }
        public string fechaAnt { get; set; }
        public string superior { get; set; }
        public string categoriapk { get; set; }
        public string categorialbl { get; set; }
        public string rolepk { get; set; }
        public string rolelbl { get; set; }
        public string home { get; set; }
        public string person_pk_elite { get; set; }
        public string nifc { get; set; }

        public usuarioSiop(string _usuarioNT)
        {
            usuarioNT = _usuarioNT;
            nombre = "";
            apellido1 = "";
            apellido2 = "";
            dominio = "";
            person_pk = "";
            headcount_pk = "";
            site_pk = "";
            site_lbl = "";
            IdRH = "";
            servicepk = "";
            servicelbl = "";
            subproyectpk = "";
            subproyectoCodeRH = "";
            subproyectolbl = "";
            fechaAnt = "";
            superior = "";
            categoriapk = "";
            categorialbl = "";
            rolepk = "";
            rolelbl = "";
            home = "";
            person_pk_elite = "";
            nifc = "";
        }

        public string dominioSiop()
        {
            string formatoSiop = dominio.Replace("@", "").ToUpper();
            string[] partesFormato = formatoSiop.Split('.');
            try
            {
                formatoSiop = partesFormato[0].ToString() + @"\";
            }
            catch (Exception ex)
            {
                Exception excepcion = new Exception("No es posible generar el usuario en formato Siop. dominioSiop.");
                throw excepcion;
            }
            return formatoSiop;
        }
        public string nombreCompleto()
        {
            return nombre + " " + apellido1 + " " + apellido2;
        }
        public bool esElite()
        {
            if (person_pk_elite == "")
            { return false; }
            else
            { return true; }
        }
    }

    partial class usuarioconfigurador
    {
        public string usuarioNT { get; set; }
        public string nombre { get; set; }
        public string apellido1 { get; set; }
        public string apellido2 { get; set; }
        public string sede { get; set; }
        public string dominio { get; set; }
        public string person_pk { get; set; }
        public string headcount_pk { get; set; }
        public string site_pk { get; set; }
        public string site_lbl { get; set; }
        public string IdRH { get; set; }
        public string servicepk { get; set; }
        public string servicelbl { get; set; }
        public string subproyectpk { get; set; }
        public string subproyectoCodeRH { get; set; }
        public string subproyectolbl { get; set; }
        public string fechaAnt { get; set; }
        public string superior { get; set; }
        public string categoriapk { get; set; }
        public string categorialbl { get; set; }
        public string rolepk { get; set; }
        public string rolelbl { get; set; }
        public string home { get; set; }
        public string person_pk_elite { get; set; }
        public string nifc { get; set; }

        public usuarioconfigurador(string _usuarioNT)
        {
            usuarioNT = _usuarioNT;
            nombre = "";
            apellido1 = "";
            apellido2 = "";
            dominio = "";
            person_pk = "";
            headcount_pk = "";
            site_pk = "";
            site_lbl = "";
            IdRH = "";
            servicepk = "";
            servicelbl = "";
            subproyectpk = "";
            subproyectoCodeRH = "";
            subproyectolbl = "";
            fechaAnt = "";
            superior = "";
            categoriapk = "";
            categorialbl = "";
            rolepk = "";
            rolelbl = "";
            home = "";
            person_pk_elite = "";
            nifc = "";
        }
        public string dominioconfigurador()
        {
            string formatoSiop = dominio.Replace("@", "").ToUpper();
            string[] partesFormato = formatoSiop.Split('.');
            try
            {
                formatoSiop = partesFormato[0].ToString() + @"\";
            }
            catch (Exception ex)
            {
                Exception excepcion = new Exception("No es posible generar el usuario en formato Siop. dominioSiop.");
                throw excepcion;
            }
            return formatoSiop;
        }
        public string nombreCompleto()
        {
            return nombre + " " + apellido1 + " " + apellido2;
        }
        public bool esElite()
        {
            if (person_pk_elite == "")
            { return false; }
            else
            { return true; }
        }
    }

    partial class estructuraGrafica2Dimensiones
    {
        public string nombreSerie { get; set; }
        public string valorX { get; set; }
        public string valorY { get; set; }
        public estructuraGrafica2Dimensiones(string _nombreSerie, string _valorX, string _valorY)
        {
            nombreSerie = _nombreSerie;
            valorX = _valorX;
            valorY = _valorY;
        }

    }

    partial class gestionInformes
    {
        public string master="";
        public string path="";
        public string titulo="";
    }

    public class Empleado
    {
        public string nombre = "";
        public string nif = "";
    }

    public class horarioDia
    {
        public DateTime dia;
        public string[] horario = new string[2];
    }
}