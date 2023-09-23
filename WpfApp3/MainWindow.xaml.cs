using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<string,int> drinks = new Dictionary<string,int>();
        Dictionary<string,int> orders = new Dictionary<string,int>();
        public MainWindow()
        {
            InitializeComponent();
            AddNewDrink(drinks);
        }

        private void AddNewDrink(Dictionary<string, int> mydrinks)
        {
            mydrinks.Add("紅茶大杯", 60);
            mydrinks.Add("紅茶小杯", 60);
            mydrinks.Add("綠茶大杯", 60);
            mydrinks.Add("綠茶小杯", 60);
            mydrinks.Add("咖啡大杯", 60);
            mydrinks.Add("咖啡小杯", 60);
        }

        private void OderButton(object sender, RoutedEventArgs e)
        {

        }

        private void textBlock_change(object sender, TextChangedEventArgs e)
        {
            // 當輸入的 StackPanel 裡面的 textbox  輸入錯誤彈出錯誤訊息
            TextBox targetTextBox = sender as TextBox;
            bool success = int.TryParse(targetTextBox.Text, out int amount);
            if (!success)
            {
                MessageBox.Show("輸入的值要是整數!");
            }else if(amount <= 0)
            {
                MessageBox.Show("請輸入大於0的數字");
            }
            else
            {
                StackPanel targetStackPanel = targetTextBox.Parent as StackPanel;
                Label targetLabel = targetStackPanel.Children[0] as Label;
                String drinkName = targetLabel.Content.ToString();
                if (orders.ContainsKey(drinkName))
                {
                    orders.Remove(drinkName);
                }
                else
                {
                    orders.Add(drinkName, amount);
                }
            }

        }
    }
}
