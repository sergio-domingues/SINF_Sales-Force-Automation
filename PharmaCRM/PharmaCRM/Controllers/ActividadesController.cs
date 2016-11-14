using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PharmaCRM.Controllers
{
    public class ActividadesController : ApiController
    {
        public Lib_Primavera.Model.Actividade Get(string id)
        {
            return PharmaCRM.Lib_Primavera.PriIntegration.GetActividade(id);
        }
    }
}
