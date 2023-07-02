using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAn1_LuuDucQuang_10121201.DataAccess;


namespace DoAn1_LuuDucQuang_10121201.Bussiness
{
    public class QLNhanVienBUS
    {
        QLNhanVienDAO nhanvienDAO = new QLNhanVienDAO();
        public List<NhanVien> nv;
        public List<NhanVien> GetNhanViens()
        {
            return nhanvienDAO.GetNhanViens();
        }

        public NhanVien Gettheomanv(string manv)
        {
            return nhanvienDAO.Gettheomanv(manv);
        }


        public void AddNhanVien(NhanVien x)
        {
            NhanVien nhanvien = nhanvienDAO.GetNhanViens().Find(s => s.MaNV == x.MaNV);
            if (nhanvien == null)
            {
                nhanvienDAO.AddNhanVien(x);
                MessageBox.Show("Thêm thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Mã nhân viên đã tồn tại");
            }
        }

        public void DeleteNhanVIen(NhanVien d)
        {
            //NhanVien nv1 = nv.Find(s => s.MaNV == d.MaNV);
            //if (nv1 != null)
            //{
            //}
                nhanvienDAO.DeleteNhanVien(d.MaNV);
        }

        public void EditNhanvien(NhanVien xg)
        {
            //NhanVien nv2 = nv.Find(s => s.MaNV == xg.MaNV);
            //if (nv2 != null)
            //{
            //}
                nhanvienDAO.EditNhanVien(xg);   
        }
    }
}
