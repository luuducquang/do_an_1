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



namespace DoAn1_LuuDucQuang_10121201.View
{
    public partial class QLHoaDonBan : Form
    {
        public QLHoaDonBan()
        {
            InitializeComponent();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        QLHoaDonBanBUS hoadonbanBUS = new QLHoaDonBanBUS();
        QLKhachHangBUS khachHangBUS = new QLKhachHangBUS();
        QLMyPhamBUS myphamBUS = new QLMyPhamBUS();
        QLNhanVienBUS nhanvienBUS = new QLNhanVienBUS();
        QLTonKhoBUS tonKhoBUS = new QLTonKhoBUS();
        List<Hoadonban> hoadonban;
        List<ThongTinMyPham> mypham;
        List<KhachHang> khachHang;
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
        private void QLHoaDonBan_Load(object sender, EventArgs e)
        {
            try
            {
                PhanQuyen();
                mypham = myphamBUS.GetThongTinMyPhams();

                khachHang = khachHangBUS.GetKhachHangs();
                cboMaKH.DataSource = khachHang;
                cboMaKH.ValueMember = "MaKH";
                cboMaKH.DisplayMember = "TenKH";

                nhanvien = nhanvienBUS.GetNhanViens();
                cboMaNV.DataSource = nhanvien;
                cboMaNV.ValueMember = "MaNV";
                cboMaNV.DisplayMember = "TenNV";

                hoadonban = hoadonbanBUS.GetHoadonbans();
                dataGridView1.DataSource = hoadonban;
                dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;

                HideColums();

                OpenChildForm(new ChitietHDBan());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void HideColums()
        {

            dataGridView1.Columns[dataGridView1.ColumnCount - 1].Visible = false;
            dataGridView1.Columns[dataGridView1.ColumnCount - 2].Visible = false;
            dataGridView1.Columns[dataGridView1.ColumnCount - 3].Visible = false;
        }

        private void cboMaKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            hoadonban = hoadonbanBUS.GetHoadonbans(cboMaKH.SelectedValue.ToString());
            dataGridView1.DataSource = hoadonban;
            khachHang = khachHangBUS.GetKhachHangs();

        }

        List<Hoadonnhap> hdn;
        QLHoaDonNhapBUS hdnbus = new QLHoaDonNhapBUS();
        ThongTinMyPham tt ;

        //List<string> listmassp  = new List<string>();
        private void cboMaMyPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string value = cboMaMyPham.SelectedValue.ToString();
            //if(listmassp.Count > 0)
            //{
            //    for (int i = 0; i < listmassp.Count - 1; i++)
            //    {
            //        string temp = listmassp[i];
            //        if (temp != listmassp[i + 1])
            //        {
            //            listmassp.Add(value);

            //        }
            //    }
            //    Console.WriteLine(listmassp.Count);
            //}
            //else
            //{
            //    listmassp.Add(value);

            //}


            //tt = myphamBUS.getTheomasp(cboMaMyPham.SelectedValue.ToString());
            //if (tt != null)
            //{
            //    txtDongia.Text = tt.Giaban.ToString();
            //}




            //mp = mpbus.getTheomasp(cboMaMyPham.SelectedValue.ToString());
            //foreach (ThongTinMyPham mp in mp)
            //{
            //    Console.WriteLine(mp.Giaban);
            //    txtDongia.Text =mp.Giaban.ToString();
            //    break;
            //}
            //tt = myphamBUS.getTheomasp(cboMaMyPham.SelectedValue.ToString());
            //Console.WriteLine(tt.Giaban);
            //txtDongia.Text = tt.Giaban.ToString();
            //dataGridView1.DataSource = hoadonban;
            //mypham = myphamBUS.GetThongTinMyPhams();
            //hdn = hdnbus.GetHoadonnhaps(cboMaMyPham.SelectedValue.ToString());
            //foreach(Hoadonnhap hd in hdn)
            //{
            //    Console.WriteLine(hd.Dongia);
            //    txtDongia.Text = hd.Dongia.ToString();
            //    break;
            //}






        }

        private void cboMaNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                hoadonban = hoadonbanBUS.GetHoadonbans(cboMaNV.SelectedValue.ToString());
                dataGridView1.DataSource = hoadonban;
                nhanvien = nhanvienBUS.GetNhanViens();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int dong = dataGridView1.CurrentRow.Index;
                if (dataGridView1.Rows[dong].Cells["MaHDB"].Value != null)
                    txtMaHoaDonBan.Text = dataGridView1.Rows[dong].Cells["MaHDB"].Value.ToString();
                if (dataGridView1.Rows[dong].Cells["Ngayban"].Value != null)
                    dateTimePicker1.Text = dataGridView1.Rows[dong].Cells["Ngayban"].Value.ToString();
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnAdd.Enabled = false;
                txtMaHoaDonBan.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        public void LoadDgv()
        {
            hoadonban = hoadonbanBUS.GetHoadonbans();
            dataGridView1.DataSource = hoadonban;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaHoaDonBan.Text != "" )
                {
                    Hoadonban hdb = new Hoadonban();
                    Tonkho tk = new Tonkho();
                    hdb.MaHDB = txtMaHoaDonBan.Text;
                    hdb.MaNV = cboMaNV.SelectedValue.ToString();
                    hdb.MaKH = cboMaKH.SelectedValue.ToString();
                    hdb.Ngayban = dateTimePicker1.Value;
                    //tk.MaMP = cboMaMyPham.SelectedValue.ToString();
                    //tk.SLton = Int32.Parse(txtSoluong.Text);
                    hoadonbanBUS.AddHoadonban(hdb);
                    hoadonban.Add(hdb);
                    LoadDgv();

                    OpenChildForm(new ChitietHDBan());

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
                if (txtMaHoaDonBan.Text != "" )
                {
                    Hoadonban hdb = new Hoadonban();
                    hdb.MaHDB = txtMaHoaDonBan.Text;
                    hdb.MaNV = cboMaNV.SelectedValue.ToString();
                    hdb.MaKH = cboMaKH.SelectedValue.ToString();
                    hdb.Ngayban = dateTimePicker1.Value;
                    hoadonbanBUS.EditHoadonban(hdb);
                    //tonKhoBUS.EditSLSuaBan(cboMaMyPham.SelectedValue.ToString(), QLTonKhoBUS.sltoncuban, Int32.Parse(txtSoluong.Text));
                    LoadDgv();
                    OpenChildForm(new ChitietHDBan());
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
            
                if (txtMaHoaDonBan.Text != "" )
                {
                    Hoadonban hdb = new Hoadonban();
                    hdb.MaHDB = txtMaHoaDonBan.Text;
                    hdb.MaNV = cboMaNV.SelectedValue.ToString();
                    hdb.MaKH = cboMaKH.SelectedValue.ToString();
                    hdb.Ngayban = dateTimePicker1.Value;
                    hoadonbanBUS.DeleteHoadonban(hdb);
                    hoadonban.Remove(hdb);
                    LoadDgv();
                    OpenChildForm(new ChitietHDBan());
                    MessageBox.Show("Xóa thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không được để trống !");
                }
            

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtMaHoaDonBan.Clear();
            txtMaHoaDonBan.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnAdd.Enabled = true;
            dateTimePicker1.Value = DateTime.Now;
            LoadDgv();
            OpenChildForm(new ChitietHDBan());
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            QLMyPhamCuaCuaHangBanMyPhamEntities db = new QLMyPhamCuaCuaHangBanMyPhamEntities();
            DateTime dateTime = DateTime.Now;
            var results = db.Hoadonbans.Where(p => p.MaKH.ToLower().Contains(txtSearch.Text));
            dataGridView1.DataSource = results.ToList();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (QLMyPhamCuaCuaHangBanMyPhamEntities db = new QLMyPhamCuaCuaHangBanMyPhamEntities())
                {
                    db.Hoadonbans.Where(p => p.MaKH.ToLower().Contains(txtSearch.Text)).ToList();
                }
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
                worksheet.Name = "Hoá đơn bán";
                
                worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, 10]].Merge();
                worksheet.Cells[1, 1].Value = "THÔNG TIN HOÁ ĐƠN BÁN";
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



                
                worksheet.Cells[2, 1] = "Mã hoá đơn bán";
                worksheet.Cells[2, 2] = "Mã nhân viên";
                worksheet.Cells[2, 3] = "Mã khách hàng";
                worksheet.Cells[2, 4] = "Mã mỹ phẩm";
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
            if (txtSearch.Text == "Nhập mã khách hàng muốn tìm")
            {
                txtSearch.Text = "";
            }
        }


        
        private void txtDongia_TextChanged(object sender, EventArgs e)
        {
            //CalculateSum();
        }

