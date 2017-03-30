using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class QueryBuySellRequest
    {
        public int id;
        public string type;

        /// <summary>
        /// Constructs a Buy/Sell request object, that has its own request Id and request type.
        /// </summary>
        /// <param name="id">Id of the request</param>
        /// <param name="type">Type of request (Buy/Sell)</param>
        public QueryBuySellRequest (int id, string type)
        {
            this.id = id;
            this.type = type;
        }

        public int getId()
        {
            return this.id;
        }
        public string getType()
        {
            return this.type;
        }
    }

}
