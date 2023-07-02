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
    public partial class QLTonKho : Form
    {
        public QLTonKho()
        {
            InitializeComponent();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        QLTonKhoBUS tonKhoBUS = new QLTonKhoBUS();
        List<Tonkho> tonkho;

        private void QLTonKho_Load(object sender, EventArgs e)
        {
            tonkho = tonKhoBUS.GetTonkhos();
            dataGridView1.DataSource = tonkho;
            dataGridView1.Columns[dataGridView1.ColumnCount - 1].Visible = false;

            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int dong = dataGridView1.CurrentRow.Index;
                if (dataGridView1.Rows[dong].Cells["MaMP"].Value != null)
                    txtMaMP.Text = dataGridView1.Rows[dong].Cells["MaMP"].Value.ToString();
                if (dataGridView1.Rows[dong].Cells["SLton"].Value != null)
                    txtSoLuong.Text = dataGridView1.Rows[dong].Cells["SLton"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void LoadDgv()
        {
            tonkho = tonKhoBUS.GetTonkhos();
            dataGridView1.DataSource = tonkho;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaMP.Text != "" && txtSoLuong.Text != "")
                {
                    Tonkho n = new Tonkho();
                    n.MaMP = txtMaMP.Text;
                    n.SLton = Int32.Parse(txtSoLuong.Text);
                    tonKhoBUS.EditTonkho(n);
                    LoadDgv();
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

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Nhập mã mỹ phẩm muốn tìm")
            {
                txtSearch.Text = "";
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (QLMyPhamCuaCuaHangBanMyPhamEntities db = new QLMyPhamCuaCuaHangBanMyPhamEntities())
                {
                    db.Tonkhoes.Where(p => p.MaMP.ToLower().Contains(txtSearch.Text)).ToList();
                }
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            QLMyPhamCuaCuaHangBanMyPhamEntities db = new QLMyPhamCuaCuaHangBanMyPhamEntities();
            var results = db.Tonkhoes.Where(p => p.MaMP.ToLower().Contains(txtSearch.Text));
            dataGridView1.DataSource = results.ToList();
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            
        }
    }
}
