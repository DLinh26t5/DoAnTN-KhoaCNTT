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

        BUS_NganhHoc busnganh = new BUS_NganhHoc();
        BUS_KhoaHoc buskhoa = new BUS_KhoaHoc();
        public FormLopHoc()
        {
            InitializeComponent();
        }

        private void FormLopHoc_Load(object sender, EventArgs e)
        {
            BUS_Lop buslop = new BUS_Lop();
            dataGridView1.DataSource = buslop.Load();

            Loadkhoatocombobox();
        }
        private void Loadkhoatocombobox()
        {
            BUS_KhoaHoc busK = new BUS_KhoaHoc();
            DataTable dt = busK.LoadKhoa();
            comboBoxKhoa.DisplayMember = "TenKhoa";
            comboBoxKhoa.ValueMember = "ID";
            comboBoxKhoa.DataSource = dt;
        }
        private void comboBoxKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ID_Khoa = (int)comboBoxKhoa.SelectedValue;
            LoadNganh(ID_Khoa);
        }
        private void LoadNganh(int ID_Khoa)
        {
            BUS_NganhHoc bus = new BUS_NganhHoc();
            DataTable dt = bus.GetNganhbyKhoa(ID_Khoa);
            comboBoxNganh.DisplayMember = "Tennganh";
            comboBoxNganh.ValueMember = "ID";
            comboBoxNganh.DataSource = dt;
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            string Tenlop = textBoxTenLop.Text;
            int ID_Nganh = Convert.ToInt32(comboBoxNganh.SelectedValue);

            LopHoc L = new LopHoc();
            L.TenLop = Tenlop;
            L.ID_Nganh = ID_Nganh;

            BUS_Lop bus = new BUS_Lop();
            string s = bus.Insert(L);
            LoadLoptheonganh(ID_Nganh);
            MessageBox.Show(s);
        }
        private void LoadLoptheonganh(int idNganh)
        {
            BUS_Lop bus = new BUS_Lop();
            DataTable dt = bus.GetLopbyNganh(idNganh);
            if (dt != null && dt.Rows.Count > 0)
            {
                // Kiểm tra nếu dữ liệu đã thay đổi
                if (dataGridView1.DataSource != dt)
                {
                    dataGridView1.DataSource = dt;
                }
            }
        }
        private int selectedid = -1;
        private void buttonSua_Click(object sender, EventArgs e)
        {
            int ID = selectedid;
            string Tenlop = textBoxTenLop.Text;
            int ID_nganh = Convert.ToInt32(comboBoxNganh.SelectedValue);

            LopHoc lop = new LopHoc();
            lop.TenLop = Tenlop;
            lop.ID_Nganh = ID_nganh;
            lop.ID = ID;

            BUS_Lop bus = new BUS_Lop();
            string s = bus.Update(lop);
            LoadLoptheonganh(ID_nganh);
            MessageBox.Show(s);
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            int ID_nganh = (int)comboBoxNganh.SelectedValue;
            int ID = selectedid;
            DialogResult d = MessageBox.Show($"Ban co chac chan mua xoa Lop {textBoxTenLop.Text}?", "Xac nhan xoa", MessageBoxButtons.YesNo);
            if (d == DialogResult.No)
            {
                return;
            }
            LopHoc lop = new LopHoc();
            lop.ID = ID;

            BUS_Lop bus = new BUS_Lop();
            string s = bus.Delete(lop);
            LoadLoptheonganh(ID_nganh);
            MessageBox.Show(s);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedid = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID"].Value);
            textBoxTenLop.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }
    }
}
