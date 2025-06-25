using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace QLBD
{
    public partial class FormBangDiemLop_Mon : Form
    {
        public FormBangDiemLop_Mon()
        {
            InitializeComponent();
            this.bangDiemBox1.MoDanhSach += GenBaoCao;
            this.bangDiemBox1.XuatDanhSach += (bd) => webBrowser1.ShowPrintDialog();

        }

        private void FormBangDiemLop_Mon_Load(object sender, EventArgs e)
        {
            
        }


       
        
        void GenBaoCao(DTO.BangDiem bd)
        {
            var iLop = bd.ID_LopHoc;
            var iDotThi = bd.ID_DotThi;

            BUS_Diem bus = new BUS_Diem();
            DataTable dt = bus.LoadBangDiem(iLop, iDotThi, false);

            string template = File.ReadAllText("BangDiemLopMon.html", Encoding.UTF8);
               template = template.Replace("{Lop}", bangDiemBox1.GetText("lop"));
            template = template.Replace("{MaMH}", bangDiemBox1.GetText("ma"));
            template = template.Replace("{MonHoc}", bangDiemBox1.GetText("mon"));
            template = template.Replace("{HinhThuc}", bangDiemBox1.GetText("hinhthuc"));

            StringBuilder sb = new StringBuilder();
            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                sb.Append("<tr>");
                sb.AppendFormat("<td>{0}</td>", i++);
                sb.AppendFormat("<td>{0}</td>", row["Ma"]);
                sb.AppendFormat("<td>{0}</td>", row["HoTen"]);
                sb.AppendFormat("<td>{0:dd/MM/yyyy}</td>", Convert.ToDateTime(row["NgaySinh"]));
                sb.AppendFormat("<td>{0}</td>", row["DiemThi"]);
                sb.Append("<td></td></tr>");
            }
            template = template.Replace("{BangDiem}", sb.ToString());

            webBrowser1.DocumentText = template;
        }

      
    }
}


