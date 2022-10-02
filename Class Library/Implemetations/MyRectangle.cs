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
        private int _Height { get; set; }
        private int _Width { get; set; }
        private int _PositionX { get; set; }
        private int _PositionY { get; set; }

        private bool _IsVisible = true;
        
        public int Height { get => _Height; set => _Height = value; }

        public int Width { get => _Width; set => _Width = value; }

        public int PositionX { get => _PositionX; set => _PositionX = value; }

        public int PositionY { get => _PositionY; set => _PositionY = value; }

        public bool IsVisible { get => _IsVisible; set => _IsVisible = value; } 

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
            newRect = new Rectangle {Height = Height, 
                Width = Width, 
                Stroke = Brushes.Black, 
                StrokeThickness = 3, 
                Fill = Brushes.DarkGreen, 
                Visibility = _IsVisible ? Visibility.Visible : Visibility.Hidden};
            Canvas.SetTop(newRect, _PositionY);
            Canvas.SetLeft(newRect, _PositionX);
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

            PositionX = new Random().Next(0, (int)(DrawingCanvas.ActualWidth - _Width));
            PositionY = new Random().Next(0, (int)(DrawingCanvas.ActualHeight - _Height));

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
