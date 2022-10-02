﻿using System;
using ClassLibrary.Interfaces;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows;

namespace ClassLibrary.Implemetations
{

    public class MyCircle:IGraphicPrimitive
    {
        private int Diametr { get; set; }
        private int PositionX { get; set; } //Координата центра по OX
        private int PositionY { get; set; } //Координата центра по OY

        private bool IsVisible = true;

        private Ellipse? el;
        public MyCircle(int diametr, int positionX, int positionY)
        {
            Diametr = diametr;
            PositionY = positionY;
            PositionX = positionX;
        }

        public MyCircle()
        {
            Random rndm = new Random();
            Diametr = rndm.Next(50, 200);
            PositionX = rndm.Next(Diametr/2, 500);
            PositionY = rndm.Next(Diametr/2, 300);
        }

        public void Show(Canvas DrawingCanvas)
        {
            el = new Ellipse { Height = Diametr, Width = Diametr, Fill = Brushes.Red, StrokeThickness = 3, Stroke = Brushes.Black, Visibility = IsVisible ? Visibility.Visible : Visibility.Hidden};
            Canvas.SetLeft(el, PositionX - Diametr/2);
            Canvas.SetTop(el, PositionY - Diametr/2);
            DrawingCanvas.Children.Add(el);
        }
        public void MoveTo(Canvas DrawingCanvas)
        {
            DrawingCanvas.Children.Remove(el);
            el = null;

            PositionX = new Random().Next(Diametr / 2, (int)DrawingCanvas.ActualWidth - Diametr/2);
            PositionY = new Random().Next(Diametr / 2, (int)DrawingCanvas.ActualHeight - Diametr/2);

            Show(DrawingCanvas);
        }

        public void MoveTo(Canvas DrawingCanvas, int deltaX, int deltaY)
        {
            DrawingCanvas.Children.Remove(el);
            el = null;

            PositionX += deltaX;
            PositionY += deltaY;

            Show(DrawingCanvas);
        }
        public void ChangeSize(Canvas DrawingCanvas)
        {
            DrawingCanvas.Children.Remove(el);
            el = null;

            Diametr = new Random().Next(50, 150);
            Show(DrawingCanvas);
        }

        public void Hide(Canvas DrawingCanvas)
        {
            DrawingCanvas.Children.Remove(el);
            el = null;

            IsVisible = !IsVisible;

            Show(DrawingCanvas);
        }

        public void Dispose()
        {
            Diametr = 0;
            PositionX = 0;
            PositionY = 0;
            el = null;
        }

    }
}
