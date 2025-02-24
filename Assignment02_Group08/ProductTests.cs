﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment02_Group08
{
    public class ProductTests
    {
        // <Test Aims>
        // 1. *Product ID Validation*  
        //    - Ensures the product ID is within a valid range (8 to 80,000).  
        //    - Tests that the minimum (8) values are accepted.
        //    - Tests that the maximum (80,000) values are accepted.  
        // 
        // 2. *Product Name Validation*  
        //    - Ensures the product name is case-sensitive.  
        //    - Tests handling lower cases and upper cases words.  
        //    - Ensures the product name is not null or empty.  
        // 
        // 3. *Item Price Validation*  
        //    - Ensures the price is within the valid range ($8 to $8,000).  
        //    - Tests that the minimum ($8) prices are accepted.
        //    - Tests that the maximum ($8,000) prices are accepted.

        [Test]
        public void ProductID_900_900()
        {
            // Arrange
            var product = new Product(900, "Drone", 1200.00m, 50);

            // Act
            int productID = product.ProdID;

            // Assert
            Assert.That(productID, Is.InRange(8, 80000));
        }

        [Test]
        public void ProductID_8_8()
        {
            // Arrange
            var product = new Product(8, "Drone", 1200.00m, 50);

            // Act
            int productID = product.ProdID;

            // Assert
            Assert.That(productID, Is.EqualTo(8), "Product ID should accept the minimum value of 8.");
        }

        [Test]
        public void ProductID_80000_80000()
        {
            var product = new Product(80000, "Drone", 1200.00m, 50);

            // Act
            int productID = product.ProdID;

            // Assert
            Assert.That(productID, Is.EqualTo(80000), "Product ID should accept the maximum value of 80,000.");

        }

        [Test]
        public void ProductName_Drone_Drone()
        {
            // Arrange
            var product = new Product(100, "Drone", 1200.00m, 50);

            // Act
            string productName = product.ProdName;

            // Assert
            Assert.That(productName, Is.EqualTo("Drone"), "Product name should be case-sensitive.");

        }

        [Test]
        public void ProductName_droneDRONE_droneDRONE()
        {
            // Arrange
            var productLower = new Product(101, "drone", 1200.00m, 50);
            var productUpper = new Product(102, "DRONE", 1200.00m, 50);

            // Act
            string productNameLower = productLower.ProdName;
            string productNameUpper = productUpper.ProdName;

            // Assert
            Assert.That(productNameLower, Is.EqualTo("drone"), "Product name should store lowercase as provided.");
            Assert.That(productNameUpper, Is.EqualTo("DRONE"), "Product name should store uppercase as provided.");
        }

        [Test]
        public void ProductName_NotNull_NotNull()
        {
            //Arrange
            var product = new Product(100, "Drone", 1200.00m, 50);

            //Act
            string productName = product.ProdName;

            //Assert
            Assert.That(string.IsNullOrEmpty(productName), Is.False, "Product name should not be null or empty.");
        }

        [Test]
        public void ItemPrice_1200_1200()
        {
            // Arrange
            var product = new Product(100, "Drone", 1200.00m, 50);

            // Act
            decimal itemPrice = product.ItemPrice;

            // Assert
            Assert.That(itemPrice, Is.InRange(8.00m, 8000.00m), "Item price should be between $8 and $8,000.");
        }

        [Test]
        public void ItemPrice_8_8()
        {
            // Arrange
            var product = new Product(100, "Drone", 8.00m, 50);

            // Act
            decimal itemPrice = product.ItemPrice;

            // Assert
            Assert.That(itemPrice, Is.EqualTo(8.00m), "Item price should accept the minimum value of $8.");
        }

        [Test]
        public void ItemPrice_8000_8000()
        {
            // Arrange
            var product = new Product(100, "Drone", 8000.00m, 50);

            // Act
            decimal itemPrice = product.ItemPrice;

            // Assert
            Assert.That(itemPrice, Is.EqualTo(8000.00m), "Item price should accept the maximum value of $8,000.");
        }
        //4. Stock Amount Validation  
        //   - Ensures the stock amount is within the valid range (8 to 800,000).  
        //   - Validates that the minimum (8) stock values are accepted.
        //   - Validates that the maximum (800,000) stock values are accepted.  

        //5. Stock Modification Tests :
        //     IncreaseStock :
        //   - Verifies that stock increases correctly when adding stock.  
        //   - Ensures stock can be increased up to the maximum allowed limit (800,000).  
        //   - Ensures an exception is thrown if stock exceeds the maximum limit.
        //     DecreaseStock:
        //   - Verifies that stock decreases correctly when removing stock.  
        //   - Ensures an exception is thrown when attempting to decrease stock with a negative value.  
        //   - Ensures an exception is thrown if stock is reduced below the minimum allowed limit (8).  

        [Test]
        public void StockAmount_500_500()
        {
            // Arrange
            var product = new Product(100, "Drone", 1200.00m, 500);

            // Act
            int stockAmount = product.StockAmount;

            // Assert
            Assert.That(stockAmount, Is.InRange(8, 800000), "Stock amount should be between 8 and 800,000.");
        }

        [Test]
        public void StockAmount_8_8()
        {
            // Arrange
            var product = new Product(100, "Drone", 1200.00m, 8);

            // Act
            int stockAmount = product.StockAmount;

            // Assert
            Assert.That(stockAmount, Is.EqualTo(8), "Stock amount should accept the minimum value of 8.");
        }

        [Test]
        public void StockAmount_800000_800000()
        {
            //Arrange
            var product = new Product(100, "Drone", 1200.00m, 800000);

            //Act
            int stockAmount = product.StockAmount;

            //Assert
            Assert.That(stockAmount, Is.EqualTo(800000), "Stock amount should accept the maximum value of 800,000.");

        }

        [Test]
        public void IncreaseStock_50_60()
        {
            // Arrange
            var product = new Product(100, "Drone", 1200.00m, 50);

            // Act
            product.IncreaseStock(10);
            int updatedStock = product.StockAmount;

            // Assert
            Assert.That(updatedStock, Is.EqualTo(60), "Stock amount should increase by 10.");
        }

        [Test]
        public void IncreaseStock_799990_800000()
        {
            // Arrange
            var product = new Product(100, "Drone", 1200.00m, 799990);

            // Act
            product.IncreaseStock(10);
            int updatedStock = product.StockAmount;

            // Assert
            Assert.That(updatedStock, Is.EqualTo(800000), "Stock amount should increase to the maximum limit of 800,000.");
        }

        [Test]
        public void IncreaseStock_800000_Exception()
        {
            // Arrange
            var product = new Product(100, "Drone", 1200.00m, 800000);

            // Act
            var ex = Assert.Throws<InvalidOperationException>(() => product.IncreaseStock(10));

            // Assert
            Assert.That(ex.Message, Is.EqualTo("Stock amount cannot exceed the maximum limit of 800,000."));
        }

        [Test]
        public void DecreaseStock_50_60()
        {
            // Arrange
            var product = new Product(100, "Drone", 1200.00m, 50);

            // Act
            product.DecreaseStock(10);
            int updatedStock = product.StockAmount;

            // Assert
            Assert.That(updatedStock, Is.EqualTo(40), "Stock amount should decrease by 10.");
        }

        [Test]
        public void DecreaseStock_NegativeValue_Exception()
        {
            // Arrange
            var product = new Product(100, "Drone", 1200.00m, 50);

            // Act
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                product.DecreaseStock(-10);
            });

            // Assert
            Assert.That(ex.Message, Does.Contain("Amount to decrease stock cannot be negative."));
        }

        [Test]
        public void DecreaseStock_8_Exception()
        {
            // Arrange
            var product = new Product(100, "Drone", 1200.00m, 8);

            // Act
            var ex = Assert.Throws<InvalidOperationException>(() =>
            {
                product.DecreaseStock(1);
            });

            // Assert
            Assert.That(ex.Message, Is.EqualTo("Stock amount cannot exceed the minimum limit of 8."));
        }
    }

}

