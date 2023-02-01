using PR_91_2019_AndjelaObradovic2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_91_2019_AndjelaObradovic2.UserInterfaceHandler
{
    public class UIHandler
    {
        private static readonly ObjekatService objekatService =  new ObjekatService();
        public void UIHandlerMenu()
        {
            int odg=100;
            

            while(odg != 0)
            {
                string idl;
                string vrstaObjekta;
                Console.WriteLine();
                Console.WriteLine("Odaberite opciju:");
                Console.WriteLine("1 - Izvestaj za uneti zeljeno lice po ID");
                Console.WriteLine("2 - Izvestaj po vrstama lica");
                Console.WriteLine("3 - Kupovina");
                Console.WriteLine("4 - Izvestaj po vrsti objekta");
                Console.WriteLine("0 - Izlazak iz programa");

                odg=Convert.ToInt32(Console.ReadLine());

                switch (odg)
                {
                    case 1:
                        Console.WriteLine("Unesite lice za koje zelite izvestaj :");
                        idl = Console.ReadLine();
                        objekatService.izvestajObjekataPoLicu(idl);
                        break;
                    case 2:
                        objekatService.IzvestajObjekataPoVrstiLica();
                        break;
                    case 3:
                        Console.WriteLine("treca opcija");
                        break;
                    case 4:
                        Console.WriteLine("Unesite vrstu objekta za koju zelite izvestaj: ");
                        vrstaObjekta = Console.ReadLine();
                        objekatService.IzvestajPoVrstiObjekta(vrstaObjekta);

                        break;

                }
            }
        }
        
    }
}
