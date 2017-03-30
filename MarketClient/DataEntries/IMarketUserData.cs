using System.Collections.Generic;

namespace DAL.DataEntries
{
    public interface IMarketUserData
    {
        /// <summary>
        /// Returns dictionary of commodities and amounts of each.
        /// </summary>
        /// <returns>Returns dictionary of commodities and amounts of each.</returns>
        Dictionary<string,int> getCommodities();

        /// <summary>
        /// Returns funds.
        /// </summary>
        /// <returns>Returns funds.</returns>
        double getFunds();

        /// <summary>
        /// Returns a list representing all the request id's.
        /// </summary>
        /// <returns>Returns a list representing all the request id's.</returns>
        List<int> getRequests();

    }
}