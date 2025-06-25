using BUS;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;


namespace QLBD
{
    public partial class FormBangDiemCaNhan : Form
    {
        BUS_CaNhan bus = new BUS_CaNhan();

        void ShowBangDiem(string mssv)
        {
            bus.MSSV = mssv;
            if (bus.SinhVien == null)
            {
                MessageBox.Show("Không tìm thấy sinh viên này");
                textBox1.Focus();
                return;
            }

            var mau = new XmlDocument();
            using (var sr = new System.IO.StreamReader("BangDiemCaNhan.html"))
            {
                var content = sr.ReadToEnd();
                content = content.Replace("{Ma}", bus.MSSV);
                content = content.Replace("{Ten}", bus.SinhVien.Ten);
                content = content.Replace("{NgaySinh}", bus.SinhVien.NgaySinh.ToString("dd/MM/yyyy"));

                var rows = bus.GetBangDiem();
                int i = 0;
                var s = "";

                Action<object, string> cell = (v, c) => s += $"<td class='{c}'>{v}</td>";
                foreach (DataRow r in rows)
                {
                    s += "<tr>";
                    cell(++i, "TT");
                    cell(r["TenMon"], "TenMon");
                    cell((int)r["SoGio"] / 15, "SoTC");
                    cell(r["DiemThi"], "Diem");
                    s += "<td/></tr>";
                }
                content = content.Replace("{BangDiem}", s);



                mau.LoadXml(content);

                webBrowser1.DocumentText = mau.OuterXml;
            }
        }
        public FormBangDiemCaNhan()
        {
            InitializeComponent();
            textBox1.Text = "CD220337";
            textBox1.LostFocus += (s, e) => ShowBangDiem(textBox1.Text.ToUpper());
            button1.Click += (s, e) => webBrowser1.ShowPrintDialog();
        }

       
    }
}
