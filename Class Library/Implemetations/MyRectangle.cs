using ClassLibrary.Interfaces;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ClassLibrary.Implemetations
{
    public class MyRectangle : IGraphicPrimitive
    {
        private int Height { get; set; }
        private int Width { get; set; }
        private int PositionX { get; set; }
        private int PositionY { get; set; }

        private Rectangle newRect = new Rectangle();

        private Random rndm = new Random();

        public MyRectangle(int height, int width)
        {
            Height = height;
            Width = width;
            PositionX = 0;
            PositionY = 0;
        }

        public MyRectangle()
        {
            Height = rndm.Next(100, 250);
            Width = rndm.Next(100, 250);
        }
        public void Show(Canvas DrawingCanvas)
        {
            newRect.Height = Height;
            newRect.Width = Width;
            newRect.Fill = Brushes.DarkGreen;
            newRect.Stroke = Brushes.Black;
            newRect.StrokeThickness = 3;
            DrawingCanvas.Children.Add(newRect);
        }
        public void ChangeSize(Canvas DrawingCanvas)
        {
            newRect.Width = rndm.Next(50, 300);
            newRect.Height = rndm.Next(50, 300);
        }

        public void MoveTo(Canvas DrawingCanvas)
        {
            PositionX = rndm.Next((int)(DrawingCanvas.ActualWidth - Width));
            PositionY = rndm.Next((int)(DrawingCanvas.ActualHeight - Height));
            Canvas.SetLeft(newRect, PositionX);
            Canvas.SetTop(newRect, PositionY);
        }

        public void Hide()
        {
            newRect.Visibility = newRect.IsVisible ? Visibility.Hidden : Visibility.Visible;
        }
    }
}
