using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCajaBanco.Habladores
{
    
    public class data
    {

        private OOB.LibCajaBanco.Reporte.Habladores.Ficha ficha;
        private string idPrecio;


        public string codigoPrd { get { return ficha.codigoPrd; } }
        public string nombrePrd { get { return ficha.nombrePrd; } }
        public bool imprimir { get; set; }

        public decimal precioFull 
        {
            get
            {
                var rt = 0.0m;
                switch (idPrecio)
                {
                    case "1":
                        rt = calculaFull(ficha.pneto_1);
                        break;
                    case "2":
                        rt = calculaFull(ficha.pneto_2);
                        break;
                    case "3":
                        rt = calculaFull(ficha.pneto_3);
                        break;
                    case "4":
                        rt = calculaFull(ficha.pneto_4);
                        break;
                    case "5":
                        rt = calculaFull(ficha.pneto_5);
                        break;
                }
                return rt;
            }
        }

        public decimal divisaFull 
        {
            get 
            {
                var rt = 0.0m;
                switch (idPrecio)
                {
                    case "1":
                        rt = ficha.pdivisaFull_1;
                        break;
                    case "2":
                        rt = ficha.pdivisaFull_2;
                        break;
                    case "3":
                        rt = ficha.pdivisaFull_3;
                        break;
                    case "4":
                        rt = ficha.pdivisaFull_4;
                        break;
                    case "5":
                        rt = ficha.pdivisaFull_5;
                        break;

                }
                return rt;
            }
        }


        public data(OOB.LibCajaBanco.Reporte.Habladores.Ficha rg, string idprecio)
        {
            this.ficha= rg;
            this.idPrecio = idprecio;
        }


        private decimal calculaFull(decimal p)
        {
            var rt = 0.0m;
            rt = p + (p * ficha.tasaIva / 100);
            return rt;
        }

        public void Marcar(bool p)
        {
            imprimir = p;
        }

    }

}