using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDDMarcDemo.Models
{

    public abstract class DiscountRule
    {

        public double Discount { get; set; }
        public abstract void RecalPrice(Product product);
    }

    public class ColorDiscountRule : DiscountRule
    {
        public ColorDiscountRule(Colors color, double discount)
        {
            if (discount == 0 || discount < 0)
                throw new ArgumentException("product cant be free");
            Color = color;
            Discount = discount;
        }
        public Colors Color { get; set; }
        public override void RecalPrice(Product product)
        {
            product.PriceDiscount = product.Color == Color ? product.PriceDiscount * Discount : product.PriceDiscount;
        }
    }


    public class ProductTypeDiscountRule : DiscountRule
    {
        public ProductTypeDiscountRule(ProductName name, double discount)
        {
            if (discount == 0 || discount < 0)
                throw new ArgumentException("product cant be free");
            Name = name;
            Discount = discount;
        }
        public ProductName Name { get; set; }
        public override void RecalPrice(Product product)
        {
            product.PriceDiscount = product.Name == Name ? product.PriceDiscount * Discount : product.PriceDiscount;
        }

    }

}
