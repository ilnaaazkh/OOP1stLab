using System;
using System.Collections.Generic;
using System.Windows;
using ClassLibrary.Implemetations;
using ClassLibrary.Interfaces;

namespace OOP1stLab
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        List<MyCircle> Circles = new List<MyCircle>();
        List<MyRectangle> Rects = new List<MyRectangle>();
        List<MyTriangle> Tris = new List<MyTriangle>();

        Mode mode = Mode.NotChoosed;

        bool GroupRedacting = false;

        private void Circle_Click(object sender, RoutedEventArgs e)
        {
            if(mode != Mode.MyCircle)
            {
                mode = Mode.MyCircle;
                MemoryCleaning();
                MainCanvas.Children.Clear();
            }


            if (GroupRedacting)
            {
                int count = new Random().Next(5, 10);
                for (int i = 0; i < count; i++)
                {
                    MyCircle? circ = new MyCircle();
                    circ.Show(MainCanvas);
                    Circles.Add(circ);
                }
            }

            else if(Circles.Count < 1)
            {
                MyCircle? circ = new MyCircle();
                circ.Show(MainCanvas);
                Circles.Add(circ);
            }

            else
            {
                string messageBoxText = "Круг уже был создан";
                MessageBoxResult result;
                result = MessageBox.Show(messageBoxText, "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Rectangle_Click(object sender, RoutedEventArgs e)
        {
            if (mode != Mode.MyRectangle)
            {
                mode = Mode.MyRectangle;
                MemoryCleaning();
                MainCanvas.Children.Clear();
            }


            if (GroupRedacting)
            {
                int count = new Random().Next(5, 10);
                for (int i = 0; i < count; i++)
                {
                    MyRectangle? rect = new MyRectangle();
                    rect.Show(MainCanvas);
                    Rects.Add(rect);
                }
            }

            else if (Rects.Count < 1)
            {
                MyRectangle? rect = new MyRectangle();
                rect.Show(MainCanvas);
                Rects.Add(rect);
            }

            else
            {
                string messageBoxText = "Прямоугольник уже был создан";
                MessageBoxResult result;
                result = MessageBox.Show(messageBoxText, "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Triangle_Click(object sender, RoutedEventArgs e)
        {
            if (mode != Mode.MyTriangle)
            {
                mode = Mode.MyTriangle;
                MemoryCleaning();
                MainCanvas.Children.Clear();
            }


            if (GroupRedacting)
            {
                int count = new Random().Next(5, 10);
                for (int i = 0; i < count; i++)
                {
                    MyTriangle? tri = new MyTriangle();
                    tri.Show(MainCanvas);
                    Tris.Add(tri);
                }
            }

            else if (Tris.Count < 1)
            {
                MyTriangle? tri = new MyTriangle();
                tri.Show(MainCanvas);
                Tris.Add(tri);
            }

            else
            {
                string messageBoxText = "Треугоольник уже был создан";
                MessageBoxResult result;
                result = MessageBox.Show(messageBoxText, "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void MoveShape_Click(object sender, RoutedEventArgs e)
        {
            if(mode == Mode.MyCircle)
            {
                foreach(MyCircle c in Circles)
                {
                    c.MoveTo(MainCanvas);
                }
            }
            else if(mode == Mode.MyRectangle)
            {
                foreach (MyRectangle r in Rects)
                {
                    r.MoveTo(MainCanvas);
                }
            }
            else if(mode == Mode.MyTriangle)
            {
                foreach (MyTriangle t in Tris)
                {
                    t.MoveTo(MainCanvas);
                }
            }
        }

        private void ResizeShape_Click(object sender, RoutedEventArgs e)
        {
            if (mode == Mode.MyCircle)
            {
                foreach (MyCircle c in Circles)
                {
                    c.ChangeSize(MainCanvas);
                }
            }
            else if (mode == Mode.MyRectangle)
            {
                foreach (MyRectangle r in Rects)
                {
                    r.ChangeSize(MainCanvas);
                }
            }
            else if (mode == Mode.MyTriangle)
            {
                foreach (MyTriangle t in Tris)
                {
                    t.ChangeSize(MainCanvas);
                }
            }
        }

        private void HideShape_Click(object sender, RoutedEventArgs e)
        {
            if (mode == Mode.MyCircle)
            {
                foreach (MyCircle c in Circles)
                {
                    c.Hide(MainCanvas);
                }
            }
            else if (mode == Mode.MyRectangle)
            {
                foreach (MyRectangle r in Rects)
                {
                    r.Hide(MainCanvas);
                }
            }
            else if (mode == Mode.MyTriangle)
            {
                foreach (MyTriangle t in Tris)
                {
                    t.Hide(MainCanvas);
                }
            }
        }

        private void ClearAll_Click(object sender, RoutedEventArgs e)
        {
            MemoryCleaning();
            MainCanvas.Children.Clear();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            GroupRedacting = true;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            MainCanvas.Children.Clear();
            MemoryCleaning();
            GroupRedacting = false;
        }

        private void MemoryCleaning()
        {
            for(int i = 0; i < Circles.Count; i++)
            {
                Circles[i].Dispose();
                Circles[i] = null;
            }
            for (int i = 0; i < Rects.Count; i++)
            {
                Rects[i].Dispose();
                Rects[i] = null;
            }
            for (int i = 0; i < Tris.Count; i++)
            {
                Tris[i].Dispose();
                Tris[i] = null;
            }
            Rects.Clear();
            Circles.Clear();
            Tris.Clear();
            GC.Collect();
        }
    }
}
