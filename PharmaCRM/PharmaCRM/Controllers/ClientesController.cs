﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PharmaCRM.Controllers
{
    public class ClientesController : ApiController
    {
        //
        // GET: /Clientes/
        [Route("api/clientes")]
        [HttpGet]
        public IEnumerable<Lib_Primavera.Model.Cliente> Get()
        {
            return Lib_Primavera.PriIntegration.ListaClientes();
        }


        // GET api/cliente/5    
        [Route("api/clientes/{id}")]
        [HttpGet]  
        public Lib_Primavera.Model.Cliente Get(string id)
        {
            Lib_Primavera.Model.Cliente cliente = Lib_Primavera.PriIntegration.GetCliente(id);
            if (cliente == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            else
            {
                return cliente;
            }
        }

        [Route("api/clientes")]
        [HttpPost]
        public HttpResponseMessage Post(Lib_Primavera.Model.Cliente cliente)
        {
            Lib_Primavera.Model.RespostaErro erro = new Lib_Primavera.Model.RespostaErro();
            erro = Lib_Primavera.PriIntegration.InsereClienteObj(cliente);

            if (erro.Erro == 0)
            {
                return Request.CreateResponse(HttpStatusCode.Created, cliente);
            }

            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, erro.Descricao);
            }

        }

        [Route("api/clientes/{id}")]
        [HttpPut]
        public HttpResponseMessage Put(Lib_Primavera.Model.Cliente cliente)
        {

            Lib_Primavera.Model.RespostaErro erro = new Lib_Primavera.Model.RespostaErro();

            try
            {
                erro = Lib_Primavera.PriIntegration.UpdCliente(cliente);
                if (erro.Erro == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, erro.Descricao);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, erro.Descricao);
                }
            }

            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, erro.Descricao);
            }
        }

        [Route("api/clientes/{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete(string id)
        {


            Lib_Primavera.Model.RespostaErro erro = new Lib_Primavera.Model.RespostaErro();

            try
            {

                erro = Lib_Primavera.PriIntegration.DelCliente(id);

                if (erro.Erro == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, erro.Descricao);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, erro.Descricao);
                }

            }

            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, erro.Descricao);

            }

        }

        [Route("api/clientes/{id}/encomendas")]
        [HttpGet]
        public IEnumerable<Lib_Primavera.Model.Encomenda> GetClienteEncomendas(string id)
        {
            return Lib_Primavera.PriIntegration.GetEncomendasCliente(id);
        }

        [Route("api/clientes/{id}/atividades")]
        [HttpGet]
        public IEnumerable<Lib_Primavera.Model.Atividade> GetClienteAtividades(string id)
        {
            return Lib_Primavera.PriIntegration.GetAtividadesCliente(id);
        }

        [Route("api/clientes/{id}/oportunidades")]
        [HttpGet]
        public IEnumerable<Lib_Primavera.Model.Oportunidade> GetClienteOportunidades(string id)
        {
            return Lib_Primavera.PriIntegration.GetOportunidadesCliente(id);
        }
    }
}
