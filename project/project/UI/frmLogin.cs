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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (UserDAO.Instance.Login(txtUserName.Text, txtPasswork.Text))
            {
                ACCOUNT user = UserDAO.Instance.GetUserByUserName(txtUserName.Text);
                frmMain.USER = user;
                this.Close();
            }
            else
            {
                MessageBox.Show("Đăng nhập không thành công");
                txtUserName.Clear();
                txtPasswork.Clear();
                txtUserName.Focus();
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
