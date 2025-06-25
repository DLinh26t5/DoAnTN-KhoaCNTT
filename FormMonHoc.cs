using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBD
{
    public partial class FormMonHoc : Form
    {
        public string QuyenNguoiDung { get; internal set; }
        BUS_MonHoc bus = new BUS_MonHoc();
        public FormMonHoc()
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
        private void FormMonHoc_Load(object sender, EventArgs e)
        {
            if (QuyenNguoiDung == "User")
            {
                buttonThem.Enabled = true;
                buttonSua.Enabled = true;
                buttonXoa.Enabled = true;
            }
            RefreshData();

        }
        private void GetObject(Action<MonHoc> callback)
        {
            callback(new MonHoc
            {
                ID = selectedid,
                Ma = textBoxMaMH.Text,
                Ten = textBoxTenMH.Text,
                SoGio =int.Parse(textBoxSoGio.Text)
            });
        }
        private void buttonThem_Click(object sender, EventArgs e)
        {

            GetObject(o => {
                bus.Insert(o);
                RefreshData();
            });
        }
        private int selectedid = -1;
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
                DialogResult d = MessageBox.Show($"Ban co chac chan muon xoa Mon {o.Ten}?", "Xac nhan xoa", MessageBoxButtons.YesNo);
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
            textBoxMaMH.Text = GetViewData<string>("Ma");
            textBoxTenMH.Text = GetViewData<string>("Ten");
            textBoxSoGio.Text = GetViewData<string>("SoGio");


        }
    }
}
