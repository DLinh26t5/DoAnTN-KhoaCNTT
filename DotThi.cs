using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DotThi
    {
        public int ID {  get; set; }
        public int Lan {  get; set; }
        public DateTime Ngay { get; set; }
        public int ID_ChuongTrinh {  get; set; }
        public int ID_HinhThuc { get; set; }
        public DotThi() { }
       
    }
}
