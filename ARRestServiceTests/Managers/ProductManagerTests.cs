using ARRestService.Context;
using ARRestService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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
            
            _products = new Products() {productBrand = "", productName = "ArgumentException", 
                productDescription = "", organic = true, noeglemaerket = true};
        }

        [TestMethod()]
        public void TestGetAllProducts()
        {
            IEnumerable<Products> products =
            _productManager.GetAll();
            Assert.AreEqual(3, products.Count());
        }

        [TestMethod()]
        public void TestGetProductName()
        {

            IEnumerable<Products> products =
            _productManager.GetAll("Mælk");
            Assert.AreEqual(1, products.Count());
            
        } 

        [TestMethod()]
        public void TestAddProduct()
        {
            Products a = new() { productId = 4, productBrand = "NOR", productName = 
            "Makrel", productDescription = "PD4", organic = true, noeglemaerket = true };
            _context.Add(a);
            _context.SaveChanges();

            Assert.AreEqual("Makrel", a.productName);
            Assert.AreEqual(4, _productManager.GetAll().Count());

            a.productName = "updatedName";
            Products updatedProduct = _productManager.Update(a.productId, a);
            Assert.AreEqual("updatedName", updatedProduct.productName);
        }
       
        //[TestMethod()]
        //public void TestArgumentException()
        //{
        //    try
        //    {
        //        _products.productName = null;
        //        Assert.Fail();
        //    }
        //    catch (ArgumentException ex)
        //    {
        //        Assert.AreEqual("Name is null or empty", ex.Message);
        //    }
        //}

        [TestMethod()]
        public void TestDeleteProduct()
        {

            Products deleteProduct = 
            _productManager.Delete(4);
            Assert.AreEqual("updatedName", deleteProduct.productName);
            Assert.AreEqual(3, _productManager.GetAll().Count());

        }



    }
}


