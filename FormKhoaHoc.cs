
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;

namespace QLBD
{
    public partial class FormKhoaHoc : Form
    {
        public string QuyenNguoiDung { get; internal set; }
        BUS_KhoaHoc bus = new BUS_KhoaHoc();
        public FormKhoaHoc()
        {
            InitializeComponent();
        }
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
        private void FormKhoaHoc_Load(object sender, EventArgs e)
        {
            if (QuyenNguoiDung == "User")
            {
                buttonThem.Enabled = true;
                buttonSua.Enabled = true;
                buttonXoa.Enabled = true;
            }
            dataGridView1.DataSource = bus.Load();
            RefreshData();
        }
        private int selectedid = -1;
        private void GetObject(Action<KhoaHoc> callback)
        {
            callback(new KhoaHoc
            {
                ID = selectedid,
                Ten = textBoxTen.Text,
                NamVao = int.Parse(textBoxNamVao.Text)

            });
        }
        private void buttonThem_Click(object sender, EventArgs e)
        {
            GetObject(o => {
                bus.Insert(o);
                RefreshData();
            });
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            
            GetObject(o => {
                bus.Update(o);
                RefreshData();
                //MessageBox.Show(s);
            });
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
           
            GetObject(o => {
                DialogResult d = MessageBox.Show($"Ban co chac chan muon xoa nganh {o.Ten}?", "Xac nhan xoa", MessageBoxButtons.YesNo);
                if (d == DialogResult.Yes)
                {
                    bus.Delete(o);
                    RefreshData();
                }
            });
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedid = GetViewData<int>("ID");
            textBoxTen.Text = GetViewData<string>("Ten");
            textBoxNamVao.Text = GetViewData<string>("NamVao");
        }
    }     
}
