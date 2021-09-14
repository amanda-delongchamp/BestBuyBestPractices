using System;
using System.Data;
using System.IO;
//using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;

namespace BestBuyBestPractices
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");
            IDbConnection conn = new SqlConnection(connString);
            var deptRepo = new DapperDepartmentRepository(conn);

            var prodRepo = new DapperProductRepository(conn);

            Console.WriteLine("Type a new Department name");

            var newDepartment = Console.ReadLine();

            deptRepo.InsertDepartment(newDepartment);

            var departments = deptRepo.GetAllDepartments();

            foreach (var dept in departments)
            {
                Console.WriteLine(dept.Name);
            }

            Console.WriteLine("Type a new product name");
            var newProduct = Console.ReadLine();
            Console.WriteLine("Type a price for the new product");
            var newPrice =   Convert.ToDouble (Console.ReadLine());
            Console.WriteLine("Type a category ID for the new product");
            var newCat = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Type 0 for not on sale or 1 for on sale");
            var newOnSale = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Type a stock level for the new product");
            var newStockLevel = Console.ReadLine();

            prodRepo.CreateProduct(newProduct, newPrice, newCat, newOnSale, newStockLevel);

            var products = prodRepo.GetAllProducts();

            Console.WriteLine("Product Name | Price | Category ID | On Sale | Stock Level");
            foreach (var product in products)
            {
                Console.WriteLine($" {product.Name} | {product.Price} | {product.CategoryID} | {product.OnSale} | {product.StockLevel}");
            }
        }
    }
}
