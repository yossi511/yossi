using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class SellRequest
    {
        public string type;
        public int commodity;
        public int amount;
        public int price;

        /// <summary>
        /// Constructs a SellRequest object with properties such as, type, commodity, amoun and price.
        /// That object represents a sell offer.
        /// </summary>
        /// <param name="type">Type of request</param>
        /// <param name="commodity">Commodity for sale</param>
        /// <param name="amount">Amount of commodities for sale</param>
        /// <param name="price">Price listed for sale</param>
        public SellRequest(string type, int commodity, int amount, int price)
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
