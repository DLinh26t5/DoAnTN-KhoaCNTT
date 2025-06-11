label4.Text = Global.TenDangNhap + Environment.NewLine +
                  " --" + Global.Quyen + "--";

    if (Global.Quyen == "Admin")
    {
        label4.ForeColor = Color.DarkBlue;
        menuStrip1.Enabled = true;
        btnQuanLyNguoiDung.Visible = true; // Admin thấy
    }
    else if (Global.Quyen == "Giáo viên")
    {
        label4.ForeColor = Color.Green;
        menuStrip1.Enabled = true;
        btnQuanLyNguoiDung.Visible = false; // Giáo viên không thấy nút quản lý người dùng
    }
    else
    {
        label4.ForeColor = Color.Black;
        menuStrip1.Enabled = true;
        btnQuanLyNguoiDung.Visible = false; // Mặc định cũng không cho
    }
