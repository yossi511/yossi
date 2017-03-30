using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B
{
    class Class1
    {
        public static void whichAction()
        {
            Console.WriteLine("f");
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
                            Console.WriteLine("please enter on of the above numbers");
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
                type = -1;
            }
            else
                if (int.Parse(x) < 0)
                type = -1;
            else
                type = int.Parse(x);
            return type;
        }

        public static void sellAction()
        {
            Console.WriteLine("please enter the commodity Id");
            string commodityInput = Console.ReadLine();
            int commodity = ezer(commodityInput);

            Console.WriteLine("please enter the amount");
            string amountInput = Console.ReadLine();
            int amount = ezer(amountInput);

            Console.WriteLine("please enter the price");
            string priceInput = Console.ReadLine();
            int price = ezer(priceInput);

        }
        public static void buyAction()
        {
            Console.WriteLine("please enter the commodity Id");
            string commodityInput = Console.ReadLine();
            int commodity = ezer(commodityInput);

            Console.WriteLine("please enter the amount");
            string amountInput = Console.ReadLine();
            int amount = ezer(amountInput);

            Console.WriteLine("please enter the price");
            string priceInput = Console.ReadLine();
            int price = ezer(priceInput);

        }
        public static void cancelRequestAction()
        {
            Console.WriteLine("please enter the Id of the request you want to cancel");
            string Id = Console.ReadLine();
            int id = ezer(Id);

        }
        public static void sellBuyAction()
        {
            Console.WriteLine("please enter the Id of the request you want to see information about");
            string Id = Console.ReadLine();
            int id = ezer(Id);

        }
        public static void userRequestAction()
        {

        }
        public static void marketRequestAction()
        {
            Console.WriteLine("please enter the commodity Id");
            string commodityInput = Console.ReadLine();
            int commodity = ezer(commodityInput);

        }
    }
}
