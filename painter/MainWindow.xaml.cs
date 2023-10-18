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

namespace painter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string shape;
        Color strokeColor = Colors.Red;
        int strukeThickness;
        Brush strukeBrush = new SolidColorBrush(Colors.Red);
        Point start, dest;
        public MainWindow()
        {
            InitializeComponent();
            strokeColorPicker.SelectedColor = strokeColor;
        }

        private void shape_click(object sender, RoutedEventArgs e)
        {
            var shapeChoose = sender as RadioButton;
            shape = shapeChoose.Tag.ToString();
            MessageBox.Show(shape);
        }

        private void colorSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            strukeThickness = Convert.ToInt32(colorSlider.Value);
        }

        private void myCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            start = e.GetPosition(myCanvas);
            myCanvas.Cursor = Cursors.Cross;
            switch(shape)
            {
                case "Line":
                    break;
                case "rectangle":
                    break;
                case "circle":
                    break;
            }
        }
    }
}
