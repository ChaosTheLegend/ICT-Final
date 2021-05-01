using System.Drawing;
using System.Windows.Forms;

namespace Paint
{
    public class LineTool : ITool
    {
        private Point _startPoint;
        private Point _endPoint;
        private bool _isDrawing;
        private Color _selectedColor;
        public void OnMouseDown(Graphics canvas, MouseEventArgs args)
        {
            _startPoint = args.Location;
            _endPoint = args.Location;
            _isDrawing = true;
        }

        public void OnMouseMove(Graphics canvas, MouseEventArgs args)
        {
            if (_isDrawing)
            {
                _endPoint = args.Location;
            }
        }

        public void OnMouseUp(Graphics canvas, MouseEventArgs args)
        {
            _isDrawing = false;
            canvas.DrawLine(new Pen(_selectedColor) , _startPoint ,_endPoint);
        }

        public void OnPaint(Graphics canvas, PaintEventArgs e)
        {
            if (_isDrawing)
            {
                e.Graphics.DrawLine(new Pen(_selectedColor) , _startPoint, _endPoint);
            }
        }

        public void SelectPen(Color color)
        {
            _selectedColor = color;
        }
    }
}