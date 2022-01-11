using RentReady.Sample.Business.Abstract;
using RentReady.Sample.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RentReady.Sample.Business.Concrete
{

    public class CardService : ICardService
    {
        public void AddToCard(Card card, Product product)
        {
            CardLine cardLine = card.CardLines.FirstOrDefault(c => c.Product.ProductId == product.ProductId);
            if (cardLine != null)
            {
                cardLine.Quantity++;
                return;
            }
            card.CardLines.Add(new CardLine { Product = product, Quantity = 1 });
        }

        public void RemoveFromCard(Card card, int productId)
        {
            card.CardLines.Remove(card.CardLines.FirstOrDefault(c => c.Product.ProductId == productId));
        }


        public List<CardLine> List(Card card)
        {
            return card.CardLines;
        }

    }


}
