using DataAccess1.Model;
using Moq;
using NHibernate;
using NUnit.Framework;
using Sklad.Controllers;
using System.Collections.Generic;
using System.Web.Mvc;

namespace TestProject
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
        
       [Test]
        public void TestDetailsView()
        {
            var controller = new ItemsController();
            var result = controller.Detail(2) as ViewResult;
            Assert.AreEqual("Detail", result.ViewName);
        }
        [Test]
        public void DummyTest()
        {
            var itemList = new List<Item>() { new Item() { Id = 1011,Description="dasa"} };
            var sessionMock = new Mock<ISession>();
            var queryMock = new Mock<IQuery>();
            var transactionMock = new Mock<ITransaction>();

            sessionMock.SetupGet(x => x.Transaction).Returns(transactionMock.Object);
            sessionMock.Setup(session => session.CreateQuery("from Items")).Returns(queryMock.Object);
            queryMock.Setup(x => x.List<Item>()).Returns(itemList);

            var controller = new ItemsController();//sessionMock.Object);
            var result = controller.Detail(0) as ViewResult;
            Assert.IsNotNull(result.ViewData);
        }

    }
}