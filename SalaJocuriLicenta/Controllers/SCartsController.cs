using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalaJocuriLicenta.Data;
using SalaJocuriLicenta.Models;
using SalaJocuriLicenta.Repository;
using SalaJocuriLicenta.ViewModels;

namespace SalaJocuriLicenta.Controllers
{
    public class SCartsController : Controller
    {
        private readonly ApplicationDbContext _context;
        
        private readonly IProductRepository _productRepository;
        private readonly SCart _sCart;

        public SCartsController(ApplicationDbContext context, IProductRepository productRepository, SCart sCart)
        {
            _context = context;
            _productRepository = productRepository;
            _sCart = sCart;
        }

        // GET: SCarts
        public ViewResult Index()
        {
            var items = _sCart.GetShoppingCartItems();
            _sCart.SCartItems = items;

            var sCVM = new SCartViewModel
            {
                SCart = _sCart,
                SCartTotal = _sCart.GetShoppingCartTotal()
            };

            return View(sCVM);
        }


        public RedirectToActionResult AddToShoppingCart(int productId)
        {
            var selectedProduct = _productRepository.Products.FirstOrDefault(p => p.ProductId == productId);
            if (selectedProduct != null)
            {
                _sCart.AddToCart(selectedProduct, 1);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int productId)
        {
            var selectedProduct = _productRepository.Products.FirstOrDefault(p => p.ProductId == productId);
            if (selectedProduct != null)
            {
                _sCart.RemoveFromCart(selectedProduct);
            }
            return RedirectToAction("Index");
        }
    }
}
