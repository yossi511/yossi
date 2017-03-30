using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    class PresentationLayer
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Hello Trader !" + "\n");
            string openMessage = "These are the actions you may preform : " + "\n" + "\n";
            openMessage += "> Press 1 to sell a commodity." + "\n";
            openMessage += "> Press 2 to buy a commodity." + "\n";
            openMessage += "> Press 3 to cancel a request." + "\n";
            openMessage += "> Press 4 to see an information about a sell request or a buy request." + "\n";
            openMessage += "> Press 5 to see an information about your status in the market." + "\n";
            openMessage += "> Press 6 to see an information about a commodity in the market.";
            Console.WriteLine(openMessage + "\n");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Please notice that at every action you can still return to the main menu by entering 'e' as for exit." + "\n");
            Console.ResetColor();

            while (true)
            {
                Console.WriteLine("Please select an action you wish to use and press on 1-6 to execute it" + "\n");
                BL.BusinessLayer.whichAction();
                Console.ResetColor();
                Console.WriteLine("\n");
            }
        }
    }
}
