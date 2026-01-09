using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ILibCajaBanco
{
    public interface IMoneda
    {
        DtoLib.ResultadoEntidad<DtoLibCajaBanco.Moneda.Entidad.Ficha>
            Moneda_GetFichaById(int id);
    }
}