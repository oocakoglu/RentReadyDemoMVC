using RentReady.Core.DataAccess;
using RentReady.Sample.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentReady.Sample.DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
        
    }


}
