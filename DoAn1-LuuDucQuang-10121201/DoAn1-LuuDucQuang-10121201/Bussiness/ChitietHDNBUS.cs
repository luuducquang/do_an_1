using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAn1_LuuDucQuang_10121201.DataAccess;
using System.Windows.Forms;

namespace DoAn1_LuuDucQuang_10121201.Bussiness
{
    public class ChitietHDNBUS
    {
        ChitietHDNDAO chitietHDNDAO = new ChitietHDNDAO();
        QLTonKhoBUS QLTonKhoBUS = new QLTonKhoBUS();
        QLTonKhoDAO qLTonKhoDAO = new QLTonKhoDAO();
        List<ChitietHDN> list;
        public List<ChitietHDN> GetChitietHDNs()
        {
            list = chitietHDNDAO.GetChitietHDNs();
            return list;
        }

        public List<SP_SPsaphet_Result> GetSPsaphet()
        {
            return chitietHDNDAO.GetSPsaphet();
        }

        public List<SP_TimthoigianHDN_Result> Getthoigian(DateTime start, DateTime end)
        {
            return chitietHDNDAO.Getthoigian(start, end);
        }

        public List<SP_thongkethangHDN_Result> Gettheothang(int a)
        {
            return chitietHDNDAO.Gettheothang(a);
        }

        public List<SP_thongkenamHDN_Result> Gettheonam(int a)
        {
            return chitietHDNDAO.Gettheonam(a);
        }
        public void AddHDN(ChitietHDN x,Tonkho y,string mahdn, string mamp, int gianhap, int soluong)
        {
            ChitietHDN cthdn = chitietHDNDAO.GetChitietHDNs().Find(s => s.ID == x.ID);
                //if (cthdn != null && x.MaHDN == mahdn && x.MaMP == mamp && x.Dongia == gianhap)
                //{
                //    chitietHDNDAO.UpAmount(mamp, soluong);
                //    cthdn.Tongtien = cthdn.Tongtien + (soluong * gianhap);
                //}

                if (cthdn == null)
                {
                    QLTonKhoBUS.AddTonkho(y,soluong);
                    chitietHDNDAO.AddHDN(x);
                    MessageBox.Show("Thêm thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("ID đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            

        }

        public void DeleteHDN(ChitietHDN d)
        {
            chitietHDNDAO.DeleteHDN(d.ID);
        }

        public void EditHDN(ChitietHDN xg)
        {
            ChitietHDN ct = list.Find(s => s.ID == xg.ID);
            QLTonKhoBUS.sltoncu = (int)ct.Soluong;
            if (ct != null)
            {
                chitietHDNDAO.EditHDN(xg);
            }
        }
    }
}
