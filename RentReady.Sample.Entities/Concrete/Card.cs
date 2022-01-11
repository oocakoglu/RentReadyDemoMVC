using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RentReady.Sample.Entities.Concrete
{
    public class Card
    {
        public Card()
        {
            CardLines = new List<CardLine>();
        }

        public List<CardLine> CardLines { get; set; }

        public decimal Total
        {
            get { return CardLines.Sum(q => q.Product.UnitPrice * q.Quantity); }
        }

    }
}
