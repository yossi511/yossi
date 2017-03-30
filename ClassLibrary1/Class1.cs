using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Class1
    {
        public static void whichAction()
        {
            bool flag = false;
            string x = Console.ReadLine();
            while (!flag)
            {
                switch (x)
                {
                    case "1":
                        {
                            sellAction();
                            flag = true;
                        }
                        break;
                    case "2":
                        {
                            buyAction();
                            flag = true;
                        }
                        break;
                    case "3":
                        {
                            cancelRequestAction();
                            flag = true;
                        }
                        break;
                    case "4":
                        {
                            sellBuyAction();
                            flag = true;
                        }
                        break;
                    case "5":
                        {
                            userRequestAction();
                            flag = true;
                        }
                        break;
                    case "6":
                        {
                            marketRequestAction();
                            flag = true;
                        }
                        break;
                    default:
                        {
                            Console.WriteLine("please enter one of the above numbers");
                            x = Console.ReadLine();
                        }
                        break;
                }
            }
        }
        private static int ezer(string x)
        {
            int a;
            int type;
            if (!int.TryParse(x, out a))
            {
                Console.WriteLine("You need to enter a positive integer, please enter again");
                type = -1;
            }
            else
                if (int.Parse(x) < 0)
            {
                Console.WriteLine("You need to enter a positive integer, please enter again");
                type = -1;
            }
            else
                type = int.Parse(x);
            return type;
        }
        
        public static void sellAction()
        {
            Console.WriteLine("please enter the commodity Id");
            string commodityInput = Console.ReadLine();
            int commodity = ezer(commodityInput);
            while (commodity == -1)
            {
                commodityInput = Console.ReadLine();
                commodity = ezer(commodityInput);
            }

            Console.WriteLine("please enter the amount");
            string amountInput = Console.ReadLine();
            int amount = ezer(amountInput);
            while (amount == -1)
            {
                amountInput = Console.ReadLine();
                amount = ezer(amountInput);
            }

            Console.WriteLine("please enter the price");
            string priceInput = Console.ReadLine();
            int price = ezer(priceInput);
            while (price == -1)
            {
                priceInput = Console.ReadLine();
                price = ezer(priceInput);
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
            catch(AggregateException ax)
            {
                Console.WriteLine("The server isn't working at the momment, please try again later");
            }
        }
        public static void buyAction()
        {
            Console.WriteLine("please enter the commodity Id");
            string commodityInput = Console.ReadLine();
            int commodity = ezer(commodityInput);
            while (commodity == -1)
            {
                commodityInput = Console.ReadLine();
                commodity = ezer(commodityInput);
            }

            Console.WriteLine("please enter the amount");
            string amountInput = Console.ReadLine();
            int amount = ezer(amountInput);
            while (amount == -1)
            {
                amountInput = Console.ReadLine();
                amount = ezer(amountInput);
            }

            Console.WriteLine("please enter the price");
            string priceInput = Console.ReadLine();
            int price = ezer(priceInput);
            while (price == -1)
            {
                priceInput = Console.ReadLine();
                price = ezer(priceInput);
            }

            DAL.MarketClient m = new DAL.MarketClient();
            try
            {
                m.SendBuyRequest(price, commodity, amount);

            }       
            catch(DAL.Utils.MarketException mx)
            {
                Console.WriteLine(mx.Message.ToString());
            }
            catch (AggregateException ax)
            {
                Console.WriteLine("The server isn't working at the momment, please try again later");
            }
        }

        public static void cancelRequestAction()
        {
            Console.WriteLine("please enter the Id of the request you want to cancel");
            string Id = Console.ReadLine();
            int id = ezer(Id);
            while (id == -1)
            {
                Id = Console.ReadLine();
                id = ezer(Id);
            }
            DAL.MarketClient m = new DAL.MarketClient();
            try
            {
                m.SendCancelBuySellRequest(id);

            }
            catch (DAL.Utils.MarketException mx)
            {
                Console.WriteLine(mx.Message.ToString());
            }
            catch (AggregateException ax)
            {
                Console.WriteLine("The server isn't working at the momment, please try again later");
            }
        }
        public static void sellBuyAction()
        {
            Console.WriteLine("please enter the Id of the request you want to see information about");
            string Id = Console.ReadLine();
            int id = ezer(Id);
            while (id == -1)
            {
                Id = Console.ReadLine();
                id = ezer(Id);
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
                Console.WriteLine(mx.Message.ToString());
                flag = false;
            }
            catch (AggregateException ax)
            {
                Console.WriteLine("The server isn't working at the momment, please try again later");
                flag = false;
            }
            if (flag)
                Console.WriteLine("The user that sent the request is: " + info.getUser() + ", the request's type is " + info.getType() + ", the request's commodity id is " + info.getCommodity() + ", the request's price is " + info.getPrice() + ", the request's amount is " + info.getAmount());
        }
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
                Console.WriteLine("The server isn't working at the momment, please try again later");
                flag = false;
            }

            if (flag)
            {
                Dictionary<string, int> dic = info.getCommodities();
                Console.WriteLine("You have the following commodities: ");

                for (int i = 0; i < dic.Count; i++)
                {
                    Console.WriteLine("The amount of commodities with the Id " + dic.Keys.ElementAt(i) + " is " + dic[dic.Keys.ElementAt(i)]);
                }
                Console.WriteLine("you have " + info.getFunds() + " funds.");
                List<int> requests = info.getRequests();
                Console.WriteLine("Your requestes's id are: ");
                for (int i = 0; i < requests.Count; i++)
                {
                    Console.Write(requests.ElementAt(i));
                    if (i < requests.Count - 1)
                        Console.Write(",");
                }
            }

        }
        public static void marketRequestAction()
        {
            Console.WriteLine("please enter the commodity Id");
            string commodityInput = Console.ReadLine();
            int commodity = ezer(commodityInput);
            while (commodity == -1)
            {
                commodityInput = Console.ReadLine();
                commodity = ezer(commodityInput);
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
                Console.WriteLine(mx.Message.ToString());
                flag = false;
            }
             catch (AggregateException ax)
            {
                Console.WriteLine("The server isn't working at the momment, please try again later");
                flag = false;
            }
            if (flag)
                Console.WriteLine("the best bid price is: " + info.getBestBidPrice() + ", the best ask price is: "+ info.getBestAskPrice());
        }
    }
}
