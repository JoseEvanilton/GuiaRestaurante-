﻿using GuiaRestaurante.Dominio.Comando.PratoComando;
using GuiaRestaurante.Dominio.Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace GuiaRestaurante.Api.Controllers
{
    public class PratoController : BaseController
    {
        private readonly IPratoServico _service;
        private readonly IRestauranteServico _serviceRestaurante;

        public PratoController(IPratoServico service, IRestauranteServico serviceRestaurante)
        {
            this._service = service;
            this._serviceRestaurante = serviceRestaurante;
        }

        [HttpPost]
        [Route("api/pratos/create/")]
        public Task<HttpResponseMessage> PostCad([FromBody]dynamic body) // Cadastra os pratos
        {
            var response = new HttpResponseMessage();
            try
            {
                var pratoExiste = _service.GetOne((string)body.nome);
                try
                {
                    if (pratoExiste.Nome.Equals((string)body.nome))
                    {
                        response = Request.CreateResponse(HttpStatusCode.OK, "Este prato já esta cadastrado!");
                    }
                }
                catch
                {
                    var restaurante = _serviceRestaurante.GetOne((string)body.restaurante);

                    var command = new RegistrarPratoComando(
                    nome: (string)body.nome,
                    preco: (string)body.preco,
                    restauranteId: restaurante.RestauranteId
                    );

                    var pratos = _service.Create(command);

                    return CreateResponse(HttpStatusCode.Created, pratos);
                }

            }
            catch
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, "Não foi criado o prato!");
            }
            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }

        [HttpGet]
        [Route("api/pratos/getAll/{restaurante}")]
        public Task<HttpResponseMessage> GetAll(string restaurante) // Retorna todos os pratos do restaurante
        {
            var response = new HttpResponseMessage();
            try
            {
                var prato = _service.GetAll(restaurante);
                response = Request.CreateResponse(HttpStatusCode.OK, prato);
            }
            catch
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, "Procura por prato não encontrada!");
            }
            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;

        }

        [HttpGet]
        [Route("api/pratos/getOne/{prato}")]
        public Task<HttpResponseMessage> GetOne(string prato) // Retorna todos os usuários
        {
            var response = new HttpResponseMessage();
            try
            {
                var pratos = _service.GetOne(prato);
                response = Request.CreateResponse(HttpStatusCode.OK, pratos);
            }
            catch
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, "Procura por prato não encontrada!");
            }
            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;

        }

        [HttpGet]
        [Route("api/pratos/getPrato/{restaurante},{prato}")]
        public Task<HttpResponseMessage> GetPrato(string restaurante, string prato) // Retorna todos os usuários
        {
            var response = new HttpResponseMessage();
            try
            {
                var pratos = _service.GetPrato(restaurante, prato);
                response = Request.CreateResponse(HttpStatusCode.OK, pratos);
            }
            catch
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, "Procura por prato não encontrada!");
            }
            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;

        }

        [HttpPut]
        [Route("api/pratos/update/")]
        public Task<HttpResponseMessage> Put([FromBody]dynamic body) // Atualiza restaurante
        {
            //var pratoUpdate = _service.GetOne((string)body.nomeOld);

            var response = new HttpResponseMessage();
            try
            {
                var command = new AtualizarPratoComando(
                    pratoId: (int)body.id,
                    nome: (string)body.nome,
                    preco: (string)body.preco
                );

                var pratos = _service.Update(command);
                response = Request.CreateResponse(HttpStatusCode.OK, "Atualizado com sucesso!");
            }
            catch
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, "Não foi Atualizado o prato!");
            }
            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }

        [HttpDelete]
        [Route("api/pratos/deleta/{nome}")]
        public Task<HttpResponseMessage> delete(string nome) // Deleta o restaurante
        {
            var response = new HttpResponseMessage();
            try
            {
                var command = new DeletarPratoComando(nome);

                var pratos = _service.Delete(command);

                response = Request.CreateResponse(HttpStatusCode.OK, "Apagado com sucesso!");
            }
            catch
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, "Prato não encontrado!");
            }
            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;

        }
    }
}