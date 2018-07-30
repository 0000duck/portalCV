using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinSCP;

namespace Arvato.PortalCandidato.UI.Service
{
    public class CvFileService
    {


        public SessionOptions sessionOptions;

        public CvFileService()
        {
            ///Configuracion del FTP
            this.sessionOptions = new SessionOptions
            {
                Protocol = Protocol.Sftp,
                HostName = "10.20.56.60",
                UserName = "gdpr",
                Password = "RHcB5WfB6vpWpXpw",
                GiveUpSecurityAndAcceptAnySshHostKey =true,
            };
        }

        /// <summary>
        /// Elimina un archivo del FTP
        /// </summary>
        /// <param name="nombreCv">nombre del archivo</param>
        /// <returns></returns>
        public bool deleteFtpFile(string nombreCv)
        {

            if (System.IO.File.Exists(ConfigurationManager.AppSettings["pathCv"] + nombreCv))
            {
                File.Delete(ConfigurationManager.AppSettings["pathCv"] + nombreCv);
                return true;
            }
            else {

                try
                {
                    using (Session session = new Session())
                    {
                        session.Open(sessionOptions);
                        RemoteDirectoryInfo dir = session.ListDirectory(".");
                        session.RemoveFiles(nombreCv).Check();

                    }
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Mueve un archivo de la carpeta local del servidor al FTP
        /// </summary>
        /// <param name="pathCv"> ruta completa del archivo a mover</param>
        /// <returns></returns>
        public bool moveFileToFtp(string pathFile)
        {
            var p = Path.GetFullPath(pathFile);
          
            try {
                using (Session session = new Session())
                {
                    // Connect
                    session.Open(sessionOptions);

                    // Upload files
                    TransferOptions transferOptions = new TransferOptions();
                    transferOptions.TransferMode = TransferMode.Automatic;
                    TransferOperationResult transferResult = session.PutFiles(p, "/", false, transferOptions);

                    // Throw on any error
                    transferResult.Check();

                }
          

            }catch(Exception e)
            {
                return false;
            }
            finally
            {
                // Delete the file after uploading
                //if (File.Exists(pathFile))
                //{
                //    File.Delete(pathFile);
                //}

            }

            return true;

        }






    }
}
