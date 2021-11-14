using AutoMapper;
using Bootcamp.Workshop.Business.Engines.Interfaces;
using Bootcamp.Workshop.Business.Engines.Models;
using Bootcamp.Workshop.Business.Engines.Models.RequestModels;
using Bootcamp.Workshop.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.Workshop.Business.Engines.Implementations
{
    public class CatalogEngine : ICatalogEngine
    {
        private readonly EFContext _context;
        private readonly IMapper _mapper;
        public CatalogEngine(EFContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<CategoryModel> GetCategoryList()
        {
            var allCategories = _context.Categories.ToList();
            var categoryModels = allCategories.Select(p => _mapper.Map<CategoryModel>(p)).ToList();
            return categoryModels;
        }

        public List<ProductModel> GetProductList()
        {
            var allProducts = _context.Products.ToList();
            /*
            var productModels = allProducts.Select(p => new ProductModel()
            {
                Name = p.Name,
                Price = p.Price,
                Picture = p.Picture
            }).ToList();
            */
            var productModels = allProducts.Select(p => _mapper.Map<ProductModel>(p)).ToList();
            return productModels;
        }
        public List<ProductModel> GetProductList(ProductListRequestModel model )
        {
            var allProducts = _context.Products.AsQueryable();
            if (model.CategoryId > 0)
            {
                allProducts = allProducts.Where(q => q.CategoryId == model.CategoryId);
            }
            if (model.OrderBy != null)
            {
                switch (model.OrderBy)
                {
                    case OrderBy.PriceAsc:
                        allProducts = allProducts.OrderBy(q => q.Price);
                        break;
                    case OrderBy.PriceDesc:
                        allProducts = allProducts.OrderByDescending(q => q.Price);
                        break;
                }
            }
            var products = allProducts.Skip((model.PageIndex - 1) * model.PageSize).Take(model.PageSize).ToList();
            var productModels = products.Select(p => _mapper.Map<ProductModel>(p)).ToList();
            return productModels;
        }

        public double Sum(double a, double b)
        {
            return a + b;
        }
    }
}
