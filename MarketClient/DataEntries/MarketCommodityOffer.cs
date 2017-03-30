using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataEntries
{
    public class MarketCommodityOffer : IMarketCommodityOffer
    {
        public int bid;
        public int ask;

        /// <summary>
        /// Gets best ask price.
        /// </summary>
        /// <returns>Returns best ask price.</returns>
        public int getBestAskPrice()
        {
            return this.ask;
        }

        /// <summary>
        /// Gets best bid price.
        /// </summary>
        /// <returns>Returns best bid price</returns>
        public int getBestBidPrice()
        {
            return this.bid;
        }
    }
}
