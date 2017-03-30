using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class BuyRequest
    {
        public string type;
        public int commodity;
        public int amount;
        public int price;

        /// <summary>
        /// Constructs a BuyRequest object with properties such as, type, commodity, amoun and price.
        /// That object represents a buy offer.
        /// </summary>
        /// <param name="type">Type of request</param>
        /// <param name="commodity">Commodity for purchase</param>
        /// <param name="amount">Amount of commodities for purchase</param>
        /// <param name="price">Price listed for purchase</param>
        public BuyRequest(string type,int commodity,int amount,int price)
        {
            this.type = type;
            this.price = price;
            this.amount = amount;
            this.commodity = commodity;
        }
        public int getPrice()
        {
            return this.price;
        }
        public int getAmount()
        {
            return this.amount;
        }
        public int getCommodity()
        {
            return this.commodity;
        }
        public string getType()
        {
            return this.type;
        }
    }
}
