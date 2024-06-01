using FoodOrderService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderService
{
    public class InMemoryFoodOrderRepositoty : IFoodOrderRepository
    {

        private readonly List<FoodOrder> _foodOrders = new List<FoodOrder>();
        private int _nextId = 1;

        public void AddOrder(FoodOrder foodOrder)
        {
            foodOrder.Id = _nextId++;
            _foodOrders.Add(foodOrder);
        }

        public void DeleteOrder(int orderId)
        {
            var order = _foodOrders.FirstOrDefault(o => o.Id == orderId);
            if(order != null)
            {
                _foodOrders.Remove(order);
            }
        }

        public IEnumerable<FoodOrder> GetAllOrders()
        {
            return _foodOrders;
        }

        public void UpdateOrder(FoodOrder foodOrder)
        {
            var existingOrder = _foodOrders.FirstOrDefault(o => o.Id ==  foodOrder.Id);
            if(existingOrder != null)
            {
                existingOrder.CustomerName = foodOrder.CustomerName;
                existingOrder.FoodItem = foodOrder.FoodItem;
                existingOrder.Quantity = foodOrder.Quantity;
                existingOrder.OrderDate = foodOrder.OrderDate;
            }
        }
    }
}
