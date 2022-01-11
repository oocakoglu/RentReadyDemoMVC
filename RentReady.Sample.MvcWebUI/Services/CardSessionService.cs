using Microsoft.AspNetCore.Http;
using RentReady.Sample.Entities.Concrete;
using RentReady.Sample.MvcWebUI.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentReady.Sample.MvcWebUI.Services
{
    public class CardSessionService : ICardSessionService
    {
        private IHttpContextAccessor _httpContextAccessor;

        public CardSessionService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Card GetCard()
        {
            Card cardToCheck = _httpContextAccessor.HttpContext.Session.GetObject<Card>("card");
            if (cardToCheck == null)
            {
                _httpContextAccessor.HttpContext.Session.SetObject("card", new Card());
                cardToCheck = _httpContextAccessor.HttpContext.Session.GetObject<Card>("card");
            }

            return cardToCheck;
        }

        public void SetCard(Card card)
        {
            _httpContextAccessor.HttpContext.Session.SetObject("card", card);
        }
    }
}
