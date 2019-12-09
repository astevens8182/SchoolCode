using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectVer1Steven
{
    public class CartItem
    {
        public CartItem()
        {

        }
        public CartItem(Product product, int quantity)
        {
           this.Product = product;
            this.Quantity = quantity;
        }

        public Product Product { get; set; }
        public int Quantity { get; set; }

        /// <summary>
         /// adds the quantity to the current quantity
        /// </summary>
        /// <param name="quantity"></param>
        public void AddQuantity (int quantity)
        {
            this.Quantity += quantity;
        }
        ///method that formats an items name, quantity and price in one line
        public string Display()
        {
            string displayString = string.Format("{0} ({1} at {2} each)",
                Product.ProductName,
                Quantity.ToString(),
                Product.ProductPrice.ToString("c"));
            return displayString;
        }


       
    }
}