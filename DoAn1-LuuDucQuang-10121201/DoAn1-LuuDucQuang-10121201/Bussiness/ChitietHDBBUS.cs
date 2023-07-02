using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAn1_LuuDucQuang_10121201.DataAccess;
using System.Windows.Forms;

namespace DoAn1_LuuDucQuang_10121201.Bussiness
{
    public class ChitietHDBBUS
    {
        ChitietHDBDAO chitietHDBDAO = new ChitietHDBDAO();
        List<ChitietHDB> list; 
        QLTonKhoDAO tonKhoDAO = new QLTonKhoDAO();
        public List<Tonkho> tk;

        public List<ChitietHDB> GetChitietHDBs()
        {
            list= chitietHDBDAO.GetChitietHDBs();
            return list;
        }

        public List<ChitietHDB> Getmahdblist(string mahdb)
        {
            return chitietHDBDAO.Getmahdblist(mahdb);
        }

        public List<SP_SPbanchay_Result> GetSPbanchay()
        {
            return chitietHDBDAO.GetSPbanchay();
        }

        public List<SP_Timthoigian_Result> Getthoigian(DateTime start, DateTime end)
        {
            return chitietHDBDAO.Getthoigian(start, end);
        }

        public List<SP_thongkethangHDB_Result> Gettheothang(int a)
        {
            return chitietHDBDAO.Gettheothang(a);
        }

        public List<SP_thongkenamHDB_Result> Gettheonam(int a)
        {
            return chitietHDBDAO.Gettheonam(a);
        }

        public List<SP_SPbancham_Result> GetSPbancham()
        {
            return chitietHDBDAO.GetSPbancham();
        }

        public ChitietHDB GettheomaHDB(string x)
        {
            return chitietHDBDAO.GettheomaHDB(x);
        }

        public void AddHDB(ChitietHDB x,Tonkho y, string mahdb, string mamp, int gianhap, int soluong)
        {
            Tonkho tonkho = tonKhoDAO.GetTonkhos().SingleOrDefault(s => s.MaMP == x.MaMP);
            if (tonkho != null)
            {
                if (soluong <= tonkho.SLton)
                {
                    ChitietHDB cthdb = chitietHDBDAO.GetChitietHDBs().Find(s => s.ID == x.ID);
                    if (cthdb == null)
                    {
                        tonKhoDAO.EditSLTru(mamp, soluong);
                        chitietHDBDAO.AddHDB(x);
                        MessageBox.Show("Thêm thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        

                    }
                    else
                    {
                        MessageBox.Show("ID đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    //if (cthdb != null && x.MaHDB == mahdb && x.MaMP == mamp && x.Dongia == gianhap)
                    //{
                    //    chitietHDBDAO.UpAmount(mamp, soluong);
                    //    cthdb.Tongtien = cthdb.Tongtien + (soluong * gianhap);
                    //    MessageBox.Show("Đã tăng số lượng sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //}
                    //if (cthdb != null)
                    //{
                    //    MessageBox.Show("ID đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //}
                }

                else
                {
                    MessageBox.Show("Số lượng tồn kho không đủ vui lòng nhập nhỏ hơn " + tonkho.SLton, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

            }
            else
            {
                MessageBox.Show("Không có sản phẩm trong kho ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }



        }

        public void DeleteHDB(ChitietHDB d)
        {
            chitietHDBDAO.DeleteHDB(d.ID);
        }

        public void EditHDB(ChitietHDB xg)
        {
            try
            {
                ChitietHDB ct = list.Find(s => s.ID == xg.ID);
                
                QLTonKhoBUS.sltoncuban = (int)ct.Soluong;
                
                if (ct != null)
                {
                    chitietHDBDAO.EditHDB(xg);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
