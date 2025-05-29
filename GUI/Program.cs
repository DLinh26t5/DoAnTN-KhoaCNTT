using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            FormDangNhap FormDangNhap = new FormDangNhap();

            if (FormDangNhap.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new FormMDI(FormDangNhap.tenDangNhap));
            }
        }
    } }
