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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace QLBD
{
    public partial class FormHinhTHuc : Form
    {
       
        public FormHinhTHuc()
        {
            InitializeComponent();
        }
        public string QuyenNguoiDung { get; internal set; }
        private void FormHinhTHuc_Load(object sender, EventArgs e)
        {
            if (QuyenNguoiDung == "User")
            {
                buttonThem.Enabled = true;
                buttonSua.Enabled = true;
                buttonXoa.Enabled = true;
            }
            BUS_HinhThuc busht = new BUS_HinhThuc();
            dataGridView1.DataSource = busht.Load();
        }
        
        private void buttonThem_Click(object sender, EventArgs e)
        {
            string selectedoption = "";
            if (radioButtonLT.Checked)
            {
                selectedoption = "Lý thuyết";
            }
            else if (radioButtonTH.Checked)
            {
                selectedoption = "Thực hành ";
            }
            if (string.IsNullOrEmpty(selectedoption))
            {
                MessageBox.Show("Vui lòng chọn một lựa chọn.");
                return;
            }

            HinhThuc h = new HinhThuc();
            h.Ten = selectedoption;
           /* h.ID_HocKy = ID;*/
            BUS_HinhThuc bus = new BUS_HinhThuc();
            string s = bus.Insert(h);
            /*LoadHinhthucbyHK(ID);*/
            MessageBox.Show(s);
        }
     /*   private void LoadHinhthucbyHK(int ID)
        {
            BUS_HinhThuc bus = new BUS_HinhThuc();
            *//*DataTable dt = bus.Getthucbyky(ID);*//*

            if (dt != null && dt.Rows.Count > 0)
            {
                // Kiểm tra nếu dữ liệu đã thay đổi
                if (dataGridView1.DataSource != dt)
                {
                    dataGridView1.DataSource = dt;
                }
            }
            else
            {
                MessageBox.Show("Không có hinh thuc nao  cho hoc ky  này.");
            }
        }
        private void comboBoxTenHK_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxHocKy.SelectedIndex >= 0) // Kiểm tra xem có lựa chọn hợp lệ không
            {
                int id = (int)comboBoxHocKy.SelectedValue;
                LoadHinhthucbyHK(id);
            }
        }*/
        private int selectedID = -1;
        private int Id_Hk = -1;
        private void buttonSua_Click(object sender, EventArgs e)
        {
            int ID = selectedID;
            string selectedoption = "";
            if (radioButtonLT.Checked)
            {
                selectedoption = "Lý thuyết";
            }
            else if (radioButtonTH.Checked)
            {
                selectedoption = "Thực hành ";
            }
            if (string.IsNullOrEmpty(selectedoption))
            {
                MessageBox.Show("Vui lòng chọn một lựa chọn.");
                return;
            }

            HinhThuc h = new HinhThuc();
            h.ID = ID;
            h.Ten = selectedoption;
           /* h.ID_HocKy = Id_Hk;*/
            BUS_HinhThuc bus = new BUS_HinhThuc();
            string s = bus.Update(h);
           /* LoadHinhthucbyHK(Id_Hk);*/
            MessageBox.Show(s);
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {

            int ID = selectedID;

            DialogResult d = MessageBox.Show($"Ban co chac chan mua xoa ?", "Xac nhan xoa", MessageBoxButtons.YesNo);
            if (d == DialogResult.No)
            {
                return;
            }

            HinhThuc h = new HinhThuc();
            h.ID = ID;

            BUS_HinhThuc bus = new BUS_HinhThuc();
            string s = bus.Delete(h);
           /* LoadHinhthucbyHK(ID_Hk);*/
            MessageBox.Show(s);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu người dùng nhấp vào một ô hợp lệ (không phải header hoặc dòng trống)
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                var selectedRow = dataGridView1.Rows[e.RowIndex];

                // Lấy giá trị ID
                selectedID = Convert.ToInt32(selectedRow.Cells["ID"].Value);
                //Lay ID_hocky
                // Lấy giá trị Hình thức
                string selectedHinhThuc = selectedRow.Cells["Ten"].Value?.ToString()?.Trim(); // Sử dụng ? để tránh NullReferenceException và Trim để loại bỏ khoảng trắng dư thừa

                // Kiểm tra nếu có giá trị "Hinhthuc"
                if (!string.IsNullOrEmpty(selectedHinhThuc))
                {
                    Console.WriteLine($"Selected Hình thức: {selectedHinhThuc}");

                    // Cập nhật trạng thái RadioButton
                    if (selectedHinhThuc.Equals("Lý thuyết", StringComparison.OrdinalIgnoreCase))
                    {
                        radioButtonLT.Checked = true;
                        radioButtonTH.Checked = false;
                    }
                    else if (selectedHinhThuc.Equals("Thực hành", StringComparison.OrdinalIgnoreCase))
                    {
                        radioButtonLT.Checked = true;
                        radioButtonTH.Checked = false;
                    }

                    else
                    {
                        // Xử lý trường hợp "Hinhthuc" không phải là "Lý thuyết" hay "Thực hành"
                        radioButtonLT.Checked = false;
                        radioButtonTH.Checked = false;
                    }
                }
            }

        }
    }
}
