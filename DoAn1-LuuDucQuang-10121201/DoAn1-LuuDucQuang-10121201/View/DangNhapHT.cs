using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAn1_LuuDucQuang_10121201.Bussiness;
using DoAn1_LuuDucQuang_10121201.DataAccess;

namespace DoAn1_LuuDucQuang_10121201.View
{
    public partial class DangNhapHT : Form
    {
        public DangNhapHT()
        {
            InitializeComponent();
        }

        UserBUS userBUS = new UserBUS();

        public static string phanquyen="";
        
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPassWord.Text != "" && txtUserName.Text != "")
                {
                    DangNhap user = new DangNhap();
                    user = userBUS.getUs(txtUserName.Text);
                    if (user != null)
                    {
                        if (user.password == txtPassWord.Text)
                        {
                            phanquyen = user.quyen;
                            MessageBox.Show("Bạn đăng nhập thành công với quyền " + phanquyen);
                            Main f = new Main();
                            f.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Mật khẩu không chính xác");
                        }
                    }
                    else MessageBox.Show("Tài khoản không chính xác");
                }
                else
                {
                    MessageBox.Show("Không được để trống !");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void checkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkShowPass.Checked)
            {
                txtPassWord.PasswordChar = (char)0;
            }
            else
            {
                txtPassWord.PasswordChar = '*';
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
