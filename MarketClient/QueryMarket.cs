using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class QueryMarket
    {
        public string type;
        public int commodity; 

        /// <summary>
        /// Query the server about a commodity
        /// </summary>
        /// <param name="type">Request type</param>
        /// <param name="commodity">Commodity Id</param>
        public QueryMarket(string type,int commodity)
        {
            this.commodity = commodity;
            this.type = type;
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
