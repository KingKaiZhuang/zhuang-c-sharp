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

namespace WpfApp2
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
            bool success = int.TryParse(Text_item.Text, out number);
            if(!success)
            {
                MessageBox.Show("請輸入整數!");
            }
            else if(number <= 2)
            {
                MessageBox.Show($"輸入數值為{number}，小於2，請重新輸入", "輸入錯誤");
            }
            else
            {
                MessageBox.Show($"輸入數值為{number}，以下是他的質數跟倍數~");
                for(int i = 2;i < number;i++)
                {
                    if (isPrime(number))
                    {
                        primes.Add(i);
                    }
                }
            }
            ListPrimePrint(primes, number);
        }

        private void ListPrimePrint(List<int> primes, int number)
        {
            string primeList = $"小於{number}的質數 : ";
            string primeMultiple = $"小於{number}的倍數 :";
        }

        private bool isPrime(int p)
        {
            // 判斷p是否為質數
            for (int i = 2; i < p; i++)
            {
                if (p % i == 0) return false;
            }
            return true;
        }

    }
}
