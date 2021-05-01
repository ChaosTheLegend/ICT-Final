using System.Drawing;
using System.Windows.Forms;

namespace Paint
{
    public class PenTool : ITool
    {
        private Point _startPoint;
        private bool _isDrawing;
        private Color _selectedColor;
        public void OnMouseDown(Graphics canvas, MouseEventArgs args)
        {
            _startPoint = new Point(args.X, args.Y);
            _isDrawing = true;
        }

        public void OnMouseMove(Graphics canvas, MouseEventArgs args)
        {
            if (_isDrawing)
            {
                canvas.DrawLine(new Pen(_selectedColor), _startPoint.X, _startPoint.Y, args.X, args.Y);
                _startPoint = new Point(args.X, args.Y);
            }
        }

        public void OnMouseUp(Graphics canvas, MouseEventArgs args)
        {
            _isDrawing = false;
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