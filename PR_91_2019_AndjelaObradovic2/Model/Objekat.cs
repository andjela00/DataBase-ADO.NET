using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_91_2019_AndjelaObradovic2.Model
{
    public class Objekat
    {

        public int IDO { get; set; }
        public string IDL { get; set; }
        public int IDVO { get; set; }
        public int Povrsina { get; set; }
        public string Adresa { get; set; }
        public int Vrednost { get; set; }

        public Objekat(int iDO, string iDL, int iDVO, int povrsina, string adresa, int vrednost)
        {
            IDO = iDO;
            IDL = iDL;
            IDVO = iDVO;
            Povrsina = povrsina;
            Adresa = adresa;
            Vrednost = vrednost;
        }

        public override bool Equals(object obj)
        {
            var objekat = obj as Objekat;
            return objekat != null &&
                IDO== objekat.IDO &&
                IDL == objekat.IDL &&
                IDVO == objekat.IDVO &&
                Povrsina == objekat.Povrsina &&
                Adresa == objekat.Adresa &&
                Vrednost == objekat.Vrednost;
        }

        public override int GetHashCode()
        {
            var hashCode = 314861883;
            hashCode = hashCode * -1521134295 + IDO.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(IDL);
            hashCode = hashCode * -1521134295 + IDVO.GetHashCode();
            hashCode = hashCode * -1521134295 + Povrsina.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Adresa);
            hashCode = hashCode * -1521134295 + Vrednost.GetHashCode();
            return hashCode;
        }
    }
}
