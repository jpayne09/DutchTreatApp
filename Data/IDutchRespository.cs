using Dutchtreat.Data.Entities;
using System.Collections.Generic;

namespace Dutchtreat.Data
{
    public interface IDutchRespository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCategory(string category);

        //Orders
        IEnumerable<Order> GetAllOrders(bool includeItems);
        Order GetAllOrders(int id);


        bool SaveAll();
        void AddEntity(object model);
        Order GetOrderById(string username, int id);
        IEnumerable<Order> GetAllordersByUser(string username, bool includeItems);
    }
}