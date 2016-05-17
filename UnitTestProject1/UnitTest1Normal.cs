using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BDDMarcDemo.Models;
using System.Collections.Generic;
using System.Linq;
using BDDMarcDemo.Service;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1Normal
    {
        public List<Product> Products { get; set; }


        [TestInitialize]
        public void Init()
        {
            Products = new List<Product>();
            Products.Add(new Product(ProductName.Jacket) { Color = Colors.Yellow, Price = 200 });
            Products.Add(new Product(ProductName.Belt) { Color = Colors.Yellow, Price = 50 });
            Products.Add(new Product(ProductName.TShirt) { Color = Colors.Red, Price = 100 });

        }

        [TestMethod]
        public void TestMethod1()
        {
            IPriceDiscountCalculator service = new PriceDiscountCalculator();
            var discountRules = new List<DiscountRule>();
            discountRules.Add(new ColorDiscountRule(Colors.Red, 0.9));
            discountRules.Add(new ProductTypeDiscountRule(ProductName.TShirt, 0.8));
            var total = service.ApplyDiscountAndCalculateTotal(Products, discountRules);
            Assert.IsTrue(total == 322, "misscalculation");
        }



        [TestMethod]
        public void TestMethod2()
        {
            IPriceDiscountCalculator service = new PriceDiscountCalculator();
            var discountRules = new List<DiscountRule>();
            discountRules.Add(new ColorDiscountRule(Colors.Yellow, 0.9));
            discountRules.Add(new ProductTypeDiscountRule(ProductName.TShirt, 0.8));
            var total = service.ApplyDiscountAndCalculateTotal(Products, discountRules);
            Assert.IsTrue(total == 305, "misscalculation");
        }
    }
}
