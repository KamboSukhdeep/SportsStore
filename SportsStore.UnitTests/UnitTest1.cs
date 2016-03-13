using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using Moq;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using SportsStore.WebUI.Controllers;

namespace SportsStore.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_Paginate()
        {
            //Arrange 
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new List<Product> {
            new Product{ ProductID=1, Name ="P1"},
            new Product {ProductID =2,Name ="P2"},
            new Product {ProductID =3 ,Name ="P3"},
            new Product {ProductID =3 ,Name ="P4"},
            new Product {ProductID =3 ,Name ="P5"},
            });
            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;

            //Act 
            IEnumerable<Product> result = (IEnumerable<Product>)controller.List(2).Model;

            //Assert
            Product[] prodArray = result.ToArray();
            Assert.IsTrue(prodArray.Length == 2);
            Assert.AreEqual(prodArray[0].Name, "P4");
            Assert.AreEqual(prodArray[1].Name, "P5");
        }
    }
}
