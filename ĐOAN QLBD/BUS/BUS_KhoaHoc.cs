using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public void Insert (KhoaHoc khoa)
        {
            dalkhoa.Insert(khoa);
        }
        public void Update(KhoaHoc khoa)
        {
            dalkhoa.Update(khoa);
        }
        public void Delete(KhoaHoc khoa)
        {
            dalkhoa.Delete(khoa);
        }
    }
}
