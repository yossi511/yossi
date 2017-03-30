namespace DAL.DataEntries
{
    public interface IMarketItemQuery
    {
        /// <summary>
        /// Returns price of item.
        /// </summary>
        /// <returns>Returns price of item.</returns>
        int getPrice();

        /// <summary>
        /// Return amount of item
        /// </summary>
        /// <returns>Returns amount.</returns>
        int getAmount();

        /// <summary>
        /// Return commodity id.
        /// </summary>
        /// <returns>Return commodity id.</returns>
        int getCommodity();

        /// <summary>
        /// Return user.
        /// </summary>
        /// <returns>Return user.</returns>
        string getUser();

        /// <summary>
        /// Return type of request.
        /// </summary>
        /// <returns>Return type of request.</returns>
        string getType();
    }
}