using PR_91_2019_AndjelaObradovic2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_91_2019_AndjelaObradovic2.DTO
{
    public class ObjekatVrsteObjekta
    {
        public VrstaObjekta Vo {get;set;}

        public List<Objekat> Objekti { get; set; }
        
    }
}
