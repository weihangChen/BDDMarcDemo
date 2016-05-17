using BDDMarcDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDDMarcDemo.Service
{
    public interface IPriceDiscountCalculator {
        double ApplyDiscountAndCalculateTotal(List<Product> products, List<DiscountRule> discountRules);
    }
    public class PriceDiscountCalculator : IPriceDiscountCalculator
    {
        public double ApplyDiscountAndCalculateTotal(List<Product> products, List<DiscountRule> discountRules)
        {
            products.ForEach(p => discountRules.ForEach(r => r.RecalPrice(p)));
            return products.Select(x => x.PriceDiscount).Sum();
        }
    }
}
