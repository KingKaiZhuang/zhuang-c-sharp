using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _20230927
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<string, int> drinkMenu = new Dictionary<string, int>();
        Dictionary<string, int> orders = new Dictionary<string, int>();
        public MainWindow()
        {
            InitializeComponent();
            addDrink(drinkMenu);
            displayDrink(drinkMenu);
        }

        private void displayDrink(Dictionary<string, int> drinkMenu)
        {
            foreach(var drink in drinkMenu)
            {
                StackPanel sp = new StackPanel();
                CheckBox cb = new CheckBox();
                Slider sl = new Slider();
                Label lb = new Label();

                cb.Content = $"{drink.Key} : {drink.Value}";
                cb.FontSize = 18;
                cb.FontFamily = new FontFamily("Consolas");
                cb.Foreground = Brushes.Blue;
                cb.Width = 200;
                cb.Margin = new Thickness(5);

                sl.Width = 100;
                sl.Minimum = 0;
                sl.Maximum = 10;
                sl.Value = 0;
                sl.SnapsToDevicePixels = true;
                sl.HorizontalAlignment = HorizontalAlignment.Right;

                lb.Content = "0";
                lb.Width = 100;
                lb.FontFamily = new FontFamily("Consolas");
                lb.FontSize = 18;

                sp.Orientation = Orientation.Horizontal;
                sp.Margin = new Thickness(5);
                sp.Children.Add(cb);
                sp.Children.Add(sl);
                sp.Children.Add(lb);

                Binding myBinding = new Binding("Value");
                myBinding.Source = sl;
                lb.SetBinding(ContentProperty, myBinding);

                menu_item.Children.Add(sp);
            }
        }

        private void addDrink(Dictionary<string, int> myDrinks)
        {
            myDrinks.Add("紅茶大杯", 60);
            myDrinks.Add("紅茶小杯", 40);
            myDrinks.Add("綠茶大杯", 60);
            myDrinks.Add("綠茶小杯", 40);
            myDrinks.Add("咖啡大杯", 80);
            myDrinks.Add("咖啡小杯", 60);
        }

        private void send_button(object sender, RoutedEventArgs e)
        {
            placeOrder(orders);

            double total = 0.0;
            double sellPrice = 0.0;
            string displayString = $"清單如下：\n";
            string message = "";

            foreach (KeyValuePair<string,int> item in orders)
            {
                string drinkName = item.Key;
                int amount = orders[drinkName];
                int price = drinkMenu[drinkName];
                total += price * amount;
                displayString += $"{drinkName} X {amount}杯，每杯{price}元，總共{price * amount}元\n";
            }

            if (total >= 500)
            {
                message = "訂購滿500元以上者打8折";
                sellPrice = total * 0.8;
            }
            else if (total >= 300)
            {
                message = "訂購滿300元以上者打85折";
                sellPrice = total * 0.85;
            }
            else if (total >= 200)
            {
                message = "訂購滿200元以上者打9折";
                sellPrice = total * 0.9;
            }
            else
            {
                message = "訂購未滿200元以上者不打折";
                sellPrice = total;
            }

            displayString += $"本次訂購總共{orders.Count}項，{message}，售價{sellPrice}元"; ;
            resultBlock.Text = displayString;
        }

        private void placeOrder(Dictionary<string, int> myOrders)
        {
            myOrders.Clear();
            for(int i = 0;i < menu_item.Children.Count; i++) {
                StackPanel sp = menu_item.Children[i] as StackPanel;
                CheckBox cb = sp.Children[0] as CheckBox;
                Slider sl = sp.Children[1] as Slider;
                string drinkName = cb.Content.ToString().Substring(0, 4);
                int quantiry = Convert.ToInt32(sl.Value);

                if(cb.IsChecked == true && quantiry !=  0)
                {
                    myOrders.Add(drinkName, quantiry);
                }
            }
        }

        private void isChecked(object sender, RoutedEventArgs e)
        {

        }
    }
}
