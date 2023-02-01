using PR_91_2019_AndjelaObradovic2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_91_2019_AndjelaObradovic2.DTO
{
    class ObjektiVrsteLicaDTO
    {
        public Lice Lice { get; set; }
        public VrstaObjekta VrstaObjekta{ get; set;}
        public List<Objekat> Objekti { get; set; }
    }
}
