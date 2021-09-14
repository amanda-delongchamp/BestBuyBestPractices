using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuyBestPractices
{
   public class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection _connection;
        public DapperProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("SELECT * FROM Products;");
        }

        public void CreateProduct(string newProduct, double newPrice, int newCat, int newOnSale, string newStockLevel)
        {
            _connection.Execute("INSERT INTO PRODUCTS (Name, Price, CategoryID, OnSale, StockLevel) " +
                "VALUES (@name, @price, @categoryID, @OnSale, @StockLevel);",
                new { name = newProduct,
                    price = newPrice,
                    categoryID = newCat,
                    OnSale = newOnSale,
                    StockLevel = newStockLevel });
        }

        public void UpdateProduct(int updateID, string updateName, double updatePrice, int updateCat, int updateOnSale, string updateStockLevel)
        {
            _connection.Execute("UPDATE PRODUCTS SET name = @name, price = @price, categoryID = @categoryID, onSale = @onSale, stockLevel = @stockLevel",
                new
                {
                    productID = updateID,
                    name = updateName,
                    price = updatePrice,
                    categoryID = updateCat,
                    OnSale = updateOnSale,
                    StockLevel = updateStockLevel
                });
        }

        public void DeleteProduct(int deleteID, string deleteName, double deletePrice, int deleteCat, int deleteOnSale, string deleteStockLevel)
        {
            //from the sales and reviews tale where the product ID may be referenced.
        }


    }
}
