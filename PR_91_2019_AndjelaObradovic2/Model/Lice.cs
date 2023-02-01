using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_91_2019_AndjelaObradovic2.Model
{
    public class Lice
    {

        public string IDL { get; set; }
        public string Imel { get; set; }
        public string Przl { get; set; }
        public string Vrstal { get; set; }
        public int MesPrihodi { get; set; }

        public Lice(string iDL, string imel, string przl, string vrstal, int mesPrihodi)
        {
            IDL = iDL;
            Imel = imel;
            Przl = przl;
            Vrstal = vrstal;
            MesPrihodi = mesPrihodi;
        }

        public override bool Equals(object obj)
        {
            var objekat = obj as Lice;
            return objekat != null &&
                IDL == objekat.IDL &&
                Imel == objekat.Imel &&
                Przl == objekat.Przl &&
                Vrstal == objekat.Vrstal &&
                MesPrihodi == objekat.MesPrihodi;
        }

        public override int GetHashCode()
        {
            var hashCode = 314861883;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(IDL);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Imel);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Przl); ;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Vrstal);
            hashCode = hashCode * -1521134295 + MesPrihodi.GetHashCode();
            return hashCode;
        }
    }
}
