using Domain.Interfaces.Services;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    /// <summary>
    /// Controller clientes
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _service;

        /// <summary>
        /// Construtor da classe
        /// </summary>
        public ClientController(IClientService service)
        {
            _service = service;
        }

        /// <summary>
        /// Cadastro de clientes
        /// </summary>
        [HttpPost]
        public ActionResult Store(Client client)
        {
            try
            {
                return new JsonResult(_service.Store(client));
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message);
            }
        }

        /// <summary>
        /// Buscar todos clientes
        /// </summary>
        [HttpGet] 
        public ActionResult GetAll()
        {
            try
            {
                return new JsonResult(_service.GetAll());
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message);
            }
        }

        /// <summary>
        /// Busca cliente por ID
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public ActionResult GetById(string id)
        {
            try
            {
                return new JsonResult(_service.GetById(id));
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message);
            }
        }

        /// <summary>
        /// Alterar cliente por ID
        /// </summary>
        [HttpPut]
        [Route("{id}")]
        public ActionResult Update(string id, [FromBody] Client client)
        {
            try
            {
                return new JsonResult(_service.Update(id, client));
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message);
            }
        }

        /// <summary>
        /// Deleta um cliente por ID
        /// </summary>
        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(string id)
        {
            try
            {
                return new JsonResult(_service.Delete(id));
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message);
            }
        }
    }
}
