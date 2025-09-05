using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceAbstractionLayer.Helpers;
using ServiceAbstractionLayer.IServices;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Controller
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductController : ControllerBase
    {
        #region Dependency injection
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        #endregion

        
        #region Get All Product
        
        [HttpGet]
        [CachAttribute(300)]
        public async Task<ActionResult> GetAllProduct([FromQuery] int? BrandId, [FromQuery] int? TypeId)
        {
            var data = await _productService.GetAllProductAsync(BrandId, TypeId);

            return Ok(data);

        }
        #endregion



        #region Get Product Id
        [HttpGet("GetById/{Id}")]

        public async Task<ActionResult> GetProductByIdAsync(int? Id)
        {
            if (!ModelState.IsValid || Id == null)
                return BadRequest("The Id Not Valid");
            var data = await _productService.GetProductByIdAsync(Id.Value);
            return Ok(data);

        }
        #endregion



        #region Get All Product Brand
        [HttpGet("Brand")]
        public async Task<ActionResult> GetAllBrandAsync()
        {
            var data = await _productService.GetAllBrandAsync();
            return Ok(data);
        }
        #endregion


        #region Get All Product Type
        [HttpGet("Type")]
        public async Task<ActionResult> GetAllTypeAsync()
        {
            var data = await _productService.GetAllTypeAsync();
            return Ok(data);
        } 
        #endregion
    }


}
