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

        List<IGraphicPrimitive> primitives = new List<IGraphicPrimitive>();
        bool GroupRedacting = false;

        private void Circle_Click(object sender, RoutedEventArgs e)
        {
            MyCircle circ = new MyCircle();
            if (GroupRedacting || primitives.Count < 1) 
            {
                circ.Show(MainCanvas);
                primitives.Add(circ);
            }
            else
            {
                MainCanvas.Children.Clear();
                primitives.Clear();
                circ.Show(MainCanvas);
                primitives.Add(circ);
            }
            
        }

        private void Rectangle_Click(object sender, RoutedEventArgs e)
        {
            MyRectangle rect = new MyRectangle();
            if (GroupRedacting || primitives.Count < 1)
            {
                rect.Show(MainCanvas);
                primitives.Add(rect);
            }
            else
            {
                MainCanvas.Children.Clear();
                primitives.Clear();
                rect.Show(MainCanvas);
                primitives.Add(rect);
            }
        }

        private void Triangle_Click(object sender, RoutedEventArgs e)
        {
            MyTriangle triangle = new MyTriangle();
            if (GroupRedacting || primitives.Count < 1)
            {
                triangle.Show(MainCanvas);
                primitives.Add(triangle);
            }
            else
            {
                MainCanvas.Children.Clear();
                primitives.Clear();
                triangle.Show(MainCanvas);
                primitives.Add(triangle);
            }
        }

        private void MoveShape_Click(object sender, RoutedEventArgs e)
        {
            foreach(IGraphicPrimitive primitive in primitives)
            {
                primitive.MoveTo(MainCanvas);
            }
        }

        private void ResizeShape_Click(object sender, RoutedEventArgs e)
        {
            foreach (IGraphicPrimitive primitive in primitives)
            {
                primitive.ChangeSize(MainCanvas);
            }
        }

        private void HideShape_Click(object sender, RoutedEventArgs e)
        {
            foreach(IGraphicPrimitive primitive in primitives)
            {
                primitive.Hide();
            }

        }

        private void ClearAll_Click(object sender, RoutedEventArgs e)
        {
            primitives.Clear();
            MainCanvas.Children.Clear();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            GroupRedacting = true;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            MainCanvas.Children.Clear();
            primitives.Clear();
            GroupRedacting = false;
        }
    }
}
