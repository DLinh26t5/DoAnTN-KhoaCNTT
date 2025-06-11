using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;

namespace QLBD
{
    public partial class FormDangNhap : Form
    {
        public FormDangNhap()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBoxTenDN.Text.Trim(); // Giả định tên textbox là textBoxUsername
            string password = textBoxMatKhau.Text.Trim(); // Giả định tên textbox là textBoxPassword

            // Biến để lưu vai trò của người dùng sau khi xác thực
            string quyenNguoiDung = null;
            if (username == "admin" && password == "123456")
            {
                quyenNguoiDung = "Admin";
            }


            else if (username == "GV123456" && password == "123456")
            {
                quyenNguoiDung = "GiaoVien";
            }
            else if (username == "GV147852" && password == "123456")
            {
                quyenNguoiDung = "GiaoVien";
            }


            else if (username == "CD220337" && password == "123456")
            {
                quyenNguoiDung = "SinhVien";
            }

            // **************************************************************************
            
            if (!string.IsNullOrEmpty(quyenNguoiDung)) // Nếu xác thực thành công và có quyền
            {
                // GÁN VAI TRÒ VÀO LỚP TĨNH ClassDangNhap
                ClassDangNhap.vaiTro = quyenNguoiDung;

                this.Hide(); // Ẩn Form đăng nhập hiện tại

                // Tạo và hiển thị Form MDI.
                // Constructor mặc định của FormMDI sẽ gọi ApplyPermissions() và dựa vào ClassDangNhap.vaiTro
                FormMDI mainForm = new FormMDI();
                mainForm.Show();

                // Tùy chọn: Đóng Form đăng nhập khi Form MDI được đóng
                mainForm.FormClosed += (s, args) => this.Close();
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu.", "Lỗi Đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }

       
    
}
