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

        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void TestResultCountByCategory()
        {
            List<Result> result = new List<Result>();
            IList<Item> item = new List<Item>();
            IList<ItemCategory> itemCategories = new List<ItemCategory>();
            item.Add(new Item() { Id = 1011, Name = "e34", ImageName = "s15453sad", Price = 10000, Producer = "BMW" });
            itemCategories.Add(new ItemCategory() { Id = 1, CategoryName = "dasa", CategoryDescription = "neco" });

            for (int i = 1; i <= itemCategories.Count; i++)
            {
                int id = 1011;
                String a = "e34";
                int b = item.Count;
                result.Add(new Result(id, a, b));
                Assert.AreEqual(1, item.Count);
            }
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void DummyTest()
        {
            var itemList = new List<Item>() { new Item() { Id = 1011, Name = "e34", ImageName = "s15453sad", Price = 10000, Producer = "BMW" } };
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