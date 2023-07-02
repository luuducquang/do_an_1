using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn1_LuuDucQuang_10121201.View
{
    public partial class MDI : Form
    {
        public MDI()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        private void thôngTinMỹPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLThongTinMyPham a = new QLThongTinMyPham();
            a.MdiParent = this;
            a.Show();
        }

        private void thôngTinNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLThongTinNhanVien b = new QLThongTinNhanVien();
            b.Show();
        }

        private void thôngTinNhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLNhaCungCap b = new QLNhaCungCap();
            b.Show();
        }

        private void thôngTinKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLKhachHang b = new QLKhachHang();
            b.Show();
        }

        private void MDI_Load(object sender, EventArgs e)
        {

        }

        private void hoáĐơnNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLHoaDonNhap a = new QLHoaDonNhap();
            a.Show();
        }

        private void hoáĐơnBánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLHoaDonBan b = new QLHoaDonBan();
            b.Show();
        }
    }
}
