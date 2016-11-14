using PharmaCRM.Models;
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
        public Lib_Primavera.Models.Atividade Get(string id)
        {
            return PharmaCRM.Lib_Primavera.PriIntegration.GetActividade(string id);
        }
    }
}
