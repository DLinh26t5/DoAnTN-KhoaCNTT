using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_CaNhan
    {
        public SinhVien SinhVien { get; set; }
        public string MSSV
        {
            get => SinhVien?.Ma;
            set
            {
                SinhVien = new DAL_SinhVien().GetByMSSV(value);
            }
        }
        public DataRowCollection GetBangDiem()
        {
            var da = new DAL_Diem();
            var dt = da.Select($"ID_SinhVien='{SinhVien.ID}'");

            return dt.Rows;
        }
    }
}
