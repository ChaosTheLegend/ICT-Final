using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
  public partial class Form1 : Form
  {
      private ITool _selectedTool;
      private Button _selectedButton;
      private Graphics _canvas;
      private Color _selectedColor;
      private Bitmap _bitmap;
        public Form1()
        {
            InitializeComponent();
            _selectedTool = new PenTool();
            _bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            _canvas = Graphics.FromImage(_bitmap);
            pictureBox1.Image = _bitmap;
            SelectTool(button1, new PenTool());
        }
        
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            _selectedTool.OnMouseDown(_canvas, e);
            pictureBox1.Refresh();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            _selectedTool.OnMouseUp(_canvas, e);
            pictureBox1.Refresh();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            _selectedTool.OnMouseMove(_canvas, e);
            pictureBox1.Refresh();
            toolStripStatusLabel1.Text = $"{e.X}:{e.Y}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(_selectedButton != null) _selectedButton.Enabled = true;
            _selectedButton = (Button)sender;
            _selectedTool = new PenTool();
            _selectedButton.Enabled = false;
        }

        private void SelectTool(Button btn, ITool tool)
        {
            if (_selectedButton != null)
            {
                _selectedButton.Enabled = true;
            }
            _selectedTool = tool;
            _selectedButton = btn;
            _selectedButton.Enabled = false;
            _selectedTool.SelectPen(_selectedColor);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SelectTool((Button)sender, new EraiserTool());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SelectTool((Button)sender, new LineTool());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SelectTool((Button) sender, new FillTool());
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            _selectedTool.OnPaint(_canvas , e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SelectTool((Button) sender, new RectangleTool());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SelectTool((Button) sender, new CircleTool());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SelectTool((Button) sender, new SprayTool());
        }

        private void SelectColor(object sender, EventArgs e)
        {
            var btn = (Button) sender;
            var color = btn.BackColor;
            _selectedColor = color;
            _selectedTool.SelectPen(color);
        }

        private void SavePicture(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                _bitmap.Save(saveFileDialog1.FileName);
            }
        }

        private void OpenFile(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                _bitmap = Image.FromFile(openFileDialog1.FileName) as Bitmap; 
                _canvas = Graphics.FromImage(_bitmap);
                pictureBox1.Image = _bitmap;
                pictureBox1.Refresh();
            }
        }
  }
}