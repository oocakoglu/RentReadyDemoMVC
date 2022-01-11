using RentReady.Sample.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentReady.Sample.Business.Abstract
{
    public interface ICardService
    {        
        void AddToCard(Card card, Product product);
        void RemoveFromCard(Card card, int productId);
        List<CardLine> List(Card card);
    }
}
