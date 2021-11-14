using Bootcamp.Workshop.Business.Engines.Models;
using Bootcamp.Workshop.Business.Engines.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.Workshop.Business.Engines.Interfaces
{
    public interface ICatalogEngine
    {
        List<ProductModel> GetProductList();
        List<ProductModel> GetProductList(ProductListRequestModel model);
        List<CategoryModel> GetCategoryList();
        double Sum(double a, double b);
    }
}