        private void txtSoluong_TextChanged(object sender, EventArgs e)
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

        private void exportWord_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    var wordApp = new Word.Application();
            //    wordApp.Visible = false;

            //    var homNay = DateTime.Now;

            //    var templatePath = Path.Combine(Application.StartupPath, "Template\\Hoadon.docx");
            //    var document = wordApp.Documents.Add(templatePath);

            //    string[] placeholders = { "<Ngay_thang_nam>", "<Ma_hoa_don>", "<Ma_khach_hang>", "<Nhan_vien>", "<Ma_my_pham>", "<So_luong>", "<Don_gia>", "<Ngay_ban>", "<Dia_chi>", "<So_dien_thoai>", "<Tong_thanh_toan>" };
            //    string[] contents = { string.Format("Hưng Yên, ngày {0} tháng {1} năm {2}", homNay.Day, homNay.Month, homNay.Year), txtMaHoaDonBan.Text, cboMaKH.SelectedValue.ToString(), cboMaNV.SelectedValue.ToString(), cboMaMyPham.SelectedValue.ToString(), txtSoluong.Text, txtDongia.Text, dateTimePicker1.Value.ToString(), txtTongtien.Text };

            //    for (int i = 0; i < placeholders.Length; i++)
            //    {
            //        string placeholder = placeholders[i];
            //        string replacement = contents[i];

            //        var range = document.Content;
            //        range.Find.Execute(FindText: placeholder, ReplaceWith: replacement);
            //    }

            //    string fileName = "";
            //    string savePath = Path.Combine(Application.StartupPath, fileName);

            //    SaveFileDialog saveFileDialog = new SaveFileDialog();
            //    saveFileDialog.FileName = fileName;
            //    saveFileDialog.Filter = "Tệp tin Word (*.docx)|*.docx|Tất cả các tệp tin (*.*)|*.*";
            //    saveFileDialog.FilterIndex = 1;
            //    saveFileDialog.RestoreDirectory = true;

            //    if (saveFileDialog.ShowDialog() == DialogResult.OK)
            //    {
            //        savePath = saveFileDialog.FileName;
            //        document.SaveAs2(savePath);

            //        Process.Start(savePath);
            //        MessageBox.Show("Xuất dữ liệu thành công!");

            //    }

            //    document.Close();
            //    wordApp.Quit();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}


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
    }
}
