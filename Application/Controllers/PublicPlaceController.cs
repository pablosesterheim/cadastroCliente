using Domain.Interfaces.Services;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    /// <summary>
    /// Controller Public Places
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PublicPlaceController : ControllerBase
    {
        private readonly IPublicPlaceService _service;

        PublicPlaceController(IPublicPlaceService service)
        {
            _service = service;
        }

    

        /// <summary>
        /// Cadastro de Logradouros
        /// </summary>
        [HttpPost]
        public ActionResult Store(PublicPlace publicPlace)
        {
            try
            {
                return new JsonResult(_service.Store(publicPlace));
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message);
            }
        }
    }
}
