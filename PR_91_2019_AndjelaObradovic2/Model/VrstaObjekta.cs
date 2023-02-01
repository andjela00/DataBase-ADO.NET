using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_91_2019_AndjelaObradovic2.Model
{
    public class VrstaObjekta
    {

        public int Idvo { get; set; }
        public string Nazivvo { get; set; }

        public VrstaObjekta(int idvo, string nazivvo)
        {
            Idvo = idvo;
            Nazivvo = nazivvo;
        }

        public override bool Equals(object obj)
        {
            var objekat = obj as VrstaObjekta;
            return objekat != null &&
                Idvo == objekat.Idvo &&
                Nazivvo == objekat.Nazivvo;
        }

        public override int GetHashCode()
        {
            var hashCode = 314861883;
            hashCode = hashCode * -1521134295 + Idvo.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nazivvo);
            return hashCode;
        }
    }
}
