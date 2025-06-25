using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_Diem : KetNoi
    {
        protected override string GetSelectSQL()
        {
            return "select d.*, ID_LopHoc, sv.Ma, sv.Ten as HoTen, MonHoc.SoGio, MonHoc.Ten as TenMon, dt.Lan, dt.Ngay, HinhThuc.Ten as HinhThuc"
                + " from Diem d"
                + " inner join SinhVien sv on ID_SinhVien = sv.ID"
                + " inner join DotThi dt on ID_DotThi = dt.ID"
                + " inner join ChuongTrinh on ID_ChuongTrinh = ChuongTrinh.ID"
                + " inner join MonHoc on ID_MonHoc = MonHoc.ID"
                + " inner join HinhThuc on ID_HinhThuc = HinhThuc.ID";
        }

        public void Insert(BangDiem dB)
        {
            string sql = CreateInsertSQL(dB);
            Excecute(sql);
        }
    }
}
