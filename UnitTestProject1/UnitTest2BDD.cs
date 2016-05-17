using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using System.Collections.Generic;
using BDDMarcDemo.Models;
using BDDMarcDemo.Service;
using BDDMarcDemo.Extensions;
using System.Linq;
namespace UnitTestProject1
{
    [Binding]
    public class UnitTest2BDD
    {
        public List<Product> Products { get; set; }
        public List<DiscountRule> DiscountRules { get; set; }
        public double total;
        public IPriceDiscountCalculator CalService = new PriceDiscountCalculator();

        [Given(@"a new calculation")]
        public void StartDiscoutCalculation()
        {
            Products = new List<Product>();
            DiscountRules = new List<DiscountRule>();
        }


        [Given("(?i)the following \"Products\" exist")]
        public void ProductSetup(Table productTbl)
        {
            foreach (var row in productTbl.Rows)
            {
                var name = row["ProductName"].AsEnum<ProductName>();
                var color = row["Color"].AsEnum<Colors>();
                var price = Convert.ToDouble(row["Price"]);
                Products.Add(new Product(name) { Color = color, Price = price });
            }
        }


        [Given("(?i)the following \"ColorDiscountRules\" exist")]
        public void ColorDiscountRuleSetup(Table discountRulesTbl)
        {
            foreach (var row in discountRulesTbl.Rows)
            {
                var discount = Convert.ToDouble(row["Discount"]);
                var color = row["Color"].AsEnum<Colors>();
                DiscountRules.Add(new ColorDiscountRule(color, discount));

            }
        }


        [Given("(?i)the following \"ProductTypeDiscountRules\" exist")]
        public void ProductTypeDiscountRuleSetup(Table discountRulesTbl)
        {
            foreach (var row in discountRulesTbl.Rows)
            {
                var discount = Convert.ToDouble(row["Discount"]);
                var name = row["ProductName"].AsEnum<ProductName>();
                DiscountRules.Add(new ProductTypeDiscountRule(name, discount));
            }
        }


        [When(@"apply discount rule")]
        public void ApplyDiscountRules()
        {
            total = CalService.ApplyDiscountAndCalculateTotal(Products, DiscountRules);

        }



        [Then(@"total price should be (\d+)")]
        public void ThenTotalShouldBe(int total)
        {
            Assert.IsTrue(this.total == total, "misscalculation");
        }



    }
}
