using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace Dijkstra_v2._0._1
{
    public partial class DoThi : Form
    {
        public delegate void LayDuLieu(List<string[]> dsCanh, int[] nhan, int sodinh);
        public LayDuLieu DuLieu;
        int _sodinh;
        List<string[]> _dsCanh;
        int[] _kq;

        public DoThi()
        {
            InitializeComponent();
            DuLieu = new LayDuLieu(TruyenDuLieu);
        }
        void TruyenDuLieu(List<string[]> dsCanh, int[] kq, int sodinh) // lấy dữ liệu từ form chính
        {
            _dsCanh = dsCanh;
            _kq = kq;
            _sodinh = sodinh;
        }
        /*--------------------------------- HÀM XỬ LÝ -------------------------------*/
        void VeDoThi(int sodinh, PaintEventArgs e)
        {
            Font myfont = new Font(FontFamily.GenericSansSerif, 14, FontStyle.Regular);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            e.Graphics.InterpolationMode = InterpolationMode.High;
            e.Graphics.TextRenderingHint = TextRenderingHint.SingleBitPerPixel;

            Brush black = new SolidBrush(Color.Black);
            Pen pencil = new Pen(Color.Black, 1);
            Pen redpen = new Pen(Color.Red, 2);

            Random rd = new Random();
            int w = this.Width;
            int h = this.Height;
            int dem = 0;

            Point[] ds = new Point[sodinh + 1];

            for(int i = 1; i <= sodinh; i++)
            {
                int vitri_w;
                int vitri_h;
                if(i <= sodinh / 2)
                {
                    vitri_w = w / sodinh * 2 * i - w / sodinh;
                    if (i % 2 == 0)
                        vitri_h = rd.Next(50, h / 4);
                    else
                        vitri_h = rd.Next(h / 4, h / 2);
                }
                else
                {
                    vitri_w = w / sodinh * 2 * (i- sodinh / 2) - w / sodinh;
                    if (i % 2 == 0)
                        vitri_h = rd.Next(h / 2, h * 3 / 4);
                    else
                        vitri_h = rd.Next(h * 3 / 4, h - 50);
                }    

                Point diem = new Point( vitri_w , vitri_h);
                ds[i] = diem;
            }
            foreach (string[] x in _dsCanh)
            {
                e.Graphics.DrawLine(pencil, ds[int.Parse(x[0])], ds[int.Parse(x[1])]);
            }
            while (_kq[dem] != 1)
            {
                e.Graphics.DrawLine(redpen, ds[_kq[dem]], ds[_kq[dem + 1]]);
                dem++;
            }
            for(int i = 1; i <= sodinh; i++)
            {
                e.Graphics.DrawString(i + "", myfont, black, ds[i]);
            }    
        }
        private void DoThi_Load(object sender, EventArgs e)
        {
            
            
        }

        private void pnBangVe_Paint(object sender, PaintEventArgs e)
        {
            VeDoThi(_sodinh, e);
        }

        private void pnBangVe_SizeChanged(object sender, EventArgs e)
        {
            pnBangVe.Invalidate();
        }

        private void DoThi_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.R)
            {
                Refresh();
                return;
                //MessageBox.Show("Nhấn R");
            }
            return;
        }
    }
}
