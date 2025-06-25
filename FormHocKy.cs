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
    public partial class FormHocKy : Form
    {
        public string QuyenNguoiDung { get; internal set; }
        BUS_HocKy bus = new BUS_HocKy();

        public FormHocKy()
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
        private void FormHocKy_Load(object sender, EventArgs e)
        {
            if (QuyenNguoiDung == "User")
            {
                buttonThem.Enabled = true;
                buttonSua.Enabled = true;
                buttonXoa.Enabled = true;
            }

            RefreshData();
        }
        private int selectedid = -1;
        private void GetObject(Action<HocKy> callback)
        {
            callback(new HocKy
            {
                ID = selectedid,
                Ten = textBoxHocKy.Text,
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
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedid = GetViewData<int>("ID");
            textBoxHocKy.Text = GetViewData<string>("Ten");
           
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            GetObject(o => {
                DialogResult d = MessageBox.Show($"Ban co chac chan muon xoa HocKy {o.Ten}?", "Xac nhan xoa", MessageBoxButtons.YesNo);
                if (d == DialogResult.Yes)
                {
                    bus.Delete(o);
                    RefreshData();
                }
            });
        }
    }
}
