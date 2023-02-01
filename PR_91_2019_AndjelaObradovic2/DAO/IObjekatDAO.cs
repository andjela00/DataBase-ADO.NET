using PR_91_2019_AndjelaObradovic2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_91_2019_AndjelaObradovic2.DAO
{
    public interface IObjekatDAO : ICRUDDao<Objekat,  int>
    {
        int CenaObjekataPoLicima(string id);
        IEnumerable<Objekat> ObjektiPoLicima(string idl);
        List<Objekat> ObjektiPoVrstiLica(string vrstal);
        int IzbrojObjektePoVrstiLica(string vrstal);
        List<Objekat> SviObjektiPoVrsti(string vrstaObjekta);
        double ProsecnaVrednostObjektaPoTipu(string vrstaObjekta);
    }
}
