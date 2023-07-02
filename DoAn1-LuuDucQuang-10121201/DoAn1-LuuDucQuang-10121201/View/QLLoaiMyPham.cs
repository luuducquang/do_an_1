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
    public partial class QLLoaiMyPham : Form
    {
        public QLLoaiMyPham()
        {
            InitializeComponent();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        QLLoaiMyPhamBUS loaiMyPhamBUS = new QLLoaiMyPhamBUS();
        List<LoaiMyPham> loaiMyPham;


        public void PhanQuyen()
        {
            if (DangNhapHT.phanquyen == "quản lý")
            {

            }


            if (DangNhapHT.phanquyen == "nhân viên")
            {
                btnNew.Visible = false;
                btnAdd.Visible = false;
                btnEdit.Visible = false;
                btnDelete.Visible = false;
            }
        }
        private void QLLoaiMyPham_Load(object sender, EventArgs e)
        {
            PhanQuyen();
            loaiMyPham = loaiMyPhamBUS.GetLoaiMyPhams();
            dataGridView1.DataSource = loaiMyPham;
            dataGridView1.Columns[dataGridView1.ColumnCount - 1].Visible = false;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int dong = dataGridView1.CurrentRow.Index;
                if (dataGridView1.Rows[dong].Cells["MaLoaiMP"].Value != null)
                    txtMaloaiMP.Text = dataGridView1.Rows[dong].Cells["MaLoaiMP"].Value.ToString();
                if (dataGridView1.Rows[dong].Cells["TenloaiMP"].Value != null)
                    txtTenloaiMP.Text = dataGridView1.Rows[dong].Cells["TenloaiMP"].Value.ToString();
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnAdd.Enabled = false;
                txtMaloaiMP.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void LoadDgv()
        {
            loaiMyPham = loaiMyPhamBUS.GetLoaiMyPhams();
            dataGridView1.DataSource = loaiMyPham;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtMaloaiMP.Clear();
            txtTenloaiMP.Clear();
            txtMaloaiMP.Focus();
            txtMaloaiMP.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnAdd.Enabled = true;
            LoadDgv();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaloaiMP.Text != "" && txtTenloaiMP.Text != "")
                {
                    LoaiMyPham n = new LoaiMyPham();
                    n.MaloaiMP = txtMaloaiMP.Text;
                    n.TenloaiMP = txtTenloaiMP.Text;
                    loaiMyPhamBUS.AddLoaiMP(n);
                    loaiMyPham.Add(n);
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
                if (txtMaloaiMP.Text != "" && txtTenloaiMP.Text != "")
                {
                    LoaiMyPham n = new LoaiMyPham();
                    n.MaloaiMP = txtMaloaiMP.Text;
                    n.TenloaiMP = txtTenloaiMP.Text;
                    loaiMyPhamBUS.EditLoaiMP(n);
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
                if (txtMaloaiMP.Text != "" && txtTenloaiMP.Text != "")
                {
                    LoaiMyPham n = new LoaiMyPham();
                    n.MaloaiMP = txtMaloaiMP.Text;
                    n.TenloaiMP = txtTenloaiMP.Text;
                    loaiMyPhamBUS.DeleteLoaiMP(n);
                    loaiMyPham.Remove(n);
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
            var results = db.LoaiMyPhams.Where(p => p.TenloaiMP.ToLower().Contains(txtSearch.Text));
            dataGridView1.DataSource = results.ToList();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (QLMyPhamCuaCuaHangBanMyPhamEntities db = new QLMyPhamCuaCuaHangBanMyPhamEntities())
                {
                    db.LoaiMyPhams.Where(p => p.TenloaiMP.ToLower().Contains(txtSearch.Text)).ToList();
                }
            }
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Nhập tên loại mỹ phẩm muốn tìm")
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
                worksheet.Name = "Thông tin loại mỹ phẩm";

                worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, 2]].Merge();
                worksheet.Cells[1, 1].Value = "THÔNG TIN LOẠI MỸ PHẨM";
                worksheet.Cells[1, 1].Font.Bold = true;
                worksheet.Cells[1, 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                worksheet.Rows[1].RowHeight = 30;
                worksheet.Rows[1].Font.Name = "Arial";
                worksheet.Rows[1].Font.Size = 13;

                Excel.Range headerRange = worksheet.Range["A2", "B2"];
                headerRange.Font.Bold = true; 
                headerRange.Interior.Color = System.Drawing.Color.Yellow; 

                Excel.Range range = worksheet.Range["A2", worksheet.Cells[dgv.Rows.Count + 2, dgv.Columns.Count]];

                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                range.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;


                range.Columns[1].ColumnWidth = 15;
                range.Columns[2].ColumnWidth = 15;



                worksheet.Cells[2, 1] = "Mã loại mỹ phẩm";
                worksheet.Cells[2, 2] = "Tên loại mỹ phẩm";



                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    for (int j = 0; j < 2; j++)
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
