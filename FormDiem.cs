using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Runtime.CompilerServices;
using DAL;

namespace QLBD
{
    public partial class FormDiem : Form
    {
        public string QuyenNguoiDung { get; internal set; } //gọi quyền người dùng ra

        public FormDiem()
        {
            InitializeComponent();

            Init();

            bangDiemBox1.MoDanhSach += bd => {
                var lst = bus.LoadBangDiem(bd.ID_LopHoc, bd.ID_DotThi, bd.LanThi != 1);
                dataGridView1.DataSource = lst;
            };
        }
        BUS_Diem bus = new BUS_Diem();
        void RefreshData()
        {
            dataGridView1.ShowData(bus.Load());
        }

        public T GetViewData<T>(string name)
        {
            var r = dataGridView1.CurrentRow;
            if (r == null)
                return default(T);

            var v = r.Cells[name]?.Value;
            if (v == null) return default(T);

            return (T)Convert.ChangeType(v, typeof(T));
        }

        void Init()
        {
            Func<string, string, int, bool, DataGridViewColumn> col = (h, n, w, b) =>
            {
                var c = new DataGridViewTextBoxColumn();
                c.ReadOnly = !b;
                c.HeaderText = h;
                c.DataPropertyName = n;
                c.Width = w;
                return c;
            };

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] {
                col("ID", "ID_Diem", 0, false),
                col("Mã sinh viên", "Ma", 150, false),
                col("Họ tên", "HoTen", 200, false),
                col("Điểm", "DiemThi", 80, true),
                col("", "", 1000, false),
            });

            var colDiem = (DataGridViewTextBoxColumn)dataGridView1.Columns["DiemThi"];

            object old = null;
            dataGridView1.CellBeginEdit += (s, ev) => {
                old = dataGridView1.SelectedCells[0].Value;
            };
            dataGridView1.CellEndEdit += (s, ev) => {

                var view = (DataTable)dataGridView1.DataSource;
                var row = view.Rows[ev.RowIndex];
                var v = row["DiemThi"];

                var err = !double.TryParse(v?.ToString(), out double d);
                if (!err)
                {
                    err = d > 10 || d < 0;
                }
                if (err)
                {
                    MessageBox.Show("Điểm không hợp lệ");
                    row["DiemThi"] = old;
                    return;
                }

                var info = bangDiemBox1.GetValue();

                var iSinhVien = row["ID"];
                var iDotThi = info.ID_DotThi;

                var i = row["ID_Diem"];
                bus.SetDiem(i, iSinhVien, iDotThi, v);
            };
        }
        private void FormDiem_Load(object sender, EventArgs e)
        {
            if (QuyenNguoiDung == "User")
            {
                bangDiemBox1.Enabled = false;
            }


        }

        
    }
}
