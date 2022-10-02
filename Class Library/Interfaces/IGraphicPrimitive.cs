using System.Windows.Controls;

namespace ClassLibrary.Interfaces
{
    public interface IGraphicPrimitive
    {
        public void Show(Canvas DrawingCanvas);
        public void MoveTo(Canvas DrawingCanvas);
        public void Hide(Canvas DrawingCanvas);
        public void ChangeSize(Canvas DrawingCanvas);
        
    }
}
