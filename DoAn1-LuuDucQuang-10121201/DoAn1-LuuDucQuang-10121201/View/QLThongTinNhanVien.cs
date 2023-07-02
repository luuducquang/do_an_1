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
    public partial class QLThongTinNhanVien : Form
    {
        public QLThongTinNhanVien()
        {
            InitializeComponent();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        QLNhanVienBUS nhanvienBUS = new QLNhanVienBUS();
        List<NhanVien> nhanvien;


        private void QLThongTinNhanVien_Load(object sender, EventArgs e)
        {
            nhanvien = nhanvienBUS.GetNhanViens();
            dataGridView1.DataSource = nhanvien;
            dataGridView1.Columns[dataGridView1.ColumnCount - 1].Visible = false;
            dataGridView1.Columns[dataGridView1.ColumnCount - 2].Visible = false;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
        }

        public void LoadDgv()
        {
            nhanvien = nhanvienBUS.GetNhanViens();
            dataGridView1.DataSource = nhanvien;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int dong = dataGridView1.CurrentRow.Index;
                if (dataGridView1.Rows[dong].Cells["MaNV"].Value != null)
                    txtMaNV.Text = dataGridView1.Rows[dong].Cells["MaNV"].Value.ToString();
                if (dataGridView1.Rows[dong].Cells["TenNV"].Value != null)
                    txtTenNV.Text = dataGridView1.Rows[dong].Cells["TenNV"].Value.ToString();
                if (dataGridView1.Rows[dong].Cells["GioiTinh"].Value != null)
                    txtGioiTinh.Text = dataGridView1.Rows[dong].Cells["GioiTinh"].Value.ToString();
                if (dataGridView1.Rows[dong].Cells["DiaChi"].Value != null)
                    txtDiaChi.Text = dataGridView1.Rows[dong].Cells["DiaChi"].Value.ToString();
                if (dataGridView1.Rows[dong].Cells["Sdt"].Value != null)
                    txtSDT.Text = dataGridView1.Rows[dong].Cells["Sdt"].Value.ToString();
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnAdd.Enabled = false;
                txtMaNV.Enabled = false;
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
                if (txtMaNV.Text != "" && txtTenNV.Text != "" && txtGioiTinh.Text != "" && txtSDT.Text != "" && txtDiaChi.Text != "")
                {
                    NhanVien n = new NhanVien();
                    n.MaNV = txtMaNV.Text;
                    n.TenNV = txtTenNV.Text;
                    n.DiaChi = txtDiaChi.Text;
                    n.GioiTinh = txtGioiTinh.Text;
                    n.Sdt = txtSDT.Text;
                    nhanvienBUS.AddNhanVien(n);
                    nhanvien.Add(n);
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
                if (txtMaNV.Text != "" && txtTenNV.Text != "" && txtGioiTinh.Text != "" && txtSDT.Text != "" && txtDiaChi.Text != "")
                {
                    NhanVien n = new NhanVien();
                    n.MaNV = txtMaNV.Text;
                    n.TenNV = txtTenNV.Text;
                    n.DiaChi = txtDiaChi.Text;
                    n.GioiTinh = txtGioiTinh.Text;
                    n.Sdt = txtSDT.Text;
                    nhanvienBUS.EditNhanvien(n);
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaNV.Text != "" && txtTenNV.Text != "" && txtGioiTinh.Text != "" && txtSDT.Text != "" && txtDiaChi.Text != "")
                {
                    NhanVien n = new NhanVien();
                    n.MaNV = txtMaNV.Text;
                    n.TenNV = txtTenNV.Text;
                    n.DiaChi = txtDiaChi.Text;
                    n.GioiTinh = txtGioiTinh.Text;
                    n.Sdt = txtSDT.Text;
                    nhanvienBUS.DeleteNhanVIen(n);
                    nhanvien.Remove(n);
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

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtMaNV.Clear();
            txtTenNV.Clear();
            txtSDT.Clear();
            txtGioiTinh.Clear();
            txtDiaChi.Clear();
            txtMaNV.Focus(); 
            txtMaNV.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnAdd.Enabled = true;
            LoadDgv();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            QLMyPhamCuaCuaHangBanMyPhamEntities db = new QLMyPhamCuaCuaHangBanMyPhamEntities();
            var results = db.NhanViens.Where(p => p.TenNV.ToLower().Contains(txtSearch.Text));
            dataGridView1.DataSource = results.ToList();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (QLMyPhamCuaCuaHangBanMyPhamEntities db = new QLMyPhamCuaCuaHangBanMyPhamEntities())
                {
                    db.NhanViens.Where(p => p.TenNV.ToLower().Contains(txtSearch.Text)).ToList();
                }
            }
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Nhập tên nhân viên muốn tìm")
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
                worksheet.Name = "Thông tin nhân viên";

                worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, 5]].Merge();
                worksheet.Cells[1, 1].Value = "THÔNG TIN NHÂN VIÊN";
                worksheet.Cells[1, 1].Font.Bold = true;
                worksheet.Cells[1, 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                worksheet.Rows[1].RowHeight = 30;
                worksheet.Rows[1].Font.Name = "Arial";
                worksheet.Rows[1].Font.Size = 19;

                Excel.Range headerRange = worksheet.Range["A2", "E2"]; 
                headerRange.Font.Bold = true; 
                headerRange.Interior.Color = System.Drawing.Color.Yellow; 


                Excel.Range range = worksheet.Range["A2", worksheet.Cells[dgv.Rows.Count + 2, dgv.Columns.Count]];

                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                range.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;


                range.Columns[1].ColumnWidth = 15;
                range.Columns[2].ColumnWidth = 15;
                range.Columns[3].ColumnWidth = 15;
                range.Columns[4].ColumnWidth = 15;
                range.Columns[5].ColumnWidth = 15;



                worksheet.Cells[2, 1] = "Mã nhân viên";
                worksheet.Cells[2, 2] = "Tên nhân viên";
                worksheet.Cells[2, 3] = "Giới tính";
                worksheet.Cells[2, 4] = "Địa chỉ";
                worksheet.Cells[2, 5] = "Số điện thoại";



                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    for (int j = 0; j < 5; j++)
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

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
