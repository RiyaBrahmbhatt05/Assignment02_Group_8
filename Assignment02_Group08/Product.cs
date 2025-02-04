using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment02_Group08
{
    public class Product
    {
        // Attributes
        public int ProdID { get; set; }
        public string ProdName { get; set; }
        public decimal ItemPrice { get; set; }
        public int StockAmount { get; set; }

        // Constructor
        public Product(int prodID, string prodName, decimal itemPrice, int stockAmount)
        {
            ProdID = prodID;
            ProdName = prodName;
            ItemPrice = itemPrice;
            StockAmount = stockAmount;
        }

        // Methods to increase and decrease stock
        public void IncreaseStock(int amount)
        {
            if (StockAmount + amount > 800000)
            {
                throw new InvalidOperationException("Stock amount cannot exceed the maximum limit of 800,000.");
            }
            StockAmount += amount;
        }

        public void DecreaseStock(int amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount to decrease stock cannot be negative.");
            }

            if (StockAmount - amount < 8)
            {
                throw new InvalidOperationException("Stock amount cannot exceed the minimum limit of 8.");
            }

            StockAmount -= amount;
        }

    }
}
