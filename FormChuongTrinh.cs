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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QLBD
{
    public partial class FormChuongTrinh : Form
    {
        public void RefreshData() => dataGridView1.ShowData(bus.Load());
        private void GetObject(Action<ChuongTrinh> callback)
        {
            callback(new ChuongTrinh {
                ID = current.ID,
                ID_NganhHoc = (int)comboBoxNganh.SelectedValue,
                ID_HocKy = (int)comboBoxKy.SelectedValue,
                ID_MonHoc = (int)comboBoxMon.SelectedValue,
            });
        }
        public FormChuongTrinh()
        {
            InitializeComponent();

            buttonThem.Click += (s, e) => {
                current = new ChuongTrinh { };
                GetObject(o => {
                    bus.Insert(o);
                    RefreshData();
                });
            };
            buttonSua.Click += (s, e) => {
                GetObject(o => {
                    bus.Update(o);
                    RefreshData();
                });
            };
            buttonXoa.Click += (s, e) => {
                GetObject(o => {
                    bus.Delete(o);
                    RefreshData();
                });
            };

            dataGridView1.Click += (s, e) => {
                try
                {
                    var r = dataGridView1.CurrentRow;
                    current = new ChuongTrinh {
                        ID = (int)Convert.ToInt32(r.Cells["ID"].Value)
                    };
                    comboBoxKy.SelectedValue = r.Cells["ID_HocKy"].Value;
                    comboBoxMon.SelectedValue = r.Cells["ID_MonHoc"].Value;
                    comboBoxNganh.SelectedValue = r.Cells["ID_NganhHoc"].Value;
                }
                catch
                {

                }
            };
        }
        ChuongTrinh current;
        BUS_ChuongTrinh bus = new BUS_ChuongTrinh();
        private void FormChuongTrinh_Load(object sender, EventArgs e)
        {

            comboBoxNganh.SelectedValueChanged += (s, ev) => {
                dataGridView1.ShowData(bus.LoadByNganhID(comboBoxNganh.SelectedValue));
            };
            comboBoxNganh.LoadData<DTO.NganhHoc>();
            comboBoxMon.LoadData<DTO.MonHoc>();
            comboBoxKy.LoadData<DTO.HocKy>();
        }

        private void comboBoxKy_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
