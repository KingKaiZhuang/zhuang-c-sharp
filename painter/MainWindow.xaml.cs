﻿using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace painter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string shapeType = "Line"; // 要有初始值
        int strokeThickness = 1;
        Color strokeColor = Colors.Red;
        Color fillColor = Colors.Yellow;

        Point start, dest;
        public MainWindow()
        {
            InitializeComponent();
            strokeColorPicker.SelectedColor = strokeColor;
            fillColorPicker.SelectedColor = fillColor;
        }

        private void ShapeButton_Click(object sender, RoutedEventArgs e)
        {
            var targetRadioButton = sender as RadioButton;
            shapeType = targetRadioButton.Tag.ToString();

            //MessageBox.Show(shapeType);
        }

        private void strokeThicknessSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            strokeThickness = Convert.ToInt32(strokeThicknessSlider.Value);
        }

        private void myCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            dest = e.GetPosition(myCanvas);
            DisplayStatus();
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                switch (shapeType)
                {
                    case "Line":
                        var line = myCanvas.Children.OfType<Line>().LastOrDefault();
                        line.X2 = dest.X;
                        line.Y2 = dest.Y;
                        break;
                    case "Rectangle":
                        Point origin2 = new Point
                        {
                            X = Math.Min(start.X, dest.X),
                            Y = Math.Min(start.Y, dest.Y)
                        };

                        var rect = myCanvas.Children.OfType<Rectangle>().LastOrDefault();
                        rect.SetValue(Canvas.LeftProperty, origin2.X);
                        rect.SetValue (Canvas.TopProperty, origin2.Y);
                        rect.Width = Math.Abs(dest.X - start.X);
                        rect.Height = Math.Abs(dest.Y - start.Y);
                        break;
                    case "Ellipse":
                        Point origin3 = new Point
                        {
                            X = Math.Min(start.X, dest.X),
                            Y = Math.Min(start.Y, dest.Y)
                        };

                        var ellipse = myCanvas.Children.OfType<Ellipse>().LastOrDefault();
                        ellipse.SetValue(Canvas.LeftProperty,origin3.X);
                        ellipse.SetValue(Canvas.TopProperty, origin3.Y);
                        ellipse.Width = Math.Abs(dest.X - start.X);
                        ellipse.Height = Math.Abs(dest.Y - start.Y);
                        break;
                }
            }
        }

        private void myCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            start = e.GetPosition(myCanvas);
            myCanvas.Cursor = Cursors.Cross;
            switch (shapeType)
            {
                case "Line":
                    DrawLine(Colors.Gray, 1);
                    break;
                case "Rectangle":
                    var rect = new Rectangle
                    {
                        Stroke = Brushes.Gray,
                        StrokeThickness = 1,
                        Fill = Brushes.LightGray
                    };
                    myCanvas.Children.Add(rect);
                    rect.SetValue(Canvas.LeftProperty, start.X);
                    rect.SetValue(Canvas.TopProperty, start.Y);
                    break;
                case "Ellipse":
                    var ellipse = new Ellipse
                    {
                        Stroke = Brushes.Gray,
                        StrokeThickness = 1,
                        Fill = Brushes.LightGray
                    };
                    myCanvas.Children.Add(ellipse);
                    ellipse.SetValue(Canvas.LeftProperty, start.X);
                    ellipse.SetValue (Canvas.TopProperty, start.Y);
                    break;
            }
            DisplayStatus();
        }


        private void DisplayStatus()
        {
            int LineCount = myCanvas.Children.OfType<Line>().Count();
            int rectCount = myCanvas.Children.OfType<Rectangle>().Count();
            int ElliCount = myCanvas.Children.OfType<Ellipse>().Count();
            coordinateLabel.Content = $"座標點:({Math.Round(start.X)} , {Math.Round(start.Y)}) : ({Math.Round(dest.X)} , {Math.Round(dest.Y)})";
            shapeLabel.Content = $"Line : {LineCount} Rectangle : {rectCount} Ellipse : {ElliCount}";
        }

        private void strokeColorPicker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            strokeColor = (Color)strokeColorPicker.SelectedColor;
        }

        private void fillColorPicker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            fillColor = (Color)fillColorPicker.SelectedColor;
        }

        private void myCanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            switch (shapeType)
            {
                case "Line":
                    var line = myCanvas.Children.OfType<Line>().LastOrDefault();
                    line.Stroke = new SolidColorBrush(strokeColor);
                    line.StrokeThickness = strokeThickness;
                    break;
                case "Rectangle":
                    var rect = myCanvas.Children.OfType<Rectangle>().LastOrDefault();
                    rect.Stroke = new SolidColorBrush(strokeColor);
                    rect.Fill = new SolidColorBrush(fillColor);
                    rect.StrokeThickness = strokeThickness;
                    break;
                case "Ellipse":
                    var elli = myCanvas.Children.OfType<Ellipse>().LastOrDefault();
                    elli.Stroke = new SolidColorBrush(strokeColor);
                    elli.StrokeThickness = strokeThickness;
                    elli.Fill = new SolidColorBrush(fillColor);
                    break;
            }
            myCanvas.Cursor = Cursors.Arrow;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            myCanvas.Children.Clear();
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
