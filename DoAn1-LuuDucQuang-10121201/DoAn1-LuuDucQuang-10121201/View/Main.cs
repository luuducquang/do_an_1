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
    public partial class Main : Form
    {
        DangNhapHT ht = new DangNhapHT();
        public Main()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.IsMdiContainer = true;
        }

        

        private Form currentchildForm;
        private void OpenChildForm(Form childForm)
        {
            if(currentchildForm != null)
            {
                currentchildForm.Close();
            }
                currentchildForm = childForm;
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;
                panel4.Controls.Add(childForm);
                panel4.Tag = childForm;
                childForm.BringToFront();
                childForm.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        


        public void PhanQuyen()
        {
            if(DangNhapHT.phanquyen == "quản lý")
            {
                
            }


            if(DangNhapHT.phanquyen == "nhân viên")
            {
                guna2GradientButton2.Enabled = false;
                btnQLtaikhoan.Visible = false;
                btnThongke.Visible = false;
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            PhanQuyen();
        }

        



        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new TrangChu());
            label1.Text = guna2GradientButton1.Text;
        }

        private void ttMypham_Click(object sender, EventArgs e)
        {
            OpenChildForm(new QLThongTinMyPham());
            label1.Text = ttMypham.Text;
        }

        private void btnLoaiMP_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new QLLoaiMyPham());
            label1.Text = btnLoaiMP.Text;
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new QLThongTinNhanVien());
            label1.Text = guna2GradientButton2.Text;
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new QLNhaCungCap());
            label1.Text = guna2GradientButton3.Text;
        }

        private void btnKhachhang_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new QLKhachHang());
            label1.Text = btnKhachhang.Text;
        }

        private void btnHDB_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new QLHoaDonBan());
            label1.Text = btnHDB.Text;
        }


        private void btnHDN_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new QLHoaDonNhap());
            label1.Text = btnHDN.Text;
        }

        private void btnThongke_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new Thongke());
            label1.Text = btnThongke.Text;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            DangNhapHT f = new DangNhapHT();
            f.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnQLtaikhoan_Click(object sender, EventArgs e)
        {
            OpenChildForm(new QLTaiKhoan());
            label1.Text = btnQLtaikhoan.Text;
        }
    }
}
