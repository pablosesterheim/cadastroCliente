using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    /// <summary>
    /// Controller SKU
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SkuController : ControllerBase
    {
        private readonly ISkuService _service;

        /// <summary>
        /// Construtor da classe
        /// </summary>
        public SkuController(ISkuService service) { 
            _service = service;
        }
        /// <summary>
        /// Integra todos os SKU's aptos a serem integrados
        /// </summary>
        [HttpPost]
        [Authorize]
        public ActionResult StoreAll()
        {
            try
            {
                _service.StoreAll();
                return new JsonResult("OK");
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message);
            }
        }
        /// <summary>
        /// Integra todas especificação dos SKU's aptos a serem integrados
        /// </summary>
        [HttpPost]
        [Authorize]
        [Route("specification")]
        public ActionResult StoreSpecification()
        {
            try
            {
               _service.StoreSpecifications();
                return new JsonResult("OK");
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message);
            }
        }

        /// <summary>
        /// Integra todas EAN's dos SKU's aptos a serem integrados
        /// </summary>
        [HttpPost]
        [Authorize]
        [Route("ean")]
        public ActionResult StoreEans()
        {
            try
            {
                _service.StoreEans();
                return new JsonResult("OK");
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message);
            }
        }

        /// <summary>
        /// Integra todas as Fotos dos SKU's aptos a serem integrados
        /// </summary>
        [HttpPost]
        [Authorize]
        [Route("ean")]
        public ActionResult StoreImages()
        {
            try
            {
                //_service.StoreEans();
                return new JsonResult("OK");
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message);
            }
        }
    }
}