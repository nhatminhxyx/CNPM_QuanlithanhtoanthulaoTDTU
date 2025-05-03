using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GUI.Common;
namespace GUI
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            thanhToánToolStripMenuItem.Enabled = (Session.Role=="Admin");
            
        }

        private void đềTàiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Detai formDeTai = this.MdiChildren.OfType<Detai>().FirstOrDefault();
            if (formDeTai == null)
            {
                formDeTai = new Detai();
                formDeTai.MdiParent = this; // Gán Form Main làm MDI Parent
                formDeTai.WindowState = FormWindowState.Maximized;
                formDeTai.Show();
            }
            else
            {
                // Nếu đã mở, làm nổi bật form đó
                formDeTai.Activate();
            }
        }

        private void gIảngViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Giangvien formGiangvien = this.MdiChildren.OfType<Giangvien>().FirstOrDefault();
            if (formGiangvien == null)
            {
                formGiangvien = new Giangvien();
                formGiangvien.MdiParent = this;
                formGiangvien.WindowState = FormWindowState.Maximized;
                formGiangvien.Show();
            }
            else
            {
                formGiangvien.Activate();
            }
        }

        private void sinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sinhvien formSinhvien = this.MdiChildren.OfType<Sinhvien>().FirstOrDefault();
            if (formSinhvien == null)
            {
                formSinhvien = new Sinhvien();
                formSinhvien.MdiParent = this;
                formSinhvien.WindowState = FormWindowState.Maximized;
                formSinhvien.Show();
            }
            else
            {
                formSinhvien.Activate();
            }
        }

        private void đăngKíĐềTàiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DangKiDeTai formDkDeTai = this.MdiChildren.OfType<DangKiDeTai>().FirstOrDefault();
            if (formDkDeTai == null)
            {
                formDkDeTai = new DangKiDeTai();
                formDkDeTai.MdiParent = this;
                formDkDeTai.WindowState = FormWindowState.Maximized;
                formDkDeTai.Show();
            }
            else
            {
                formDkDeTai.Activate();
            }
        }

        private void thanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thanhtoan formThanhtoan = this.MdiChildren.OfType<Thanhtoan>().FirstOrDefault();
            if (formThanhtoan == null)
            {
                formThanhtoan = new Thanhtoan();
                formThanhtoan.MdiParent = this;
                formThanhtoan.WindowState = FormWindowState.Maximized;
                formThanhtoan.Show();
            }
            else
            {
                formThanhtoan.Activate();
            }
        }
    }
}
