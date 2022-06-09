using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCajaBanco
{

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var r01 = Helpers.Utilitis.CargarXml();
            if (r01.Result != OOB.Enumerados.EnumResult.isError)
            {
                Sistema.MyData = new DataProvCajaBanco.Data.DataProv(Sistema._Instancia, Sistema._BaseDatos);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                var r02 = Sistema.MyData.Usuario_Principal();
                if (r02.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r02.Mensaje);
                    Application.Exit();
                }
                else
                {
                    Sistema.UsuarioP = r02.Entidad;
                    var _gestion = new Gestion();
                    _gestion.Inicia();
                }
                //Application.EnableVisualStyles();
                //Application.SetCompatibleTextRenderingDefault(false);
                //Application.Run(new Form1());
            }
            else 
            {
                Helpers.Msg.Error(r01.Mensaje);
                Application.Exit();
            }
        }

    }

}