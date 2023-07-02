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
using System.Globalization;

namespace DoAn1_LuuDucQuang_10121201.View
{
    public partial class ChitietHDNhap : Form
    {
        public ChitietHDNhap()
        {
            InitializeComponent();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        


        ChitietHDNBUS chitietHDNBUS = new ChitietHDNBUS();
        QLHoaDonNhapBUS QLHoaDonNhapBUS = new QLHoaDonNhapBUS();
        QLMyPhamBUS qLMyPhamBUS = new QLMyPhamBUS();
        QLTonKhoBUS tonKhoBUS = new QLTonKhoBUS();
        QLMyPhamBUS myphamBUS = new QLMyPhamBUS();
        List<Tonkho> tonkhos;
        List<ChitietHDN> chitietHDNs;
        List<Hoadonnhap> hoadonnhaps;
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
        private void ChitietHDN_Load(object sender, EventArgs e)
        {
            PhanQuyen();
            hoadonnhaps = QLHoaDonNhapBUS.GetHoadonnhaps();
            cbomahdn.DataSource = hoadonnhaps;
            cbomahdn.ValueMember = "MaHDN";
            cbomahdn.DisplayMember = "TenHDN";

            thongtinmyphams = qLMyPhamBUS.GetThongTinMyPhams();
            cboMamypham.DataSource = thongtinmyphams;
            cboMamypham.ValueMember = "MaMP";
            cboMamypham.DisplayMember = "TenMP";

            chitietHDNs = chitietHDNBUS.GetChitietHDNs();
            dataGridView1.DataSource = chitietHDNs;
            dataGridView1.Columns[dataGridView1.ColumnCount - 1].Visible = false;
            dataGridView1.Columns[dataGridView1.ColumnCount - 2].Visible = false;


            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            btnDelete.Enabled = false;
        }

        public void LoadDgv()
        {
            chitietHDNs = chitietHDNBUS.GetChitietHDNs();
            dataGridView1.DataSource = chitietHDNs;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int dong = dataGridView1.CurrentRow.Index;
                if (dataGridView1.Rows[dong].Cells["ID"].Value != null)
                    txtID.Text = dataGridView1.Rows[dong].Cells["ID"].Value.ToString();
                if (dataGridView1.Rows[dong].Cells["MaHDN"].Value != null)
                    cbomahdn.SelectedValue = dataGridView1.Rows[dong].Cells["MaHDN"].Value.ToString();
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
                txtID.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbomahdn_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
                if (txtSoluong.Text != "" && txtDongia.Text != "")
                {
                    Tonkho tonkho = new Tonkho();
                    ChitietHDN n = new ChitietHDN();
                    n.ID = txtID.Text;
                    n.MaHDN = cbomahdn.SelectedValue.ToString();
                    n.MaMP = cboMamypham.SelectedValue.ToString();
                    n.Soluong = Int32.Parse(txtSoluong.Text);
                    n.Dongia = Int32.Parse(txtDongia.Text);
                    n.Tongtien = Int32.Parse(txtTongtien.Text);
                    tonkho.MaMP = cboMamypham.SelectedValue.ToString();
                    tonkho.SLton = Int32.Parse(txtSoluong.Text);
                    chitietHDNBUS.AddHDN(n,tonkho, n.MaHDN, n.MaMP, Int32.Parse(txtDongia.Text), Int32.Parse(txtSoluong.Text));
                    chitietHDNs.Add(n);
                    LoadDgv();
                }
                else
                {
                    MessageBox.Show("Không được để trống !");
                }
            

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSoluong.Text != "" && txtDongia.Text != "")
                {
                    Tonkho tk = new Tonkho();
                    ChitietHDN n = new ChitietHDN();
                    n.ID = txtID.Text;
                    n.MaHDN = cbomahdn.SelectedValue.ToString();
                    n.MaMP = cboMamypham.SelectedValue.ToString();
                    n.Soluong = Int32.Parse(txtSoluong.Text);
                    n.Dongia = Int32.Parse(txtDongia.Text);
                    n.Tongtien = Int32.Parse(txtTongtien.Text);
                    chitietHDNBUS.EditHDN(n);
                    chitietHDNs.Add(n);
                    tonKhoBUS.EditSLSua(Int32.Parse(txtSoluong.Text), QLTonKhoBUS.sltoncu, cboMamypham.SelectedValue.ToString());
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
                if (txtSoluong.Text != "" && txtDongia.Text != "")
                {
                    ChitietHDN n = new ChitietHDN();
                    n.ID = txtID.Text;
                    n.MaHDN = cbomahdn.SelectedValue.ToString();
                    n.MaMP = cboMamypham.SelectedValue.ToString();
                    n.Soluong = Int32.Parse(txtSoluong.Text);
                    n.Dongia = Int32.Parse(txtDongia.Text);
                    n.Tongtien = Int32.Parse(txtTongtien.Text);
                    chitietHDNBUS.EditHDN(n);
                    chitietHDNBUS.DeleteHDN(n);
                    chitietHDNs.Remove(n);
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

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Nhập mã mỹ phẩm muốn tìm")
            {
                txtSearch.Text = "";
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            QLMyPhamCuaCuaHangBanMyPhamEntities db = new QLMyPhamCuaCuaHangBanMyPhamEntities();
            var results = db.ChitietHDNs.Where(p => p.MaMP.ToLower().Contains(txtSearch.Text));
            dataGridView1.DataSource = results.ToList();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (QLMyPhamCuaCuaHangBanMyPhamEntities db = new QLMyPhamCuaCuaHangBanMyPhamEntities())
                {
                    db.ChitietHDNs.Where(p => p.MaMP.ToLower().Contains(txtSearch.Text)).ToList();
                }
            }
        }


        private void CalculateSum()
        {
            if (Int32.TryParse(txtDongia.Text, out int value1) && Int32.TryParse(txtSoluong.Text, out int value2))
            {
                double sum = value1 * value2;
                txtTongtien.Text = sum.ToString();

                //CultureInfo culture = new CultureInfo("en-US");
                //string formattedNumber = sum.ToString("N", culture); 

                //txtTongtien.Text = formattedNumber;
            }
            else
            {
                txtTongtien.Text = "";
            }
        }
        private void txtTongtien_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtSoluong_TextChanged(object sender, EventArgs e)
        {
            CalculateSum();
            
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

        private void txtDongia_TextChanged(object sender, EventArgs e)
        {
            CalculateSum();
        }

        private void ExportToExcel(DataGridView dgv)
        {
            Excel.Application excel = new Excel.Application();
            Excel.Workbook workbook = excel.Workbooks.Add(Type.Missing);
            Excel.Worksheet worksheet = null;

            try
            {
                worksheet = workbook.ActiveSheet;
                worksheet.Name = "Thông tin chi tiết hoá đơn nhập";

                worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, 6]].Merge();
                worksheet.Cells[1, 1].Value = "THÔNG TIN CHI TIẾT HOÁ ĐƠN NHẬP";
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


                range.Columns[1].ColumnWidth = 15;
                range.Columns[2].ColumnWidth = 15;
                range.Columns[3].ColumnWidth = 15;
                range.Columns[4].ColumnWidth = 15;
                range.Columns[5].ColumnWidth = 15;
                range.Columns[6].ColumnWidth = 15;



                worksheet.Cells[2, 1] = "ID";
                worksheet.Cells[2, 2] = "Mã hoá đơn nhập";
                worksheet.Cells[2, 3] = "Mã mỹ phẩm";
                worksheet.Cells[2, 4] = "Số lượng";
                worksheet.Cells[2, 5] = "Đơn giá";
                worksheet.Cells[2, 6] = "Tổng tiền";



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
        ThongTinMyPham tt;
        private void cboMamypham_SelectedIndexChanged(object sender, EventArgs e)
        {
            tt = myphamBUS.getTheomasp(cboMamypham.SelectedValue.ToString());
            if (tt != null)
            {
                int a;
                int giaban = int.Parse(tt.Giaban.ToString());
                a = giaban - (giaban * 10 / 100);
                txtDongia.Text = a.ToString();
            }

        }

        private void dataGridView1_SizeChanged(object sender, EventArgs e)
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
