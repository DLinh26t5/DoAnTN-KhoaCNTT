using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class MonHoc
    {
        public int ID {  get; set; }
        public string MaMonHoc {  get; set; }
        public string TenMonHoc { get; set; }
        public int SoGio {  get; set; }
        public int ID_HinhThuc {  get; set; }
        public MonHoc() { }
        public  MonHoc(string MaMonHoc, string TenMonHoc,int SoGio, int ID_HinhThuc)
        {
            MaMonHoc = MaMonHoc;
            TenMonHoc = TenMonHoc;
            ID_HinhThuc = ID_HinhThuc;
            SoGio = SoGio;
        }
        public MonHoc(int iD, string maMonHoc, string tenMonHoc, int soGio, int iD_HinhThuc)
        {
            ID = iD;
            MaMonHoc = maMonHoc;
            TenMonHoc = tenMonHoc;
            SoGio = soGio;
            ID_HinhThuc = iD_HinhThuc;
        }
    }
}
