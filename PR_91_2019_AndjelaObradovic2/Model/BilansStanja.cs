using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_91_2019_AndjelaObradovic2.Model
{
    public class BilansStanja
    {

        public int Idbs { get; set; }
        public string Idl { get; set; }
        public float Saldo { get; set; }
        public float Dug { get; set; }
        public float Kamata { get; set; }

        public BilansStanja(int idbs, string idl, float saldo, float dug, float kamata)
        {
            Idbs = idbs;
            Idl = idl;
            Saldo = saldo;
            Dug = dug;
            Kamata = kamata;
        }

        public override bool Equals(object obj)
        {
            var objekat = obj as BilansStanja;
            return objekat != null &&
                Idbs == objekat.Idbs &&
                Idl == objekat.Idl &&
                Saldo == objekat.Saldo &&
                Dug == objekat.Dug &&
                Kamata == objekat.Kamata;
        }

        public override int GetHashCode()
        {
            var hashCode = 314861883;
            hashCode = hashCode * -1521134295 + Idbs.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Idl);
            hashCode = hashCode * -1521134295 + Saldo.GetHashCode();
            hashCode = hashCode * -1521134295 + Dug.GetHashCode();
            hashCode = hashCode * -1521134295 + Kamata.GetHashCode();
            return hashCode;
        }

    }
}
