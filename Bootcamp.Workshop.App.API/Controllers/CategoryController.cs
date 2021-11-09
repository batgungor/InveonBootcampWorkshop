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
    [Route("api/categories")]
    public class CategoryController : Controller
    {
        private readonly ICatalogEngine _catalogEngine;
        public CategoryController(ICatalogEngine catalogEngine)
        {
            _catalogEngine = catalogEngine;
        }
        [HttpGet]
        public List<CategoryModel> Get()
        {
            var data = _catalogEngine.GetCategoryList();
            return data;
        }
    }
}
