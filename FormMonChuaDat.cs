using BUS;
using DAL;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QLBD
{
    public partial class FormMonChuaDat : Form
    {BUS_ChuaDat bus = new BUS_ChuaDat();
        public FormMonChuaDat()
        {
            InitializeComponent();

            this.Load += FormMonChuaDat_Load;
            this.bangDiemBox1.MoDanhSach += GenBaoCao;
            this.bangDiemBox1.XuatDanhSach += (bd) => webBrowser1.ShowPrintDialog();

            this.bangDiemBox1.Title = "Môn chưa đạt";
        }

        
        private void FormMonChuaDat_Load(object sender, EventArgs e)
        {
        }

        void GenBaoCao(DTO.BangDiem info)
        {
            BUS_Diem busDiem = new BUS_Diem();
            DataTable dt = busDiem.LoadBangDiem(info.ID_LopHoc, info.ID_DotThi, true);

            // Đọc template
            string template = File.ReadAllText("MonChuaDat.html", Encoding.UTF8);

            // Thay thế thông tin chung
            template = template.Replace("{Lop}", bangDiemBox1.GetText("lop"));
            template = template.Replace("{MaMH}", bangDiemBox1.GetText("ma"));
            template = template.Replace("{MonHoc}", bangDiemBox1.GetText("mon"));
            template = template.Replace("{HinhThuc}", bangDiemBox1.GetText("hinhthuc"));

            // Sinh danh sách bảng điểm
            StringBuilder sb = new StringBuilder();
            int stt = 1;
            foreach (DataRow row in dt.Rows)
            {
                sb.Append("<tr>");
                sb.AppendFormat("<td>{0}</td>", stt++);
                sb.AppendFormat("<td>{0}</td>", row["Ma"]);
                sb.AppendFormat("<td>{0}</td>", row["HoTen"]);
                sb.AppendFormat("<td>{0:dd/MM/yyyy}</td>", row["NgaySinh"]);
                sb.AppendFormat("<td>{0}</td>", row["DiemThi"]);
                sb.Append("<td></td><td></td>");
                sb.Append("</tr>");
            }
            template = template.Replace("{DanhSach}", sb.ToString());

            // Load lên webBrowser
            webBrowser1.DocumentText = template;
        }
    }
}

    

