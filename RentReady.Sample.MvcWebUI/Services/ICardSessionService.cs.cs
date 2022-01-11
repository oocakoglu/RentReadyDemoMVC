using RentReady.Sample.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentReady.Sample.MvcWebUI.Services
{
    public interface ICardSessionService
    {
        Card GetCard();
        void SetCard(Card card);

    }
}
