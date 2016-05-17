using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDDMarcDemo.Models
{
    public class Product
    {
        public ProductName Name { get; set; }
        public Colors Color { get; set; }
        public double Price { get; set; }
        double priceDiscount;
        public double PriceDiscount
        {
            get
            {
                return priceDiscount == 0 ? Price : priceDiscount;
            }
            set
            {
                priceDiscount = value;
            }
        }

        public Product(ProductName name)
        {
            Name = name;
        }
    }
}
