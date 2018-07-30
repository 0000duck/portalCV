using System;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.DirectoryServices;
using Api2connect.Persistencia;
using System.Collections.Generic;
using System.Data;
using objetos;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Security.Principal;
using System.Runtime.InteropServices;


namespace qcode
{
    /// <summary>
    /// Utilidades simples para escribir código
    /// </summary>
    partial class util
    {
        //Imports de funciones de DLL del sistema 
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern bool LogonUser(string lpszUsername, string lpszDomain, string lpszPassword, int dwLogonType, int dwLogonProvider, ref IntPtr phToken);
        [DllImport("kernel32.dll")]
        public static extern bool CloseHandle(IntPtr token);
        //Fin de los imports DLL


        /// <summary>k
        /// Limpia caracteres potencialmente peligrosos de una cadena de texto
        /// </summary>
        /// <param name="_texto">Texto que queremos limpiar</param>
        /// <returns>Texto limpio</returns>
        public static string limpiarTexto(string _texto)
        {
            // Deminimos la lista de caracteres que queremos borrar del texto original
            string[] caracteres = @"\,',<,/,>".Split(',');
            foreach (string caracter in caracteres)
            {
                _texto = _texto.Replace(caracter, "");
            }
            return _texto;
        }

        public static string capitalizar(string _texto)
        {
            if ( string.IsNullOrEmpty(_texto)) {
                return string.Empty;
            }
            return char.ToUpper(_texto[0]) + _texto.Substring(1).ToLower();
        }

        public static string numeroDecimal(string _texto)
        {
            float Result = 0;
            bool numberResult = false;
            if (float.TryParse(_texto, out Result))
            {
                numberResult = true;
                return _texto;
            }
            else
            {
                return "";
            }

        }

        public static string numeroEntero(string _texto)
        {
            int Result = 0;
            bool numberResult = false;
            if (int.TryParse(_texto, out Result))
            {
                numberResult = true;
                return _texto;
            }
            else
            {
                return "";
            }

        }
        public static DateTime lunesSemana(DateTime fecha)
        {
            while (fecha.DayOfWeek != DayOfWeek.Monday)
            {
                fecha = fecha.AddDays(-1);
            }
            return fecha;
        }
        public static DateTime diaAnterior(DateTime fecha)
        {
            fecha = DateTime.Now.AddDays(-1);
            return fecha;
        }
        /// <summary>
        /// Función que nos permite comprobar si el último carácter coincide con un Char, si es es afirmativo trunca la cadena.
        /// </summary>
        /// <param name="cadena">Texto a truncar</param>
        /// <param name="coincidencia">Char que si está en la última posición de la cadena se elimina</param>
        /// <returns></returns>
        public static string eliminaUltimoCaracter(string cadena, string coincidencia)
        {
            if (cadena.Length == 0) { return cadena; }
            if (cadena.Substring(cadena.Length - 1, 1) == coincidencia)
            {
                cadena = cadena.Substring(0, cadena.Length - 1);
            }
            return cadena;
        }


        public static String pasarSegundosHoras(float lSegundos)
        {
            string functionReturnValue = null;
            try
            {
                Int32 _lSegundos = Convert.ToInt32(lSegundos);
                Int32 iMinutos = 0;
                Int32 iHoras = 0;
                Int32 iSegundos = 0;
                Int32 lSegundosHora = 3600;

                iHoras = _lSegundos / lSegundosHora;
                iMinutos = (_lSegundos % lSegundosHora) / 60;
                iSegundos = (_lSegundos % lSegundosHora) % 60;

                functionReturnValue = iHoras + ":";
                if (iMinutos < 10)
                {
                    functionReturnValue = functionReturnValue + "0" + iMinutos.ToString() + ":";
                }
                else
                {
                    functionReturnValue = functionReturnValue + iMinutos.ToString() + ":";
                }
                if (iSegundos < 10)
                {
                    functionReturnValue = functionReturnValue + "0" + iSegundos.ToString();

                }
                else
                {
                    functionReturnValue = functionReturnValue + iSegundos.ToString();
                }

            }
            catch (Exception ex)
            {
                functionReturnValue = "00:00:00";
            }
            return functionReturnValue;
        }

