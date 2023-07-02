using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAn1_LuuDucQuang_10121201.DataAccess;

namespace DoAn1_LuuDucQuang_10121201.Bussiness
{
    public class QLTonKhoBUS
    {
        QLTonKhoDAO tonKhoDAO = new QLTonKhoDAO();

        public List<Tonkho> tk;
        public List<Tonkho> GetTonkhos()
        {
            return tonKhoDAO.GetTonkhos();
        }

        public Tonkho gettheoma(string mamp)
        {
            return tonKhoDAO.gettheoma(mamp);
        }

        public void AddTonkho(Tonkho x, int a)
        {
            Tonkho tonkho = tonKhoDAO.GetTonkhos().SingleOrDefault(s => s.MaMP == x.MaMP);
            if (tonkho == null)
            {
                tonKhoDAO.AddTonkho(x);
            }
            else
            {
                tonKhoDAO.EditSL(x, a);
            }
        }
        static public int sltoncu = 0;

        public void EditSLTru(string x, int a)
        {
            Tonkho tonkho = tonKhoDAO.GetTonkhos().SingleOrDefault(s => s.MaMP == x);
            if (tonkho != null)
            {
                tonKhoDAO.EditSLTru(x, a);
            }
        }

        public void EditSLSua( int m, int c, string mamp)
        {
            Tonkho tonkho = tonKhoDAO.gettheoma(mamp);
            Console.WriteLine(sltoncu);
            if (tonkho != null)
            {
                tonKhoDAO.EditSLSua(mamp, m, c);
            }
        }

        static public int sltoncuban = 0;

        public void EditSLSuaBan(string mamp,int c, int m)
        {
            Tonkho tonkho = tonKhoDAO.gettheoma(mamp);
            if (tonkho != null)
            {
                tonKhoDAO.EditSLSuaBan(mamp, c, m);
            }
        }
        public void DeleteTonkho(Tonkho d)
        {
            tonKhoDAO.DeleteTonkho(d.MaMP);
        }

        public void EditTonkho(Tonkho xg)
        {
            tonKhoDAO.EditTonkho(xg);
        }

    }
}
