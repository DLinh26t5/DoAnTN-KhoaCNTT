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
    public class DAL_MonHoc:KetNoi
    {
        public DataTable Load()
        {
            return Load_Table("select * from MONHOC");
        }
        public void Insert(MonHoc mh )
        {
            string sql = "insert into MONHOC values (N'" + mh.MaMonHoc + "',N'" + mh.TenMonHoc + "','" + mh.SoGio + "','" + mh.ID_HinhThuc + "')";
            Excecute(sql);
        }
        public void Updater(MonHoc mh)
        {
            string sql = "UPDATE MONHOC SET MaMonHoc = N'" + mh.MaMonHoc + "', TenMonHoc = N'" + mh.TenMonHoc + "', SoGio = " + mh.SoGio + ", ID_HinhThuc = " + mh.ID_HinhThuc + " WHERE ID = '" + mh.ID + "'";
            Excecute(sql);
        }
        public void Delete(MonHoc mh)
        {
            string sql = "delete MONHOC from MONHOC where ID = '" + mh.ID + "'";
            Excecute(sql);
        }
        public DataTable GetmonhocbyHinhthuc(int ID_Hinhthuc)
        {
            string sql = "select * from MonHoc where ID_Hinhthuc= @ID_Hinhthuc";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@ID_Hinhthuc", ID_Hinhthuc);
            DataTable dt = new DataTable();
            Executee(cmd, dt);
            return dt;
        }
    }
}
