using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAn1_LuuDucQuang_10121201.DataAccess;
using DoAn1_LuuDucQuang_10121201.Bussiness;

namespace DoAn1_LuuDucQuang_10121201.View
{
    public partial class QLTaiKhoan : Form
    {
        public QLTaiKhoan()
        {
            InitializeComponent();
            dgvqltk.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            cboQuyen.Items.Add("nhân viên");
            cboQuyen.Items.Add("quản lý");
        }

        UserBUS ql = new UserBUS();
        List<DangNhap> list;

        public void Loaddgv()
        {
            list = ql.listUser();
            dgvqltk.DataSource = list;
        }

        private void QLTaiKhoan_Load(object sender, EventArgs e)
        {
            //list = ql.listUser();
            //cboQuyen.DataSource = list;
            //cboQuyen.DisplayMember = "quyen";
            //cboQuyen.ValueMember = "quyen";
            Loaddgv();
            dgvqltk.SelectionChanged += dgvqltk_SelectionChanged;
        }


        private void dgvqltk_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int dong = dgvqltk.CurrentRow.Index;
                if (dgvqltk.Rows[dong].Cells["username"].Value != null)
                    txtQLuser.Text = dgvqltk.Rows[dong].Cells["username"].Value.ToString();
                if (dgvqltk.Rows[dong].Cells["password"].Value != null)
                    txtQLpass.Text = dgvqltk.Rows[dong].Cells["password"].Value.ToString();
                if (dgvqltk.Rows[dong].Cells["quyen"].Value != null)
                    cboQuyen.Text = dgvqltk.Rows[dong].Cells["quyen"].Value.ToString();
                btnEdit.Enabled = true;
                btnDeleteAccount.Enabled = true;
                btnAdd.Enabled = false;
                txtQLuser.Enabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtQLuser.Text != "" && txtQLpass.Text != "")
                {
                    DangNhap user = new DangNhap();
                    user.username = txtQLuser.Text;
                    user.password = txtQLpass.Text;
                    user.quyen = cboQuyen.SelectedItem.ToString();
                    ql.DeleteUser(user);
                    list.Remove(user);
                    Loaddgv();
                    MessageBox.Show("Xoá thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtQLuser.Text != "" && txtQLpass.Text != "")
                {
                    DangNhap user = new DangNhap();
                    user.username = txtQLuser.Text;
                    user.password = txtQLpass.Text;
                    user.quyen = cboQuyen.SelectedItem.ToString();
                    ql.EditPass(user);
                    Loaddgv();
                    MessageBox.Show("Sửa thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtQLuser.Text != "" && txtQLpass.Text != "" && cboQuyen.Text != "")
                {
                    DangNhap user = new DangNhap();
                    user.username = txtQLuser.Text;
                    user.password = txtQLpass.Text;
                    user.quyen = cboQuyen.SelectedItem.ToString();
                    ql.Addtk(user);
                    list.Add(user);
                    Loaddgv();
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

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtQLuser.Clear();
            txtQLpass.Clear();
            txtQLuser.Focus();
            txtQLuser.Enabled = true;
            btnEdit.Enabled = false;
            btnDeleteAccount.Enabled = false;
            btnAdd.Enabled = true;
            Loaddgv();
        }

        

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            QLMyPhamCuaCuaHangBanMyPhamEntities db = new QLMyPhamCuaCuaHangBanMyPhamEntities();
            var results = db.DangNhaps.Where(p => p.username.Contains(txtSearch.Text));
            dgvqltk.DataSource = results.ToList();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (QLMyPhamCuaCuaHangBanMyPhamEntities db = new QLMyPhamCuaCuaHangBanMyPhamEntities())
                {
                    db.DangNhaps.Where(p => p.username.Contains(txtSearch.Text)).ToList();
                }
            }
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Nhập tài khoản muốn tìm")
            {
                txtSearch.Text = "";
            }
        }

        private void cboQuyen_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvqltk_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvqltk.SelectedRows.Count > 0)
            {
                btnDeleteAccount.Enabled = true;
                btnEdit.Enabled = true;
            }
            else
            {
                btnDeleteAccount.Enabled = false;
                btnEdit.Enabled = false;
            }
        }
    }
}
