using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DataEntries;
using DAL.Utils;

namespace DAL 
{
    public class MarketClient : IMarketClient
    {
        private const string Url = "http://ise172.ise.bgu.ac.il/";
        private const string User = "user44";
        private const string PrivateKey = @"-----BEGIN RSA PRIVATE KEY-----
                                          MIICXAIBAAKBgQCYdycLOXBSIBF/N0Vsd/gKp1UV2fSMj/iIPsnPcv5FKHyW14cl
                                          w9gyMAeo4ZaESG6QJtJ2SIb7+Hn05tasmS3bLxOWzyYrBBPOEVq5nW1PhO/y3l2+
                                          A11wLTYE1Ri+qPIxncx7sKyRfVNEwzuBYNF+O0nPkLXKuKvvXMhY59WhnwIDAQAB
                                          AoGAAy4hE1vcWuouUz/847lQ5C//V1hXgIMURQtCPGCCq0Cf8KmIOSJvpQRZdI1Y
                                          DWRRYhJdO3hh0GmraY9TFQCQ80QwAh3Gfzsy+G1010f1w+kvE4pCp0ni/YaiLxaM
                                          wd5isQVFOM0ObpG+t6dScImWoAoiKPax7h9RvDtWEzgUnmECQQC16DMRf3XIYZVi
                                          QOp0ZroyBE7Qm5nO+eVujgfPi7FOlOS0jyzqEp6DdKye15xVlzIK2R5/g38QyapU
                                          bPLFCqHPAkEA1pEFZYTPghKMgGuCOp7b70tjYc6V9uldHvfRb/M5VcPZXyzQgLSc
                                          nF4NLexxHhyXVIvT7UKfUcQECTxlK6AHMQJAabt+u4P3pTI7TzHmVSREw7/HQ++9
                                          lhWgqwL5PUS4GbHnwZ+a/q813bjagTVX1FQerTmIRZvcJpjhXVM6RRep9wJAY60Z
                                          EbEh6O4PATVwWSUlTMP71hrvRbXhQZqkW9pkvzftSi56ad/9hRKYEsZtQizMDEWs
                                          3OJ/Oq/RpCy/XwXHcQJBAKhAYOIei75jJoPm4EC+J/kuXtT5T/XwvM9ZNMQzzXi5
                                          5rvEnMQQfigEeqHuEa829bTaIsy8MjFtBCPlthAx34Q=
                                                  -----END RSA PRIVATE KEY-----";

        /// <summary>
        /// Sends a requet to purchase given amount of commodity for given price. 
        /// </summary>
        /// <param name="price">The price offred for the purchase</param>
        /// <param name="commodity">The wanted commodity id</param>
        /// <param name="amount">The amount of commodities wished for purchase</param>
        /// <returns>A request id of the purchase</returns>
        public int SendBuyRequest(int price, int commodity, int amount)
        {
            SimpleHTTPClient client = new SimpleHTTPClient();
            BuyRequest request = new BuyRequest("buy",commodity,amount,price);
            string token = SimpleCtyptoLibrary.CreateToken(User, PrivateKey);
            string response = client.SendPostRequest(Url, User, token, request);

            int a;
            if (!int.TryParse(response, out a))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                if (response == "Bad commodity")
                    throw (new MarketException("The request relates to a non existing commodity Id."));
                if (response == "Insufficient funds")
                    throw (new MarketException("Not enough funds to complete the purchase."));
            }

            Console.ForegroundColor = ConsoleColor.Green;
            int id = int.Parse(response);
            Console.WriteLine("You have successfully bought the commodity,  here is your request Id:" + id);
            Console.ResetColor();
            return id;
        }

        /// <summary>
        /// Sends a rquest for sale of given amount of commodities for given price.
        /// </summary>
        /// <param name="price">The price offer for the sale</param>
        /// <param name="commodity">The commodity id</param>
        /// <param name="amount">The amount of commodities up for sale</param>
        /// <returns>A request id of the sale</returns>
        public int SendSellRequest(int price, int commodity, int amount)
        {
            SimpleHTTPClient client = new SimpleHTTPClient();
            SellRequest request = new SellRequest("sell", commodity, amount, price);
            string token = SimpleCtyptoLibrary.CreateToken(User, PrivateKey);
            string response = client.SendPostRequest(Url, User, token, request);
            int a;
            if (!int.TryParse(response, out a))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                if (response == "Bad commodity")
                    throw (new MarketException("The request relates to a non existing commodity Id."));
                if (response == "Insufficient commodity")
                    throw (new MarketException("Not enough  amount of commodity to complete the sell."));
            }

            Console.ForegroundColor = ConsoleColor.Green;
            int id = int.Parse(response);
            Console.WriteLine("You have successfully sold the commodities, here is your request Id: " + id);
            Console.ResetColor();
            return id;
        }

        /// <summary>
        /// Canceles a buy/sell by refunding commodity/funds.
        /// </summary>
        /// <param name="id">The request id of the purchase/sell.</param>
        /// <returns>A boolean type variable validating the cancel.</returns>
        public bool SendCancelBuySellRequest(int id)
        {
            SimpleHTTPClient client = new SimpleHTTPClient();
            CancelBuySellRequest request = new CancelBuySellRequest("cancelBuySell", id);
            string token = SimpleCtyptoLibrary.CreateToken(User, PrivateKey);
            string response = client.SendPostRequest(Url, User, token, request);

            int a;
            if (!int.TryParse(response, out a))
            {
                if (response == "Id not found")
                    throw (new MarketException("The request ID was not found."));
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("You have successfully canceled the request.");
            Console.ResetColor();
            return true;
        }

        /// <summary>
        /// Describes a Sell/Purchase by given request id.
        /// </summary>
        /// <param name="id">The request id of the Purchase/Sell</param>
        /// <returns>Prints a description of the wanted Purchase/Sell, including information such as: commodity, price, amount, username and request type.</returns>
        public IMarketItemQuery SendQueryBuySellRequest(int id)
        {
            SimpleHTTPClient client = new SimpleHTTPClient();
            QueryBuySellRequest request = new QueryBuySellRequest(id, "queryBuySell");
            string token = SimpleCtyptoLibrary.CreateToken(User, PrivateKey);
            IMarketItemQuery response = client.SendPostRequest<QueryBuySellRequest, MarketItemQuery>(Url, User, token, request);
            return response;
        }

        /// <summary>
        /// Describes user information, including inventory, funds and active request ID's description.
        /// </summary>
        /// <returns>Prints a description of user information, including inventory, funds and active request ID's</returns>
        public IMarketUserData SendQueryUserRequest()
        {
            SimpleHTTPClient client = new SimpleHTTPClient();
            QueryUser request = new QueryUser("queryUser");
            string token = SimpleCtyptoLibrary.CreateToken(User, PrivateKey);
            IMarketUserData response = client.SendPostRequest<QueryUser, MarketUserData>(Url, User, token, request);
            return response;            
        }

        /// <summary>
        /// Offers best Bid price and best Ask price for a given commodity. 
        /// </summary>
        /// <param name="commodity">The wanted commidity id.</param>
        /// <returns>Prints the best bid price and best ask price for given commodity.</returns>
        public IMarketCommodityOffer SendQueryMarketRequest(int commodity)
        {
            SimpleHTTPClient client = new SimpleHTTPClient();
            QueryMarket request = new QueryMarket("queryMarket", commodity);
            string token = SimpleCtyptoLibrary.CreateToken(User, PrivateKey);
            IMarketCommodityOffer response= client.SendPostRequest<QueryMarket, MarketCommodityOffer>(Url, User, token, request);
            return response;
        }
    }
}
