using RentReady.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentReady.Sample.Entities.Concrete
{
    public class Category : IEntity
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }
    }

}
