using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataEntries
{
    public class MarketUserData : IMarketUserData
    {
        public Dictionary<string, int> commodities;
        public double funds;
        public List<int> requests;

        /// <summary>
        /// Returns funds.
        /// </summary>
        /// <returns>Returns funds.</returns>
        public double getFunds()
        {
            return this.funds;
        }

        /// <summary>
        /// Returns dictionary of commodities and amounts of each.
        /// </summary>
        /// <returns>Returns dictionary of commodities and amounts of each.</returns>
        public Dictionary<string,int> getCommodities()
        {
            return this.commodities;
        }

        /// <summary>
        /// Returns a list representing all the request id's.
        /// </summary>
        /// <returns>Returns a list representing all the request id's.</returns>
        public List<int> getRequests()
        {
            return this.requests;
        }
    }
}
