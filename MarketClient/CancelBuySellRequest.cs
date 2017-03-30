using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class CancelBuySellRequest
    {
        public string type;
        public int id;

        /// <summary>
        /// Constructs a CancelBuySellRequest, has request id and request type of a request to cancel.
        /// </summary>
        /// <param name="type">Request Type of request to cancel.</param>
        /// <param name="id">Request Id of request to cancel.</param>
        public CancelBuySellRequest(string type,int id)
        {
            this.type = type;
            this.id = id;
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
