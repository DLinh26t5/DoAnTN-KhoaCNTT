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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QLBD
{
    public partial class FormDotThi : Form
    {
        public string QuyenNguoiDung { get; internal set; }
        BUS_DotThi bus = new BUS_DotThi();
        public FormDotThi()
        {
            InitializeComponent();
        }
        void RefreshData()
        {
            dataGridView1.ShowData(bus.Load());
            dataGridView1.Columns["Lan"].Width = 50;
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
        private void FormLanThi_Load(object sender, EventArgs e)
        {
            if (QuyenNguoiDung == "User")
            {
                buttonThem.Enabled = true;
                buttonSua.Enabled = true;
                buttonXoa.Enabled = true;
            }

            comboBoxNganh.SelectedValueChanged += (s, ev) => LoadCTbyHocKy();
            comboBoxHocKy.SelectedValueChanged += (s, ev) => LoadCTbyHocKy();


            numericUpDownLT.Minimum = 1;
            numericUpDownLT.Maximum = 2;
            numericUpDownLT.Value = 1;

            comboBoxKhoa.LoadData<KhoaHoc>();
            comboBoxNganh.LoadData<NganhHoc>();
            comboBoxHinhThuc.LoadData<HinhThuc>();
            comboBoxHocKy.LoadData<HocKy>();

            RefreshData();
        }
        private void GetObject(Action<DotThi> callback)
        {
            callback(new DotThi {
                ID = selectedid,
                Lan =(int)numericUpDownLT.Value,
                Ngay = dateTimePickerNThi.Value,
                ID_ChuongTrinh = (int)comboBoxCT.SelectedValue,
                ID_HinhThuc = (int)comboBoxHinhThuc.SelectedValue,

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
            });
        }
        private int selectedid = -1;
        private void buttonXoa_Click(object sender, EventArgs e)
        {
            GetObject(o => {
                DialogResult d = MessageBox.Show($"Ban co chac chan muon xoa Lanthi {o.Lan}?", "Xac nhan xoa", MessageBoxButtons.YesNo);
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
            numericUpDownLT.Text = GetViewData<string>("Lan");
            dateTimePickerNThi.Text = GetViewData<string>("Ngay");
            comboBoxCT.SelectedValue = GetViewData<object>("ID_ChuongTrinh");
            comboBoxHinhThuc.SelectedValue = GetViewData<object>("ID_HinhThuc");


        }

        private void LoadCTbyHocKy()
        {
            if (comboBoxNganh.SelectedValue == null || comboBoxHocKy.SelectedValue == null)
                return;

            int idNganh = Convert.ToInt32(comboBoxNganh.SelectedValue);
            int idHocKy = Convert.ToInt32(comboBoxHocKy.SelectedValue);

            var dalCT = new DAL.DAL_ChuongTrinh();
            var dt = dalCT.GetChuongTrinhTheoNganhVaHocKy(idNganh, idHocKy);

            comboBoxCT.DataSource = null;
            comboBoxCT.Items.Clear();
            comboBoxCT.SetDataSource(dt, "ID", "TenMon");
        }
    }
}
