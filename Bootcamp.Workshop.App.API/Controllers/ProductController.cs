using Bootcamp.Workshop.Business.Engines.Implementations;
using Bootcamp.Workshop.Business.Engines.Interfaces;
using Bootcamp.Workshop.Business.Engines.Models;
using Bootcamp.Workshop.Business.Engines.Models.RequestModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bootcamp.Workshop.App.API.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : Controller
    {
        private readonly ICatalogEngine _catalogEngine;
        public ProductController(ICatalogEngine catalogEngine)
        {
            _catalogEngine = catalogEngine;
        }
        [HttpGet]
        public List<ProductModel> Get()
        {
            var data = _catalogEngine.GetProductList();
            return data;
        }
        [HttpPost]
        public List<ProductModel> Post(ProductListRequestModel model)
        {
            var data = _catalogEngine.GetProductList(model);
            return data;
        }
    }
}
