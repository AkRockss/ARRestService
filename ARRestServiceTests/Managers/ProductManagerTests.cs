using ARRestService.Context;
using ARRestService.Controllers;
using ARRestService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace ARRestService.Managers.Tests
{
    [TestClass()]
    public class ProductManagerTests
    {

        private ARContext _context;
        private ProductManager _productManager;
        private Products _products;

        [TestInitialize]
        public void Initialize()
        {
            DbContextOptionsBuilder<ARContext> options = new();
            options.UseSqlServer(Secrets.ConnectionString);
            _context = new ARContext(options.Options);
            _productManager = new ProductManager(_context);
            _products = new Products();

        }

        [TestMethod()]
        public void GetAllProductsTest()
        {
            // Arrange
            IEnumerable<Products> products = _productManager.GetAll();
            Assert.AreEqual(4, products.Count());

        }


        [TestMethod()]
        public void AddTest()
        {
            Products addPotato = new() {productId = "4", productName = "Potato", productDescription = "", noeglemaerket = true, organic = true, productBrand = "" };
            _context.Add(addPotato);
            Assert.AreEqual(addPotato.productName, "Potato");

        }




    }
    }
