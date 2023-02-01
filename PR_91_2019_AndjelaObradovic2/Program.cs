using PR_91_2019_AndjelaObradovic2.UserInterfaceHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_91_2019_AndjelaObradovic2
{
    class Program
    {
        private static readonly UIHandler uiHandler = new UIHandler();
        static void Main(string[] args)
        {
            uiHandler.UIHandlerMenu();
            Console.ReadKey();
        }
    }
}
