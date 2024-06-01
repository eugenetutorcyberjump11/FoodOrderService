using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderService
{
    public interface IFoodOrderRepository
    {
        IEnumerable<FoodOrder> GetAllOrders();
        void AddOrder(FoodOrder foodOrder);
        void UpdateOrder(FoodOrder foodOrder);
        void DeleteOrder(int orderId);
    }
}
