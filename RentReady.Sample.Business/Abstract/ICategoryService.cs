using RentReady.Sample.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentReady.Sample.Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll();

        void Add(Category category);
        void Update(Category category);
        void Delete(int categoryId);
        Category GetById(int categoryId);
    }
}
