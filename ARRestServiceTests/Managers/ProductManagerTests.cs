﻿using ARRestService.Context;
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
        }

        [TestMethod()]
        public void TestGetAllProducts()
        {
            IEnumerable<Products> products = _productManager.GetAll();
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
            Products a = new() { productId = 4, productBrand = "NOR", productName = "Makrel", productDescription = "PD4", organic = true, noeglemaerket = true };
            _context.Add(a);
            _context.SaveChanges();

            Assert.AreEqual("Makrel", a.productName);
            Assert.AreEqual(4, _productManager.GetAll().Count());

        }

        [TestMethod()]
        public void TestDeleteProduct()
        {

            Products deleteProduct = _productManager.Delete(4);
            Assert.AreEqual("Makrel", deleteProduct.productName);
            Assert.AreEqual(3, _productManager.GetAll().Count());

        }

    }
}


