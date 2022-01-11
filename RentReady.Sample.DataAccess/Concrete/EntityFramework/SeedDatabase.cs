using Microsoft.Extensions.DependencyInjection;
using RentReady.Sample.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RentReady.Sample.DataAccess.Concrete.EntityFramework
{
    public class SeedDatabase
    {
        //**I get sample datas https://rentready.com/turn-services website
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<RentReadyContext>();

            Category category1 = new Category
            {
                CategoryName = "Simple"
            };

            Category category2 = new Category
            {
                CategoryName = "Standart"
            };

            Category category3 = new Category
            {
                CategoryName = "Full"
            };

            Category category4 = new Category
            {
                CategoryName = "Additional Service"
            };

            if (!context.Categories.Any())
            {
                context.Categories.Add(category1);
                context.Categories.Add(category2);
                context.Categories.Add(category3);
            }

            Product product1 = new Product { CategoryId = 1, ProductName = "Paint", WorkDay = 5, UnitPrice = 500 };
            Product product2 = new Product { CategoryId = 1, ProductName = "Clean", WorkDay = 9, UnitPrice = 400 };


            Product product3 = new Product { CategoryId = 2, ProductName = "Carpet Clean", WorkDay = 7, UnitPrice = 700 };


            Product product4 = new Product { CategoryId = 3, ProductName = "Maintenance", WorkDay = 4, UnitPrice = 650 };

            Product product5 = new Product { CategoryId = 4, ProductName = "Tub Resurfacing", WorkDay = 3, UnitPrice = 800 };
            Product product6 = new Product { CategoryId = 4, ProductName = "Counter Resurfacing", WorkDay = 4, UnitPrice = 900 };
            Product product7 = new Product { CategoryId = 4, ProductName = "Wall Repair", WorkDay = 3, UnitPrice = 1100 };
            Product product8 = new Product { CategoryId = 4, ProductName = "Sanitization", WorkDay = 4, UnitPrice = 750 };



            if (!context.Products.Any())
            {
                context.Products.Add(product1);
                context.Products.Add(product2);
                context.Products.Add(product3);
                context.Products.Add(product4);
                context.Products.Add(product5);
                context.Products.Add(product6);
                context.Products.Add(product7);
                context.Products.Add(product8);
            }

        }
    }
}
