using PharmaCRM.Lib_Primavera.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PharmaCRM.Controllers
{
    public class AuthenticationController : ApiController
    {
        // GET: api/Authentication
        [Route("api/authentication")]
        [HttpGet]
        public IEnumerable<string> Get()
        {
            throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
        }

        // GET: api/Authentication/5
        [Route("api/authentication/{id}")]
        [HttpGet]
        public string Get(int id)
        {
            throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
        }

        // POST: api/Authentication
        /*
         {
            "Email":"admin@ad.min",
            "Password":"123456"
         }
         */
        [Route("api/authentication")]
        [HttpPost]
        public string Post([FromBody]AuthPair auth)
        {
            if (auth == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest));
            }
            return Lib_Primavera.PharmaCRM.isCorrectPassword(auth.Email, auth.Password);
        }

        // PUT: api/Authentication/5
        [Route("api/authentication/{id}")]
        [HttpPut]
        public void Put(int id, [FromBody]string value)
        {
            throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
        }

        // DELETE: api/Authentication/5
        [Route("api/authentication/{id}")]
        [HttpDelete]
        public void Delete(int id)
        {
            throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
        }
    }
}
