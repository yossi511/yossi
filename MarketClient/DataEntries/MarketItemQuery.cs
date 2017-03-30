using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataEntries
{
    public class MarketItemQuery : IMarketItemQuery
    {
        public int price;
        public int amount;
        public int commodity;
        public string type;
        public string user;

        /// <summary>
        /// Returns price of item.
        /// </summary>
        /// <returns>Returns price of item.</returns>
        public int getPrice()
        {
            return this.price;
        }

        /// <summary>
        /// Return amount of item
        /// </summary>
        /// <returns>Returns amount.</returns>
        public int getAmount()
        {
            return this.amount;
        }

        /// <summary>
        /// Return commodity id.
        /// </summary>
        /// <returns>Return commodity id.</returns>
        public int getCommodity()
        {
            return this.commodity;
        }

        /// <summary>
        /// Return user.
        /// </summary>
        /// <returns>Return user.</returns>
        public string getUser()
        {
            return this.user;
        }

        /// <summary>
        /// Return type of request.
        /// </summary>
        /// <returns>Return type of request.</returns>
        public string getType()
        {
            return this.type;
        }
    }
}
