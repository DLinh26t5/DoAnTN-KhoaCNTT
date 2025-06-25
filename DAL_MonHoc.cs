using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_MonHoc  :KetNoi
    {
        
        public string Insert(MonHoc mh)
        {
            try
            {
                string sql = CreateInsertSQL(mh); //"insert into MONHOC values (N'" + mh.MaMonHoc + "', N'" + mh.TenMonHoc + "', '" + mh.SoGio + "', '" + mh.ID_HinhThuc + "')";
                Excecute(sql);
                return "Thêm thành công";
            }
            catch (Exception ex)
            {
                return "Lỗi khi thêm : " + ex.Message;
            }
        }
        public string Update(MonHoc mh)
        {
            try
            {
                string sql = CreateUpdateSQL(mh); //"UPDATE MONHOC SET MaMonHoc = N'" + mh.MaMonHoc + "', TenMonHoc = N'" + mh.TenMonHoc + "', SoGio = " + mh.SoGio + ", ID_HinhThuc = " + mh.ID_HinhThuc + " WHERE ID = '" + mh.ID + "'";
                Excecute(sql);
                return "Sửa thành công";
            }
            catch (Exception ex)
            {
                return "Lỗi khi Sửa : " + ex.Message;
            }

        }
        public string Delete(MonHoc mh)
        {
            try
            {
                string sql = "delete MONHOC from MonHoc where ID = '" + mh.ID + "'";
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
