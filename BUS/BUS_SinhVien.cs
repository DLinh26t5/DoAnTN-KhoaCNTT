using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Data;
using System.Diagnostics;

namespace BUS
{
    public class BUS_SinhVien
    {
        DAL_SinhVien dalsv = new DAL_SinhVien();
        public DataTable Loadsv()
        {
            return dalsv.Load();
        }
        public string Insert(SinhVien sv)
        {
            return dalsv.Insert(sv);
        }
        public String Update(SinhVien sv)
        {
            return dalsv.Update(sv);
        }
        public string Delete(SinhVien sv)
        {
            return dalsv.Delete(sv);
        }
        public DataTable GetSinhvienbylop(int ID)
        {
            return dalsv.GetSinhVienbyLop(ID);
        }
        public int GetID(string masv)
        {
            return dalsv.GetID(masv);
        }
        public DataTable GetIDbynam(string name)
        {
            return dalsv.GetsvbyName(name);
        }
    }
}
