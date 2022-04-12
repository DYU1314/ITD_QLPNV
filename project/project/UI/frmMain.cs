using ADO.DAO;
using ADO.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project.UI
{
    public partial class frmMain : Form
    {
        private static ACCOUNT _USER;

        public static ACCOUNT USER { get => _USER; set => _USER = value; }

        public frmMain()
        {
            InitializeComponent();
            LoadForm();
            //_USER = new ACCOUNT() { ID = 1, USERNAME = "admin", PASSWORK = "", ID_QUYEN = 1, ID_NHANVIEN = null };
        }

        private void LoadForm()
        {
            pnlInfo.Visible = false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (btnLogin.Text == "Đăng Nhập")
            {
                frmLogin f = new frmLogin();
                this.Opacity = 0.8;
                f.ShowDialog();
                this.Opacity = 0.96;
                _USER = USER;
                if (_USER != null)
                {
                    btnLogin.Text = "Đăng Xuất";
                    pnlInfo.Visible = true;
                    LoadInfo();
                }
                return;
            }

            if (btnLogin.Text == "Đăng Xuất")
            {
                btnLogin.Text = "Đăng Nhập";
                pnlInfo.Visible = false;
                USER = null;
                _USER = USER;
                return;
            }
        }

        private void LoadInfo()
        {
            NHAN_VIEN nv = NhanVienDAO.Instance.GetNhanVienByUser(_USER);
            txtUserName.Text = USER.USERNAME;
            txtEmployeeCode.Text = nv.MANV;
            txtFullName.Text = nv.HOTEN;
            txtPhone.Text = nv.SODIENTHOAI;
            txtEmail.Text = nv.EMAIL;
            txtAddress.Text = nv.DIACHI;
        }

        private void btnManage_Click(object sender, EventArgs e)
        {
            if (UserNull(_USER))
            {
                MessageBox.Show("Chưa đăng nhập tài khoản");
                return;
            }

            LEVEL_USER q = QuyenDAO.Instance.GetQuyenByUser(_USER);

            if (q.QUYEN == "ADMIN" || q.QUYEN == "QUẢN LÝ")
            {
                frmManage f = new frmManage(_USER);
                this.Opacity = 0.8;
                f.ShowDialog();
                this.Opacity = 0.96;
            }
            else
            {
                MessageBox.Show("Không có quyền truy cập");
                return;
            }

        }

        private bool UserNull(ACCOUNT user)
        {
            if (user == null) return true;
            return false;
        }

        private void btnChangePasswork_Click(object sender, EventArgs e)
        {
            frmChangePasswork f = new frmChangePasswork(_USER);
            this.Opacity = 0.8;
            f.ShowDialog();
            this.Opacity = 0.96;
        }
    }
}
