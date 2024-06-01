using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FoodOrderService
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IFoodOrderRepository foodOrderRepository;
        private FoodOrder _selectedOrder;
        public MainWindow()
        {
            InitializeComponent();
            foodOrderRepository = new InMemoryFoodOrderRepositoty();
            LoadOrders();
        }

        private void LoadOrders()
        {
            OrderListView.ItemsSource = foodOrderRepository.GetAllOrders();
        }

        private void OrderListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedOrder = (FoodOrder)OrderListView.SelectedItem;
            if(_selectedOrder != null )
            {
                CustomerNameTextBox.Text = _selectedOrder.CustomerName;
                FoodItemTextBox.Text = _selectedOrder.FoodItem;
                QuantityTextBox.Text = _selectedOrder.Quantity.ToString();
                OrderDatePicker.SelectedDate = _selectedOrder.OrderDate;
            }
        }

        private void AddOrderButton_Click(object sender, RoutedEventArgs e)
        {
            var order = new FoodOrder
            {
                CustomerName = CustomerNameTextBox.Text,
                FoodItem = FoodItemTextBox.Text,
                Quantity = int.Parse(QuantityTextBox.Text),
                OrderDate = OrderDatePicker.SelectedDate ?? DateTime.Now
            };

            foodOrderRepository.AddOrder(order);
            LoadOrders();
        }

        private void UpdateOrderButton_Click(object sender, RoutedEventArgs e)
        {
            if(_selectedOrder != null)
            {
                _selectedOrder.CustomerName = CustomerNameTextBox.Text;
                _selectedOrder.FoodItem = FoodItemTextBox.Text;
                _selectedOrder.Quantity = int.Parse(QuantityTextBox.Text);
                _selectedOrder.OrderDate = OrderDatePicker.SelectedDate ?? DateTime.Now;
                foodOrderRepository.UpdateOrder(_selectedOrder);
                LoadOrders();
            }
        }

        private void DeleteOrderButton_Click(object sender, RoutedEventArgs e)
        {
            if(_selectedOrder != null)
            {
                foodOrderRepository.DeleteOrder(_selectedOrder.Id);
                LoadOrders();
                CustomerNameTextBox.Clear();
                FoodItemTextBox.Clear();
                QuantityTextBox.Clear();
                OrderDatePicker.SelectedDate = null;
            }
        }
    }
}