﻿using System;
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

namespace WpfApp2
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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox targetTextBox = sender as TextBox;
            bool success = int.TryParse(targetTextBox.Text, out int amount);

            if(!success)
            {
                MessageBox.Show("請輸入整數", "輸入錯誤");
            }else if(amount <= 0)
            {
                MessageBox.Show("請輸入正整數", "輸入錯誤");
            }else
            {
                StackPanel targetStackPanel = targetTextBox.Parent as StackPanel;
                Label targetLabel = targetStackPanel.Children[0] as Label;
                String drinkName = targetLabel.Content.ToString();
                if(orders.ContainsKey(drinkName)) orders.Remove(drinkName);
                orders.Add(drinkName, amount);
            }
        }
    }
}
