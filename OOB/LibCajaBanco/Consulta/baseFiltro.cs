using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCajaBanco.Consulta
{
    public abstract class baseFiltro
    {
        public DateTime desde { get; set; }
        public DateTime hasta { get; set; }
        //
        public baseFiltro()
        {
        }
    }
}
