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
using Excel = Microsoft.Office.Interop.Excel;

namespace DoAn1_LuuDucQuang_10121201.View
{
    public partial class QLKhachHang : Form
    {
        public QLKhachHang()
        {
            InitializeComponent();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        QLKhachHangBUS khachHangBUS = new QLKhachHangBUS();
        List<KhachHang> khachHang;

        public void PhanQuyen()
        {
            if (DangNhapHT.phanquyen == "quản lý")
            {

            }


            if (DangNhapHT.phanquyen == "nhân viên")
            {
                btnDelete.Visible = false;
                btnEdit.Visible = false;

            }
        }
        private void QLKhachHang_Load(object sender, EventArgs e)
        {
            PhanQuyen();
            khachHang = khachHangBUS.GetKhachHangs();
            dataGridView1.DataSource = khachHang;
            dataGridView1.Columns[dataGridView1.ColumnCount - 1].Visible = false;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int dong = dataGridView1.CurrentRow.Index;
                if (dataGridView1.Rows[dong].Cells["MaKH"].Value != null)
                    txtMaKH.Text = dataGridView1.Rows[dong].Cells["MaKH"].Value.ToString();
                if (dataGridView1.Rows[dong].Cells["TenKH"].Value != null)
                    txtTenKH.Text = dataGridView1.Rows[dong].Cells["TenKH"].Value.ToString();
                if (dataGridView1.Rows[dong].Cells["GioiTinh"].Value != null)
                    txtGioitinh.Text = dataGridView1.Rows[dong].Cells["GioiTinh"].Value.ToString();
                if (dataGridView1.Rows[dong].Cells["DiaChi"].Value != null)
                    txtDiaChi.Text = dataGridView1.Rows[dong].Cells["DiaChi"].Value.ToString();
                if (dataGridView1.Rows[dong].Cells["Sdt"].Value != null)
                    txtSDT.Text = dataGridView1.Rows[dong].Cells["Sdt"].Value.ToString();
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnAdd.Enabled = false;
                txtMaKH.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void LoadDgv()
        {
            khachHang = khachHangBUS.GetKhachHangs();
            dataGridView1.DataSource = khachHang;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            LoadDgv();
            txtMaKH.Clear();
            txtTenKH.Clear();
            txtDiaChi.Clear();
            txtSDT.Clear();
            txtGioitinh.Clear();
            txtMaKH.Focus();
            txtMaKH.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnAdd.Enabled = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaKH.Text != "" && txtTenKH.Text != "" && txtGioitinh.Text != "" && txtDiaChi.Text != "" && txtSDT.Text != "")
                {
                    KhachHang n = new KhachHang();
                    n.MaKH = txtMaKH.Text;
                    n.TenKH = txtTenKH.Text;
                    n.DiaChi = txtDiaChi.Text;
                    n.GioiTinh = txtGioitinh.Text;
                    n.Sdt = txtSDT.Text;
                    khachHangBUS.AddKH(n);
                    khachHang.Add(n);
                    LoadDgv();
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
                if (txtMaKH.Text != "" && txtTenKH.Text != "" && txtGioitinh.Text != "" && txtDiaChi.Text != "" && txtSDT.Text != "")
                {
                    KhachHang n = new KhachHang();
                    n.MaKH = txtMaKH.Text;
                    n.TenKH = txtTenKH.Text;
                    n.DiaChi = txtDiaChi.Text;
                    n.GioiTinh = txtGioitinh.Text;
                    n.Sdt = txtSDT.Text;
                    khachHangBUS.EditKH(n);
                    LoadDgv();
                    MessageBox.Show("Sửa thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không được để trống !");
                }
            }
            catch(Exception ex)
{
                MessageBox.Show(ex.Message);
            }


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaKH.Text != "" && txtTenKH.Text != "" && txtGioitinh.Text != "" && txtDiaChi.Text != "" && txtSDT.Text != "")
                {
                    KhachHang n = new KhachHang();
                    n.MaKH = txtMaKH.Text;
                    n.TenKH = txtTenKH.Text;
                    n.DiaChi = txtDiaChi.Text;
                    n.GioiTinh = txtGioitinh.Text;
                    n.Sdt = txtSDT.Text;
                    khachHangBUS.DeleteKH(n);
                    khachHang.Remove(n);
                    LoadDgv();
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

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            QLMyPhamCuaCuaHangBanMyPhamEntities db = new QLMyPhamCuaCuaHangBanMyPhamEntities();
            var results = db.KhachHangs.Where(p => p.TenKH.ToLower().Contains(txtSearch.Text));
            dataGridView1.DataSource = results.ToList();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (QLMyPhamCuaCuaHangBanMyPhamEntities db = new QLMyPhamCuaCuaHangBanMyPhamEntities())
                {
                    db.KhachHangs.Where(p => p.TenKH.ToLower().Contains(txtSearch.Text)).ToList();
                }
            }
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Nhập tên khách hàng muốn tìm")
            {
                txtSearch.Text = "";
            }
        }

        private void ExportToExcel(DataGridView dgv)
        {
            Excel.Application excel = new Excel.Application();
            Excel.Workbook workbook = excel.Workbooks.Add(Type.Missing);
            Excel.Worksheet worksheet = null;

            try
            {
                worksheet = workbook.ActiveSheet;
                worksheet.Name = "Thông tin khách hàng";

                worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, 4]].Merge();
                worksheet.Cells[1, 1].Value = "THÔNG TIN KHÁCH HÀNG";
                worksheet.Cells[1, 1].Font.Bold = true;
                worksheet.Cells[1, 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                worksheet.Rows[1].RowHeight = 30;
                worksheet.Rows[1].Font.Name = "Arial";
                worksheet.Rows[1].Font.Size = 19;

                Excel.Range headerRange = worksheet.Range["A2", "D2"]; 
                headerRange.Font.Bold = true; 
                headerRange.Interior.Color = System.Drawing.Color.Yellow; 


                Excel.Range range = worksheet.Range["A2", worksheet.Cells[dgv.Rows.Count + 2, dgv.Columns.Count]];

                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                range.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;


                range.Columns[1].ColumnWidth = 15;
                range.Columns[2].ColumnWidth = 15;
                range.Columns[3].ColumnWidth = 15;
                range.Columns[4].ColumnWidth = 15;



                worksheet.Cells[2, 1] = "Mã khách hàng";
                worksheet.Cells[2, 2] = "Tên khách hàng";
                worksheet.Cells[2, 3] = "Giới tính";
                worksheet.Cells[2, 4] = "Số điện thoại";



                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        worksheet.Cells[i + 3, j + 1] = dgv.Rows[i].Cells[j].Value.ToString();
                    }
                }


                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel Workbook|*.xlsx";
                saveFileDialog.Title = "Lưu tệp Excel";
                saveFileDialog.ShowDialog();

                if (saveFileDialog.FileName != "")
                {
                    workbook.SaveAs(saveFileDialog.FileName);
                    MessageBox.Show("Dữ liệu đã được xuất thành công sang tệp Excel!");
                    System.Diagnostics.Process.Start(saveFileDialog.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                excel.Quit();
                workbook = null;
                excel = null;
            }
        }
        private void btnexcel_Click(object sender, EventArgs e)
        {
            ExportToExcel(dataGridView1);
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                btnDelete.Enabled = true;
                btnEdit.Enabled = true;
            }
            else
            {
                btnDelete.Enabled = false;
                btnEdit.Enabled = false;
            }
        }
    }
}
