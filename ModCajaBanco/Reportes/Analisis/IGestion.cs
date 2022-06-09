using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCajaBanco.Reportes.Analisis
{

    public interface IGestion
    {

        DateTime DesdeFecha { get; }
        DateTime HastaFecha { get; }
        bool IsOk { get; }


        bool CargarData();
        void Procesar();
        void setFechaDesde(DateTime fecha);
        void setFechaHasta(DateTime fecha);
        void Inicializar();

    }

}