using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using DTO;

namespace DAL
{
    public class DAL_KhoaHoc : KetNoi
    {

        public string Insert(KhoaHoc khoa)
        {
            try
            {
                string sql = CreateInsertSQL(khoa);
                Excecute(sql);
                return "Thêm thành công!";
            }
            catch (Exception ex)
            {
                return "Lỗi khi thêm: " + ex.Message;
            }
        }

        public string Update(KhoaHoc khoa)
        {
            try
            {
                string sql = CreateUpdateSQL(khoa);
                Excecute(sql);
                return "Sửa thành công!";
            }
            catch (Exception ex)
            {
                return "Lỗi khi sửa: " + ex.Message;
            }
        }

        public string Delete(KhoaHoc khoa)
        {
            try
            {
                string sql = "DELETE FROM KHOAHOC WHERE ID = " + khoa.ID;
                Excecute(sql);
                return "Xóa thành công!";
            }
            catch (Exception ex)
            {
                return "Lỗi khi xóa: " + ex.Message;
            }
        }
    }
}
