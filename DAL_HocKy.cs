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
    public class DAL_HocKy:KetNoi
    {
        public DataTable Load()
        {
            //return Load_Table("SELECT HOCKY.ID, HOCKY.Ten, NGANHHOC.Ten\r\nFROM     HOCKY INNER JOIN\r\n                NGANHHOC ON HOCKY.ID_NganhHoc = NGANHHOC.ID");
            return LoadTable("SELECT * From HocKy");
        }
       
        public void Insert(HocKy hk)
        {
            string sql = CreateInsertSQL(hk);
            Excecute(sql);
        }
        public void Update(HocKy hk)
        {
            string sql = CreateUpdateSQL(hk);
            Excecute(sql);
        }
        public void Delete(HocKy hk)
        {
            string sql = "delete HOCKY from HOCKY where ID = '"+ hk.ID+"'";
            Excecute(sql);
        }

    }
}
