using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Api2connect.arvatoControl;
using System.Net;

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//Agregar la referencia al proyecto con Click derecho sobre Proyecto, agregar referencia de servicio: http://repositorio/arvatologws/arvatocontrol.asmx?wsdl
//Establecer el namespace que se considere apropiado en cada proyecto
//Agregar Using donde se quiere hacer referencia
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
namespace qcoderegistroEventos
{
    public class registroEventos : IDisposable
    {
        arvatocontrolSoapClient peticion;
        int IdAplicacion = 0;
        //Obtener la lista actualziada de la tabla "TipoEvento"
        public enum TipoEvento
        {
            Informacion = 1,
            Incidencia = 2,
            Excepcion = 3
        }

        //Obtener la lista actualziada de la tabla "Acciones"
        public enum Accion
        {
            BaseDatos = 1,
            CalculoAritmetico = 6,
            Conversion = 3,
            CTI = 4,
            Grabadora = 2,
            Pendiente1 = 11,
            Pendiente2 = 10,
            General = 9,
            Reporting = 8,
            SistemaFicheros = 5,
            SoftwareTerceros = 7
        }

        /// <summary>
        /// Iniciar instancia de encapsulación
        /// </summary>
        /// <param name="_IdAplicacion"></param>
        public registroEventos(int _IdAplicacion)
        {
            peticion = new arvatocontrolSoapClient();
            //Establecemos el IdAplicación al instanciar para evitar repeticiones/errores
            IdAplicacion = _IdAplicacion;
        }
        /// <summary>
        /// Inserta evento
        /// </summary>
        /// <param name="IdTipoEvento"></param>
        /// <param name="IdAccion"></param>
        /// <param name="modulo"></param>
        /// <param name="descipcion"></param>
        /// <param name="resultado"></param>
        /// <param name="ipCliente"></param>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public resultadoEvento insertarEvento(TipoEvento IdTipoEvento, Accion IdAccion, string modulo, string descipcion, string resultado, string ipCliente, string usuario)
        {
            return peticion.insertarEvento(IdAplicacion, (int)IdTipoEvento, (int)IdAccion, modulo, descipcion, resultado, ipCliente, usuario);
        }
        /// <summary>
        /// Inserta detalle de un evento
        /// </summary>
        /// <param name="evento">Identificador del Evento</param>
        /// <param name="prefijo"Código de 2 dígitos que representa la instancia del WS></param>
        /// <param name="variable">Key memorizada</param>
        /// <param name="valor">Valor memorizado</param>
        /// <returns>Objeto de tipo resultadoEvento: resultado, mensaje y prefijo</returns>
        public resultadoEvento insertarDetalle(long evento, string prefijo, string variable, string valor)
        {
            return peticion.insertarDetalle(evento, prefijo, variable, valor);

        }

        /// <summary>
        /// Consultamos los registros de eventos que coincidan con nuestro criterio de búsqueda
        /// </summary>
        /// <param name="IdEvento"></param>
        /// <param name="Prefijo"></param>
        /// <param name="IdAplicacion"></param>
        /// <param name="IdTipoEvento"></param>
        /// <param name="IdAccion"></param>
        /// <param name="Modulo"></param>
        /// <param name="Descripcion"></param>
        /// <param name="Resultado"></param>
        /// <param name="FechaDesde"></param>
        /// <param name="FechaHasta"></param>
        /// <param name="IpServidor"></param>
        /// <param name="IpCliente"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public List<SP_Consultar_Eventos_Result> consultarEventos(long? IdEvento, string Prefijo, int? IdAplicacion, int? IdTipoEvento, int? IdAccion, string Modulo, string Descripcion, string Resultado, DateTime? FechaDesde, DateTime? FechaHasta, string IpServidor, string IpCliente, string Usuario)
        {
            return peticion.consultarEventos(IdEvento, Prefijo, IdAplicacion, IdTipoEvento, IdAccion, Modulo, Descripcion, Resultado, FechaDesde, FechaHasta, IpServidor, IpCliente, Usuario).ToList();
        }


        /// <summary>
        /// Consultamos los registros de detalle que coincidan con nuestro criterio de búsqueda
        /// </summary>
        /// <param name="IdDetalle"></param>
        /// <param name="IdEvento"></param>
        /// <param name="Prefijo"></param>
        /// <param name="Variable"></param>
        /// <param name="Valor"></param>
        /// <returns></returns>
        public List<SP_Consultar_Detalles_Result> consultarDetalles(long? IdDetalle, long? IdEvento, string Prefijo, string Variable, string Valor)
        {
            return peticion.consultarDetalles(IdDetalle, IdEvento, Prefijo, Variable, Valor).ToList();
        }

        #region Miembros de IDisposable
        //Debemos implementar Dispose para poder hacer uso de Using
        void IDisposable.Dispose()
        {
            try
            {
                peticion.Close();
                peticion = null;
                GC.Collect();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        /// <summary>
        /// Obtener la dirección IP del equipo
        /// </summary>
        /// <returns>Cadena con la dirección IP</returns>
        public string obtenerIP()
        {
            string strHostName = "";
            strHostName = System.Net.Dns.GetHostName();
            IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);
            IPAddress[] addr = ipEntry.AddressList;
            return addr[addr.Length - 1].ToString();
        }
    }
}