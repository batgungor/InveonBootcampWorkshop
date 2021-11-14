using Bootcamp.Workshop.Business.Engines.Implementations;
using Bootcamp.Workshop.Business.Engines.Interfaces;
using Bootcamp.Workshop.Business.Engines.Models;
using Bootcamp.Workshop.Business.Engines.Models.RequestModels;
using Bootcamp.Workshop.Data.DAL;
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
        private readonly IBardak _bardak;
        public CategoryController(
            ICatalogEngine catalogEngine,
            IBardak bardak)
        {
            _catalogEngine = catalogEngine;
            _bardak = bardak;
        }
        [HttpGet]
        public List<CategoryModel> Get()
        {
            var result = _bardak.Drink();
            var data = _catalogEngine.GetCategoryList();
            return data;
        }
    }
}
