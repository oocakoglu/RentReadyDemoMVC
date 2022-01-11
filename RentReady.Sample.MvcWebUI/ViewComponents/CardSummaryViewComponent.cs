using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using RentReady.Sample.MvcWebUI.Models;
using RentReady.Sample.MvcWebUI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentReady.Sample.MvcWebUI.ViewComponents
{
    public class CardSummaryViewComponent : ViewComponent
    {
        private ICardSessionService _cardSessionService;

        public CardSummaryViewComponent(ICardSessionService cardSessionService)
        {
            _cardSessionService = cardSessionService;
        }

        public ViewViewComponentResult Invoke()
        {
            var model = new CardSummaryViewModel
            {
                Card = _cardSessionService.GetCard()
            };
            return View(model);
        }

    }
}
