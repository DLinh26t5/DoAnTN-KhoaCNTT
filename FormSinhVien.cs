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
    public partial class FormSinhVien : Form
    {
        BUS_SinhVien bus = new BUS_SinhVien();
        public string QuyenNguoiDung { get; internal set; }
        public FormSinhVien()
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.SelectionChanged += (s, e) => {
                try
                {
                    selectedid = GetViewData<int>("ID");
                    textBoxMaSV.Text = GetViewData<string>("Ma");
                    textBoxTenSV.Text = GetViewData<string>("Ten");
                    comboBoxLop.SelectedValue = GetViewData<object>("ID_LopHoc");
                }
                catch
                {

                }
            };
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
        private void FormSinhVien_Load(object sender, EventArgs e)
        {
            if (QuyenNguoiDung == "User")
            {
                buttonThem.Enabled = true;
                buttonSua.Enabled = true;
                buttonXoa.Enabled = true;
            }
            comboBoxKhoa.LoadData<KhoaHoc>();
            comboBoxNganh.LoadData<NganhHoc>();
            comboBoxLop.LoadData<LopHoc>();
            RefreshData();
        }

        private void GetObject(Action<SinhVien> callback)
        {
            callback(new SinhVien
            {
                ID = selectedid,
                Ten = textBoxTenSV.Text,
                Ma = textBoxMaSV.Text,
                NgaySinh = dateTimePicker.Value,
                ID_LopHoc = (int)comboBoxLop.SelectedValue,
                
            }) ;
        }
  

        private void buttonThem_Click(object sender, EventArgs e)
        {
            GetObject(o => {
                var code = bus.Insert(o);
                if (code != null)
                {
                    MessageBox.Show(code);
                    return;
                }    
                RefreshData();
            });
        }
        

        private int selectedid = -1;

        private void buttonSua_Click(object sender, EventArgs e)
        {
            GetObject(o => {
                bus.Update(o);
                RefreshData();
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

      

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
