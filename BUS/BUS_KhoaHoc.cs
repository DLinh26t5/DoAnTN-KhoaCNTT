
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;
using DTO;


namespace BUS
{
    public class BUS_KhoaHoc
    {
        DAL_KhoaHoc dalkhoa = new DAL_KhoaHoc();
        public DataTable LoadKhoa()
        {
            return dalkhoa.Load();
        }
        public void Insert(KhoaHoc hoc)
        {
            dalkhoa.Insert(hoc);
        }
        public void Update(KhoaHoc hoc)
        {
            dalkhoa.Update(hoc);
        }
        public void Delete(KhoaHoc hoc)
        {
            dalkhoa.Delete(hoc);
        }
    }
}
