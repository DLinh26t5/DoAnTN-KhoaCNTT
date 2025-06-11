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
    public partial class FormMDI : Form
    {
        public FormMDI()
        {
            InitializeComponent();
            ApplyPermissions();
        }
        private void ApplyPermissions()
        {
            this.khóaHọcToolStripMenuItem.Enabled = false;
            this.ngànhHọcToolStripMenuItem.Enabled = false;
            this.thôngTinToolStripMenuItem.Enabled = false; // Ví dụ: Menu "Thông tin cá nhân"
            this.thốngKêToolStripMenuItem.Enabled = false;  // Ví dụ: Menu "Thống kê"
            this.lớpToolStripMenuItem.Enabled = false;   // Ví dụ: Menu "Quản lý Lớp học"
            this.mônHọcToolStripMenuItem.Enabled = false;   // Ví dụ: Menu "Quản lý Môn học"
            this.điểmToolStripMenuItem.Enabled = false;     // Ví dụ: Menu "Quản lý Điểm" / "Nhập điểm"
            this.sinhViênToolStripMenuItem.Enabled = false; // Ví dụ: Menu "Quản lý Sinh viên"
            this.thốngKêToolStripMenuItem.Enabled = false;   // Ví dụ: Menu "Báo cáo"
            switch (ClassDangNhap.vaiTro)
            {
                case "Admin":
                    // Admin có quyền truy cập tất cả các chức năng quản lý
                    this.khóaHọcToolStripMenuItem.Enabled = true;
                    this.ngànhHọcToolStripMenuItem.Enabled = true;
                    this.thôngTinToolStripMenuItem.Enabled = true; // Admin cũng có thông tin
                    this.thốngKêToolStripMenuItem.Enabled = true;
                    this.lớpToolStripMenuItem.Enabled = true;
                    this.mônHọcToolStripMenuItem.Enabled = true;
                    this.điểmToolStripMenuItem.Enabled = true;
                    this.sinhViênToolStripMenuItem.Enabled = true;
                    this.thốngKêToolStripMenuItem.Enabled = true;
                    // ... bật tất cả các menu khác mà Admin có quyền
                    break;
                case "GiaoVien":
                    // Giáo viên có quyền xem các danh mục và quản lý điểm
                    this.khóaHọcToolStripMenuItem.Enabled = true; // Giáo viên có thể xem danh sách khóa học
                    this.ngànhHọcToolStripMenuItem.Enabled = true; // Giáo viên có thể xem danh sách ngành học
                    this.thốngKêToolStripMenuItem.Enabled = true; // Giả sử Giáo viên có thể xem thống kê cơ bản
                    this.thôngTinToolStripMenuItem.Enabled = true; // Giáo viên có thể xem thông tin cá nhân
                    this.lớpToolStripMenuItem.Enabled = true; // Giáo viên có thể xem lớp học
                    this.mônHọcToolStripMenuItem.Enabled = true; // Giáo viên có thể xem môn học
                    this.điểmToolStripMenuItem.Enabled = true; // QUAN TRỌNG: Giáo viên có thể nhập/quản lý điểm
                    this.sinhViênToolStripMenuItem.Enabled = true; // Giáo viên có thể xem danh sách sinh viên
                    this.thốngKêToolStripMenuItem.Enabled = true; // Tùy chọn: Giáo viên không có quyền báo cáo tổng hợp
                    // ... bật các menu khác mà Giáo viên có quyền
                    break;
                case "SinhVien":
                    // Sinh viên chỉ có quyền xem thông tin cá nhân và điểm của mình
                    this.khóaHọcToolStripMenuItem.Enabled = false; // Sinh viên không quản lý khóa học
                    this.ngànhHọcToolStripMenuItem.Enabled = false; // Sinh viên không quản lý ngành học
                    this.thôngTinToolStripMenuItem.Enabled = false; // QUAN TRỌNG: Sinh viên xem thông tin cá nhân
                    this.thốngKêToolStripMenuItem.Enabled = false;
                    this.lớpToolStripMenuItem.Enabled = false;
                    this.mônHọcToolStripMenuItem.Enabled = false;
                    this.điểmToolStripMenuItem.Enabled = false; // QUAN TRỌNG: Sinh viên có thể xem điểm của mình
                    this.sinhViênToolStripMenuItem.Enabled = false;
                    this.thốngKêToolStripMenuItem.Enabled = true;
                    // ... bật các menu khác mà Sinh viên có quyền
                    break;
                default:
                    // Vai trò không xác định hoặc không khớp, ẩn tất cả các menu chức năng
                    // Hoặc có thể hiển thị thông báo lỗi
                    MessageBox.Show("Quyền người dùng không xác định. Vui lòng liên hệ quản trị viên.", "Lỗi Phân quyền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }
        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!ClassDangNhap.dangnhap)
            {
                // Tắt tất cả khi chưa đăng nhập
                this.khóaHọcToolStripMenuItem.Enabled = false;
                this.ngànhHọcToolStripMenuItem.Enabled = false;
                // ...
            }
            else
            {
                switch (ClassDangNhap.vaiTro)
                {
                    case "Admin":
                        // Bật tất cả
                        this.khóaHọcToolStripMenuItem.Enabled = true;
                        this.ngànhHọcToolStripMenuItem.Enabled = true;
                        this.thôngTinToolStripMenuItem.Enabled = true;
                        this.thốngKêToolStripMenuItem.Enabled = true;
                        break;
                    case "GiaoVien":
                        // Chỉ bật những mục liên quan đến giảng viên
                        this.khóaHọcToolStripMenuItem.Enabled = true;
                        this.ngànhHọcToolStripMenuItem.Enabled = true;
                        this.thốngKêToolStripMenuItem.Enabled = true;
                        this.thôngTinToolStripMenuItem.Enabled = false;
                        break;
                    case "SinhVien":
                        // Sinh viên chỉ được xem thông tin cá nhân và điểm
                        this.khóaHọcToolStripMenuItem.Enabled = false;
                        this.ngànhHọcToolStripMenuItem.Enabled = false;
                        this.thôngTinToolStripMenuItem.Enabled = true;
                        this.thốngKêToolStripMenuItem.Enabled = false;
                        break;
                }
            }

        }

        private void FormMDI_Load(object sender, EventArgs e)
        {

            this.khóaHọcToolStripMenuItem.Enabled = ClassDangNhap.dangnhap;
            this.ngànhHọcToolStripMenuItem.Enabled = ClassDangNhap.dangnhap;
            this.hìnhThứcToolStripMenuItem.Enabled = ClassDangNhap.dangnhap;
            this.họcKỳToolStripMenuItem.Enabled = ClassDangNhap.dangnhap;
            this.lớpToolStripMenuItem.Enabled = ClassDangNhap.dangnhap;
            this.lầnThiToolStripMenuItem.Enabled = ClassDangNhap.dangnhap;
            this.mônHọcToolStripMenuItem.Enabled = ClassDangNhap.dangnhap;
            this.sinhViênToolStripMenuItem.Enabled = ClassDangNhap.dangnhap;
            this.điểmToolStripMenuItem.Enabled = ClassDangNhap.dangnhap;
        }

        private void thôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.khóaHọcToolStripMenuItem.Enabled = ClassDangNhap.dangnhap;
            this.ngànhHọcToolStripMenuItem.Enabled = ClassDangNhap.dangnhap;
            this.hìnhThứcToolStripMenuItem.Enabled = ClassDangNhap.dangnhap;
            this.họcKỳToolStripMenuItem.Enabled = ClassDangNhap.dangnhap;
            this.lớpToolStripMenuItem.Enabled = ClassDangNhap.dangnhap;
            this.lầnThiToolStripMenuItem.Enabled = ClassDangNhap.dangnhap;
            this.mônHọcToolStripMenuItem.Enabled = ClassDangNhap.dangnhap;
            this.sinhViênToolStripMenuItem.Enabled = ClassDangNhap.dangnhap;
            this.điểmToolStripMenuItem.Enabled = ClassDangNhap.dangnhap;
        }

        private void khóaHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormKhoaHoc f = new FormKhoaHoc();
            f.MdiParent = this;
            f.Show();
        }

        private void ngànhHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
           FormNganhHoc f = new FormNganhHoc();
            f.MdiParent = this;
            f.Show();
        }

        private void họcKỳToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHocKy f = new FormHocKy();
            f.MdiParent = this;
            f.Show();
        }

        private void hìnhThứcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHinhTHuc f = new FormHinhTHuc();
            f.MdiParent = this;
            f.Show();
        }

        private void mônHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMonHoc f = new FormMonHoc();
            f.MdiParent = this;
            f.Show();
        }

        private void lớpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLopHoc f = new FormLopHoc();
            f.MdiParent = this;
            f.Show();
        }

        private void sinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSinhVien f = new FormSinhVien();
            f.MdiParent = this;
            f.Show();
        }

        private void lầnThiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLanThi f = new FormLanThi();
            f.MdiParent = this;
            f.Show();
        }

        private void điểmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDiem f = new FormDiem();
            f.MdiParent = this;
            f.Show();
        }
    }

}
