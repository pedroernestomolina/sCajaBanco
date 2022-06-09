using DataProvCajaBanco.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvCajaBanco.Data
{
    
    public partial class DataProv: IData
    {

        OOB.ResultadoEntidad<OOB.LibCajaBanco.Usuario.Ficha> IUsuario.Usuario_Principal()
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibCajaBanco.Usuario.Ficha>();

            var r01 = MyData.Usuario_Principal();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibCajaBanco.Usuario.Ficha()
            {
                auto = s.auto,
                codigo = s.codigo,
                nombre = s.nombre,
            };
            rt.Entidad = nr;

            return rt;
        }

    }

}