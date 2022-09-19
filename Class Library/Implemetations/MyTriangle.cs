using System;
using ClassLibrary.Interfaces;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows;
using System.Windows.Media;

namespace ClassLibrary.Implemetations
{
    public class MyTriangle : IGraphicPrimitive
    {
        private PointCollection points = new PointCollection();

        private int PositionX;

        private int PositionY;

        private Polygon polygon = new Polygon();

        private Random rndm = new Random();

        public MyTriangle()
        {
            int value = rndm.Next(0, 100);
            points.Add(new Point(value, 0));
            points.Add(new Point(0, 2*value));
            points.Add(new Point(2*value, 2*value));
            polygon.Points = points;
        }

        public MyTriangle(Point a, Point b, Point c)
        {
            points.Add(a);
            points.Add(b);
            points.Add(c);
            polygon.Points = points;
        }

        public void ChangeSize(Canvas DrawingCanvas)
        {
            int newValue = rndm.Next(50, 100);
            points[0] = new Point(newValue, 0);
            points[1] = new Point(0, 2 * newValue);
            points[2] = new Point(2 * newValue, 2 * newValue);
        }

        public void Hide()
        {
            polygon.Visibility = polygon.IsVisible ? Visibility.Hidden : Visibility.Visible;
        }

        public void MoveTo(Canvas DrawingCanvas)
        {
            PositionX = rndm.Next((int)(DrawingCanvas.ActualWidth - 2 * points[0].X));
            PositionY = rndm.Next((int)(DrawingCanvas.ActualHeight - 2 * points[0].X));
            Canvas.SetLeft(polygon, PositionX);
            Canvas.SetTop(polygon, PositionY);
        }

        public void Show(Canvas DrawingCanvas)
        {
            polygon.Fill = Brushes.Blue;
            polygon.Stroke = Brushes.Black;
            polygon.StrokeThickness = 3;
            DrawingCanvas.Children.Add(polygon);
        }
    }
}
