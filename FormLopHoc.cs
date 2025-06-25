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


namespace QLBD
{
    public partial class FormLopHoc : Form
    {
        public string QuyenNguoiDung { get; internal set; }
        BUS_Lop bus = new BUS_Lop();

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

        public FormLopHoc()
        {
           
            InitializeComponent();
        }

        private void FormLopHoc_Load(object sender, EventArgs e)
        {
            if (QuyenNguoiDung == "User")
            {
                buttonThem.Enabled = true;
                buttonSua.Enabled = true;
                buttonXoa.Enabled = true;
            }
            comboBoxKhoa.LoadData<KhoaHoc>();
            comboBoxNganh.LoadData<NganhHoc>();

            RefreshData();

        }
        private void GetObject(Action<LopHoc> callback)
        {
            callback(new LopHoc { 
                ID = selectedid,
                Ten = textBoxTenLop.Text,
                ID_NganhHoc = (int)comboBoxNganh.SelectedValue,
                ID_KhoaHoc = (int)comboBoxKhoa.SelectedValue,  
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
                DialogResult d = MessageBox.Show($"Ban co chac chan muon xoa Lop {o.Ten}?", "Xac nhan xoa", MessageBoxButtons.YesNo);
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
            textBoxTenLop.Text = GetViewData<string>("Ten");
            comboBoxKhoa.SelectedValue = GetViewData<object>("ID_KhoaHoc");
            comboBoxNganh.SelectedValue = GetViewData<object>("ID_NganhHoc");

            //selectedid = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID"]?.Value);
            //textBoxTenLop.Text = dataGridView1.CurrentRow.Cells["Ten"].Value?.ToString();
        }
    }
}
