using NorthWind.Entities.Interfaces;
using NorthWind.Entities.POCOEntities;
using NorthWind.Entities.Specifications;
using NorthWind.Repositories.EFCore.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Repositories.EFCore.Repositories
{
    
  
    public class OrderRepository : IOrderRepository
    {
        readonly NorthWindContext Context;

        public OrderRepository(NorthWindContext context) {  Context = context; }
        public void create(Order order)
        {
            Context.Orders.Add(order);
        }

        public IEnumerable<Order> GetOrdersBySpecification(Specification<Order> specification)
        {
           var ExpressionDeLegate = specification.Expression.Compile();
            return Context.Orders.Where(ExpressionDeLegate);
        }
    }
}
