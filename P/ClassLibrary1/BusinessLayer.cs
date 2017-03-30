using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BusinessLayer
    {
        /// <summary>
        /// Allows the user to use an action he wishes to use, each input activates different function.
        /// Actions are represented by digits 1-6, each has its own puprose, such as sell, buy, cancel and etc.
        /// </summary>
        public static void whichAction()
        {
            bool flag = false;
            ConsoleKeyInfo cki = Console.ReadKey();
            while (!flag)
            {
                switch (cki.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        {
                            Console.WriteLine();
                            sellAction();

                            flag = true;
                        }
                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        {
                            Console.WriteLine();
                            buyAction();

                            flag = true;
                        }
                        break;

                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        {
                            Console.WriteLine();
                            cancelRequestAction();

                            flag = true;
                        }
                        break;

                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        {
                            Console.WriteLine();
                            sellBuyAction();

                            flag = true;
                        }
                        break;

                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        {
                            Console.WriteLine();
                            userRequestAction();

                            flag = true;
                        }
                        break;

                    case ConsoleKey.D6:
                    case ConsoleKey.NumPad6:
                        {
                            Console.WriteLine();
                            marketRequestAction();

                            flag = true;
                        }
                        break;

                    default:
                        {
                            Console.ResetColor();
                            Console.WriteLine("\n" + "Please select one of the actions given above" + "\n");
                            cki = Console.ReadKey();
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// Checks if user input is parsable into int as positive integer, if user enters 'e' than he wishes to return back to menu.
        /// </summary>
        /// <param name="x">User input</param>
        /// <returns>return the parse result of x if positive integer, also returns -1 if user wants to return to menu.</returns>
        private static int inputCheck2(string x)
        {
            int a;
            int type;
            if (x == "e")
            {
                return -1;
            }
            if (!int.TryParse(x, out a) || a < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You need to enter a positive integer number, please re-enter it !");
                Console.ResetColor();
                string y = Console.ReadLine();
                return inputCheck2(y);
            }
            else
            {
                type = a;
            }
            return type;
        }

        /// <summary>
        /// Checks if user input is parsable into int as positive integer greater than 0, if user enters 'e' than he wishes to return back to menu.
        /// </summary>
        /// <param name="x">User input</param>
        /// <returns>return the parse result of x if positive integer greater than 0, also returns -1 if user wants to return to menu.</returns>
        private static int inputCheck1(string x)
        {
            int a;
            int type;
            if (x == "e")
            {
                return -1;
            }
            if (!int.TryParse(x, out a) || a <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You need to enter a positive number greater than zero, please re-enter it !");
                Console.ResetColor();
                string y = Console.ReadLine();
                type = inputCheck1(y);
            }
            else
            {
                type = a;
            }
            return type;
        }

        /// <summary>
        /// Notifies when the server crashes by printing a message, and allows exiting the emulator.
        /// </summary>
        private static void ServerCrashError()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("We're sorry the server isn't working at the momment, please try again later.");
            Console.WriteLine("To exit the trading emulator please press the Escape key, press any other key to continue...");
            Console.ResetColor();
            if (Console.ReadKey().Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// Sends a rquest for sale of given amount of commodities for given price.
        /// </summary>
        public static void sellAction()
        {
            Console.WriteLine("> Please enter the commodity Id:");
            string commodityInput = Console.ReadLine();
            int commodity = inputCheck2(commodityInput);
            if (commodity == -1)
            {
                return;
            }

            Console.WriteLine("> Please enter the amount:");
            string amountInput = Console.ReadLine();
            int amount = inputCheck1(amountInput);
            if (amount == -1)
            {
                return;
            }

            Console.WriteLine("> Please enter the price:");
            string priceInput = Console.ReadLine();
            int price = inputCheck1(priceInput);
            if (price == -1)
            {
                return;
            }

            DAL.MarketClient m = new DAL.MarketClient();
            try
            {
                m.SendSellRequest(price, commodity, amount);
            }
            catch (DAL.Utils.MarketException mx)
            {
                Console.WriteLine(mx.Message.ToString());
            }
            catch (AggregateException ax)
            {
                ServerCrashError();
            }
        }

        /// <summary>
        /// Sends a requet to purchase given amount of commodity for given price.
        /// </summary>
        public static void buyAction()
        {
            Console.WriteLine("> Please enter the commodity Id:");
            string commodityInput = Console.ReadLine();
            int commodity = inputCheck2(commodityInput);
            if (commodity == -1)
            {
                return;
            }

            Console.WriteLine("> Please enter the amount:");
            string amountInput = Console.ReadLine();
            int amount = inputCheck1(amountInput);
            if (amount == -1)
            {
                return;
            }

            Console.WriteLine("> Please enter the price:");
            string priceInput = Console.ReadLine();
            int price = inputCheck1(priceInput);
            if (price == -1)
            {
                return;
            }

            DAL.MarketClient m = new DAL.MarketClient();
            try
            {
                m.SendBuyRequest(price, commodity, amount);
            }
            catch (DAL.Utils.MarketException mx)
            {
                Console.WriteLine(mx.Message.ToString());
            }
            catch (AggregateException ax)
            {
                ServerCrashError();
            }
        }

        /// <summary>
        /// Canceles a buy/sell by refunding commodity/funds.
        /// </summary>
        public static void cancelRequestAction()
        {
            Console.WriteLine("> Please enter the Id of the request you wish to cancel:");
            string Id = Console.ReadLine();
            int id = inputCheck1(Id);
            if (id == -1)
            {
                return;
            }

            DAL.MarketClient m = new DAL.MarketClient();
            try
            {
                m.SendCancelBuySellRequest(id);

            }
            catch (DAL.Utils.MarketException mx)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(mx.Message.ToString());
                Console.ResetColor();
            }
            catch (AggregateException ax)
            {
                ServerCrashError();
            }
        }

        /// <summary>
        /// Describes a Sell/Purchase by given request id.
        /// </summary>
        public static void sellBuyAction()
        {
            Console.WriteLine("> Please enter the Id of the request you wish to see information of:");
            string Id = Console.ReadLine();
            int id = inputCheck1(Id);
            if (id == -1)
            {
                return;
            }

            DAL.MarketClient m = new DAL.MarketClient();
            DAL.DataEntries.IMarketItemQuery info = new DAL.DataEntries.MarketItemQuery();

            bool flag = true;
            try
            {
                info = m.SendQueryBuySellRequest(id);

            }
            catch (DAL.Utils.MarketException mx)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(mx.Message.ToString());
                Console.ResetColor();
                flag = false;
            }
            catch (AggregateException ax)
            {
                ServerCrashError();
                flag = false;
            }
            if (flag)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The user that sent the request is " + info.getUser() + ", the request's type is " + info.getType() + ", the request's commodity id is " + info.getCommodity() + ", the request's price is " + info.getPrice() + ", the request's amount is " + info.getAmount());
                Console.ResetColor();
            }
        }

        /// <summary>
        /// Describes user information, including inventory, funds and active request ID's description.
        /// </summary>
        public static void userRequestAction()
        {
            DAL.MarketClient m = new DAL.MarketClient();
            DAL.DataEntries.IMarketUserData info = new DAL.DataEntries.MarketUserData();
            bool flag = true;
            try
            {
                info = m.SendQueryUserRequest();
            }
            catch (AggregateException ax)
            {
                ServerCrashError();
                flag = false;
            }

            if (flag)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Dictionary<string, int> dic = info.getCommodities();
                Console.WriteLine("You have the following commodities:");

                for (int i = 0; i < dic.Count; i++)
                {
                    Console.WriteLine("* The amount of commodities with the Id of " + dic.Keys.ElementAt(i) + " is " + dic[dic.Keys.ElementAt(i)]);
                }
                Console.WriteLine("You have " + info.getFunds() + " funds.");
                List<int> requests = info.getRequests();
                Console.WriteLine("Your requests Id's are: ");
                for (int i = 0; i < requests.Count; i++)
                {
                    Console.Write(requests.ElementAt(i));
                    if (i < requests.Count - 1)
                        Console.Write(",");
                }
                Console.ResetColor();
            }

        }

        /// <summary>
        /// Offers best Bid price and best Ask price for a given commodity. 
        /// </summary>
        public static void marketRequestAction()
        {
            Console.WriteLine("> Please enter the commodity Id:");
            string commodityInput = Console.ReadLine();
            int commodity = inputCheck2(commodityInput);
            if (commodity == -1)
            {
                return;
            }

            DAL.MarketClient m = new DAL.MarketClient();
            DAL.DataEntries.IMarketCommodityOffer info = new DAL.DataEntries.MarketCommodityOffer();

            bool flag = true;
            try
            {
                info = m.SendQueryMarketRequest(commodity);

            }
            catch (DAL.Utils.MarketException mx)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(mx.Message.ToString());
                Console.ResetColor();
                flag = false;
            }
            catch (AggregateException ax)
            {
                ServerCrashError();
                flag = false;
            }
            if (flag)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The best bid price is: " + info.getBestBidPrice() + ", the best ask price is: " + info.getBestAskPrice());
                Console.ResetColor();
            }
        }
    }
}
