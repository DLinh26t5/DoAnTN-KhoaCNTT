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
    public partial class FormNganhHoc : Form
    {
        BUS_NganhHoc busnganh = new BUS_NganhHoc();
        BUS_KhoaHoc buskhoa = new BUS_KhoaHoc();
        public FormNganhHoc()
        {
            InitializeComponent();
        }

        private void FormNganhHoc_Load(object sender, EventArgs e)
        {
            //đổ dữ liệu ra combobox
            comboBoxKhoa.DataSource = buskhoa.LoadKhoa();
            comboBoxKhoa.DisplayMember = "TenKhoa";
            comboBoxKhoa.ValueMember = "ID";// dòng này đúng ko c
            //đổ dữ liệu ra datagridview
            dataGridView1.DataSource = busnganh.LoadNganh();
            textBoxTenNganh.Clear();
            comboBoxKhoa.SelectedIndex = -1;
        }
       /* private int slID = -1;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }*/
        private void buttonThem_Click(object sender, EventArgs e)
        {
            NganhHoc n = new NganhHoc(0,textBoxTenNganh.Text,Convert.ToInt32(comboBoxKhoa.SelectedValue.ToString()));
            busnganh.Insert(n);
            dataGridView1.DataSource = busnganh.LoadNganh();
            // FormNganhHoc_Load(sender, e);
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            NganhHoc n = new NganhHoc(Convert.ToInt32(textBoxID.Text),textBoxTenNganh.Text,Convert.ToInt32(comboBoxKhoa.SelectedValue.ToString()));
            busnganh.Update(n);
            dataGridView1.DataSource = busnganh.LoadNganh();
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            NganhHoc n = new NganhHoc(Convert.ToInt32(textBoxID.Text),textBoxTenNganh.Text,Convert.ToInt32(comboBoxKhoa.SelectedValue.ToString()));
            busnganh.Delete(n);
            FormNganhHoc_Load(sender,e);
        }

        private void comboBoxKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
           /* if (comboBoxKhoa.SelectedValue != null && comboBoxKhoa.SelectedValue is int)
            {
                int tenKhoa = Convert.ToInt32(comboBoxKhoa.SelectedValue);
                NganhHoc nganh = new NganhHoc(0, "", tenKhoa);
                comboBoxNganh.DataSource = busNganh.GetNganhbyKhoa(nganh);
                comboBoxNganh.DisplayMember = "TenNganh"; // Hiển thị tên ngành
                comboBoxNganh.ValueMember = "ID";    // Lấy giá trị là mã ngành
                comboBoxNganh.SelectedIndex = -1;
            }*/
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBoxTenNganh.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBoxKhoa.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }
    }
}