        public static int copiarArchivo(String rutaNombreOrigen, String rutaNombreDestino)
        {
            /// <summary>
            /// Copiar un archivo en local, hacia una carpeta de destino
            /// NombreCompleto : localpath+filename
            /// </summary>
            try
            {
                int _tamanoCompleto = rutaNombreOrigen.Length;
                int _positionUltimaBara = rutaNombreOrigen.LastIndexOf(@"\") + 1;

                string _fileName = rutaNombreOrigen.Substring(_positionUltimaBara, _tamanoCompleto - (_positionUltimaBara));
                string _targetPath = rutaNombreDestino;

                // Concatenacion de la carpeta de destino y del nombre del archivo
                string _destFile = System.IO.Path.Combine(_targetPath, _fileName);

                // Si la carpeta de destino no existe, la creamos
                if (!System.IO.Directory.Exists(_targetPath))
                {
                    System.IO.Directory.CreateDirectory(_targetPath);
                }

                // Copia el archivo y sobre escribe si existe
                System.IO.File.Copy(rutaNombreOrigen, _destFile, true);
            }
            catch (Exception ex)
            {
                return 0;
            }
            return 1;

        }

        public static int copiarArchivo(String rutaNombreOrigen, String rutaNombreDestino, String usuarioSuplantado, String dominioSuplantado, String pwdSuplantado)
        {
            try
            {
                //Declaramos usuario
                string nombreArchivo = rutaNombreOrigen.Substring(rutaNombreOrigen.LastIndexOf(@"\") + 1, rutaNombreOrigen.Length - rutaNombreOrigen.LastIndexOf(@"\") - 1);
                
                IntPtr token = IntPtr.Zero;
                bool valid = LogonUser(usuarioSuplantado, dominioSuplantado, pwdSuplantado, 2, 0, ref token);

                //Todo lo que se haga dentro del siguiente using se hace con las credenciales del usuario declarado
                using (WindowsImpersonationContext context = WindowsIdentity.Impersonate(token))
                {
                    File.Copy(@rutaNombreOrigen, @rutaNombreDestino + nombreArchivo, true);
                }
            }
            catch (Exception ex)
            {

                return 0; // error?
            }
            return 1;
        }


        /// <summary>
        /// Función para encriptar una cadena de texto
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        public static string encode(string plainText)
        {
            string passPhrase = "qu4l1t3l";
            string saltValue = "S10Ps10p";
            int passwordIterations = 1;
            string initVector = "sistemasoperacio";
            int keySize = 256;
            byte[] initVectorBytes = null;
            initVectorBytes = Encoding.ASCII.GetBytes(initVector);
            byte[] saltValueBytes = null;
            saltValueBytes = Encoding.ASCII.GetBytes(saltValue);
            byte[] plainTextBytes = null;
            plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            Rfc2898DeriveBytes password = default(Rfc2898DeriveBytes);
            password = new Rfc2898DeriveBytes(passPhrase, saltValueBytes, passwordIterations);
            byte[] keyBytes = null;
            keyBytes = password.GetBytes(keySize / 8);
            RijndaelManaged symmetricKey = default(RijndaelManaged);
            symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform encryptor = default(ICryptoTransform);
            encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = default(MemoryStream);
            memoryStream = new MemoryStream();
            CryptoStream cryptoStream = default(CryptoStream);
            cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            cryptoStream.FlushFinalBlock();
            byte[] cipherTextBytes = null;
            cipherTextBytes = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            string cipherText = null;
            cipherText = Convert.ToBase64String(cipherTextBytes);
            cipherText = cipherText.Replace("+", "@").ToString();
            return cipherText;
        }

        /// <summary>
        /// función para desencriptar cadenas de texto
        /// </summary>
        /// <param name="cipherText"></param>
        /// <returns></returns>
        public static string decode(string cipherText)
        {
            cipherText = cipherText.Replace("@", "+").ToString();
            string passPhrase = "qu4l1t3l";
            string saltValue = "S10Ps10p";
            int passwordIterations = 1;
            string initVector = "sistemasoperacio";
            int keySize = 256;
            byte[] initVectorBytes = null;
            initVectorBytes = Encoding.ASCII.GetBytes(initVector);
            byte[] saltValueBytes = null;
            saltValueBytes = Encoding.ASCII.GetBytes(saltValue);
            byte[] cipherTextBytes = null;
            cipherTextBytes = Convert.FromBase64String(cipherText);
            Rfc2898DeriveBytes password = default(Rfc2898DeriveBytes);
            password = new Rfc2898DeriveBytes(passPhrase, saltValueBytes, passwordIterations);
            byte[] keyBytes = null;
            keyBytes = password.GetBytes(keySize / 8);
            RijndaelManaged symmetricKey = default(RijndaelManaged);
            symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform decryptor = default(ICryptoTransform);
            decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = default(MemoryStream);
            memoryStream = new MemoryStream(cipherTextBytes);
            CryptoStream cryptoStream = default(CryptoStream);
            cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = null;
            plainTextBytes = new byte[cipherTextBytes.Length + 1];
            int decryptedByteCount = 0;
            decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            string plainText = null;
            plainText = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
            return plainText;
        }
    }


    /// <summary>
    /// Utilidades de conversión a objetos de tipo HTMl
    /// </summary>
    partial class html
    {
        public static HtmlGenericControl separadorBR()
        {
            HtmlGenericControl separador = new HtmlGenericControl("BR");
            return separador;
        }

        public static HtmlGenericControl separadorHorizontal(int anchoPX)
        {
            HtmlGenericControl separador = new HtmlGenericControl("span");
            separador.Style.Add("width", anchoPX + "px");
            separador.Style.Add("display", "inline-block");
            return separador;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="controlSelect"></param>
        /// <param name="separador"></param>
        /// <returns></returns>
        public static string devuelveValuesMultiselec(ListBox controlSelect, string separador)
        {
            string valoresSelect = "";
            foreach (int elemento in controlSelect.GetSelectedIndices())
            {
                valoresSelect += controlSelect.Items[elemento].Value + separador;
            }
            valoresSelect = util.eliminaUltimoCaracter(valoresSelect, separador);
            return valoresSelect;
        }
        public static string devuelveValuesMultiselecTexto(ListBox controlSelect, string separador)
        {
            string valoresSelect = "";
            for (int i = 0; i <= controlSelect.Items.Count - 1; i++)
            {
                if (controlSelect.Items[i].Selected)
                {

                    valoresSelect += controlSelect.Items[i].Text + separador;
                }
            }
            valoresSelect = util.eliminaUltimoCaracter(valoresSelect, separador);
            return valoresSelect;
        }
        public static string devuelveValuesMultiselecValor(ListBox controlSelect, string separador)
        {
            string valoresSelect = "";
            for (int i = 0; i <= controlSelect.Items.Count - 1; i++)
            {
                if (controlSelect.Items[i].Selected)
                {

                    valoresSelect += "'" + controlSelect.Items[i].Value + "'" + separador;
                }
            }
            valoresSelect = util.eliminaUltimoCaracter(valoresSelect, separador);
            return valoresSelect;
        }
        public static Label nLabel(string texto, string estilo)
        {
            Label etiqueta = new Label();
            etiqueta.Text = texto;
            etiqueta.CssClass = estilo;
            return etiqueta;
        }

        public static Label nLabel2(string texto, string estilo)
        {
            Label etiqueta = new Label();
            etiqueta.Text = texto;
            etiqueta.CssClass = estilo;
            etiqueta.Style.Add("padding-left", "100px");
            etiqueta.ForeColor = System.Drawing.Color.Black;
            return etiqueta;
        }
        public static HtmlTableCell nLabelCelda(string texto, string estilo)
        {
            HtmlTableCell nuevaCelda = new HtmlTableCell();
            Label textoCelda = new Label();
            textoCelda.Text = texto;
            textoCelda.CssClass = estilo;
            nuevaCelda.Controls.Add(textoCelda);
            return nuevaCelda;

        }
        public static TableCell nLabelCelda2(String texto)
        {
            TableCell nuevaCelda = new TableCell();
            nuevaCelda.Width = 0;
            Label textoCelda = new Label();
            textoCelda.Text = texto;
            textoCelda.ForeColor = System.Drawing.Color.White;
            nuevaCelda.ForeColor = System.Drawing.Color.White;
            nuevaCelda.BackColor = System.Drawing.Color.Transparent;
            nuevaCelda.Controls.Add(textoCelda);
            return nuevaCelda;

        }
        public static TableCell celdaIconoLoad(String pathIcono, String jsOnClick)
        {
            TableCell celdaLoad = new TableCell();
            celdaLoad.CssClass = "celdaLoad";
            HtmlImage imagenLoad = new HtmlImage();
            imagenLoad.Attributes.Add("class", "imagenLoad");
            imagenLoad.Src = pathIcono;
            imagenLoad.Attributes.Add("onClick", jsOnClick);
            celdaLoad.Controls.Add(imagenLoad);
            return celdaLoad;
        }

        public static TableCell celdaSelectJustLoad(String jsOnClick, String idControl, List<ListItem> valores)
        {
            TableCell celdaLoad = new TableCell();
            celdaLoad.CssClass = "celdaLoad";
            HtmlSelect SelectLoad = new HtmlSelect();
            SelectLoad.Attributes.Add("onClick", jsOnClick);
            SelectLoad.ClientIDMode = System.Web.UI.ClientIDMode.Static;
            SelectLoad.ID = idControl;
            foreach (ListItem elemento in valores)
            {
                SelectLoad.Items.Add(elemento);
            }
            celdaLoad.Controls.Add(SelectLoad);
            return celdaLoad;
        }

        public static TableCell celdaBotonLoad(String jsOnClick)
        {
            TableCell celdaLoad = new TableCell();
            celdaLoad.CssClass = "celdaLoad";
            HtmlButton BotonLoad = new HtmlButton();
            BotonLoad.InnerText = "Validar";
            BotonLoad.Attributes.Add("onClick", jsOnClick);
            celdaLoad.Controls.Add(BotonLoad);
            return celdaLoad;
        }


                public static TableCell celdaBotonLoadHide(String jsOnClick)
        {
            TableCell celdaLoad = new TableCell();
            celdaLoad.CssClass = "celdaLoad";
            HtmlButton BotonLoad = new HtmlButton();
            BotonLoad.InnerText = "Validar";
         //  BotonLoad.Attributes.Add("onClick", jsOnClick);
            BotonLoad.Attributes.Add("onclick", "$(this).hide();"+jsOnClick+";");
            BotonLoad.Attributes.Add("onDblClick", "alert('No utilice doble click en los botones por favor.')");
            celdaLoad.Controls.Add(BotonLoad);
            return celdaLoad;
        }


        public static TableCell celdaBotonLoad2(String jsOnClick)
        {
            TableCell celdaLoad = new TableCell();
            celdaLoad.CssClass = "celdaLoad";
            HtmlButton BotonLoad = new HtmlButton();
            BotonLoad.InnerText = "Modificar";
            BotonLoad.Attributes.Add("onClick", jsOnClick);
            celdaLoad.Controls.Add(BotonLoad);
            return celdaLoad;
        }
        public static TableCell celdaBotonLoad3(String jsOnClick, String idboton)
        {
            TableCell celdaLoad = new TableCell();
            celdaLoad.CssClass = "celdaLoad";
            HtmlButton BotonLoad = new HtmlButton();
            BotonLoad.InnerText = "Validar";
            BotonLoad.ClientIDMode = System.Web.UI.ClientIDMode.Static;
            BotonLoad.ID = idboton;
            BotonLoad.Attributes.Add("onClick", jsOnClick);
            celdaLoad.Controls.Add(BotonLoad);
            return celdaLoad;
        }
        public static TableCell celdaBotonLoad4(String jsOnClick, String idboton)
        {
            TableCell celdaLoad = new TableCell();
            celdaLoad.CssClass = "celdaLoad";
            HtmlButton BotonLoad = new HtmlButton();
            BotonLoad.InnerText = "Eliminar";
            BotonLoad.ClientIDMode = System.Web.UI.ClientIDMode.Static;
            BotonLoad.ID = idboton;
            BotonLoad.Attributes.Add("onClick", jsOnClick);
            celdaLoad.Controls.Add(BotonLoad);
            return celdaLoad;
        }
        public static TableCell celdaBotonLoad5(String jsOnClick)
        {
            TableCell celdaLoad = new TableCell();
            celdaLoad.CssClass = "celdaLoad";
            HtmlButton BotonLoad = new HtmlButton();
            BotonLoad.InnerText = "Eliminar";
            BotonLoad.Attributes.Add("onClick", jsOnClick);
            celdaLoad.Controls.Add(BotonLoad);
            return celdaLoad;
        }
        public static TableCell celdaBotonLoad6(String jsOnClick)
        {
            TableCell celdaLoad = new TableCell();
            celdaLoad.CssClass = "celdaLoad";
            HtmlButton BotonLoad = new HtmlButton();
            BotonLoad.InnerText = "Desasignar";
            BotonLoad.Attributes.Add("onClick", jsOnClick);
            BotonLoad.Attributes.Add("OnClientClick", "return confirm('¿Desea Guardar Asistencia?');");
            celdaLoad.Controls.Add(BotonLoad);
            return celdaLoad;
        }
        public static TableCell celdaBotonLoad7(String jsOnClick)
        {
            TableCell celdaLoad = new TableCell();
            celdaLoad.CssClass = "celdaLoad";
            HtmlButton BotonLoad = new HtmlButton();
            BotonLoad.InnerText = "Validar";
            BotonLoad.Attributes.Add("onClick", jsOnClick);
            celdaLoad.Controls.Add(BotonLoad);
            return celdaLoad;
        }
        public static TableCell celdaTextoLoad(String jsOnClick, String idTexto, String Objetivo)
        {
            TableCell celdaLoad = new TableCell();
            celdaLoad.CssClass = "celdaLoad";
            HtmlInputText TextoLoad = new HtmlInputText();
            TextoLoad.Value = Objetivo;
            celdaLoad.Controls.Add(TextoLoad);
            return celdaLoad;
        }
        public static TableCell celdaTexto(String jsOnClick, String idTexto)
        {
            TableCell celdaLoad = new TableCell();
            celdaLoad.CssClass = "celdaLoad";
            HtmlInputText TextoLoad = new HtmlInputText();
            TextoLoad.ClientIDMode = System.Web.UI.ClientIDMode.Static;
            TextoLoad.ID = idTexto;
            celdaLoad.Controls.Add(TextoLoad);
            return celdaLoad;
        }
        public static TableCell celdaCheck(String jsOnClick, String idCheck)
        {
            TableCell celdaLoad = new TableCell();
            celdaLoad.CssClass = "celdaLoad";
            HtmlInputCheckBox CheckLoad = new HtmlInputCheckBox();
            CheckLoad.ClientIDMode = System.Web.UI.ClientIDMode.Static;
            CheckLoad.ID = idCheck;
            celdaLoad.Controls.Add(CheckLoad);
            return celdaLoad;
        }
        public static TableRow tablaNuevaFila(String[] textos)
        {
            TableRow filaTabla = new TableRow();

            filaTabla.CssClass = "filaBody";

            foreach (string titulo in textos)
            {
                Label etiqueta = new Label();
                etiqueta.Text = titulo;
                TableCell celdaEtiqueta = new TableCell();

                celdaEtiqueta.Controls.Add(etiqueta);
                filaTabla.Controls.Add(celdaEtiqueta);
            }
            return filaTabla;

        }



        public static TableHeaderRow tablaNuevaFilaCabecera(String[] textos)
        {
            TableHeaderRow filaTabla = new TableHeaderRow();

            filaTabla.TableSection = TableRowSection.TableHeader;
            filaTabla.CssClass = "filaHeader";


            foreach (string titulo in textos)
            {
                Label etiqueta = new Label();
                etiqueta.Text = titulo;
                TableCell celdaEtiqueta = new TableCell();

                celdaEtiqueta.Controls.Add(etiqueta);
                filaTabla.Controls.Add(celdaEtiqueta);
            }
            return filaTabla;

        }
        public static TableHeaderRow tablaNuevaFilaCabeceraOtra(String[] textos)
        {
            TableHeaderRow filaTabla = new TableHeaderRow();

            filaTabla.TableSection = TableRowSection.TableHeader;
            filaTabla.BackColor = System.Drawing.Color.White;


            foreach (string titulo in textos)
            {
                Label etiqueta = new Label();
                etiqueta.Text = titulo;
                TableCell celdaEtiqueta = new TableCell();

                celdaEtiqueta.Width = 20;
                celdaEtiqueta.Controls.Add(etiqueta);
                filaTabla.Controls.Add(celdaEtiqueta);
            }
            return filaTabla;

        }
        public static TableHeaderRow tablaNuevaFilaCabeceraCecos(String[] textos)
        {
            TableHeaderRow filaTabla = new TableHeaderRow();

            filaTabla.TableSection = TableRowSection.TableHeader;
            filaTabla.CssClass = "filaHeader";

            foreach (string titulo in textos)
            {
                Label etiqueta = new Label();
                etiqueta.Text = titulo;
                TableCell celdaEtiqueta = new TableCell();
                if (titulo == "Nombre")
                {
                    celdaEtiqueta.Width = 150;
                    etiqueta.Width = 150;
                }
                //if (titulo == "Codigo empleado")
                //{
                //    celdaEtiqueta.Width = 100;
                //    etiqueta.Width = 100;
                //}
                //if (titulo == "Categoria")
                //{
                //    celdaEtiqueta.Width = 100;
                //    etiqueta.Width = 100;
                //}
                //if (titulo == "Subproyecto actual")
                //{
                //    celdaEtiqueta.Width = 150;
                //    etiqueta.Width = 150;
                //}
                celdaEtiqueta.Controls.Add(etiqueta);
                filaTabla.Controls.Add(celdaEtiqueta);
            }
            return filaTabla;

        }
        public static TableRow tablaNuevaFilaCecos(String[] textos)
        {
            TableRow filaTabla = new TableRow();

            foreach (string titulo in textos)
            {
                Label etiqueta = new Label();
                etiqueta.Text = titulo;
                TableCell celdaEtiqueta = new TableCell();
                //if (textos[1] != "")
                //{
                //    celdaEtiqueta.Width = 150;
                //    etiqueta.Width = 150;
                //}
                //if (textos[0] != "")
                //{
                //    celdaEtiqueta.Width = 100;
                //    etiqueta.Width = 100;
                //}
                //if (textos[2] != "")
                //{
                //    celdaEtiqueta.Width = 100;
                //    etiqueta.Width = 100;
                //}
                //if (textos[3] != "")
                //{
                //    celdaEtiqueta.Width = 150;
                //    etiqueta.Width = 150;
                //}
                celdaEtiqueta.Controls.Add(etiqueta);
                filaTabla.Controls.Add(celdaEtiqueta);
            }
            return filaTabla;

        }
        public static TableRow tablaNuevaFilaOtra(String[] textos)
        {
            TableRow filaTabla = new TableRow();

            foreach (string titulo in textos)
            {
                Label etiqueta = new Label();
                etiqueta.Text = titulo;
                TableCell celdaEtiqueta = new TableCell();

                celdaEtiqueta.Controls.Add(etiqueta);
                filaTabla.Controls.Add(celdaEtiqueta);
            }
            return filaTabla;

        }
        public static TableRow tablaNuevaFilaPorcen(String[] textos)
        {
            TableRow filaTabla = new TableRow();

            foreach (string titulo in textos)
            {
                Label etiqueta = new Label();
                etiqueta.Text = titulo;
                TableCell celdaEtiqueta = new TableCell();

                celdaEtiqueta.Controls.Add(etiqueta);
                filaTabla.Controls.Add(celdaEtiqueta);
            }
            return filaTabla;

        }
    }
    /// <summary>
    /// Generación de gráficas Jquery con Highcharts
    /// </summary>

    partial class graficaHighcharts
    {
        public static GridView estructuraGraficaATabla(IList<estructuraGrafica2Dimensiones> elementos, string lblPrimeraColumna, bool esCalidad)
        {
            DataTable tablaTemporal = new DataTable("tablaTemporal");
            GridView vistaTabla = new GridView();

            tablaTemporal.Columns.Add(lblPrimeraColumna);
            foreach (estructuraGrafica2Dimensiones elemento in elementos)
            {
                //comprobamos si ya existe en la tabla temporal
                int numeroFila = -1;
                for (int i = 0; i < tablaTemporal.Rows.Count; i++)
                {
                    if (tablaTemporal.Rows[i][0].ToString() == elemento.nombreSerie)
                    {
                        numeroFila = i;
                        break;
                    }
                }
                if (numeroFila == -1)
                {
                    tablaTemporal.Rows.Add(elemento.nombreSerie);

                    numeroFila = tablaTemporal.Rows.Count - 1;
                }
                int numeroColumna = -1;
                for (int i = 0; i < tablaTemporal.Columns.Count; i++)
                {
                    if (tablaTemporal.Columns[i].ColumnName == elemento.valorX.ToString().Substring(6, 2) + "/" + elemento.valorX.ToString().Substring(4, 2) + "/" + elemento.valorX.ToString().Substring(0, 4))
                    {
                        numeroColumna = i;
                        break;
                    }
                }
                if (numeroColumna == -1)
                {
                    tablaTemporal.Columns.Add(elemento.valorX.ToString().Substring(6, 2) + "/" + elemento.valorX.ToString().Substring(4, 2) + "/" + elemento.valorX.ToString().Substring(0, 4));
                    numeroColumna = tablaTemporal.Columns.Count - 1;
                }
                if (elemento.valorY != "0")
                {
                    if (esCalidad == true)
                    {
                        tablaTemporal.Rows[numeroFila][numeroColumna] = elemento.valorY;
                    }
                    else
                    {
                        tablaTemporal.Rows[numeroFila][numeroColumna] = util.pasarSegundosHoras(float.Parse(elemento.valorY.ToString()));
                    }
                }
            }
            vistaTabla.DataSource = tablaTemporal;
            vistaTabla.DataBind();

            vistaTabla.CssClass = "tablaGrafico";

            return vistaTabla;
        }



        public static string serializaXdateTimeYint(IList<estructuraGrafica2Dimensiones> elementos)
        {
            string cadenaResultado = "[";
            string nombreSerieAnterior = "";
            bool primerElemento = true;
            foreach (estructuraGrafica2Dimensiones elemento in elementos)
            {
                if (elemento.nombreSerie != nombreSerieAnterior)
                {
                    //Disinta serie
                    if (primerElemento == true)
                    {
                        primerElemento = false;
                    }
                    else
                    {
                        cadenaResultado += "]},";
                    }
                    DateTime fechaX = DateTime.Parse(elemento.valorX.ToString().Substring(6, 2) + "/" + elemento.valorX.ToString().Substring(4, 2) + "/" + elemento.valorX.ToString().Substring(0, 4)).AddMonths(-1);
                    cadenaResultado += "{ name: '" + elemento.nombreSerie + "', data: [[Date.UTC(" + fechaX.Year.ToString() + "," + fechaX.Month.ToString() + "," + fechaX.Day.ToString() + ")," + elemento.valorY.ToString().Replace(',', '.') + "]";
                }
                else
                {

                    DateTime fechaX = DateTime.Parse(elemento.valorX.ToString().Substring(6, 2) + "/" + elemento.valorX.ToString().Substring(4, 2) + "/" + elemento.valorX.ToString().Substring(0, 4)).AddMonths(-1);
                    cadenaResultado += ", [Date.UTC(" + fechaX.Year.ToString() + "," + fechaX.Month.ToString() + "," + fechaX.Day.ToString() + ")," + elemento.valorY.ToString().Replace(',', '.') + "]";
                }
                nombreSerieAnterior = elemento.nombreSerie.ToString();
            }
            cadenaResultado += "]}]";
            return cadenaResultado;
        }

        public static string creaGraficaspline(string destino, string titulo, string subtitulo, string tituloY, string valores, string formatoLabelX)
        {
            //Formatos LabelX
            //second: '%H:%M:%S',
            //minute: '%H:%M',
            //hour: '%H:%M',
            //day: '%e. %b',
            //week: '%e. %b',
            //month: '%b \'%y',
            //year: '%Y'

            string migrafica = "var chart;$(document).ready(function () { chart = new Highcharts.Chart({chart: { height: 600,renderTo: '" + destino + "',defaultSeriesType: 'spline',marginRight: 30,marginBottom: 190},";
            migrafica += " title: {text: '" + titulo + "', style: { font: 'bold 12px Verdana', color: 'Black' },x: -20},";
            migrafica += "subtitle: {text: '" + subtitulo + "',style: { font: 'bold 10px Verdana', color: 'Black' },x: -20},";
            migrafica += "xAxis: {type: 'datetime',labels: {formatter: function() { return Highcharts.dateFormat('" + formatoLabelX + "', this.value);}}},";
            migrafica += "yAxis: {title: {text: '" + tituloY + "'},min: 0},";
            migrafica += "tooltip: {formatter: function() {return '<b>'+ this.series.name +'</b><br/>'+Highcharts.dateFormat('%e. %b', this.x) +': '+ this.y ;}},";
            migrafica += "series: " + valores + "});});";
            return migrafica;
        }

        public static string creaGraficasplineDatetime(string destino, string titulo, string subtitulo, string tituloY, string valores, string formatoLabelX)
        {
            string migrafica = "var chart;$(document).ready(function () { chart = new Highcharts.Chart({chart: { height: 600,renderTo: '" + destino + "',defaultSeriesType: 'spline',marginRight: 30,marginBottom: 190},";
            migrafica += " title: {text: '" + titulo + "', style: { font: 'bold 12px Verdana', color: 'Black' },x: -20},";
            migrafica += "subtitle: {text: '" + subtitulo + "',style: { font: 'bold 10px Verdana', color: 'Black' },x: -20},";
            migrafica += "xAxis: {type: 'datetime',labels: {formatter: function() { return Highcharts.dateFormat('" + formatoLabelX + "', this.value);}}},";
            migrafica += "yAxis: {title: {text: '" + tituloY + "'},min: 0},";
            migrafica += "tooltip: {formatter: function() {return '<b>'+ this.series.name +'</b><br/>'+convertminute(this.y ) + ' (hh:mm:ss)' ;}},";
            migrafica += "series: " + valores + "});});";
            migrafica += " function convertminute(time) { var addZero = function (v) { return v < 10 ? '0' + v : v; }; var d = new Date(time * 1000); var t = [];t.push(addZero(d.getHours() - 1)); t.push(addZero(d.getMinutes()));t.push(addZero(d.getSeconds()));return t.join(':');}";

            return migrafica;
        }
    }

    /// <summary>
    /// Funcionalidad para validar con Active Directory de Arvato Qualytel
    /// </summary>
    partial class directorioActivo
    {
        /// <summary>
        /// Funcion para validar con Active Directory
        /// </summary>
        /// <param name="username">Usuario a validar (Sin dominio)</param>
        /// <param name="pwd">Clave del usuario</param>
        /// <param name="domain">Dominio con el que validar</param>
        /// <returns>True si es acceso correcto/False si es incorrecto</returns>
        public static bool compruebaAcceso(string username, string pwd, string domain, string urlDirectorio)
        {
            //Creamos un obejto que nos permite interactuar con Directorio Activo
            DirectoryEntry entry = new DirectoryEntry();
            entry = new DirectoryEntry(urlDirectorio, username + domain, pwd);
            try
            {
                object obj = entry.NativeObject;
                DirectorySearcher search = new DirectorySearcher(entry);
                search.Filter = "(SAMAccountName=" + username + ")";
                search.PropertiesToLoad.Add("cn");
                SearchResult result = search.FindOne();
            }
            catch (System.Exception ex)
            {
                return false;
            }
            return true;
        }
    }



}


