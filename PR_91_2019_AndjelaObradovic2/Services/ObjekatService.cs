using PR_91_2019_AndjelaObradovic2.Model;
using PR_91_2019_AndjelaObradovic2.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PR_91_2019_AndjelaObradovic2.DAO.Implements;

namespace PR_91_2019_AndjelaObradovic2.Services
{
    public class ObjekatService
    {
        private static readonly ILiceDAO liceDAO = new LiceDAO();
        private static readonly IObjekatDAO objekatDAO = new ObjekatDAO();
        private static readonly IVrstaObjektaDAO vrstaObjektaDAO = new VrstaObjektaDAO();

        public void izvestajObjekataPoLicu( string idl)
        {
            Lice lice = liceDAO.FindById(idl);
            if (lice == null)
                Console.WriteLine("Lice sa tim ID ne postoji");
            else
            {
                IEnumerable<Objekat> objektiPoLicu = objekatDAO.ObjektiPoLicima(lice.IDL);
                int cena = objekatDAO.CenaObjekataPoLicima(lice.IDL);

                Console.WriteLine("Objekti lica " + idl);
                if (objektiPoLicu == null)
                {
                    Console.WriteLine($"Lice {idl} ne poseduje objekte");
                }
                else
                {

                    Console.WriteLine("IDO\tIDVO\tPOVRSINA\tADRESA\t\t\tVREDNOST");

                    foreach (Objekat obj in objektiPoLicu)
                    {
                        Console.WriteLine($" {obj.IDO}\t{obj.IDVO}\t{obj.Povrsina}\t\t{obj.Adresa}\t\t{obj.Vrednost}\n");
                    }

                    Console.WriteLine("Ukupna cena svih objekata je : " + cena+"\n\n");
                }
            }
        }

        public void IzvestajObjekataPoVrstiLica()
        {
            //FIZICKO
            List<Objekat> objektiPoVrstiLica = objekatDAO.ObjektiPoVrstiLica("FIZICKO");
            List<Lice> licaPoVrsti = liceDAO.FindByVrstaL("FIZICKO");
            int brojObjekata = objekatDAO.IzbrojObjektePoVrstiLica("FIZICKO");
            int ukupanDug = liceDAO.UkupanDugVrsteLica("FIZICKO");

            Console.WriteLine("Objekti FIZICKIH lica :");
            Console.WriteLine("IDO\tVRSTA OBJEKTA\tVREDNOST\tIDL\tIMEL\t\tPRZL");
            foreach (var lice in licaPoVrsti)
            { 
                foreach (var obj in objektiPoVrstiLica)
                {
                    if (lice.IDL.Equals(obj.IDL))
                    {
                        string vrstaObjekta = vrstaObjektaDAO.VrsteObjekataPoId(obj.IDVO);
                        Console.WriteLine($"{obj.IDO}\t{vrstaObjekta}\t{obj.Vrednost}\t{lice.IDL}\t{lice.Imel}\t\t{lice.Przl}");
                    }

                }

            }
            Console.WriteLine("Ukupan broj objekata je : "+brojObjekata+"; Ukupno dugovanje: " + ukupanDug+"\n\n");

            //PRAVNO
            List<Objekat> objektiPoVrstiLica1 = objekatDAO.ObjektiPoVrstiLica("PRAVNO");
            List<Lice> licaPoVrsti1 = liceDAO.FindByVrstaL("PRAVNO");
            int brojObjekata1 = objekatDAO.IzbrojObjektePoVrstiLica("PRAVNO");
            int ukupanDug1 = liceDAO.UkupanDugVrsteLica("PRAVNO");

            Console.WriteLine("Objekti PRAVNIH lica :");
            Console.WriteLine("IDO\tVRSTA OBJEKTA\tVREDNOST\tIDL\tIMEL\t\tPRZL");
            foreach (var lice in licaPoVrsti1)
            {
                foreach (var obj in objektiPoVrstiLica1)
                {
                    if (lice.IDL.Equals(obj.IDL))
                    {
                        string vrstaObjekta = vrstaObjektaDAO.VrsteObjekataPoId(obj.IDVO);
                        Console.WriteLine($"{obj.IDO}\t{vrstaObjekta}\t{obj.Vrednost}\t{lice.IDL}\t{lice.Imel}\t\t{lice.Przl}");
                    }
                }

            }

            Console.WriteLine("Ukupan broj objekata je : " + brojObjekata1 + "; Ukupno dugovanje: " + ukupanDug1+"\n\n");
        }

        public void IzvestajPoVrstiObjekta(string vrstaObjekta)
        {
            List<Objekat> objektiPoVrsti = objekatDAO.SviObjektiPoVrsti(vrstaObjekta);
            double prosecnaVrednost = objekatDAO.ProsecnaVrednostObjektaPoTipu(vrstaObjekta);

            if (objektiPoVrsti == null)
            {
                Console.WriteLine("Izabrali ste nepostojecu vrstu objekta\n\n");
            }
            else
            {
                Console.WriteLine("Izvestaj objekta za " + vrstaObjekta);
                Console.WriteLine("IDO\tIDL\tPOVRSINA\tADRESA\t\t\tVREDNOST");
                foreach (var obj in objektiPoVrsti)
                {
                    Console.WriteLine($" {obj.IDO}\t{obj.IDL}\t{obj.Povrsina}\t\t{obj.Adresa}\t\t{obj.Vrednost}\n");
                }
                Console.WriteLine($"Prosecna vrednost objekata vrste {vrstaObjekta} je : {prosecnaVrednost} e\n\n");
            }
        }
    }
}
