using System;
using System.Drawing;
using System.Windows.Forms;

namespace Paint
{
    public class RectangleTool : ITool
    {
        private Point _startPoint;
        private Point _endPoint;
        private bool _isDrawing;
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
            _isDrawing = false;
            canvas.DrawRectangle(new Pen(_selectedColor), GetRect(_startPoint, _endPoint));
        }

        public void OnPaint(Graphics canvas, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(_selectedColor), GetRect(_startPoint, _endPoint));
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