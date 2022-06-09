using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCajaBanco.Reportes.Analisis
{
    
    public class Gestion
    {


        private IGestion _gestion;


        public DateTime DesdeFecha { get { return _gestion.DesdeFecha; } }
        public DateTime HastaFecha { get { return _gestion.HastaFecha; } }



        private FiltrarFrm frm;
        public void Inicia()
        {
            if (_gestion.CargarData()) 
            {
                if (frm == null) 
                {
                    frm = new FiltrarFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        public void setGestion(IGestion gestion)
        {
            _gestion = gestion;
        }

        public void Procesar()
        {
            _gestion.Procesar();
            if (_gestion.IsOk)
                frm.Cerrar();
        }

        public void setFechaDesde(DateTime fecha)
        {
            _gestion.setFechaDesde(fecha);
        }

        public void setFechaHasta(DateTime fecha)
        {
            _gestion.setFechaHasta(fecha);
        }

        public void Inicializar()
        {
            _gestion.Inicializar();
        }

    }

}