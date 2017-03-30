namespace DAL.DataEntries
{
    public interface IMarketCommodityOffer
    {
        /// <summary>
        /// Returns the best ask price for given commodity.
        /// </summary>
        /// <returns>Returns the best ask price for given commodity.</returns>
        int getBestAskPrice();
        /// <summary>
        /// Returns the best bid price for given commodity.
        /// </summary>
        /// <returns>Returns the best bid price for given commodity.</returns>
        int getBestBidPrice();
    }
}
