using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAn1_LuuDucQuang_10121201.DataAccess;

namespace DoAn1_LuuDucQuang_10121201.Bussiness
{
    public class QLNhaCungCapBUS
    {
        QLNhaCungCapDAO nhacungcapDAO = new QLNhaCungCapDAO();
        public List<NhaCungCap> ncc;
        public List<NhaCungCap> GetNhaCungCaps()
        {
            return nhacungcapDAO.GetNhaCungCaps();
        }

        public void AddNCC(NhaCungCap x)
        {
            NhaCungCap nhaCungCap = nhacungcapDAO.GetNhaCungCaps().Find(s => s.MaNCC == x.MaNCC);
            if (nhaCungCap == null)
            {
                nhacungcapDAO.AddNCC(x);
                MessageBox.Show("Thêm thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Mã nhà cung cấp đã tồn tại");
            }
        }

        public void DeleteNCC(NhaCungCap d)
        {
            //NhanVien nv1 = nv.Find(s => s.MaNCC == d.MaNCC);
            //if (nv1 != null)
            //{
            //}
            nhacungcapDAO.DeleteNCC(d.MaNCC);
        }

        public void EditNCC(NhaCungCap xg)
        {
            //NhanVien nv2 = nv.Find(s => s.MaNCC == xg.MaNCC);
            //if (nv2 != null)
            //{
            //}
            nhacungcapDAO.EditNCC(xg);
        }
    }
}
