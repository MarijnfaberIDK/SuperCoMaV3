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
using SuperCoMa.Models;

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
                using (var streamReader = new StreamReader(response.GetResponseStream ()))
                {
                    return streamReader.ReadToEnd();
                }
            }

        }


        // GET: Products
        public async Task<IActionResult> Index()
        {

            XmlDocument xml = new XmlDocument();
            xml.Load("https://supermaco.starwave.nl/api/products");

            XmlElement root = xml.DocumentElement;
            XmlNodeList nodes = root.SelectNodes("Product");


            foreach (XmlNode node in nodes)
            {
                var productId = Convert.ToInt32(node.Attributes["Id"].Value);
                var productExists = _context.ProductsModel.Where(p => p.ProductID == productId).FirstOrDefault();

                if(productExists == null)
                {
                    var product = new ProductsModel
                    {
                        ProductID = productId,
                        EAN = node["EAN"].InnerText,
                        Title = node["Title"].InnerText,
                        Brand = node["Brand"].InnerText,
                        ShortDescription = node["Shortdescription"].InnerText,
                        FullDescription = node["Fulldescription"].InnerText,
                        Image = node["Image"].InnerText,
                        Weight = Double.Parse(node["Weight"].InnerText),
                        Price = Double.Parse(node["Price"].InnerText),
                        Category = node["Category"].InnerText,
                        SubCategory = node["Subcategory"].InnerText,
                        SubSubCategory = node["Subsubcategory"].InnerText
                    };
                    //Add Student object into Students DBset
                    _context.ProductsModel.Add(product);
                }

                // call SaveChanges method to save student into database
                _context.SaveChanges();
            }




            
    
            
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
    }
}
