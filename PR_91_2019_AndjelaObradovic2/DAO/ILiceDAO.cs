using PR_91_2019_AndjelaObradovic2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_91_2019_AndjelaObradovic2.DAO
{
    public interface ILiceDAO
    {
        Lice FindById(string id);
        List<Lice> FindByVrstaL(string vrstal);
        int UkupanDugVrsteLica(string vrstal);
    }
}
