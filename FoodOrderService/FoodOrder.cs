using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderService
{
    public class FoodOrder
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string FoodItem {  get; set; }
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
