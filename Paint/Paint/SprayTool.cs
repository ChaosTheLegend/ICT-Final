using System;
using System.Drawing;
using System.Windows.Forms;

namespace Paint
{
    public class SprayTool : ITool
    {
        private const int Radius = 25;
        private const int Iterations = 50;
        private bool _isDrawing;
        private Color _selectedColor;

        public void OnMouseDown(Graphics canvas, MouseEventArgs args)
        {
            _isDrawing = true;
        }

        public void OnMouseMove(Graphics canvas, MouseEventArgs args)
        {
            if (_isDrawing)
            {
                Spay(canvas, args);
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
        
        private void Spay(Graphics canvas, MouseEventArgs e)
        {
            var rand = new Random();
            var mousePos = e.Location;
            for (int i = 0; i<Iterations; i++)
            {
                var angle = rand.Next(0, 360);
                var size = rand.Next(0, Radius);
                var distance = FromPolarToPoint(angle, size);
                var pos = new Point(mousePos.X + distance.X, mousePos.Y + distance.Y);
                canvas.FillEllipse(new SolidBrush(_selectedColor), new Rectangle(pos, new Size(2, 2)));
            }
        }

        public Point FromPolarToPoint(int angle, int radius)
        {
            var rad = angle * Math.PI / 180;
            var x = radius * Math.Cos(angle);
            var y = radius * Math.Sin(angle);
            
            return new Point((int)x, (int)y);
        }
    }
}