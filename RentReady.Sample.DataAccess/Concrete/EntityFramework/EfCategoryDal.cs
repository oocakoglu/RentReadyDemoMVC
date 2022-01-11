using RentReady.Core.DataAccess.EntityFramework;
using RentReady.Sample.DataAccess.Abstract;
using RentReady.Sample.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentReady.Sample.DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category, RentReadyContext>, ICategoryDal
    {

    }
}
