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

namespace QLBD
{
    public partial class FormDiem : Form
    {
        public FormDiem()
        {
            InitializeComponent();
        }
        BUS_BangDiem busD = new BUS_BangDiem();

        private void FormDiem_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = busD.LoadBD();
            LoadKhoatocombobox();
        }
        private void LoadKhoatocombobox()
        {
            BUS_KhoaHoc bus = new BUS_KhoaHoc();
            DataTable dt = bus.LoadKhoa();
            comboBoxTenKhoa.DisplayMember = "TenKhoa";
            comboBoxTenKhoa.ValueMember = "ID";
            comboBoxTenKhoa.DataSource = dt;
            comboBoxTenKhoa.SelectedIndex = -1;
        }
        BUS_SinhVien busSV = new BUS_SinhVien();
        private void comboBoxTenKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;

            if (comboBoxTenKhoa.SelectedIndex != -1)
            {
                int ID = (int)comboBoxTenKhoa.SelectedValue;
                LoadNganh(ID);
            }
            else
            {
                comboBoxTenNganh.DataSource = null;
                comboBoxHocKy.DataSource = null;
                comboBoxHinhThuc.DataSource = null;
                comboBoxMonHoc.DataSource = null;
                comboBoxLanThi.DataSource = null;
                comboBoxLop.DataSource = null;
            }
        }
        private void LoadNganh(int ID)
        {
            BUS_NganhHoc bus = new BUS_NganhHoc();
            DataTable dt = bus.GetNganhbyKhoa(ID);
            comboBoxTenNganh.DisplayMember = "Tennganh";
            comboBoxTenNganh.ValueMember = "ID";
            comboBoxTenNganh.DataSource = dt;
            comboBoxTenNganh.SelectedIndex = -1;

        }
        private void comboBoxTenNganh_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;

            if (comboBoxTenNganh.SelectedIndex != -1)
            {
                int ID = (int)comboBoxTenNganh.SelectedValue;
                LoadHk(ID);
                LoadLop(ID);
            }
            else
            {
                comboBoxHocKy.DataSource = null;
                comboBoxHinhThuc.DataSource = null;
                comboBoxMonHoc.DataSource = null;
                comboBoxLanThi.DataSource = null;
                comboBoxLop.DataSource = null;
            }
        }
        private void LoadHk(int id)
        {
            BUS_HocKy bus = new BUS_HocKy();
            DataTable dt = bus.Gethkybynganh(id);
            comboBoxHocKy.DisplayMember = "TenHocky";
            comboBoxHocKy.ValueMember = "ID";
            comboBoxHocKy.DataSource = dt;
            comboBoxHocKy.SelectedIndex = -1;
        }
        private void LoadLop(int id)
        {
            BUS_Lop bus = new BUS_Lop();
            DataTable dt = bus.GetLopbyNganh(id);
            comboBoxLop.DisplayMember = "Tenlop";
            comboBoxLop.ValueMember = "ID";
            comboBoxLop.DataSource = dt;
            comboBoxLop.SelectedIndex = -1;
        }

        private void comboBoxHocKy_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;

            if (comboBoxHocKy.SelectedIndex != -1)
            {
                int ID = (int)comboBoxHocKy.SelectedValue;
                LoadHT(ID);
            }
            else
            {
                comboBoxHinhThuc.DataSource = null;
                comboBoxMonHoc.DataSource = null;
                comboBoxLanThi.DataSource = null;
            }
        }
        private void LoadHT(int iD)
        {
            BUS_HinhThuc bus = new BUS_HinhThuc();
            DataTable dt = bus.Getthucbyky(iD);
            comboBoxHinhThuc.DisplayMember = "HinhThuc";
            comboBoxHinhThuc.ValueMember = "ID";
            comboBoxHinhThuc.DataSource = dt;
            comboBoxHinhThuc.SelectedIndex = -1;

        }

        private void comboBoxHinhThuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;

            if (comboBoxHinhThuc.SelectedIndex != -1)
            {
                int ID = (int)comboBoxHinhThuc.SelectedValue;
                LoadMonhoc(ID);
            }
            else
            {
                comboBoxMonHoc.DataSource = null;
                comboBoxLanThi.DataSource = null;
            }
        }
        private void LoadMonhoc(int Id)
        {
            BUS_MonHoc bus = new BUS_MonHoc();
            DataTable dt = bus.GetmonhocbyHinhthuc(Id);
            comboBoxMonHoc.DisplayMember = "TenMonHoc";
            comboBoxMonHoc.ValueMember = "ID";
            comboBoxMonHoc.DataSource = dt;
            comboBoxMonHoc.SelectedIndex = -1;
        }

        private void comboBoxMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;

            if (comboBoxMonHoc.SelectedIndex != -1)
            {
                int ID = (int)comboBoxMonHoc.SelectedValue;
                LoadLanThi(ID);
            }
            else
            {
                comboBoxLanThi.DataSource = null;
            }
        }
        private void LoadLanThi(int ID)
        {

            BUS_LanThi bus = new BUS_LanThi();
            DataTable dt = bus.GetlanthibyMonhoc(ID);
            comboBoxLanThi.DisplayMember = "LanThi";
            comboBoxLanThi.ValueMember = "ID";
            comboBoxLanThi.DataSource = dt;
            comboBoxLanThi.SelectedIndex = -1;
        }

        private void comboBoxLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTenKhoa.SelectedIndex == -1 ||
                 comboBoxTenNganh.SelectedIndex == -1 ||
                 comboBoxLop.SelectedIndex == -1 ||
                 comboBoxLanThi.SelectedIndex == -1)
            {
                return;
            }
           
            // Lấy dữ liệu
            int selectedclass = (int)comboBoxLop.SelectedValue;
            int selecttedLanthi = Convert.ToInt32(comboBoxLanThi.Text);
            int selectedMon = (int)comboBoxMonHoc.SelectedValue;

            BUS_BangDiem bus = new BUS_BangDiem();
            DataTable dt = new DataTable();

            // Gọi đúng hàm lấy dữ liệu theo lần thi
            if (selecttedLanthi == 1)
            {
                dt = bus.GetAllSV(selectedclass, selectedMon);
            }
            else if (selecttedLanthi == 2)
            {
                dt = bus.GetSVL2(selectedclass, selectedMon);
            }

            // Gán vào DataGridView
            dataGridView1.DataSource = dt;
            dataGridView1.ReadOnly = false;               // Cho phép sửa tất cả ô
            dataGridView1.AllowUserToAddRows = false;     // Không cho thêm dòng mới
            dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter; // Cho phép sửa khi chọn ô
            // Đặt tên cột cho dễ nhìn
            dataGridView1.Columns["MaSinhVien"].HeaderText = "Mã sinh viên";
            dataGridView1.Columns["TenSinhVien"].HeaderText = "Tên Sinh Viên";

            if (selecttedLanthi == 1)
            {
                dataGridView1.Columns["Diem"].HeaderText = "Điểm Lần 1";
            }
            else if (selecttedLanthi == 2)
            {
                dataGridView1.Columns["DiemLan1"].HeaderText = "Điểm Lần 1";
                dataGridView1.Columns["DiemLan2"].HeaderText = "Điểm Lần 2";
            }

            // Cập nhật chế độ cho phép chỉnh sửa cột điểm phù hợp với lần thi
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                // Mặc định: không cho sửa
                column.ReadOnly = true;

                // Lần thi 1 → chỉ cho sửa cột "Diem"
                if (selecttedLanthi == 1 && column.Name == "Diem")
                {
                    column.ReadOnly = false;
                }

                // Lần thi 2 → chỉ cho sửa cột "DiemLan2"
                if (selecttedLanthi == 2 && column.Name == "DiemLan2")
                {
                    column.ReadOnly = false;
                }
            }
        }

        private void buttonLuu_Click(object sender, EventArgs e)
        {
            int selectedLanthi;
            if (!int.TryParse(comboBoxLanThi.Text, out selectedLanthi))
            {
                MessageBox.Show("Vui lòng chọn đúng lần thi.");
                return;
            }

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                if (selectedLanthi == 1)
                {
                    object diemValue = row.Cells["Diem"].Value;

                    if (diemValue != null && diemValue.ToString().Trim() != "")
                    {
                        try
                        {
                            string masv = row.Cells["MaSinhVien"].Value.ToString();
                            int idSinhVien = busSV.GetID(masv);

                            if (idSinhVien == -1)
                            {
                                MessageBox.Show($"Không tìm thấy sinh viên với mã {masv}");
                                continue;
                            }

                            int idMonHoc = Convert.ToInt32(comboBoxMonHoc.SelectedValue);
                            int diem = Convert.ToInt32(diemValue);

                            BangDiem d = new BangDiem
                            {
                                ID_SinhVien = idSinhVien,
                                Diem = diem,
                                ID_LanThi = selectedLanthi,
                                // ID_MonHoc = idMonHoc // Thêm nếu cần
                            };

                            BUS_BangDiem bus = new BUS_BangDiem();
                            bus.Insert(d);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi lưu điểm: " + ex.Message);
                        }
                    }
                }
            }

            MessageBox.Show("Lưu điểm thành công!");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
