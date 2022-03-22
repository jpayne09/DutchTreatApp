using Dutchtreat.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dutchtreat.Data
{
    public class DutchRespository : IDutchRespository
    {
        private readonly DutchContext _ctx;
        private readonly ILogger _logger;
        public DutchRespository(DutchContext ctx, ILogger<DutchRespository> logger)
        {
            _ctx = ctx;
            _logger = logger;
        }

        public void AddEntity(object model)
        {
            _ctx.Add(model);
        }

        public IEnumerable<Order> GetAllOrders(bool includeItems)
        {
            if (includeItems)
            {
                return _ctx.Orders
                    .Include(o => o.Items)
                    .ThenInclude(i => i.Product)
                    .ToList();
            }
            else
            {
                return _ctx.Orders
                    .ToList();
            }
        }

        public Order GetAllOrders(int id)
        {
            return _ctx.Orders
              .Include(o => o.Items)
              .ThenInclude(i => i.Product)
              .Where( o => o.Id == id)
              .FirstOrDefault();
        }

        public IEnumerable<Order> GetAllordersByUser(string username, bool includeItems)
        {
            if (includeItems)
            {
                return _ctx.Orders
                .Where(o => o.User.UserName == username)
                .Include(o => o.Items)
                .ThenInclude(i => i.Product)
                .ToList();
            }
            else
            {
                return _ctx.Orders
                    .ToList();
            }
        }

        public IEnumerable<Product> GetAllProducts()
        {
            try
            {
                _logger.LogInformation("GetAll Products was called");
                return _ctx.Products
                        .OrderBy(p => p.Title)
                        .ToList();
            }
            catch(Exception ex)
            {
                _logger.LogError("Failed to get all products: {ex}");
                return null;
            }
        }

        public Order GetOrderById(string username, int id)
        {
            
            try
            {
                _logger.LogInformation("Get product orderid");
                return _ctx.Orders
                    .Include(o => o.Items)
                    .ThenInclude( i => i.Product)
                    .Where(p => p.Id == id && p.User.UserName == username)
                    .FirstOrDefault();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            return _ctx.Products
                    .Where(p => p.Category == category)
                    .ToList();
        }

        public bool SaveAll()
        {
            return _ctx.SaveChanges() > 0;
        }
    }
}
