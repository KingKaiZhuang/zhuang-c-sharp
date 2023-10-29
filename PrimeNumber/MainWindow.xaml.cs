using System;
using System.Collections.Generic;
using System.Printing;
using System.Windows;
using System.Windows.Documents;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<int> primes = new List<int>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            int number;
            bool success = int.TryParse(TextBlock1.Text, out number);
            
            if(!success)
            {
                MessageBox.Show("請輸入整數", "輸入錯誤");
            } else if(number < 2)
            {
                MessageBox.Show($"輸入數值為{number}，小於2，請重新輸入","輸入錯誤");
            } else {
                MessageBox.Show($"輸入數值為{number}，以下是他的質數跟倍數~");
                for (int i = 2;i <= number;i++)
                {
                    if (Isprime(i))
                    {
                        primes.Add(i);
                    }
                }
            }
            // 列出所有的質數與倍數
            ListAllPrimes(primes,number);

        }

        private void ListAllPrimes(List<int> myPrimes, int n)
        {
            string primeList = $"小於{n}的質數為:";
            string primeMultiple = "";
            foreach (int p in myPrimes) {
                primeList += $"{p} ";
                primeMultiple += $"{p}的倍數為:";
                int i = 1;
                while(p*i <= n)
                {
                    primeMultiple += $"{p * i} ";
                    i++;
                }
                primeMultiple += "\n";
            }
            textblock_prime.Text = primeList;
            TextBlock_multiple.Text = primeMultiple;
        }

        private bool Isprime(int p)
        {
            // 判斷p是否為質數
            for (int i = 2; i < p; i++)
            {
                if (p % i == 0) return false;
            }
            return true;
        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

    }
}
