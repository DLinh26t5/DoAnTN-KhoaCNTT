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
    public class DAL_DotThi : KetNoi
    {
        protected override string GetSelectSQL()
        {
            return "SELECT DotThi.*, ID_NganhHoc, MonHoc.Ma, MonHoc.Ten as TenMon, HinhThuc.Ten as HinhThuc FROM DotThi "
                + "INNER JOIN ChuongTrinh ON ID_ChuongTrinh = ChuongTrinh.ID "
                + "INNER JOIN MonHoc ON ID_MonHoc = MonHoc.ID "
                + "INNER JOIN HinhThuc ON ID_HinhThuc = HinhThuc.ID";
        }

        public string Insert(DotThi lt)
        {
            try
            {
                string sql = CreateInsertSQL(lt);
                Excecute(sql);
                return "Thêm thành công";
            }
            catch (Exception ex)
            {
                return "Lỗi khi thêm : " + ex.Message;
            }
        }
        public string Update(DotThi lt)
        {
            try
            {
                string sql = CreateUpdateSQL(lt);
                Excecute(sql);
                return "Sửa thành công";
            }
            catch (Exception ex)
            {
                return "Lỗi khi Sửa : " + ex.Message;
            }
        }
        public string Delete(DotThi lt)
        {
            try
            {
                string sql = CreateDeleteSQL(lt);
                Excecute(sql);
                return "Xóa thành công";
            }
            catch (Exception ex)
            {
                return "Lỗi khi xóa : " + ex.Message;
            }
        }
    }
}
