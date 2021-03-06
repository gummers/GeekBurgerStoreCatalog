﻿using System.Linq;
using Microsoft.EntityFrameworkCore;
using GeekBurger.StoreCatalog.Core;
using GeekBurger.StoreCatalog.Contract;
using GeekBurger.StoreCatalog.Infra.Services;
using GeekBurger.StoreCatalog.Core.Interfaces;
using GeekBurger.StoreCatalog.Infra.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeekBurger.StoreCatalog.Tests.IntegrationsTests
{
    [TestClass]
    public class ProductCoreTest
    {
        private IProductCore _productCore;

        [TestInitialize]
        public void Setup()
        {
            _productCore = new ProductCore(new RequestApi(), new Repository<ProductionAreasCore>(new StoreCatalogDbContext(new DbContextOptions<StoreCatalogDbContext>())));
        }

        [TestMethod]
        public void Check_All_Products_Available()
        {
            var user = new User();
            user.Restrictions = new string[] { "" };

            var result = _productCore.GetProductsFromUser(user);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.ToList().Count > 0);
        }
    }
}
