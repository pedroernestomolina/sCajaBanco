using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCajaBanco.Reportes.Movimientos.VentaPorCliente
{
    
    public class data
    {

        public string entidad { get; set; }
        public string ciRif { get; set; }
        public string dirFiscal { get; set; }
        public string telefono { get; set; }
        public string sucursal { get; set; }
        public decimal monto { get; set; }
        public decimal montoDivisa { get; set; }
        public int cnt { get; set; }


        public data() 
        {
            entidad = "";
            ciRif = "";
            dirFiscal = "";
            telefono = "";
            sucursal = "";
            monto = 0.0m;
            montoDivisa = 0.0m;
            cnt = 0;
        }

        public data(string _entidad , string _cirif , string _dirF , string _telef , string _suc, decimal? _monto, decimal? _montoDiv, int _cnt)
        {
            var xmonto = 0.0m;
            var xmontoDiv = 0.0m;

            if (_monto.HasValue)
                xmonto = _monto.Value;
            if (_montoDiv.HasValue)
                xmontoDiv = _montoDiv.Value;

            this.entidad = _entidad ;
            this.ciRif= _cirif ;
            this.dirFiscal= _dirF ;
            this.telefono= _telef ;
            this.sucursal= _suc ;
            this.monto = xmonto;
            this.montoDivisa = xmontoDiv;
            this.cnt = _cnt;
        }

    }

}