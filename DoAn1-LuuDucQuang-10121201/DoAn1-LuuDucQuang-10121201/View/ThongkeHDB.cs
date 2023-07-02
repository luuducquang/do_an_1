using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAn1_LuuDucQuang_10121201.DataAccess;
using DoAn1_LuuDucQuang_10121201.Bussiness;

namespace DoAn1_LuuDucQuang_10121201.View
{
    public partial class ThongkeHDB : Form
    {
        public ThongkeHDB()
        {
            InitializeComponent();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            cbomonth.Items.Add(1);
            cbomonth.Items.Add(2);
            cbomonth.Items.Add(3);
            cbomonth.Items.Add(4);
            cbomonth.Items.Add(5);
            cbomonth.Items.Add(6);
            cbomonth.Items.Add(7);
            cbomonth.Items.Add(8);
            cbomonth.Items.Add(9);
            cbomonth.Items.Add(10);
            cbomonth.Items.Add(11);
            cbomonth.Items.Add(12);

            cboyear.Items.Add(2023);
            cboyear.Items.Add(2022);
            cboyear.Items.Add(2021);
            cboyear.Items.Add(2020);
            cboyear.Items.Add(2019);
            cboyear.Items.Add(2018);
        }

        QLHoaDonBanBUS hoadonbanBUS = new QLHoaDonBanBUS();
        ChitietHDBBUS chitietbus = new ChitietHDBBUS();
        List<Hoadonban> hoadonban;
        QLHoaDonBanDAO hoadonbanDAO = new QLHoaDonBanDAO();
        QLMyPhamDAO myphamDAO = new QLMyPhamDAO();
        QLNhanVienDAO nhanVienDAO = new QLNhanVienDAO();
        QLKhachHangDAO khachhangDAO = new QLKhachHangDAO();
        public List<Hoadonban> hdb;
        List<ChitietHDB> cthdb;

        private void ThongkeHDB_Load(object sender, EventArgs e)
        {
            cthdb = chitietbus.GetChitietHDBs();
            dataGridView1.DataSource = cthdb;
            dataGridView1.Columns[dataGridView1.ColumnCount - 1].Visible = false;
            dataGridView1.Columns[dataGridView1.ColumnCount - 2].Visible = false;
        }


        List<SP_Timthoigian_Result> time;
        private void btnSearch_Click(object sender, EventArgs e)
        {
            BtnTinhdoanhthu.Enabled = true;
            time = chitietbus.Getthoigian(dateTimePicker1.Value, dateTimePicker2.Value);
            dataGridView1.DataSource = time;

            //using (var dbContext = new QLMyPhamCuaCuaHangBanMyPhamEntities())
            //{
            //    // Tìm kiếm các hoá đơn bán trong khoảng thời gian từ startDate đến endDate
            //    var invoices = dbContext.Hoadonbans
            //        .Where(hd => hd.Ngayban >= startDate && hd.Ngayban <= endDate)
            //        .ToList();

            //    if (invoices.Count > 0)
            //    {
            //        // Lấy danh sách mã hoá đơn bán
            //        var invoiceNumbers = invoices.Select(hd => hd.MaHDB).ToList();

            //        // Tìm kiếm các chi tiết hoá đơn bán có mã hoá đơn bán trong danh sách
            //        var invoiceDetails = dbContext.ChitietHDBs
            //            .Where(detail => invoiceNumbers.Contains(detail.MaHDB))
            //            .ToList();

            //        dataGridView1.DataSource = invoiceDetails;
            //        dataGridView1.Columns[dataGridView1.ColumnCount - 1].Visible = false;
            //        dataGridView1.Columns[dataGridView1.ColumnCount - 2].Visible = false;
            //    }
            //    else
            //    {
            //        dataGridView1.DataSource = null;
            //        MessageBox.Show("Không có hoá đơn bán trong khoảng thời gian đã chọn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
        }
        private List<Hoadonban> GetSearchResults(DateTime startDate, DateTime endDate)
        {
            List<Hoadonban> productList = hoadonban; 

            List<Hoadonban> searchResults = productList.Where(p => p.Ngayban >= startDate && p.Ngayban <= endDate).ToList();

            return searchResults;
        }


        private void DisplaySearchResults(List<Hoadonban> searchResults)
        {
            dataGridView1.DataSource = searchResults.ToList();
        }


        private void BtnTinhdoanhthu_Click(object sender, EventArgs e)
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

                txtDoanhthu.Text = totalRevenue.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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
                    dataGridView1.Columns[dataGridView1.ColumnCount - 1].Visible = false;
                    dataGridView1.Columns[dataGridView1.ColumnCount - 2].Visible = false;
                }
            }
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Tìm kiếm theo mã hoá đơn bán")
            {
                txtSearch.Text = "";
            }
        }
        List<SP_SPbancham_Result> spcham;
        private void spbancham_Click(object sender, EventArgs e)
        {
            BtnTinhdoanhthu.Enabled = false;
            spcham = chitietbus.GetSPbancham();
            dataGridView1.DataSource = spcham;

        }

        List<SP_SPbanchay_Result> sp;
        private void topsale_Click(object sender, EventArgs e)
        {
            BtnTinhdoanhthu.Enabled = false;
            sp = chitietbus.GetSPbanchay();
            dataGridView1.DataSource = sp;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        List<SP_thongkethangHDB_Result> monthHDB;
        private void cbomonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            monthHDB = chitietbus.Gettheothang(Int32.Parse(cbomonth.SelectedItem.ToString()));
            dataGridView1.DataSource = monthHDB;
            BtnTinhdoanhthu.Enabled = true;
        }
        List<SP_thongkenamHDB_Result> yearHDB;
        private void cboyear_SelectedIndexChanged(object sender, EventArgs e)
        {
            yearHDB = chitietbus.Gettheonam(Int32.Parse(cboyear.SelectedItem.ToString()));
            dataGridView1.DataSource = yearHDB;
            BtnTinhdoanhthu.Enabled = true;
        }
    }
}
