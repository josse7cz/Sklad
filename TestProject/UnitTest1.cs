using DataAccess1.Dao;
using DataAccess1.Model;
using Moq;
using NHibernate;
using NUnit.Framework;
using Sklad.Controllers;
using System;
using System.Collections.Generic;
using System.Web.Mvc;



namespace TestProject
{
    public class Tests
    {
        public Mock<IDaoBase> mock = new Mock<IDaoBase>();
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
        public void IndexGetDataPassToView()
        {
            var data = new Item[0];
            var svc = new FakeItemsService(data);
            var controller = new ItemsController();
            var result = controller.Index();
            Assert.That(result, Is.InstanceOf<ViewResult>());
            var model = ((ViewResult)result).Model;
        }
        public class FakeItemsService : IDaoBase
        {
            readonly IEnumerable<Item> _data;

            public FakeItemsService(IEnumerable<Item> data)
            {
                _data = data;
            }

        }
        [Test]
        public void TestCreateSesion()
        {
            var sessionMock = new Mock<ISession>();
            var queryMock = new Mock<IQuery>();
            var transactionMock = new Mock<ITransaction>();

        }


        [Test]
        public void DummyTest()
        {
            var itemList = new List<Item>() { new Item() { Id = 2, Name = "John", Producer = "Peterson" } };
            var sessionMock = new Mock<ISession>();
            var queryMock = new Mock<IQuery>();
            var transactionMock = new Mock<ITransaction>();

            sessionMock.SetupGet(x => x.Transaction).Returns(transactionMock.Object);
            sessionMock.Setup(session => session.CreateQuery("from User")).Returns(queryMock.Object);
            queryMock.Setup(x => x.List<Item>()).Returns(itemList);

            var controller = new ItemsController();//sessionMock.Object);
            var result = controller.Index() as ViewResult;
            Assert.IsNotNull(result.ViewData);
        }

    }
}