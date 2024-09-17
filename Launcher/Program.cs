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

            try
            {
                if (Loader.Inject())
                    return;
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("An exception has occured. It might help running Launcher as administrator, " +
                                  " please make sure your antivirus is not blocking required files.\n\n" +
                                  $"Exception details:\n{e}");
               
                Console.ReadKey(true);
                return;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Injection failed, make sure your antivirus hasn't deleted any required files.");
            Console.WriteLine("!!! No support is provided for this software, don't contact me for fixes, help or support !!!");
            
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey(true);
        }
    }
}
