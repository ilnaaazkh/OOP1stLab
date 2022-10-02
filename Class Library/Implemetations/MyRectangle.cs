using ClassLibrary.Interfaces;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ClassLibrary.Implemetations
{
    public class MyRectangle
    {
        private int Height { get; set; }
        private int Width { get; set; }
        private int PositionX { get; set; }
        private int PositionY { get; set; }

        private bool IsVisible = true;
        
        private Rectangle? newRect;

        public MyRectangle(int height, int width, int positionX, int positionY)
        {
            Height = height;
            Width = width;
            PositionX = positionX;
            PositionY = positionY;
        }

        public MyRectangle()
        {
            Random rndm = new Random();
            Height = rndm.Next(100, 250);
            Width = rndm.Next(100, 250);
            PositionX = rndm.Next(0, 300);
            PositionY = rndm.Next(0, 300);
        }
        public void Show(Canvas DrawingCanvas)
        {
            newRect = new Rectangle {Height = this.Height, 
                Width = this.Width, 
                Stroke = Brushes.Black, 
                StrokeThickness = 3, 
                Fill = Brushes.DarkGreen, 
                Visibility = IsVisible ? Visibility.Visible : Visibility.Hidden};
            Canvas.SetTop(newRect, PositionY);
            Canvas.SetLeft(newRect, PositionX);
            DrawingCanvas.Children.Add(newRect);
        }
        public void ChangeSize(Canvas DrawingCanvas)
        {
            DrawingCanvas.Children.Remove(newRect);
            newRect = null;
            Width = new Random().Next(50, 300);
            Height = new Random().Next(50, 300);
            Show(DrawingCanvas);
        }

        public void MoveTo(Canvas DrawingCanvas)
        {
            DrawingCanvas.Children.Remove(newRect);
            newRect = null;

            PositionX = new Random().Next(0, (int)(DrawingCanvas.ActualWidth - Width));
            PositionY = new Random().Next(0, (int)(DrawingCanvas.ActualHeight - Height));

            Show(DrawingCanvas);
        }

        public void MoveTo(Canvas DrawingCanvas, int deltaX, int deltaY)
        {
            DrawingCanvas.Children.Remove(newRect);
            newRect = null;

            PositionX += deltaX;
            PositionY += deltaY;

            Show(DrawingCanvas);
        }

        public void Hide(Canvas DrawingCanvas)
        {
            DrawingCanvas.Children.Remove(newRect);
            newRect = null;
            IsVisible = !IsVisible;
            Show(DrawingCanvas);
        }

        public void Dispose()
        {
            PositionX = 0;
            PositionY = 0;
            Height = 0;
            Width = 0;
            newRect = null;
        }
    }
}
