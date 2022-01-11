using Microsoft.AspNetCore.Mvc;
using RentReady.Sample.Business.Abstract;
using RentReady.Sample.Entities.Concrete;
using RentReady.Sample.MvcWebUI.Models;
using RentReady.Sample.MvcWebUI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentReady.Sample.MvcWebUI.Controllers
{
    public class CardController : Controller
    {
        private ICardSessionService _cardSessionService;
        private ICardService _cardService;
        private IProductService _productService;

        public CardController(
            ICardSessionService cardSessionService,
            ICardService cardService,
            IProductService productService)
        {
            _cardSessionService = cardSessionService;
            _cardService = cardService;
            _productService = productService;
        }

        public ActionResult AddToCard(int productId)
        {
            var productToBeAdded = _productService.GetById(productId);

            var card = _cardSessionService.GetCard();

            _cardService.AddToCard(card, productToBeAdded);

            _cardSessionService.SetCard(card);

            //**(TempData) data move for one request
            TempData.Add("message", String.Format("Your product, {0}, was successfully added to the cart!", productToBeAdded.ProductName));

            return RedirectToAction("Index", "Product");
        }

        public ActionResult List()
        {
            var card = _cardSessionService.GetCard();
            CardListViewModel cardListViewModel = new CardListViewModel
            {
                Card = card
            };
            return View(cardListViewModel);
        }

        public ActionResult Remove(int productId)
        {
            var card = _cardSessionService.GetCard();
            _cardService.RemoveFromCard(card, productId);
            _cardSessionService.SetCard(card);
            TempData.Add("message", String.Format("Your product was successfully removed from the cart!"));
            return RedirectToAction("List");
            //**self redirect
        }


        public ActionResult Complete()
        {
            var shippingDetailsViewModel = new ShippingDetailsViewModel
            {
                ShippingDetails = new ShippingDetails()
            };
            return View(shippingDetailsViewModel);
        }

        [HttpPost]
        public ActionResult Complete(ShippingDetails shippingDetails)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            TempData.Add("message", String.Format("Thank you {0}, you order is in process", shippingDetails.FirstName));
            return View();
        }
    }
}
