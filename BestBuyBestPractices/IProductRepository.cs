using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuyBestPractices
{
    interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();

        public void CreateProduct(string name, double price, int categoryID, int OnSale, string StockLevel);


    }
}
