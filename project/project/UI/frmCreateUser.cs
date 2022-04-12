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
    public partial class frmCreateUser : Form
    {
        private NHAN_VIEN _NHANVIEN;
        private ACCOUNT _USER;
        private String _EVENT;
        public frmCreateUser(ACCOUNT user, NHAN_VIEN nv, String e)
        {
            InitializeComponent();
            this._NHANVIEN = nv;
            this._EVENT = e;
            this._USER = user;
            LoadForm();
        }

        private void LoadForm()
        {
            if (this._EVENT == "add")
            {
                cboQuyen.DataSource = QuyenDAO.Instance.GetListUser();
                cboQuyen.DisplayMember = "QUYEN";
                return;
            }

            if (this._EVENT == "update")
            {
                LEVEL_USER quyen = QuyenDAO.Instance.GetQuyenByUser(this._USER);
                cboQuyen.Text = quyen.QUYEN;
                txtUserName.Text = this._USER.USERNAME;
                txtUserName.Enabled = false;
                return;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (this._EVENT == "add")
            {
                if (UserDAO.Instance.Add(
                    this._NHANVIEN,
                    cboQuyen.Text,
                    txtUserName.Text,
                    txtPasswork.Text,
                    txtRepeat.Text
                    ))
                    this.Close();
                else
                {
                    MessageBox.Show("Thêm không thành công");
                    return;
                }
            }

            if(this._EVENT == "update")
            {
                if (UserDAO.Instance.Update(
                    this._USER,
                    cboQuyen.Text,
                    txtPasswork.Text,
                    txtRepeat.Text
                    ))
                    this.Close();
                else
                {
                    MessageBox.Show("Cập nhật không thành công");
                    return;
                }
            }
        }

        private void cboQuyen_Click(object sender, EventArgs e)
        {
            cboQuyen.DataSource = QuyenDAO.Instance.GetListUser();
            cboQuyen.DisplayMember = "QUYEN";
            return;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
