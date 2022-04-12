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
    public partial class frmDepartment : Form
    {
        private PHONG_BAN _PHONGBAN;

        private String _EVENT = null;

        public frmDepartment(PHONG_BAN p, String e)
        {
            InitializeComponent();
            this._EVENT = e;
            this._PHONGBAN = p;
            LoadForm();
        }

        private void LoadForm()
        {
            if (this._EVENT == "add")
            {
                txtDepartmentCode.Text = PhongBanDAO.Instance.GetCode();
                return;
            }

            if(this._EVENT == "update")
            {
                txtDepartmentCode.Text = this._PHONGBAN.MAPB;
                txtDepartmentName.Text = this._PHONGBAN.TENPB;
                return;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this._EVENT == "add")
            {
                if (PhongBanDAO.Instance.Add(txtDepartmentCode.Text, txtDepartmentName.Text))
                {
                    this.Close();
                    return;
                }
                MessageBox.Show("Thêm không thành công");
                txtDepartmentName.Clear();
                txtDepartmentName.Focus();
                return;
            }

            if (this._EVENT == "update")
            {
                if (PhongBanDAO.Instance.Update(this._PHONGBAN, txtDepartmentName.Text))
                {
                    this.Close();
                    return;
                }
                MessageBox.Show("Cập nhật không thành công");
                txtDepartmentName.Clear();
                txtDepartmentName.Focus();
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
