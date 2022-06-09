using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCajaBanco.Reportes.Analisis
{

    public class dataFiltro
    {

        public DateTime _desde;
        public DateTime _hasta;
        public OOB.LibCajaBanco.Sucursal.Ficha _sucursal;

        public DateTime Desde { get { return _desde.Date; } }
        public DateTime Hasta { get { return _hasta.Date; } }
        public OOB.LibCajaBanco.Sucursal.Ficha Sucursal { get { return _sucursal; } }


        public dataFiltro()
        {
            Inicializar();
        }


        private void Inicializar()
        {
            _desde = DateTime.Now.Date;
            _hasta = DateTime.Now.Date;
            _sucursal = null;
        }

        public void setFechaDesde(DateTime fecha) 
        {
            _desde = fecha;
        }

        public void setFechaHasta (DateTime fecha)
        {
            _hasta = fecha;
        }

        public void setSucursal (OOB.LibCajaBanco.Sucursal.Ficha suc)
        {
            _sucursal=suc;
        }

        public bool isOk() 
        {
            var rt = true;
            if (Desde > Hasta) 
            {
                Helpers.Msg.Error("Fechas Incorrectas. Veirifique Por Favor");
                return false;
            }
            return rt;
        }

        public string Texto() 
        {
            var rt = "";
            rt += "Desde: " + Desde.ToShortDateString() + ", Hasta: " + Hasta.ToShortDateString();
            return rt;
        }

        public void Limpiar()
        {
            Inicializar();
        }

    }

}