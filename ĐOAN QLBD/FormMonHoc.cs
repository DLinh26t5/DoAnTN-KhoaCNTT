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

namespace ĐOAN_QLBD
{
    public partial class FormMonHoc : Form
    {
        public FormMonHoc()
        {
            InitializeComponent();
        }
        public string QuyenNguoiDung { get; internal set; }
        BUS_MonHoc busmh = new BUS_MonHoc();
        private void FormMonHoc_Load(object sender, EventArgs e)
        {
            if (QuyenNguoiDung != "Admin")
            {
                buttonThem.Enabled = false;
                buttonSua.Enabled = false;
                buttonXoa.Enabled = false;
            }
            dataGridView1.DataSource = busmh.Load();
            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.Columns["MaMonHoc"].HeaderText = "Mã môn học";
            dataGridView1.Columns["TenMonHoc"].HeaderText = "Tên môn học";
            dataGridView1.Columns["SoGio"].HeaderText = "Số giờ";
            dataGridView1.Columns["HinhThuc"].HeaderText = "Hình thức";
            dataGridView1.Columns["TenHocKy"].HeaderText = "Học kỳ";
            dataGridView1.Columns["TenNganh"].HeaderText = "Ngành học";
            dataGridView1.Columns["TenKhoa"].HeaderText = "Khóa học";
            LoadComboboxkhoa();
        }
        private void LoadComboboxkhoa()
        {
            BUS_KhoaHoc buskhoa = new BUS_KhoaHoc();
            DataTable dt = buskhoa.LoadKhoa();
            comboBoxTenKhoa.DisplayMember = "TenKhoa";
            comboBoxTenKhoa.ValueMember = "ID";
            comboBoxTenKhoa.DataSource = dt;
        }

        private void comboBoxTenKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTenKhoa.SelectedValue != null && comboBoxTenKhoa.SelectedValue != DBNull.Value)
            {
                int id = (int)comboBoxTenKhoa.SelectedValue;
                LoadNganh(id);
            }
            else
            {
                // Xử lý trường hợp không có lựa chọn nào, ví dụ: xóa dữ liệu comboboxNganh
                comboBoxTenNganh.DataSource = null;
            }
        }
        private void LoadNganh(int id)
        {
            BUS_NganhHoc busN = new BUS_NganhHoc();
            DataTable dt = busN.GetNganhbyKhoa(id);
            comboBoxTenNganh.DisplayMember = "TenNganh";
            comboBoxTenNganh.ValueMember = "id";
            comboBoxTenNganh.DataSource = dt;
        }

        private void comboBoxTenNganh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTenNganh.SelectedValue != null && comboBoxTenNganh.SelectedValue != DBNull.Value)
            {
                int Id = (int)comboBoxTenNganh.SelectedValue;
                LoadHk(Id);
            }
        }
        private void LoadHk(int Id)
        {
            BUS_HocKy bus = new BUS_HocKy();
            DataTable dt = bus.Gethkybynganh(Id);
            comboBoxHocKy.DisplayMember = "TenHocKy";
            comboBoxHocKy.ValueMember = "ID";
            comboBoxHocKy.DataSource = dt;
        }

        private void comboBoxHocKy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxHocKy.SelectedValue != null)
            {
                int Id = (int)comboBoxHocKy.SelectedValue;
                LoadHT(Id);
            }
        }
        private void LoadHT(int Id)
        {
            BUS_HinhThuc bus = new BUS_HinhThuc();
            DataTable dt = bus.Getthucbyky(Id);
            comboBoxHinhThuc.DisplayMember = "HinhThuc";
            comboBoxHinhThuc.ValueMember = "ID";
            comboBoxHinhThuc.DataSource = dt;
        }
        private int ID_Select = -1;
        private void buttonThem_Click(object sender, EventArgs e)
        {
            MonHoc mh = new MonHoc();
            mh.TenMonHoc = textBoxTenMH.Text;
            mh.MaMonHoc = textBoxMaMH.Text;
            mh.SoGio = Convert.ToInt32(textBoxSoGio.Text);
            mh.ID_HinhThuc = Convert.ToInt32(comboBoxHinhThuc.SelectedValue);
            busmh.Insert(mh);
            dataGridView1.DataSource = busmh.Load();
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            MonHoc mh = new MonHoc();
            mh.TenMonHoc = textBoxTenMH.Text;
            mh.MaMonHoc = textBoxMaMH.Text;
            mh.SoGio = Convert.ToInt32(textBoxSoGio.Text);
            mh.ID_HinhThuc = Convert.ToInt32(comboBoxHinhThuc.SelectedValue);
            mh.ID = ID_Select;
            busmh.Update(mh);
            dataGridView1.DataSource = busmh.Load();
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            if (ID_Select == -1)
            {
                MessageBox.Show("Vui lòng chọn môn học cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa môn học này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                MonHoc mh = new MonHoc();
                mh.ID = ID_Select;

                try
                {
                    busmh.Delete(mh);
                    dataGridView1.DataSource = busmh.Load();
                    MessageBox.Show("Xóa môn học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xóa không thành công. Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ClearForm()
        {
            textBoxMaMH.Clear();
            textBoxTenMH.Clear();
            textBoxSoGio.Clear();
            comboBoxTenKhoa.SelectedIndex = -1;
            comboBoxTenNganh.DataSource = null;
            comboBoxHocKy.DataSource = null;
            comboBoxHinhThuc.DataSource = null;
            ID_Select = -1;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                ID_Select = Convert.ToInt32(row.Cells["ID"].Value);
                textBoxMaMH.Text = row.Cells["MaMonHoc"].Value.ToString();
                textBoxTenMH.Text = row.Cells["TenMonHoc"].Value.ToString();
                textBoxSoGio.Text = row.Cells["SoGio"].Value.ToString();

                comboBoxTenKhoa.Text = dataGridView1.Rows[e.RowIndex].Cells["TenKhoa"].Value.ToString();
                comboBoxTenNganh.Text = dataGridView1.Rows[e.RowIndex].Cells["TenNganh"].Value.ToString();
                comboBoxHocKy.Text = dataGridView1.Rows[e.RowIndex].Cells["TenHocKy"].Value.ToString();
                comboBoxHinhThuc.Text = dataGridView1.Rows[e.RowIndex].Cells["HinhThuc"].Value.ToString();
            }
        }
    }
}
