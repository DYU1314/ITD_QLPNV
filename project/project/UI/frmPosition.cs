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
    public partial class frmPosition : Form
    {
        private CHUC_VU _CHUCVU;

        private String _EVENT = null;

        public frmPosition(CHUC_VU c, String e)
        {
            InitializeComponent();
            this._CHUCVU = c;
            this._EVENT = e;
            LoadForm();
        }

        private void LoadForm()
        {
            if(this._EVENT == "add")
            {
                txtPositionCode.Text = ChucVuDAO.Instance.GetCode();
                return;
            }
            if(this._EVENT == "update")
            {
                txtPositionCode.Text = this._CHUCVU.MACV;
                txtPositionName.Text = this._CHUCVU.TENCV;
                return;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(this._EVENT == "add")
            {
                if (ChucVuDAO.Instance.Add(txtPositionCode.Text, txtPositionName.Text))
                {
                    this.Close();
                    return;
                }
                MessageBox.Show("Thêm không thành công");
                txtPositionName.Clear();
                txtPositionName.Focus();
                return;
            }

            if (this._EVENT == "update")
            {
                if (ChucVuDAO.Instance.Update(this._CHUCVU, txtPositionName.Text))
                {
                    this.Close();
                    return;
                }
                MessageBox.Show("Cập nhật không thành công");
                txtPositionName.Clear();
                txtPositionName.Focus();
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
