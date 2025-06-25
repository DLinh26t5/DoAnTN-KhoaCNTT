using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Khoa
    {
        public int ID { get; set; }
        public string Ten { get; set; }
    }
    public class NganhHoc
    {
        public int ID {  get; set; }
        public string Ten {  get; set; }
        public int ID_Khoa {  get; set; }
        public NganhHoc() { }
        
    }
}
