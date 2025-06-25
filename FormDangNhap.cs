using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using DTO;

namespace QLBD
{
    public partial class FormDangNhap : Form
    {
        Modify modify = new Modify();
        public FormDangNhap()
        {
            InitializeComponent();
            modify = new Modify();
        }
        private SqlConnection GetSqlConnection()
        {
            return DTO.KetNoi.CreateConnection();

            // Replace with your actual connection string    
            //string connectionString = "Data Source=DieuLinh\\LINH;Initial Catalog=LTMT1_K14_BUITHIDIEULINH_CD220337_QuanLyDiemCNTT;Integrated Security=True";
            //return new SqlConnection(connectionString);
        }

       
        private void FormDangNhap_Load(object sender, EventArgs e)
        {

            // focus textbox  
            textBoxTenDN.Focus();
        }

        private void buttonDangNhap_Click(object sender, EventArgs e)
        {
            string Ten = textBoxTenDN.Text.Trim();
            string matKhau = textBoxMatKhau.Text.Trim();

            if (Ten == "")
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!");
                return;
            }
            if (matKhau == "")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!");
                return;
            }

            string query = "SELECT * FROM TaiKhoan WHERE Ten = @Ten AND MatKhau = @MatKhau";
            List<TaiKhoan> list = modify.TaiKhoan(query, Ten, matKhau);
            if (list.Count > 0)
            {
                // Gán tài khoản cho biến toàn cục  
                Global.Ten = Ten;

                // Lấy quyền từ CSDL  
                string quyenQuery = "SELECT Quyen FROM TaiKhoan WHERE Ten = @Ten";
                using (SqlConnection conn = GetSqlConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(quyenQuery, conn);
                    cmd.Parameters.AddWithValue("@Ten", Ten);
                    Global.Quyen = cmd.ExecuteScalar()?.ToString(); // Gán quyền  
                }

                ClassDangNhap.DangNhap = false;
                //MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();
                FormMDI mdi = new FormMDI();
                mdi.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Tên tài khoản hoặc mật khẩu không chính xác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel_QuenMatKhau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            FormQuenMatKhau f = new FormQuenMatKhau();
            f.Show();
        }
    }
}
