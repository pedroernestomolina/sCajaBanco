using DataProvCajaBanco.Infra;
using ServiceCajaBanco.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvCajaBanco.Data
{
    
    public partial class DataProv: IData
    {

        public static IService MyData;


        public DataProv(string instancia, string bd)
        {
            MyData = new ServiceCajaBanco.MyService.Service(instancia,bd);
        }


        public OOB.ResultadoEntidad<DateTime> FechaServidor()
        {
            var result = new OOB.ResultadoEntidad<DateTime>();

            var r01 = MyData.FechaServidor();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Enumerados.EnumResult.isError;
                return result;
            }

            result.Entidad = (DateTime)r01.Entidad;

            return result;
        }

    }

}