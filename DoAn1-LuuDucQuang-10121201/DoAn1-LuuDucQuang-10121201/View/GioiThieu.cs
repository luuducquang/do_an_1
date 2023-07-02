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
    public partial class GioiThieu : Form
    {
        public GioiThieu()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void login_Click(object sender, EventArgs e)
        {
        }

        private void regestry_Click(object sender, EventArgs e)
        {

        }
        

        private void exit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn chắc chắn muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
