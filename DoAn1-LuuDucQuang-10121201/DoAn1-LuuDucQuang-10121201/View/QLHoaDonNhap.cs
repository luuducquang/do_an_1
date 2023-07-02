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
    public partial class QLHoaDonNhap : Form
    {
        public QLHoaDonNhap()
        {
            InitializeComponent();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        QLHoaDonNhapBUS hoadonnhapBUS = new QLHoaDonNhapBUS();
        QLNhaCungCapBUS nhacungcapBUS = new QLNhaCungCapBUS();
        QLMyPhamBUS myphamBUS = new QLMyPhamBUS(); 
        QLNhanVienBUS nhanVienBUS = new QLNhanVienBUS();
        QLTonKhoBUS tonKhoBUS = new QLTonKhoBUS();
        List<Hoadonnhap> hoadonnhap;
        List<ThongTinMyPham> mypham;
        List<NhaCungCap> nhacungcap;
        List<NhanVien> nhanvien;
        List<Tonkho> tonkho;


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
            panel1.Controls.Add(childForm);
            panel1.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void QLHoaDonNhap_Load(object sender, EventArgs e)
        {
            PhanQuyen();

            nhacungcap = nhacungcapBUS.GetNhaCungCaps();

            nhanvien = nhanVienBUS.GetNhanViens();
            cboMaNV.DataSource = nhanvien;
            cboMaNV.ValueMember = "MaNV";
            cboMaNV.DisplayMember = "TenNV";

            hoadonnhap = hoadonnhapBUS.GetHoadonnhaps();
            dataGridView1.DataSource = hoadonnhap;
            HideColums();
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;

            OpenChildForm(new ChitietHDNhap());
        }

        public void HideColums()
        {

            dataGridView1.Columns[dataGridView1.ColumnCount - 1].Visible = false;
            dataGridView1.Columns[dataGridView1.ColumnCount - 2].Visible = false;
        }

        private void cboMamypham_SelectedIndexChanged(object sender, EventArgs e)
        {
            //hoadonnhap = hoadonnhapBUS.GetHoadonnhaps(cboMamypham.SelectedValue.ToString());
            //dataGridView1.DataSource = hoadonnhap;
            //mypham = myphamBUS.GetThongTinMyPhams();
        }


        private void cboMaNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            hoadonnhap = hoadonnhapBUS.GetHoadonnhaps(cboMaNV.SelectedValue.ToString());
            dataGridView1.DataSource = hoadonnhap;
            nhanvien = nhanVienBUS.GetNhanViens();
        }


        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int dong = dataGridView1.CurrentRow.Index;
                if (dataGridView1.Rows[dong].Cells["MaHDN"].Value != null)
                    txtMahoadonnhap.Text = dataGridView1.Rows[dong].Cells["MaHDN"].Value.ToString();
                if (dataGridView1.Rows[dong].Cells["Ngaynhap"].Value != null)
                    dateTimePicker1.Text = dataGridView1.Rows[dong].Cells["Ngaynhap"].Value.ToString();
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnAdd.Enabled = false;
                txtMahoadonnhap.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void LoadDgv()
        {
            hoadonnhap = hoadonnhapBUS.GetHoadonnhaps();
            dataGridView1.DataSource = hoadonnhap;
        }
        private void btnNew_Click(object sender, EventArgs e)
        {

            LoadDgv(); 
            txtMahoadonnhap.Clear();
            txtMahoadonnhap.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnAdd.Enabled = true;
            dateTimePicker1.Value = DateTime.Now;
            OpenChildForm(new ChitietHDNhap());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMahoadonnhap.Text != "" )
                {
                    Hoadonnhap hdn = new Hoadonnhap();
                    hdn.MaHDN = txtMahoadonnhap.Text;
                    hdn.MaNV = cboMaNV.SelectedValue.ToString();
                    hdn.Ngaynhap = dateTimePicker1.Value;
                    hoadonnhapBUS.AddHoadonnhap(hdn);
                    hoadonnhap.Add(hdn);
                    LoadDgv();
                    OpenChildForm(new ChitietHDNhap());
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
                if (txtMahoadonnhap.Text != "" )
                {
                    Hoadonnhap hdn = new Hoadonnhap();
                    Tonkho tk = new Tonkho();
                    hdn.MaHDN = txtMahoadonnhap.Text;
                    hdn.MaNV = cboMaNV.SelectedValue.ToString();
                    hdn.Ngaynhap = dateTimePicker1.Value;
                    hoadonnhapBUS.EditHoadonnhap(hdn);  
                    LoadDgv();
                    OpenChildForm(new ChitietHDNhap());
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
                if (txtMahoadonnhap.Text != "" )
                {
                    Hoadonnhap hdn = new Hoadonnhap();
                    hdn.MaHDN = txtMahoadonnhap.Text;
                    hdn.MaNV = cboMaNV.SelectedValue.ToString();
                    hdn.Ngaynhap = dateTimePicker1.Value;
                    hoadonnhapBUS.DeleteHoadonnhap(hdn);
                    hoadonnhap.Remove(hdn);
                    LoadDgv();
                    OpenChildForm(new ChitietHDNhap());
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
            var results = db.Hoadonnhaps.Where(p => p.MaHDN.ToLower().Contains(txtSearch.Text));
            dataGridView1.DataSource = results.ToList();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (QLMyPhamCuaCuaHangBanMyPhamEntities db = new QLMyPhamCuaCuaHangBanMyPhamEntities())
                {
                    db.Hoadonnhaps.Where(p => p.MaHDN.ToLower().Contains(txtSearch.Text)).ToList();
                }
            }
        }



        private void ExportToExcel(DataGridView dgv)
        {
            // Tạo đối tượng Excel
            Excel.Application excel = new Excel.Application();
            Excel.Workbook workbook = excel.Workbooks.Add(Type.Missing);
            Excel.Worksheet worksheet = null;

            try
            {
                worksheet = workbook.ActiveSheet;
                worksheet.Name = "Hoá đơn nhập";

                worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, 10]].Merge();
                worksheet.Cells[1, 1].Value = "THÔNG TIN HOÁ ĐƠN NHẬP";
                worksheet.Cells[1, 1].Font.Bold = true;
                worksheet.Cells[1, 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                worksheet.Rows[1].RowHeight = 30;
                worksheet.Rows[1].Font.Name = "Arial";
                worksheet.Rows[1].Font.Size = 19;

                Excel.Range headerRange = worksheet.Range["A2", "J2"];
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
                range.Columns[8].ColumnWidth = 15;
                range.Columns[9].ColumnWidth = 15;
                range.Columns[10].ColumnWidth = 15;



                worksheet.Cells[2, 1] = "Mã hoá đơn nhập";
                worksheet.Cells[2, 2] = "Mã nhân viên";
                worksheet.Cells[2, 3] = "Mã mỹ phẩm";
                worksheet.Cells[2, 4] = "Mã nhà cung cấp";
                worksheet.Cells[2, 5] = "Số lượng";
                worksheet.Cells[2, 6] = "Ngày bán";
                worksheet.Cells[2, 7] = "Địa chỉ";
                worksheet.Cells[2, 8] = "Số điện thoại";
                worksheet.Cells[2, 9] = "Đơn giá";
                worksheet.Cells[2, 10] = "Tổng tiền";



                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    for (int j = 0; j < 10; j++)
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

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Nhập mã hoá đơn nhập muốn tìm")
            {
                txtSearch.Text = "";
            }
        }

        

        private void txtSoluong_TextChanged(object sender, EventArgs e)
        {
            //CalculateSum();

        }

        private void txtDongia_TextChanged(object sender, EventArgs e)
        {
            //CalculateSum();
        }

        private void txtSoluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDongia_KeyPress(object sender, KeyPressEventArgs e)
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
