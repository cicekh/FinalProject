using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            //swagger Apiler için hazır dokümantasyonlar veren bir yapıdır.
            // dependency chain
            // IProductService productService = new ProductManager(new EfProductDal());


            var result = _categoryService.GetAll();


            if (result.Success)
            {   
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
