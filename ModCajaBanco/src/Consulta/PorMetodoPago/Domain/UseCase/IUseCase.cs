using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCajaBanco.src.Consulta.PorMetodoPago.Domain.UseCase
{
    public interface IUseCase
    {
        DataTable 
            CargarArqueoPorMetodosPago(DateTime desde, DateTime hasta);
        DateTime 
            CargarFechaServidor();
    }
}
