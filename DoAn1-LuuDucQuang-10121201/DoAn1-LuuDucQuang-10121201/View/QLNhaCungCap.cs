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
    public partial class QLNhaCungCap : Form
    {
        public QLNhaCungCap()
        {
            InitializeComponent();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        QLNhaCungCapBUS nhacungcapBUS = new QLNhaCungCapBUS();
        List<NhaCungCap> nhacungcap;

        public void PhanQuyen()
        {
            if (DangNhapHT.phanquyen == "quản lý")
            {

            }


            if (DangNhapHT.phanquyen == "nhân viên")
            {
                btnXoa.Visible = false;
                btnSua.Visible = false;
                btnAdd.Visible = false;
                btnNew.Visible = false;

            }
        }

        private void QLNhaCungCap_Load(object sender, EventArgs e)
        {
            PhanQuyen();
            nhacungcap = nhacungcapBUS.GetNhaCungCaps();
            dataGridView1.DataSource = nhacungcap;
            dataGridView1.Columns[dataGridView1.ColumnCount - 1].Visible = false;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int dong = dataGridView1.CurrentRow.Index;
                if (dataGridView1.Rows[dong].Cells["MaNCC"].Value != null)
                    txtMaNCC.Text = dataGridView1.Rows[dong].Cells["MaNCC"].Value.ToString();
                if (dataGridView1.Rows[dong].Cells["TenNCC"].Value != null)
                    txtTenNCC.Text = dataGridView1.Rows[dong].Cells["TenNCC"].Value.ToString();
                if (dataGridView1.Rows[dong].Cells["Diachi"].Value != null)
                    txtDiaChiNCC.Text = dataGridView1.Rows[dong].Cells["Diachi"].Value.ToString();
                if (dataGridView1.Rows[dong].Cells["Sdt"].Value != null)
                    txtSDTNCC.Text = dataGridView1.Rows[dong].Cells["Sdt"].Value.ToString();
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnAdd.Enabled = false;
                txtMaNCC.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        public void LoadDgv()
        {
            nhacungcap = nhacungcapBUS.GetNhaCungCaps();
            dataGridView1.DataSource = nhacungcap;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtMaNCC.Clear();
            txtTenNCC.Clear();
            txtDiaChiNCC.Clear();
            txtSDTNCC.Clear();
            txtMaNCC.Focus();
            txtMaNCC.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnAdd.Enabled = true;
            LoadDgv();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaNCC.Text != "" && txtTenNCC.Text != "" && txtDiaChiNCC.Text != "" && txtSDTNCC.Text != "")
                {
                    NhaCungCap n = new NhaCungCap();
                    n.MaNCC = txtMaNCC.Text;
                    n.TenNCC = txtTenNCC.Text;
                    n.Diachi = txtDiaChiNCC.Text;
                    n.Sdt = txtSDTNCC.Text;
                    nhacungcapBUS.AddNCC(n);
                    nhacungcap.Add(n);
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaNCC.Text != "" && txtTenNCC.Text != "" && txtDiaChiNCC.Text != "" && txtSDTNCC.Text != "")
                {
                    NhaCungCap n = new NhaCungCap();
                    n.MaNCC = txtMaNCC.Text;
                    n.TenNCC = txtTenNCC.Text;
                    n.Diachi = txtDiaChiNCC.Text;
                    n.Sdt = txtSDTNCC.Text;
                    nhacungcapBUS.EditNCC(n);
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaNCC.Text != "" && txtTenNCC.Text != "" && txtDiaChiNCC.Text != "" && txtSDTNCC.Text != "")
                {
                    NhaCungCap n = new NhaCungCap();
                    n.MaNCC = txtMaNCC.Text;
                    n.TenNCC = txtTenNCC.Text;
                    n.Diachi = txtDiaChiNCC.Text;
                    n.Sdt = txtSDTNCC.Text;
                    nhacungcapBUS.DeleteNCC(n);
                    nhacungcap.Remove(n);
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
            var results = db.NhaCungCaps.Where(p => p.TenNCC.ToLower().Contains(txtSearch.Text));
            dataGridView1.DataSource = results.ToList();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (QLMyPhamCuaCuaHangBanMyPhamEntities db = new QLMyPhamCuaCuaHangBanMyPhamEntities())
                {
                    db.NhaCungCaps.Where(p => p.TenNCC.ToLower().Contains(txtSearch.Text)).ToList();
                }
            }
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Nhập tên nhà cung cấp muốn tìm")
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
                worksheet.Name = "Thông tin nhà cung cấp";

                worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, 4]].Merge();
                worksheet.Cells[1, 1].Value = "THÔNG TIN NHÀ CUNG CẤP";
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


                worksheet.Cells[2, 1] = "Mã nhà cung cấp";
                worksheet.Cells[2, 2] = "Tên nhà cung cấp";
                worksheet.Cells[2, 3] = "Địa chỉ";
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

        private void txtSDTNCC_KeyPress(object sender, KeyPressEventArgs e)
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
                btnXoa.Enabled = true;
                btnSua.Enabled = true;
            }
            else
            {
                btnXoa.Enabled = false;
                btnSua.Enabled = false;
            }
        }
    }
}
