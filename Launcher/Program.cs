using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launcher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (Loader.GetActiveSnapProcess() == null)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("MarvelSnap is not running, launch MarvelSnap and then press any key to retry");
                Console.ReadKey(true);
            }

            if (Loader.Inject())
                return;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Injection failed, make sure your antivirus hasn't deleted any required files.");
            Console.WriteLine("!!! No support is provided for this software, don't contact me for fixes, help or support !!!");
            
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey(true);
        }
    }
}
