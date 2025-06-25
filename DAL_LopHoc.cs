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
    public class DAL_LopHoc : KetNoi
    {
        protected override string GetSelectSQL()
        {
            return "select LopHoc.*, NganhHoc.Ten as Nganh, KhoaHoc.Ten as Khoa from LOPHOC "
                + "INNER JOIN NganhHoc on ID_NganhHoc = NganhHoc.ID "
                + "INNER JOIN KhoaHoc on ID_KhoaHoc = KhoaHoc.ID ";
        }
        
        public string Insert(LopHoc lh)
        {
            try
            {
                string sql = CreateInsertSQL(lh);
                Excecute(sql);
                return "Thêm thành công";
            }
            catch (Exception ex)
            {
                return "Lỗi khi thêm : " + ex.Message;
            }
        }
        public string Update(LopHoc lh)
        {
            try
            {
                string sql = CreateUpdateSQL(lh);
                Excecute(sql);
                return "Sửa thành công";
            }
            catch (Exception ex)
            {
                return "Lỗi khi Sửa : " + ex.Message;
            }
        }
        public string Delete(LopHoc lh)
        {
            string sql = CreateDeleteSQL(lh);
            return Excecute(sql) == 0 ? "ERROR" : null;

        }
    }
}

