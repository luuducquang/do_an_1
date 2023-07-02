using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAn1_LuuDucQuang_10121201.DataAccess;
using System.Windows.Forms;

namespace DoAn1_LuuDucQuang_10121201.Bussiness
{
    public class QLLoaiMyPhamBUS
    {
        QLLoaiMyPhamDAO loaiMyPhamDAO = new QLLoaiMyPhamDAO();
        public List<LoaiMyPham> Loaimypham;
        public List<LoaiMyPham> GetLoaiMyPhams()
        {
            return loaiMyPhamDAO.GetLoaiMyPhams();
        }

        public void AddLoaiMP(LoaiMyPham x)
        {
            LoaiMyPham lmp = loaiMyPhamDAO.GetLoaiMyPhams().Find(s => s.MaloaiMP == x.MaloaiMP);
            if (lmp == null)
            {
                loaiMyPhamDAO.AddLoaiMP(x);
                MessageBox.Show("Thêm thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Mã loại mỹ phẩm đã tồn tại");
            }
        }

        public void DeleteLoaiMP(LoaiMyPham d)
        {
            //NhanVien nv1 = nv.Find(s => s.MaNCC == d.MaNCC);
            //if (nv1 != null)
            //{
            //}
            loaiMyPhamDAO.DeleteLoaiMP(d.MaloaiMP);
        }

        public void EditLoaiMP(LoaiMyPham xg)
        {
            //NhanVien nv2 = nv.Find(s => s.MaNCC == xg.MaNCC);
            //if (nv2 != null)
            //{
            //}
            loaiMyPhamDAO.EditLoaiMP(xg);
        }
    }
}
