using System.Drawing;
using System.Windows.Forms;

namespace Paint
{
    public interface ITool
    {
        public void OnMouseDown(Graphics canvas, MouseEventArgs args);
        public void OnMouseMove(Graphics canvas, MouseEventArgs args);
        public void OnMouseUp(Graphics canvas, MouseEventArgs args);
        public void OnPaint(Graphics canvas, PaintEventArgs paintEventArgs);
        public void SelectPen(Color color);
    }
}