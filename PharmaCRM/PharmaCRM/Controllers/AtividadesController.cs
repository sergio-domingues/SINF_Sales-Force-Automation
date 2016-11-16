using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PharmaCRM.Controllers
{
    public class AtividadesController : ApiController
    {
        public IEnumerable<Lib_Primavera.Model.Atividade> Get()
        {
            return PharmaCRM.Lib_Primavera.PriIntegration.GetListaAtividades();
        }

        public Lib_Primavera.Model.Atividade Get(string id)
        {
            return PharmaCRM.Lib_Primavera.PriIntegration.GetAtividade(id);
        }
    }
}
