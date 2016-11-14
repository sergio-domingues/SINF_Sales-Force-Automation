using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PharmaCRM.Models
{
    public class Actividade
    {
        //todo ENUM for attr type

        public string name
        {
            get;
            set;
        }

        public string type
        {
            get;
            set;
        }

        public bool finished
        {
            get;
            set;
        }

        public string sales_rep 
        {
            get;
            set;
        }

        public string address
        {
            get;
            set;
        }
    }
}
