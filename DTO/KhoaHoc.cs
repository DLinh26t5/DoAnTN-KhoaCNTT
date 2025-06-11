using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhoaHoc
    {
        public int ID {  get; set; }
        public string TenKhoa {  get; set; }
        public KhoaHoc() { }
        public KhoaHoc(int iD, string tenKhoa)
        {
            ID = ID;
            TenKhoa = tenKhoa;
        }
        public KhoaHoc(string tenKhoa)
        {
            TenKhoa = tenKhoa;
        }
    }
}
