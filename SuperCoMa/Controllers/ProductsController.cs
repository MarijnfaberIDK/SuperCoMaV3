using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SuperCoMa.Areas.Admin.Models;
using SuperCoMa.Data;
using Microsoft.AspNetCore.Http;
using SuperCoMa.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

namespace SuperCoMa.Controllers
{

    public class ProductsController : Controller
    {


        private string _baseUrl;
        ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
            _baseUrl = "https://supermaco.starwave.nl/api/";
        }

        private dynamic GetData(string path)
        {

            var request = WebRequest.Create(_baseUrl + path);
            request.Method = "GET";
            request.ContentType = "application/xml; charset=utf-8";

            using (var response = request.GetResponse())
            {
                using (var streamReader = new StreamReader(response.GetResponseStream()))
                {
                    return streamReader.ReadToEnd();
                }
            }

        }


        // GET: Products
        public async Task<IActionResult> Index()
        {

            //XmlDocument xml = new XmlDocument();
            //xml.Load("https://supermaco.starwave.nl/api/products");

            //XmlElement root = xml.DocumentElement;
            //XmlNodeList nodes = root.SelectNodes("Product");


            //foreach (XmlNode node in nodes)
            //{
            //    var productId = Convert.ToInt32(node.Attributes["Id"].Value);
            //    var productExists = _context.ProductsModel.Where(p => p.ProductId == productId).FirstOrDefault();

            //    if (productExists == null)
            //    {
            //        var product = new ProductsModel
            //        {
            //            ProductId = productId,
            //            EAN = node["EAN"].InnerText,
            //            Title = node["Title"].InnerText,
            //            Brand = node["Brand"].InnerText,
            //            ShortDescription = node["Shortdescription"].InnerText,
            //            FullDescription = node["Fulldescription"].InnerText,
            //            Image = node["Image"].InnerText,
            //            Weight = Double.Parse(node["Weight"].InnerText),
            //            Price = Double.Parse(node["Price"].InnerText),
            //            Category = node["Category"].InnerText,
            //            SubCategory = node["Subcategory"].InnerText,
            //            SubSubCategory = node["Subsubcategory"].InnerText
            //        };
            //        //Add Student object into Students DBset
            //        _context.ProductsModel.Add(product);
            //    }

            //    // call SaveChanges method to save student into database
            //    _context.SaveChanges();
            //}







            return View(await _context.ProductsModel.ToListAsync());

        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productsModel = await _context.ProductsModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productsModel == null)
            {
                return NotFound();
            }

            return View(productsModel);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductID,EAN,Title,Brand,ShortDescription,FullDescription,Image,Weight,Price,Category,SubCategory,SubSubCategory")] ProductsModel productsModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productsModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productsModel);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productsModel = await _context.ProductsModel.FindAsync(id);
            if (productsModel == null)
            {
                return NotFound();
            }
            return View(productsModel);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductID,EAN,Title,Brand,ShortDescription,FullDescription,Image,Weight,Price,Category,SubCategory,SubSubCategory")] ProductsModel productsModel)
        {
            if (id != productsModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productsModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductsModelExists(productsModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(productsModel);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productsModel = await _context.ProductsModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productsModel == null)
            {
                return NotFound();
            }

            return View(productsModel);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productsModel = await _context.ProductsModel.FindAsync(id);
            _context.ProductsModel.Remove(productsModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductsModelExists(int id)
        {
            return _context.ProductsModel.Any(e => e.Id == id);
        }

        public IActionResult AddToCart(int id)
        {
            //add cart  
            List<CartItem> cart = new List<CartItem>();


            //if alive add existing cart
            string cartString = HttpContext.Session.GetString("cart");

            if (cartString != null)
            {
                cart = JsonConvert.DeserializeObject<List<CartItem>>(cartString);
            }

            //add product to cart
            //new cart in session & check if product is in cart

            cartString = JsonConvert.SerializeObject(cart);
            HttpContext.Session.SetString("cart", cartString);

            CartItem item = cart.Find(c => c.ProductId == id);
            if (item != null)
            {
                item.Amount++;
            }

            if (item == null)
            {
                cart.Add(item);
            }

            return View("Index", _context.ProductsModel.ToList());
        }

        public IActionResult Cart()
        {
            List<CartItem> cart = new List<CartItem>();

            string cartString = HttpContext.Session.GetString("cart");
            if (cartString != null)
            {
                cart = JsonConvert.DeserializeObject<List<CartItem>>(cartString);
            }

            //List<CartItemViewModel> list = new List<CartItemViewModel>(); //dit is ook crack niet gebruiken als de join moet werken.

            //TODO: list vullen

            List<CartItemViewModel> list = (from ProductsModel in _context.ProductsModel
                                            join CartItem in cart on ProductsModel.Id equals CartItem.ProductId
                                            select new CartItemViewModel
                                            {
                                                ProductId = CartItem.ProductId,
                                                Amount = CartItem.Amount,
                                                Name = ProductsModel.Title,
                                                Price = ProductsModel.Price,
                                                ImageUrl = ProductsModel.Image,
                                                ShortDescription = ProductsModel.ShortDescription,
                                                Category = ProductsModel.Category
                                            }).ToList();

            //select query gegevens uit db halen niet goed maar het werkt iig

            //foreach (CartItem ci in cart)
            //{
            //    CartItemViewModel civm = new CartItemViewModel();
            //    civm.Amount = ci.Amount;
            //    civm.ProductId = ci.ProductId;

            //    ProductsModel p = _context.ProductsModel.Find(ci.ProductId);
            //    civm.Name = p.Title;
            //    civm.Price = p.Price;
            //    civm.ShortDescription = p.ShortDescription;
            //    civm.Category = p.ShortDescription;

            //    list.Add(civm);
            //}
            return View();
        }
        
        //Checkout
        [HttpGet]
        [Authorize]
        public IActionResult Checkout()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public IActionResult Checkout(CheckoutViewModel cvm)
        {
            return View();
        }
    }
}
