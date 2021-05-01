using System.Drawing;
using System.Windows.Forms;

namespace Paint
{
    public class EraiserTool:ITool
    {
        private Point _startPoint;
        private bool _isDrawing;
        public void OnMouseDown(Graphics canvas, MouseEventArgs args)
        {
            _isDrawing = true;
            _startPoint = new Point(args.X, args.Y);
        }

        public void OnMouseMove(Graphics canvas, MouseEventArgs args)
        {
            if (_isDrawing)
            {
                var pen = new Pen(Color.White, 10f);
                canvas.DrawLine(pen, _startPoint.X, _startPoint.Y, args.X, args.Y);
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

        public void SelectPen(Color color) { }
        
    }
}