using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class QueryUser
    {
        public string type;

        /// <summary>
        /// Query the server about the market state of a the login user.
        /// </summary>
        /// <param name="type">Request type</param>
        public QueryUser(string type)
        {
            this.type = type;
        }
        public string getType()
        {
            return this.type;
        }
    }
}
