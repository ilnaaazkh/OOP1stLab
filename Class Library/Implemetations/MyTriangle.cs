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
        private int x1;
        private int y1;
        private int x2;
        private int y2;
        private int x3; 
        private int y3;

        private int _PositionX;
        private int _PositionY;
        private bool _IsVisible = true;

        public int PositionX { get => _PositionX; set => _PositionX = value; }
        public int PositionY { get => _PositionY; set => _PositionY = value; }
        public bool IsVisible { get => _IsVisible; set => _IsVisible = value;}

        public int X1 { get => x1; set => x1 = value; }
        public int Y1 { get => y1; set => y1 = value; }
        public int X2 { get => x2; set => x2 = value; }
        public int Y2 { get => y2; set => y2 = value; }
        public int X3 { get => x3; set => x3 = value; }
        public int Y3 { get => y3; set => y3 = value; }
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
