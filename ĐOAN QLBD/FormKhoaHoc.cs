using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;
namespace ĐOAN_QLBD
{
    public partial class FormKhoaHoc : Form
    {
        BUS_KhoaHoc buskhoa = new BUS_KhoaHoc();
        public FormKhoaHoc()
        {
            InitializeComponent();
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            KhoaHoc h = new KhoaHoc(textBoxTenKhoa.Text);
            buskhoa.Insert(h); 
            dataGridView1.DataSource = buskhoa.LoadKhoa();
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            KhoaHoc h = new KhoaHoc();
            h.TenKhoa = textBoxTenKhoa.Text;
            h.ID = slID;
            buskhoa.Update(h);
            dataGridView1.DataSource = buskhoa.LoadKhoa();
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            KhoaHoc h = new KhoaHoc(textBoxTenKhoa.Text);
            h.ID = slID;
            /*h.TenKhoa = textBoxTenKhoa.Text;*/
            buskhoa.Delete(h);
            dataGridView1.DataSource = buskhoa.LoadKhoa();
        }
        private int slID = -1;

        public string QuyenNguoiDung { get; internal set; }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            slID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value.ToString());
            textBoxTenKhoa.Text = dataGridView1.CurrentRow.Cells["TenKhoa"].Value.ToString(); ;
        }

        private void FormKhoaHoc_Load(object sender, EventArgs e)
        {
            if (QuyenNguoiDung != "Admin")
            {
                buttonThem.Enabled = false;
                buttonSua.Enabled = false;
                buttonXoa.Enabled = false;
            }
            dataGridView1.DataSource = buskhoa.LoadKhoa();
        }
    }
}
