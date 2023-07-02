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
    public partial class Thongke : Form
    {
        public Thongke()
        {
            InitializeComponent();
        }

        private Form currentchildForm;
        private void OpenChildForm(Form childForm)
        {
            if (currentchildForm != null)
            {
                currentchildForm.Close();
            }
            currentchildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelcontent.Controls.Add(childForm);
            panelcontent.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ThongkeHDB());
            label2.Text = btnHDB.Text;
        }

        private void Thongke_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnHDN_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ThongkeHDN());
            label2.Text = btnHDN.Text;
        }

        private void btnTonkho_Click(object sender, EventArgs e)
        {
            OpenChildForm(new QLTonKho());
            label2.Text = btnHDN.Text;
        }
    }
}
