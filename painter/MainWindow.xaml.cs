using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Linq;

namespace painter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string shape = "";
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
        private void myCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            dest = e.GetPosition(myCanvas);
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                switch (shape)
                { 
                    case "Line":
                        var line = myCanvas.Children.OfType<Line>().LastOrDefault();
                        line.X2 = dest.X;
                        line.Y2 = dest.Y;
                        break;
                    case "Rectangle":
                        break;
                    case "Circle":
                        break;
                }
                DisplayStatus();
            }
        }
        
        private void myCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            start = e.GetPosition(myCanvas);
            myCanvas.Cursor = Cursors.Cross;
            switch(shape)
            {
                case "Line":
                    DrawLine(Colors.Gray, 1);
                    break;
                case "Rectangle":
                    break;
                case "Circle":
                    break;
            }
            DisplayStatus();
        }

        private void DisplayStatus()
        {
            pointerLabel.Content = 
            $"座標點({Math.Round(start.X)},{Math.Round(start.Y)}) : ({Math.Round(dest.X)},{Math.Round(dest.Y)})";
        }

        private void myCanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
        }

        private void DrawLine(Color color, int thickness)
        {
            Brush stroke = new SolidColorBrush(color);
            Line line = new Line
            {
                Stroke = stroke,
                X1 = start.X,
                Y1 = start.Y,
                X2 = dest.X,
                Y2 = dest.Y
            };
            myCanvas.Children.Add(line);
        }
    }
}
