using Bootcamp.Workshop.Business.Engines.Implementations;
using Bootcamp.Workshop.Business.Engines.Interfaces;
using Bootcamp.Workshop.Data.DAL;
using Bootcamp.Workshop.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bootcamp.Workshop.Business.Engines.Infrastructure
{
    public static class ServiceInitializer
    {
        public static void AddEngineLayer(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ConnStr");
            services.AddDbContext<EFContext>(opt => opt.UseSqlServer(connectionString));
            services.AddTransient<ICatalogEngine, CatalogEngine>();
            services.AddAutoMapper(typeof(AutoMapperConfig));
        }

        public static void SeedData(EFContext context)
        {
            if (!context.Categories.Any())
            {
                var categories = new List<Category>();
                categories.Add(new Category()
                {
                    Name = "Çay"
                });
                categories.Add(new Category()
                {
                    Name = "Kahve"
                });
                var products = GetProducts();
                var productImages = GetProductImages();
                var rnd = new Random();
                foreach (var category in categories)
                {
                    category.Products = new List<Product>();
                    for (int i = 0; i < 17; i++)
                    {
                        var product = new Product()
                        {
                            Name = products[0],
                            Picture = productImages[0],
                            Price = (decimal)(rnd.NextDouble() * 100)
                        };
                        category.Products.Add(product);
                        products.RemoveAt(0);
                        productImages.RemoveAt(0);
                    }
                    context.Add(category);
                }
                context.SaveChanges();
            }
        }

        private static List<string> GetProducts()
        {
            var products = new List<string>()
            {
                "Lipton Yellow Label Demlik Poşet 100*3,2 g",
                "Doğuş Black Label Demlik Poşet Çay 100*3,2 g",
                "Obaçay 3 kg",
                "Karali Premıum Filiz 500 g",
                "Çaykur Edt Altınbaş Çay 2 kg",
                "Obaçay Rize Sarı Kuşak Çay 1 kg",
                "Lipton Filiz Çay 1 kg",
                "Şölen Yeşil Çay Yayla Çayı Karışımı 250 g",
                "Obaçay Çayın Ustalarına Edt Demlik 100*25 g",
                "Doğuş Earl Grey Demlik Poşet Çay 100*3,2 g",
                "Lipton Extra Dem 25*2,5 g",
                "Lipton Doğu Karadeniz Demlik Poşet Çay 48*3,2 g",
                "Doğuş Avantaj Demlik Poşet Çay 35*30 g",
                "Doğuş Karadeniz Tiryaki Demlik Poşet 25*40 g",
                "Obaçay Karadeniz Çayı 500 g",
                "Çaykur Siyah Süzen Poşet Çay 100*2 g",
                "Karali Karadeniz Harman Çayı 1 kg",


                "Nescafe Classic 100 g",
                "Cafe Crown Latte Karamel Aromali 24*17 g",
                "Nescafe Crema Latte 24*17 g",
                "Nescafe Mocha 24*17,9 g",
                "Nescafe Gold Kavanoz 100 g",
                "Cafe Crown 3ü1 Arada Action 24*17 g",
                "Mehmet Efendi Colombian Filtre Kahve 80 g",
                "Cafe Crown 10*11 g",
                "Ülker Cafe Crown 40*17,5 g",
                "Nescafe Gold 50*2 g",
                "Jacobs Monarch Filtre Kahve 500 g",
                "Nescafe 2+1 Şekersiz 48*10 g",
                "Nescafe Gold 100 g",
                "Bizz Cafe Klasik 100 g",
                "Mehmet Efendi Espresso Kavrulmuş Çekirdek Kahve 1 kg",
                "Nescafe 3Ü1 Arada Extra 48*16,5 g",
                "Mahmood Coffee 48*18 g"
            };
            return products;
        }

        private static List<string> GetProductImages()
        {
            var images = new List<string>()
            {
                "https://img-bizimtoptan.mncdn.com/Content/Images/Thumbs/0967776.png",
                "https://img-bizimtoptan.mncdn.com/Content/Images/Thumbs/0969506.jpeg",
                "https://img-bizimtoptan.mncdn.com/Content/Images/Thumbs/0965292.png",
                "https://img-bizimtoptan.mncdn.com/Content/Images/Thumbs/0969721.jpeg",
                "https://img-bizimtoptan.mncdn.com/Content/Images/Thumbs/0969993.jpeg",
                "https://img-bizimtoptan.mncdn.com/Content/Images/Thumbs/0967229.jpeg",
                "https://img-bizimtoptan.mncdn.com/Content/Images/Thumbs/0968533.jpeg",
                "https://img-bizimtoptan.mncdn.com/Content/Images/Thumbs/0966252.jpeg",
                "https://img-bizimtoptan.mncdn.com/Content/Images/Thumbs/0965575.jpeg",
                "https://img-bizimtoptan.mncdn.com/Content/Images/Thumbs/0965264.jpeg",
                "https://img-bizimtoptan.mncdn.com/Content/Images/Thumbs/0968778.jpeg",
                "https://img-bizimtoptan.mncdn.com/Content/Images/Thumbs/0966529.png",
                "https://img-bizimtoptan.mncdn.com/Content/Images/Thumbs/0966069.jpeg",
                "https://img-bizimtoptan.mncdn.com/Content/Images/Thumbs/0966051.jpeg",
                "https://img-bizimtoptan.mncdn.com/Content/Images/Thumbs/0584966_obacay-karadeniz-cayi-500-g.png",
                "https://img-bizimtoptan.mncdn.com/Content/Images/Thumbs/0967666.png",
                "https://img-bizimtoptan.mncdn.com/Content/Images/Thumbs/0966895.png",


                "https://img-bizimtoptan.mncdn.com/Content/Images/Thumbs/0968620.jpeg",
                "https://img-bizimtoptan.mncdn.com/Content/Images/Thumbs/0966329.png",
                "https://img-bizimtoptan.mncdn.com/Content/Images/Thumbs/0966090.jpeg",
                "https://img-bizimtoptan.mncdn.com/Content/Images/Thumbs/0966119.jpeg",
                "https://img-bizimtoptan.mncdn.com/Content/Images/Thumbs/0968671.png",
                "https://img-bizimtoptan.mncdn.com/Content/Images/Thumbs/0969769.jpeg",
                "https://img-bizimtoptan.mncdn.com/Content/Images/Thumbs/0965173.jpeg",
                "https://img-bizimtoptan.mncdn.com/Content/Images/Thumbs/0968627.jpeg",
                "https://img-bizimtoptan.mncdn.com/Content/Images/Thumbs/0967043.jpeg",
                "https://img-bizimtoptan.mncdn.com/Content/Images/Thumbs/0969696.png",
                "https://img-bizimtoptan.mncdn.com/Content/Images/Thumbs/0967231.jpeg",
                "https://img-bizimtoptan.mncdn.com/Content/Images/Thumbs/0969559.png",
                "https://img-bizimtoptan.mncdn.com/Content/Images/Thumbs/0968726.png",
                "https://img-bizimtoptan.mncdn.com/Content/Images/Thumbs/0969359.png",
                "https://img-bizimtoptan.mncdn.com/Content/Images/Thumbs/0970225.jpeg",
                "https://img-bizimtoptan.mncdn.com/Content/Images/Thumbs/0967838.jpeg",
                "https://img-bizimtoptan.mncdn.com/Content/Images/Thumbs/0968560.jpeg"
            };
            return images;
        }
    }
}
