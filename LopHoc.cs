using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LopHoc
    {
        public int ID { get; set; }
        public string Ten { get; set; }
        public int ID_NganhHoc { get; set; }
        public int ID_KhoaHoc { get; set; }
        public LopHoc() { }
        
    }
}
