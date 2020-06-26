using DutchTreat.Data.Entities;
using System.Collections.Generic;
using System.Data;

namespace DutchTreat.Data
{
    public interface IDutchRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCategory(string category);

      
        IEnumerable<Order> GetAllOrders(bool includeItems);
        IEnumerable<Order> GetAllOrdersByUser(string username, bool includeItems);


        Order GetOrderById(string username,int id);
        Order GetOrderById(int id);

       
        void AddEntity(object model);
        void DeleteOrder(int id);


        bool SaveAll();

    }
}