using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using Moq;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using SportsStore.WebUI.Controllers;
using System.Web.Mvc;
using SportsStore.WebUI.Models;
using SportsStore.WebUI.HtmlHelpers;
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
            new Product {ProductID =3 ,Name ="P5"}
            });
            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;

            //Act 
            ProductsListsViewModel result = (ProductsListsViewModel)controller.List(2).Model;

            //Assert
            Product[] prodArray = result.Products.ToArray();
            Assert.IsTrue(prodArray.Length == 2);
            Assert.AreEqual(prodArray[0].Name, "P4");
            Assert.AreEqual(prodArray[1].Name, "P5");
        }
        [TestMethod]
        public void Can_Generate_Page_Links()
        {
            HtmlHelper myHelper = null;
            PagingInfo pagingInfo = new PagingInfo { CurrentPage = 2, TotalItems = 28, ItemsPerPage = 10 };

            //Arrange 
            Func<int, string> pageUrlDelegate = i => "Page" + i;

            //Act 
            MvcHtmlString result = myHelper.PageLinks(pagingInfo, pageUrlDelegate);

            //Assert 
            Assert.AreEqual(@"<a class=""btn btn-default"" href=""Page1"">1</a>" +
@"<a class=""btn btn-default btn-primary selected"" href=""Page2"">2</a>" +
@"<a class=""btn btn-default"" href=""Page3"">3</a>", result.ToString());
        }
        [TestMethod]
        public void Can_Send_Pagination_View_Model()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(x => x.Products).Returns(new List<Product> { 
            new Product{ ProductID=1, Name ="P1"},
            new Product {ProductID =2,Name ="P2"},
            new Product {ProductID =3 ,Name ="P3"},
            new Product {ProductID =3 ,Name ="P4"},
            new Product {ProductID =3 ,Name ="P5"}
            });

            //Arrange 
            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;

            //Act 
            ProductsListsViewModel result = (ProductsListsViewModel)controller.List(2).Model;

            //Assert
            PagingInfo pagingInfo = result.PagingInfo;
            Assert.AreEqual(pagingInfo.CurrentPage, 2);
            Assert.AreEqual(pagingInfo.ItemsPerPage, 3);
            Assert.AreEqual(pagingInfo.TotalItems, 5);
            Assert.AreEqual(pagingInfo.TotalPages, 2);

        }
    }
}
