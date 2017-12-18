using GuiaRestaurante.Dominio.Comando.RestauranteComando;
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
    public class RestauranteController : BaseController
    {
        private readonly IRestauranteServico _service;

        public RestauranteController(IRestauranteServico service)
        {
            this._service = service;
        }

        [HttpPost]
        [Route("api/restaurante/create/")]
        public Task<HttpResponseMessage> PostCad([FromBody]dynamic body) // Cadastrar os restaurantes
        {
            var response = new HttpResponseMessage();
            try
            {
                var restauranteExiste = _service.GetOne((string)body.nome);
                try
                {
                    if (restauranteExiste.Nome.Equals((string)body.nome))
                    {
                        response = Request.CreateResponse(HttpStatusCode.OK, "Este restaurante já esta cadastrado!");
                    }
                }
                catch
                {
                    var command = new RegistrarRestauranteComando(
                    nome: (string)body.nome,
                    telefone: (string)body.telefone,
                    bairro: (string)body.bairro,
                    rua: (string)body.rua,
                    numero: (int)body.numero
                    );

                    var restaurante = _service.Create(command);

                    return CreateResponse(HttpStatusCode.Created, restaurante);
                }

            }
            catch
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, "Não foi criado o restaurante!");
            }
            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }

        [HttpGet]
        [Route("api/restaurante/getOne/{nome}")]
        public Task<HttpResponseMessage> GetOne(string nome) // retorna restaurante por nome
        {
            var response = new HttpResponseMessage();
            try
            {
                var restaurante = _service.GetOne(nome);
                response = Request.CreateResponse(HttpStatusCode.OK, restaurante);
            }
            catch
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, "Procura por restaurante não encontrada!");
            }
            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }

        [HttpGet]
        [Route("api/restaurante/getAll/")]
        public Task<HttpResponseMessage> GetAll() // Retorna todos os restaurantes
        {
            var response = new HttpResponseMessage();
            try
            {
                var restaurante = _service.GetAll();
                response = Request.CreateResponse(HttpStatusCode.OK, restaurante);
            }
            catch
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, "Nenhum restaurante encontrado!");
            }
            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;

        }
        

        [HttpPut]
        [Route("api/restaurante/update/")]
        public Task<HttpResponseMessage> Put([FromBody]dynamic body) // Atualiza restaurante
        {
          //  var restauranteUpdate = _service.GetOne((string)body.nomeOld);

            var response = new HttpResponseMessage();
            try
            {
                var command = new AtualizarRestauranteComando(
                    restauranteId: (int)body.id,
                    nome: (string)body.nome,
                    telefone: (string)body.telefone,
                    bairro: (string)body.bairro,
                    rua: (string)body.rua,
                    numero: (int)body.numero
                );

                var restaurante = _service.Update(command);
                response = Request.CreateResponse(HttpStatusCode.OK, "Atualizado com sucesso!");
            }
            catch
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, "Não foi Atualizado o restaurante!");
            }
            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }

        [HttpDelete]
        [Route("api/restaurante/deleta/{nome}")]
        public Task<HttpResponseMessage> delete(string nome) // Deleta o restaurante
        {
            var response = new HttpResponseMessage();
            try
            {
                var command = new DeletarRestauranteComando(nome);

                var restaurante = _service.Delete(command);

                response = Request.CreateResponse(HttpStatusCode.OK, "Apagado com sucesso!");
            }
            catch
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, "Restaurante não encontrado!");
            }
            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;

        }
    }
}