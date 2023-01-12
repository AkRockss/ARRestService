using ARRestService.Context;
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
        public void TestGetAllProducts()
        {
            IEnumerable<Products> products = _productManager.GetAll();
            //Assert.AreEqual(4, products.Count());
        //}

        //[TestMethod()]
        //public void TestGetProductName()
        //{

            /*IEnumerable<Products> products = */_productManager.GetAll(productname: "Mælk");
            Assert.IsTrue(1 == products.Count());
            Assert.AreEqual(1, products.Count());
            // Assert.IsTrue: Shows no info if the test fails.
            // Assert.AreEquals: Shows expected and actual values if test fails

        //}

        //[TestMethod()]
        //public void TestAddProduct()
        //{
            Products a = new() { productId = 4, productBrand = "NOR", productName = "Makrel", productDescription = "PD4", organic = true, noeglemaerket = true };
            _context.Add(a);
            _context.SaveChanges();

            Assert.AreEqual("Makrel", a.productName);

        //}

        //[TestMethod()]
        //public void TestGetAllProductsAfterAdd()
        //{
           /* IEnumerable<Products> products =*/ _productManager.GetAll();
            Assert.AreEqual(5, products.Count());
        //}


        //[TestMethod()]
        //public void TestDeleteProduct()
        //{

            Products deleteProduct = _productManager.Delete(4);
            Assert.AreEqual("Makrel", deleteProduct.productName);
            Assert.AreEqual(4, _productManager.GetAll().Count());

            Assert.IsNull(_productManager.Delete(100));
        //}


        //[TestMethod()]
        //public void TestGetAllProductsAfterDelete()
        //{
           /* IEnumerable<Products> products =*/ _productManager.GetAll();
            Assert.AreEqual(4, products.Count());
        }


    }
}


