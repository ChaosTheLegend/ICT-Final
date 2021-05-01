using System;
using System.Drawing;
using System.Windows.Forms;

namespace Paint
{
    public class CircleTool : ITool
    {
        private bool _isDrawing;
        private Point _startPoint;
        private Point _endPoint;
        private Color _selectedColor;
        
        public void OnMouseDown(Graphics canvas, MouseEventArgs args)
        {
            _isDrawing = true;
            _startPoint = args.Location;
            _endPoint = args.Location;
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
            _endPoint = args.Location;
            _isDrawing = false;
            canvas.DrawEllipse(new Pen(_selectedColor), GetRect(_startPoint, _endPoint));
        }

        public void OnPaint(Graphics canvas, PaintEventArgs paintEventArgs)
        {
            paintEventArgs.Graphics.DrawEllipse(new Pen(_selectedColor), GetRect(_startPoint, _endPoint));
        }

        public void SelectPen(Color color)
        {
            _selectedColor = color;
        }

        private Rectangle GetRect(Point start, Point end)
        {
            return new Rectangle(
                Math.Min(start.X, end.X),
                Math.Min(start.Y, end.Y),
                Math.Abs(start.X - end.X),
                Math.Abs(start.Y - end.Y));
        }

        
    }
}