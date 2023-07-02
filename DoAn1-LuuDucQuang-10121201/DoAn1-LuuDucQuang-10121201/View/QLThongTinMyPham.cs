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
    public partial class QLThongTinMyPham : Form
    {
        public QLThongTinMyPham()
        {
            InitializeComponent();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        QLMyPhamBUS qlb = new QLMyPhamBUS();
        List<ThongTinMyPham> mplist ;
        List<NhaCungCap> ncclist;
        List<LoaiMyPham> loaiMP;

        public void LoadDgv()
        {
            mplist = qlb.GetThongTinMyPhams();
            dataGridView1.DataSource = mplist;
        }

        public void PhanQuyen()
        {
            if (DangNhapHT.phanquyen == "quản lý")
            {
                
            }


            if (DangNhapHT.phanquyen == "nhân viên")
            {
                btnDelete.Visible = false;
                btnEdit.Visible = false;
                btnAdd.Visible = false;
                btnNew.Visible = false;

            }
        }

        private void QLThongTinMyPham_Load(object sender, EventArgs e)
        {
            PhanQuyen();
            ncclist = qlb.GetNhaCungCaps();
            cboMaNCC.DataSource = ncclist;
            cboMaNCC.DisplayMember = "TenNCC";
            cboMaNCC.ValueMember = "MaNCC";

            loaiMP = qlb.GetLoaiMyPhams();
            cboMaLoaiMP.DataSource = loaiMP;
            cboMaLoaiMP.DisplayMember = "TenloaiMP";
            cboMaLoaiMP.ValueMember = "MaloaiMP";

            mplist = qlb.GetThongTinMyPhams();
            dataGridView1.DataSource = mplist;
            dataGridView1.Columns[dataGridView1.ColumnCount - 1].Visible = false;
            dataGridView1.Columns[dataGridView1.ColumnCount - 2].Visible = false;
            dataGridView1.Columns[dataGridView1.ColumnCount - 3].Visible = false;
            dataGridView1.Columns[dataGridView1.ColumnCount - 4].Visible = false;
            dataGridView1.Columns[dataGridView1.ColumnCount - 5].Visible = false;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;

        }

        private void cboMaLoaiMP_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //mplist = qlb.Getmaloaimp(cboMaLoaiMP.SelectedValue.ToString());
            //dataGridView1.DataSource = mplist;
            //loaiMP = qlb.GetLoaiMyPhams();
        }

        private void cboMaNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            //mplist = qlb.GetThongTinMyPhams(cboMaNCC.SelectedValue.ToString());
            //dataGridView1.DataSource = mplist;
            //ncclist = qlb.GetNhaCungCaps();

        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int dong = dataGridView1.CurrentRow.Index;
                if (dataGridView1.Rows[dong].Cells["TenMP"].Value != null)
                    txtTenMP.Text = dataGridView1.Rows[dong].Cells["TenMP"].Value.ToString();
                if (dataGridView1.Rows[dong].Cells["MaLoaiMP"].Value != null)
                    cboMaLoaiMP.SelectedValue = dataGridView1.Rows[dong].Cells["MaLoaiMP"].Value.ToString();
                if (dataGridView1.Rows[dong].Cells["MaNCC"].Value != null)
                    cboMaNCC.SelectedValue = dataGridView1.Rows[dong].Cells["MaNCC"].Value.ToString();
                if (dataGridView1.Rows[dong].Cells["Dungtich"].Value != null)
                    txtdungtich.Text = dataGridView1.Rows[dong].Cells["Dungtich"].Value.ToString();
                if (dataGridView1.Rows[dong].Cells["MaMP"].Value != null)
                    txtMaMP.Text = dataGridView1.Rows[dong].Cells["MaMP"].Value.ToString();
                if (dataGridView1.Rows[dong].Cells["Giaban"].Value != null)
                    txtGiaBan.Text = dataGridView1.Rows[dong].Cells["Giaban"].Value.ToString();
                if (dataGridView1.Rows[dong].Cells["Mota"].Value != null)
                    txtMota.Text = dataGridView1.Rows[dong].Cells["Mota"].Value.ToString();

                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnAdd.Enabled = false;
                txtMaMP.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtTenMP.Clear();
            txtMaMP.Clear();
            txtGiaBan.Clear();
            txtMota.Clear();
            txtdungtich.Clear();
            txtMaMP.Focus();
            txtMaMP.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnAdd.Enabled = true;
            LoadDgv();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTenMP.Text != "" && txtMaMP.Text != "" && txtdungtich.Text != "" && txtGiaBan.Text!= "" && txtMota.Text != "")
                {
                    ThongTinMyPham cn = new ThongTinMyPham();
                    cn.MaMP = txtMaMP.Text;
                    cn.Dungtich = txtdungtich.Text;
                    cn.MaloaiMP = cboMaLoaiMP.SelectedValue.ToString();
                    cn.MaNCC = cboMaNCC.SelectedValue.ToString();
                    cn.TenMP = txtTenMP.Text;
                    cn.Giaban = Int32.Parse(txtGiaBan.Text);
                    cn.Mota = txtMota.Text;
                    qlb.AddMP(cn);
                    mplist.Add(cn);
                    LoadDgv();
                    dataGridView1.Columns[dataGridView1.ColumnCount - 1].Visible = false;
                    dataGridView1.Columns[dataGridView1.ColumnCount - 2].Visible = false;
                    dataGridView1.Columns[dataGridView1.ColumnCount - 3].Visible = false;
                    dataGridView1.Columns[dataGridView1.ColumnCount - 4].Visible = false;
                    dataGridView1.Columns[dataGridView1.ColumnCount - 5].Visible = false;
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
                if (txtTenMP.Text != "" && txtMaMP.Text != "" && txtdungtich.Text != "" && txtGiaBan.Text != "")
                {
                    ThongTinMyPham cn = new ThongTinMyPham();
                    cn.MaMP = txtMaMP.Text;
                    cn.Dungtich = txtdungtich.Text;
                    cn.MaloaiMP = cboMaLoaiMP.SelectedValue.ToString();
                    cn.MaNCC = cboMaNCC.SelectedValue.ToString();
                    cn.TenMP = txtTenMP.Text;
                    cn.Giaban = Int32.Parse(txtGiaBan.Text);
                    cn.Mota = txtMota.Text;
                    qlb.Editmp(cn);
                    LoadDgv();
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = mplist;
                    dataGridView1.Columns[dataGridView1.ColumnCount - 1].Visible = false;
                    dataGridView1.Columns[dataGridView1.ColumnCount - 2].Visible = false;
                    dataGridView1.Columns[dataGridView1.ColumnCount - 3].Visible = false;
                    dataGridView1.Columns[dataGridView1.ColumnCount - 4].Visible = false;
                    dataGridView1.Columns[dataGridView1.ColumnCount - 5].Visible = false;
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
                if (txtTenMP.Text != "" && txtMaMP.Text != "" && txtdungtich.Text != "" && txtGiaBan.Text != "")
                {
                    ThongTinMyPham cn = new ThongTinMyPham();
                    cn.MaMP = txtMaMP.Text;
                    cn.Dungtich = txtdungtich.Text;
                    cn.MaloaiMP = cboMaLoaiMP.SelectedValue.ToString();
                    cn.MaNCC = cboMaNCC.SelectedValue.ToString();
                    cn.TenMP = txtTenMP.Text;
                    cn.Giaban = Int32.Parse(txtGiaBan.Text);
                    cn.Mota = txtMota.Text;
                    cn.Mota = txtMota.Text;
                    mplist.Remove(cn);
                    qlb.DeleteMP(cn);
                    LoadDgv();
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = mplist;
                    dataGridView1.Columns[dataGridView1.ColumnCount - 1].Visible = false;
                    dataGridView1.Columns[dataGridView1.ColumnCount - 2].Visible = false;
                    dataGridView1.Columns[dataGridView1.ColumnCount - 3].Visible = false;
                    dataGridView1.Columns[dataGridView1.ColumnCount - 4].Visible = false;
                    dataGridView1.Columns[dataGridView1.ColumnCount - 5].Visible = false;

                    MessageBox.Show("Xóa thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            var results = db.ThongTinMyPhams.Where(p => p.TenMP.ToLower().Contains(txtSearch.Text));
            dataGridView1.DataSource = results.ToList();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (QLMyPhamCuaCuaHangBanMyPhamEntities db = new QLMyPhamCuaCuaHangBanMyPhamEntities())
                {
                    db.ThongTinMyPhams.Where(p => p.TenMP.ToLower().Contains(txtSearch.Text)).ToList();
                }
            }
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Nhập tên mỹ phẩm muốn tìm")
            {
                txtSearch.Text = "";
            }
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtGiaBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
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
                worksheet.Name = "Thông tin mỹ phẩm";

                worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, 7]].Merge();
                worksheet.Cells[1, 1].Value = "THÔNG TIN MỸ PHẨM";
                worksheet.Cells[1, 1].Font.Bold = true;
                worksheet.Cells[1, 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                worksheet.Rows[1].RowHeight = 30;
                worksheet.Rows[1].Font.Name = "Arial";
                worksheet.Rows[1].Font.Size = 19;

                Excel.Range headerRange = worksheet.Range["A2", "G2"];
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
                range.Columns[6].ColumnWidth = 15;
                range.Columns[7].ColumnWidth = 15;



                worksheet.Cells[2, 1] = "Mã mỹ phẩm";
                worksheet.Cells[2, 2] = "Tên mỹ phẩm";
                worksheet.Cells[2, 3] = "Dung tích";
                worksheet.Cells[2, 4] = "Mã loại mỹ phẩm";
                worksheet.Cells[2, 5] = "Mã nhà cung cấp";
                worksheet.Cells[2, 6] = "Số lượng";
                worksheet.Cells[2, 7] = "Giá bán";



                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    for (int j = 0; j < 7; j++)
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

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

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

        private void txtGiaBan_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
