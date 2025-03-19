using ServiceCajaBanco.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ServiceCajaBanco.MyService
{
    public partial class Service : IService
    {
        public static ILibCajaBanco.IProvider ServiceProv;
        
        public Service(string instancia, string bd)
        {
            ServiceProv = new ProvLibCajaBanco.Provider(instancia, bd);
        }
        
        public DtoLib.ResultadoEntidad<DateTime> 
            FechaServidor()
        {
            return ServiceProv.FechaServidor();
        }
        public DtoLib.ResultadoEntidad<DtoLibCajaBanco.Empresa.Entidad.Ficha> 
            Sistema_Empresa_GetFicha()
        {
            return ServiceProv.Sistema_Empresa_GetFicha();
        }
    }
}