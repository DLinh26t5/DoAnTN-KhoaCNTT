using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class DAL_HinhThuc : KetNoi
    {
        public string Insert(HinhThuc Hthuc)
        {
            try
            {
                string sql = CreateInsertSQL(Hthuc);
                Excecute(sql);
                return "Thêm thành công";
            }
            catch (Exception ex)
            {
                return "Lỗi khi thêm : " + ex.Message;
            }
        }
        public string Update(HinhThuc Hthuc)
        {
            try
            {
                string sql = CreateUpdateSQL(Hthuc);

                //string sql = $"update HINHTHUC set HinhThuc=N'{Hthuc.Ten}' where ID='{Hthuc.ID}')";
                Excecute(sql);
                return "Sửa thành công";
            }
            catch (Exception ex)
            {
                return "Lỗi khi Sửa : " + ex.Message;
            }
        }
        public string Delete(HinhThuc Hthuc)
        {
            try
            {
                //string sql = "delete HINHTHUC from HINHTHUC where ID = '" + Hthuc.ID + "'";
                Excecute(CreateDeleteSQL(Hthuc));
                return "Xóa thành công";
            }
            catch (Exception ex)
            {
                return "Lỗi khi xóa : " + ex.Message;
            }
        }
    }
}
