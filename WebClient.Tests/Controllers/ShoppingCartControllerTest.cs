using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebshopClient.Controllers;
using WebshopClient.Model;
using System.Web;
using Moq;
using System.Web.Mvc;

namespace WebClient.Tests.Controllers
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class ShoppingCartControllerTest
    {
        public ShoppingCartControllerTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestAddAmountOnProductLine()
        {
            // Arrange
            var context = new Mock<ControllerContext>();
            var session = new MockHttpSession();

            List<ProductLine> productLineList = new List<ProductLine>();

            ShoppingCartController cartController = new ShoppingCartController();
            cartController.ControllerContext = context.Object;

            Product product = new Product();
            product.ProductId = 1;
            product.Price = 100;

            ProductLine productLine = new ProductLine();
            productLine.Amount = 0;
            productLine.Product = product;

            productLineList.Add(productLine);

            session.insertIntoDictionary("shoppingCart", productLineList);

            context.Setup(m => m.HttpContext.Session).Returns(session);

            // Act
            cartController.Add(product);
            cartController.IncreaseAmount(productLine.Product.ProductId);

            // Assert
            Assert.AreEqual(2, productLine.Amount);
        }

        [TestMethod]
        public void TestDecreaseAmountOnProductLine()
        {
            // Arrange
            var context = new Mock<ControllerContext>();
            var session = new MockHttpSession();

            List<ProductLine> productLineList = new List<ProductLine>();

            ShoppingCartController cartController = new ShoppingCartController();
            cartController.ControllerContext = context.Object;

            Product product = new Product();
            product.ProductId = 1;
            product.Price = 100;

            ProductLine productLine = new ProductLine();
            productLine.Amount = 1;
            productLine.Product = product;

            productLineList.Add(productLine);
            session.insertIntoDictionary("shoppingCart", productLineList);

            context.Setup(m => m.HttpContext.Session).Returns(session);

            // Act
            cartController.Add(product);
            cartController.DecreaseAmount(productLine.Product.ProductId);

            // Assert
            Assert.AreEqual(1, productLine.Amount);
        }
    }
}
