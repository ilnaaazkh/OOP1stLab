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
        private int x1, y1, x2, y2, x3, y3;

        private int PositionX { get; set; }

        private int PositionY { get; set; }

        private bool IsVisible { get; set; } = true;

        private Polygon? triangle;
        public MyTriangle(int x1, int y1, int x2, int y2, int x3, int y3, int positionX, int positionY)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
            this.x3 = x3;
            this.y3 = y3;
            PositionX = positionX;
            PositionY = positionY;
        }

        public MyTriangle()
        {
            Random rndm = new Random();
            x1 = 75;
            y1 = 0;
            x2 = 0;
            y2 = 150;
            x3 = 150;
            y3 = 150;
            PositionX = rndm.Next(0, 300);
            PositionY = rndm.Next(0, 300);
        }

        public void Show(Canvas DrawingCanvas)
        {
            triangle = new Polygon
            {
                Fill = Brushes.Blue,
                Stroke = Brushes.Black,
                StrokeThickness = 3,
                Points = new PointCollection { new Point(x1, y1), new Point(x2, y2), new Point(x3, y3) },
                Visibility = IsVisible ? Visibility.Visible : Visibility.Hidden
            };
            Canvas.SetLeft(triangle, PositionX);
            Canvas.SetTop(triangle, PositionY);
            DrawingCanvas.Children.Add(triangle);
        }

        public void ChangeSize(Canvas DrawingCanvas)
        {
            DrawingCanvas.Children.Remove(triangle);
            triangle = null;

            int newValue = new Random().Next(50, 100);

            x1 = newValue;
            y2 = 2 * newValue;
            x3 = 2 * newValue;
            y3 = 2 * newValue;


            Show(DrawingCanvas);
        }

        public void Hide(Canvas DrawingCanvas)
        {
            DrawingCanvas.Children.Remove(triangle);
            triangle = null;

            IsVisible = !IsVisible;

            Show(DrawingCanvas);
        }

        public void MoveTo(Canvas DrawingCanvas)
        {
            DrawingCanvas.Children.Remove(triangle);
            triangle = null;

            int deltaX = Math.Max(x1, Math.Max(x2, x3)) - Math.Min(x1, Math.Min(x2, x3));
            int deltaY = Math.Max(y1, Math.Max(y2, y3)) - Math.Min(y1, Math.Min(y2, y3));
            PositionX = new Random().Next(0, (int)DrawingCanvas.ActualWidth - deltaX);
            PositionY = new Random().Next(0, (int)DrawingCanvas.ActualHeight - deltaY);

            Show(DrawingCanvas);
        }

        public void MoveTo(Canvas DrawingCanvas, int deltaX, int deltaY)
        {
            DrawingCanvas.Children.Remove(triangle);
            triangle = null;
;
            PositionX += deltaX;
            PositionY += deltaY;

            Show(DrawingCanvas);
        }

        public void Dispose()
        {
            x1 = 0;
            y1 = 0;
            x2 = 0;
            y2 = 0;
            x3 = 0;
            y3 = 0;
            PositionX = 0;
            PositionY = 0;
            triangle = null;
        }
    }
}
