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
    public partial class frmChangePasswork : Form
    {
        private ACCOUNT _USER;
        public frmChangePasswork(ACCOUNT user)
        {
            InitializeComponent();
            this._USER = user;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (UserDAO.Instance.ChangePass(
                this._USER,
                txtPassOld.Text,
                txtPassNew.Text,
                txtPassRepeat.Text
                ))
                this.Close();
            else
            {
                MessageBox.Show("Cập nhật không thành công");
                txtPassOld.Clear();
                txtPassNew.Clear();
                txtPassRepeat.Clear();
                txtPassOld.Focus();
            }
        }
    }
}
