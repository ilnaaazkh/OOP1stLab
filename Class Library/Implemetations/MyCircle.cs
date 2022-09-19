using System;
using ClassLibrary.Interfaces;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows;

namespace ClassLibrary.Implemetations
{

    public class MyCircle : IGraphicPrimitive
    {
        int Diametr { get; set; }
        int PositionX { get; set; }
        int PositionY { get; set; }

        private Ellipse newCircle = new Ellipse();

        private Random rndm = new Random();

        public MyCircle(int diametr)
        {
            Diametr = diametr;
            PositionY = 0;
            PositionX = 0;
        }

        public MyCircle()
        {
            Diametr = rndm.Next(50, 200);
            PositionX = 0;
            PositionY = 0;
        }

        public void Show(Canvas DrawingCanvas)
        {
            newCircle.Height = Diametr;
            newCircle.Width = Diametr;
            newCircle.Fill = Brushes.Red;
            newCircle.Stroke = Brushes.Black;
            newCircle.StrokeThickness = 3;
            DrawingCanvas.Children.Add(newCircle);
        }
        public void MoveTo(Canvas DrawingCanvas)
        {
            PositionX = rndm.Next((int)(DrawingCanvas.ActualWidth - Diametr));
            PositionY = rndm.Next((int)(DrawingCanvas.ActualHeight - Diametr));
            Canvas.SetLeft(newCircle, PositionX);
            Canvas.SetTop(newCircle, PositionY);
        }
        public void ChangeSize(Canvas DrawingCanvas)
        {
            Diametr = rndm.Next(10, 100);
            newCircle.Height = Diametr;
            newCircle.Width = Diametr;
        }

        public void Hide()
        {
            newCircle.Visibility = newCircle.IsVisible ? Visibility.Hidden : Visibility.Visible;
        }
    }
}
