using System.Drawing;
using System.Windows.Forms;

namespace Paint
{
    public class FillTool : ITool
    {
        private Color _selectedColor;
        public void OnMouseDown(Graphics canvas, MouseEventArgs args)
        {
            canvas.FillRegion(new SolidBrush(_selectedColor), canvas.Clip);
        }

        public void OnMouseMove(Graphics canvas, MouseEventArgs args)
        {
        }

        public void OnMouseUp(Graphics canvas, MouseEventArgs args)
        {
        }

        public void OnPaint(Graphics canvas, PaintEventArgs paintEventArgs)
        {
            
        }

        public void SelectPen(Color color)
        {
            _selectedColor = color;
        }
    }
}