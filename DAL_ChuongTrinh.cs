using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_ChuongTrinh: KetNoi
    {
        protected override string GetSelectSQL()
        {
            return "select ChuongTrinh.*, NganhHoc.Ten as Nganh, MonHoc.Ten as TenMon,HocKy.Ten as TenHocKy "
                 + "FROM ChuongTrinh "
                 + "INNER JOIN NganhHoc ON ID_NganhHoc = NganhHoc.ID "
                 + "INNER JOIN MonHoc ON ID_MonHoc = MonHoc.ID "
                 + "INNER JOIN HocKy ON ID_HocKy = HocKy.ID ";
        }

        public DataTable GetChuongTrinhTheoNganhVaHocKy(int idNganh, int idHocKy)
        {
            string sql = @"
        SELECT ChuongTrinh.ID, MonHoc.Ten AS TenMon
        FROM ChuongTrinh
        INNER JOIN MonHoc ON ChuongTrinh.ID_MonHoc = MonHoc.ID
        WHERE ID_NganhHoc = " + idNganh + " AND ID_HocKy = " + idHocKy;

            return LoadTable(sql);
        }

        public string Insert(ChuongTrinh ct)
        {
            try
            {
                string sql = CreateInsertSQL(ct);
                Excecute(sql);
                return "Thêm thành công";
            }
            catch (Exception ex)
            {
                return "Lỗi khi thêm : " + ex.Message;
            }
        }
        public string Update(ChuongTrinh ct)
        {
            try
            {
                string sql = CreateUpdateSQL(ct);

                //string sql = $"update HINHTHUC set HinhThuc=N'{Hthuc.Ten}' where ID='{Hthuc.ID}')";
                Excecute(sql);
                return "Sửa thành công";
            }
            catch (Exception ex)
            {
                return "Lỗi khi Sửa : " + ex.Message;
            }
        }
        public string Delete(ChuongTrinh ct)
        {
            try
            {
                //string sql = "delete HINHTHUC from HINHTHUC where ID = '" + Hthuc.ID + "'";
                Excecute(CreateDeleteSQL(ct));
                return "Xóa thành công";
            }
            catch (Exception ex)
            {
                return "Lỗi khi xóa : " + ex.Message;
            }
        }
    }
}
