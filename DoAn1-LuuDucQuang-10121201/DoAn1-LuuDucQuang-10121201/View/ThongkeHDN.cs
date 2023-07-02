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
    public partial class ThongkeHDN : Form
    {
        public ThongkeHDN()
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

        List<Hoadonnhap> hoadonnhap;
        List<ChitietHDN> ChitietHDNs;
        List<ThongTinMyPham> mypham;
        QLMyPhamBUS myPhamBUS = new QLMyPhamBUS();
        QLHoaDonNhapBUS hoadonnhapBUS = new QLHoaDonNhapBUS();
        QLHoaDonNhapDAO hoadonnhapDAO = new QLHoaDonNhapDAO();
        QLMyPhamDAO myphamDAO = new QLMyPhamDAO();
        QLNhaCungCapDAO nhaCungCapDAO = new QLNhaCungCapDAO();
        QLNhanVienDAO nhanVienDAO = new QLNhanVienDAO();
        ChitietHDNBUS chitiethdn = new ChitietHDNBUS();
        private void ThongkeHDN_Load(object sender, EventArgs e)
        {
            ChitietHDNs = chitiethdn.GetChitietHDNs();
            dataGridView1.DataSource = ChitietHDNs;

            dataGridView1.Columns[dataGridView1.ColumnCount - 1].Visible = false;
            dataGridView1.Columns[dataGridView1.ColumnCount - 2].Visible = false;
            dataGridView1.Columns[dataGridView1.ColumnCount - 3].Visible = false;
        }

        List<SP_TimthoigianHDN_Result> search;
        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            BtnTinhdoanhthu.Enabled = true;
            search = chitiethdn.Getthoigian(dateTimePicker1.Value, dateTimePicker2.Value);
            dataGridView1.DataSource = search;
        }


        private void DisplaySearchResults(List<Hoadonnhap> searchResults)
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

                txtTiennhap.Text = totalRevenue.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng tìm kiếm hoá đơn nhập");
            }

        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            QLMyPhamCuaCuaHangBanMyPhamEntities db = new QLMyPhamCuaCuaHangBanMyPhamEntities();
            var results = db.ChitietHDNs.Where(p => p.MaHDN.ToLower().Contains(txtSearch.Text));
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
                    db.ChitietHDNs.Where(p => p.MaHDN.ToLower().Contains(txtSearch.Text)).ToList();
                    dataGridView1.Columns[dataGridView1.ColumnCount - 1].Visible = false;
                    dataGridView1.Columns[dataGridView1.ColumnCount - 2].Visible = false;
                }
            }
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Tìm kiếm theo mã hoá đơn nhập")
            {
                txtSearch.Text = "";
            }
        }


        List<SP_SPsaphet_Result> sphet;
        private void button1_Click(object sender, EventArgs e)
        {
            BtnTinhdoanhthu.Enabled = false;
            sphet = chitiethdn.GetSPsaphet();
            dataGridView1.DataSource = sphet;
        }

        

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;

           
        }

        List<SP_thongkethangHDN_Result> monthHDN;
        private void cbomonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            monthHDN = chitiethdn.Gettheothang(Int32.Parse(cbomonth.SelectedItem.ToString()));
            dataGridView1.DataSource = monthHDN;
            BtnTinhdoanhthu.Enabled = true;
        }

        List<SP_thongkenamHDN_Result> yearHDN;
        private void cboyear_SelectedIndexChanged(object sender, EventArgs e)
        {
            yearHDN = chitiethdn.Gettheonam(Int32.Parse(cboyear.SelectedItem.ToString()));
            dataGridView1.DataSource = yearHDN;
            BtnTinhdoanhthu.Enabled = true;
        }
    }
}
