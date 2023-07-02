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
using Word = Microsoft.Office.Interop.Word;
using System.IO;
using System.Diagnostics;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;


namespace DoAn1_LuuDucQuang_10121201.View
{
    public partial class ChitietHDBan : Form
    {
        public ChitietHDBan()
        {
            InitializeComponent();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        

        ChitietHDBBUS chitietHDBBUS = new ChitietHDBBUS();
        QLHoaDonBanBUS QLHoaDonBanBUS = new QLHoaDonBanBUS();
        QLNhanVienBUS QLNhanVienBUS = new QLNhanVienBUS();
        QLKhachHangBUS QLKhachHangbus = new QLKhachHangBUS();
        QLMyPhamBUS qLMyPhamBUS = new QLMyPhamBUS(); 
        QLTonKhoBUS tonKhoBUS = new QLTonKhoBUS();
        QLMyPhamBUS myphamBUS = new QLMyPhamBUS();
        List<Tonkho> tonkhos;
        List<ChitietHDB> chitietHDBs;
        List<Hoadonban> hoadonbans;
        List<ThongTinMyPham> thongtinmyphams;

        public void PhanQuyen()
        {
            if (DangNhapHT.phanquyen == "quản lý")
            {

            }


            if (DangNhapHT.phanquyen == "nhân viên")
            {
                btnDelete.Visible = false;

            }
        }

        private void Tinhtien()
        {
            try
            {
                decimal totalRevenue = 0;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[5].Value != null)
                    {
                        totalRevenue += Convert.ToDecimal(row.Cells[5].Value);
                    }
                }

                textBox1.Text = totalRevenue.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
        private void ChitietHDBan_Load(object sender, EventArgs e)
        {
            PhanQuyen();
            hoadonbans = QLHoaDonBanBUS.GetHoadonbans();
            cbomahdb.DataSource = hoadonbans;
            cbomahdb.ValueMember = "MaHDB";
            cbomahdb.DisplayMember = "TenHDB";

            thongtinmyphams = qLMyPhamBUS.GetThongTinMyPhams();
            cboMamypham.DataSource = thongtinmyphams;
            cboMamypham.ValueMember = "MaMP";
            cboMamypham.DisplayMember = "TenMP";

            chitietHDBs = chitietHDBBUS.GetChitietHDBs();
            dataGridView1.DataSource = chitietHDBs;
            dataGridView1.Columns[dataGridView1.ColumnCount - 1].Visible = false;
            dataGridView1.Columns[dataGridView1.ColumnCount - 2].Visible = false;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;

            Tinhtien();
        }

        public void LoadDgv()
        {
            chitietHDBs = chitietHDBBUS.GetChitietHDBs();
            dataGridView1.DataSource = chitietHDBs;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int dong = dataGridView1.CurrentRow.Index;
                if (dataGridView1.Rows[dong].Cells["ID"].Value != null)
                    txtID.Text = dataGridView1.Rows[dong].Cells["ID"].Value.ToString();
                if (dataGridView1.Rows[dong].Cells["MaHDB"].Value != null)
                    cbomahdb.SelectedValue = dataGridView1.Rows[dong].Cells["MaHDB"].Value.ToString();
                if (dataGridView1.Rows[dong].Cells["MaMP"].Value != null)
                    cboMamypham.SelectedValue = dataGridView1.Rows[dong].Cells["MaMP"].Value.ToString();
                if (dataGridView1.Rows[dong].Cells["Soluong"].Value != null)
                    txtSoluong.Text = dataGridView1.Rows[dong].Cells["Soluong"].Value.ToString();
                if (dataGridView1.Rows[dong].Cells["Dongia"].Value != null)
                    txtDongia.Text = dataGridView1.Rows[dong].Cells["Dongia"].Value.ToString();
                if (dataGridView1.Rows[dong].Cells["Tongtien"].Value != null)
                    txtTongtien.Text = dataGridView1.Rows[dong].Cells["Tongtien"].Value.ToString();
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnAdd.Enabled = false;
                btnWord.Enabled = true;
                txtID.Enabled = false;
            }
            catch (Exception ex)
            {
               
            }


        }

        

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                btnWord.Enabled = false;
                if (txtSoluong.Text != "" && txtDongia.Text != "")
                {
                    ChitietHDB n = new ChitietHDB();
                    Tonkho tk = new Tonkho();
                    n.ID = txtID.Text;
                    n.MaHDB = cbomahdb.SelectedValue.ToString();
                    n.MaMP = cboMamypham.SelectedValue.ToString();
                    n.Soluong = Int32.Parse(txtSoluong.Text);
                    n.Dongia = Int32.Parse(txtDongia.Text);
                    n.Tongtien = Int32.Parse(txtTongtien.Text);
                    chitietHDBBUS.AddHDB(n,tk, n.MaHDB, n.MaMP, Int32.Parse(txtDongia.Text), Int32.Parse(txtSoluong.Text));
                    chitietHDBs.Add(n);
                    //tonKhoBUS.EditSLTru(n.MaMP, Int32.Parse(txtSoluong.Text));
                    LoadDgv();
                    Tinhtien();
                    
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
                btnWord.Enabled = false;
                if (txtSoluong.Text != "" && txtDongia.Text != "")
                {
                    ChitietHDB n = new ChitietHDB();
                    n.ID = txtID.Text;
                    n.MaHDB = cbomahdb.SelectedValue.ToString();
                    n.MaMP = cboMamypham.SelectedValue.ToString();
                    n.Soluong = Int32.Parse(txtSoluong.Text);
                    n.Dongia = Int32.Parse(txtDongia.Text);
                    n.Tongtien = Int32.Parse(txtTongtien.Text);
                    chitietHDBBUS.EditHDB(n);
                    chitietHDBs.Add(n);
                    tonKhoBUS.EditSLSuaBan(n.MaMP, QLTonKhoBUS.sltoncuban, Int32.Parse(txtSoluong.Text));
                    LoadDgv();
                    Tinhtien();
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
                btnWord.Enabled = false;
                if (txtSoluong.Text != "" && txtDongia.Text != "")
                {
                    ChitietHDB n = new ChitietHDB();
                    n.ID = txtID.Text;
                    n.MaHDB = cbomahdb.SelectedValue.ToString();
                    n.MaMP = cboMamypham.SelectedValue.ToString();
                    n.Soluong = Int32.Parse(txtSoluong.Text);
                    n.Dongia = Int32.Parse(txtDongia.Text);
                    n.Tongtien = Int32.Parse(txtTongtien.Text);
                    chitietHDBBUS.EditHDB(n);
                    chitietHDBBUS.DeleteHDB(n);
                    chitietHDBs.Remove(n);
                    LoadDgv();
                    Tinhtien();
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

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Nhập mã hoá đơn bán muốn tìm")
            {
                txtSearch.Text = "";
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            QLMyPhamCuaCuaHangBanMyPhamEntities db = new QLMyPhamCuaCuaHangBanMyPhamEntities();
            var results = db.ChitietHDBs.Where(p => p.MaHDB.ToLower().Contains(txtSearch.Text));
            dataGridView1.DataSource = results.ToList();
            dataGridView1.Columns[dataGridView1.ColumnCount - 1].Visible = false;
            dataGridView1.Columns[dataGridView1.ColumnCount - 2].Visible = false;
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (QLMyPhamCuaCuaHangBanMyPhamEntities db = new QLMyPhamCuaCuaHangBanMyPhamEntities())
                {
                    db.ChitietHDBs.Where(p => p.MaHDB.ToLower().Contains(txtSearch.Text)).ToList();
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtSoluong.Clear();
            txtID.Clear();
            txtDongia.Clear();
            txtTongtien.Clear();
            txtID.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnAdd.Enabled = true;
            btnWord.Enabled = false;
            LoadDgv();
            Tinhtien();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void CalculateSum()
        {
            if (Int32.TryParse(txtDongia.Text.Replace(",", ""), out int value1) && Int32.TryParse(txtSoluong.Text.Replace(",", ""), out int value2))
            {
                double sum = value1 * value2;
                txtTongtien.Text = sum.ToString();
            }
            else
            {
                txtTongtien.Text = "";
            }
        }
        private void txtTongtien_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Themdauphayhangnghin()
        {
            string input = txtDongia.Text;

            string a = input.Replace(",", "");

            if (decimal.TryParse(a, out decimal value))
            {
                string formatvalue = value.ToString("#,##0");

                txtDongia.Text = formatvalue;
            }
        }

        private void txtDongia_TextChanged(object sender, EventArgs e)
        {
            //Themdauphayhangnghin();
            CalculateSum();
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

        private void cbomahdb_SelectedIndexChanged(object sender, EventArgs e)
        {
            chitietHDBs = chitietHDBBUS.Getmahdblist(cbomahdb.SelectedValue.ToString());
            dataGridView1.DataSource = chitietHDBs;
            Tinhtien();
        }

        private void txtSoluong_KeyUp(object sender, KeyEventArgs e)
        {
            CalculateSum();
        }

        ThongTinMyPham tt;
        private void cboMamypham_SelectedIndexChanged(object sender, EventArgs e)
        {
            tt = myphamBUS.getTheomasp(cboMamypham.SelectedValue.ToString());
            if (tt != null)
            {
                txtDongia.Text = tt.Giaban.ToString();
            }

        }

        Hoadonban hdb;
        NhanVien nv;
        KhachHang kh;
        private void ExportToExcel(DataGridView dgv)
        {
            hdb = QLHoaDonBanBUS.gettheomhdb(cbomahdb.SelectedValue.ToString());
            nv = QLNhanVienBUS.Gettheomanv(hdb.MaNV);
            kh = QLKhachHangbus.Gettheomakh(hdb.MaKH);

            Excel.Application excel = new Excel.Application();
            Excel.Workbook workbook = excel.Workbooks.Add(Type.Missing);
            Excel.Worksheet worksheet = null;

            try
            {
                worksheet = workbook.ActiveSheet;
                worksheet.Name = "Thông tin chi tiết hoá đơn bán";

                worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, 6]].Merge();
                worksheet.Cells[1, 1].Value = "THÔNG TIN CHI TIẾT HOÁ ĐƠN BÁN";
                worksheet.Cells[1, 1].Font.Bold = true;
                worksheet.Cells[1, 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                worksheet.Rows[1].RowHeight = 30;
                worksheet.Rows[1].Font.Name = "Arial";
                worksheet.Rows[1].Font.Size = 13;

                Excel.Range headerRange = worksheet.Range["A2", "F2"];
                headerRange.Font.Bold = true;
                headerRange.Interior.Color = System.Drawing.Color.Yellow;

                Excel.Range range = worksheet.Range["A2", worksheet.Cells[dgv.Rows.Count + 2, dgv.Columns.Count]];

                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                range.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                worksheet.Cells[3, 8].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                worksheet.Cells[3, 9].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                worksheet.Cells[3, 10].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                range.Columns[1].ColumnWidth = 15;
                range.Columns[2].ColumnWidth = 15;
                range.Columns[3].ColumnWidth = 15;
                range.Columns[4].ColumnWidth = 15;
                range.Columns[5].ColumnWidth = 15;
                range.Columns[6].ColumnWidth = 15;
                range.Columns[7].ColumnWidth = 30;
                range.Columns[8].ColumnWidth = 15;
                range.Columns[9].ColumnWidth = 15;
                range.Columns[10].ColumnWidth = 10;



                worksheet.Cells[2, 1] = "ID";
                worksheet.Cells[2, 2] = "Mã hoá đơn bán";
                worksheet.Cells[2, 3] = "Mã mỹ phẩm";
                worksheet.Cells[2, 4] = "Số lượng";
                worksheet.Cells[2, 5] = "Đơn giá";
                worksheet.Cells[2, 6] = "Tổng tiền";
                worksheet.Cells[2, 7] = "Tổng thanh toán";
                worksheet.Cells[2, 8] = "Tên khách hàng";
                worksheet.Cells[2, 9] = "Tên nhân viên";
                worksheet.Cells[2, 10] = "Ngày bán";
                worksheet.Cells[3, 7] = textBox1.Text;
                worksheet.Cells[3, 8] = kh.TenKH;
                worksheet.Cells[3, 9] = nv.TenNV;
                worksheet.Cells[3, 10] = hdb.Ngayban;


                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    for (int j = 0; j < 6; j++)
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
                btnWord.Enabled = true;
            }
            else
            {
                btnDelete.Enabled = false;
                btnEdit.Enabled = false;
                btnWord.Enabled = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
        ThongTinMyPham mp;
        ChitietHDB cthdb;
        private void btnWord_Click(object sender, EventArgs e)
        {
            try
            {
                hdb = QLHoaDonBanBUS.gettheomhdb(cbomahdb.SelectedValue.ToString());
                cthdb = chitietHDBBUS.GettheomaHDB(cbomahdb.SelectedValue.ToString());
                kh = QLKhachHangbus.Gettheomakh(hdb.MaKH);
                nv = QLNhanVienBUS.Gettheomanv(hdb.MaNV);
                mp = qLMyPhamBUS.getTheomasp(cthdb.MaMP);
                var wordApp = new Word.Application();
                wordApp.Visible = false;

                var homNay = DateTime.Now;

                var templatePath = Path.Combine(Application.StartupPath, "Template\\Hoadon.docx");
                var document = wordApp.Documents.Add(templatePath);

                string[] placeholders = { "<Ngay_thang_nam>", "<Ma_hoa_don>", "<Ten_khach_hang>", "<Nhan_vien>", "<Ten_my_pham>", "<So_luong>", "<Don_gia>", "<Dia_chi>", "<So_dien_thoai>", "<Tong_thanh_toan>" };
                string[] contents = { string.Format("Hưng Yên, ngày {0} tháng {1} năm {2}", homNay.Day, homNay.Month, homNay.Year), cbomahdb.SelectedValue.ToString(),kh.TenKH,nv.TenNV, mp.TenMP,txtSoluong.Text,txtDongia.Text,kh.DiaChi,kh.Sdt,txtTongtien.Text};

                for (int i = 0; i < placeholders.Length; i++)
                {
                    string placeholder = placeholders[i];
                    string replacement = contents[i];

                    var range = document.Content;
                    range.Find.Execute(FindText: placeholder, ReplaceWith: replacement);
                }

                string fileName = "";
                string savePath = Path.Combine(Application.StartupPath, fileName);

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.FileName = fileName;
                saveFileDialog.Filter = "Tệp tin Word (*.docx)|*.docx|Tất cả các tệp tin (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    savePath = saveFileDialog.FileName;
                    document.SaveAs2(savePath);

                    Process.Start(savePath);
                    MessageBox.Show("Xuất dữ liệu thành công!");

                }

                try
                {
                    document.Close();
                    wordApp.Quit();
                }
                catch
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void txtSoluong_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
