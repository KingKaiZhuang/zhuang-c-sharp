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

namespace TriangleCheck
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Triangle> triangles = new List<Triangle>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }


        private void buttonClick(object sender, RoutedEventArgs e)
        {
            isTriangle();
        }

        private void isTriangle()
        {
            double number1, number2, number3;
            bool success1 = double.TryParse(triangleInput1.Text, out number1);
            bool success2 = double.TryParse(triangleInput2.Text, out number2);
            bool success3 = double.TryParse(triangleInput3.Text, out number3);
            outputBlock.Text = "";
            if (success1 && success2 && success3)
            {
                if (number1 > 0 && number2 > 0 && number3 > 0 && number1 + number2 > number3 && number2 + number3 > number1 && number1 + number3 > number2)
                {
                    triangles.Add(new Triangle { side1 = number1, side2 = number2, side3 = number3, message = "可以形成三角形!" });
                    resultOutput.Background = Brushes.Green;
                    resultOutput.Text = $"{number1}、{number2}、{number3} 可以形成三角形!";
                }
                else
                {
                    triangles.Add(new Triangle { side1 = number1, side2 = number2, side3 = number3 ,message = "無法形成三角形!" });
                    resultOutput.Background = Brushes.Red;
                    resultOutput.Text = $"{number1}、{number2}、{number3} 無法形成三角形!";
                }
            }
            else
            {
                MessageBox.Show("請輸入大於0的數字哦!");
            }
            foreach (Triangle triangle in triangles)
            {
                outputBlock.Text += $"{triangle.side1}、{triangle.side2}、{triangle.side3}，{triangle.message}\n";
            }
        }
    }
}
