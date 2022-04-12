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
    public partial class frmStaff : Form
    {
        PHONG_BAN _PHONGBAN;
        CHUC_VU _CHUCVU;
        NHAN_VIEN _NHANVIEN;
        ACCOUNT _USER;

        private String _EVENT = null;

        public frmStaff(ACCOUNT user, PHONG_BAN pb, CHUC_VU cv, NHAN_VIEN nv, String e)
        {
            InitializeComponent();
            this._EVENT = e;
            this._PHONGBAN = pb;
            this._CHUCVU = cv;
            this._NHANVIEN = nv;
            this._USER = user;
            LoadForm();
        }

        private void LoadForm()
        {
            if (this._EVENT == "add")
            {
                txtStaffCode.Text = NhanVienDAO.Instance.GetCode();

                cboDepartment.DataSource = PhongBanDAO.Instance.GetListPhongBanCustoms();
                cboDepartment.DisplayMember = "TenPB";

                cboPosition.DataSource = ChucVuDAO.Instance.GetListChucVuCustoms();
                cboPosition.DisplayMember = "TenCV";

                return;
            }

            if (this._EVENT == "update")
            {
                txtStaffCode.Text = this._NHANVIEN.MANV;

                if (this._PHONGBAN == null)
                {
                    cboDepartment.DataSource = PhongBanDAO.Instance.GetListPhongBanCustoms();
                    cboDepartment.DisplayMember = "TenPB";
                }
                else
                {
                    cboDepartment.Text = this._PHONGBAN.TENPB;
                }

                if (this._CHUCVU == null)
                {
                    cboPosition.DataSource = ChucVuDAO.Instance.GetListChucVuCustoms();
                    cboPosition.DisplayMember = "TenCV";
                }
                else
                {
                    cboPosition.Text = this._CHUCVU.TENCV;
                }

                txtStaffCode.Text = this._NHANVIEN.MANV;
                txtFullName.Text = this._NHANVIEN.HOTEN;
                txtGioiTinh.Text = this._NHANVIEN.GIOITINH;
                txtPhone.Text = this._NHANVIEN.SODIENTHOAI;
                txtEmail.Text = this._NHANVIEN.EMAIL;
                txtAddress.Text = this._NHANVIEN.DIACHI;
                dtpNS.Value = this._NHANVIEN.NGAYSINH.Value;

                if (UserDAO.Instance.GetCountUserByNhanVien(this._NHANVIEN) == 0)
                    btnAdd.Visible = true;
                return;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (this._EVENT == "add")
            {
                if (NhanVienDAO.Instance.Add(
                    cboDepartment.Text,
                    cboPosition.Text,
                    txtStaffCode.Text,
                    txtFullName.Text,
                    txtGioiTinh.Text,
                    dtpNS.Value,
                    txtPhone.Text,
                    txtEmail.Text,
                    txtAddress.Text))
                {
                    var result = MessageBox.Show("Thêm thông tin tài khoản", "", MessageBoxButtons.OKCancel);
                    if (result == DialogResult.OK)
                    {
                        frmCreateUser f = new frmCreateUser(null, this._NHANVIEN, this._EVENT);
                        this.Opacity = 0;
                        f.ShowDialog();
                    }
                    this.Close();
                    return;
                }
                MessageBox.Show("Thêm không thành công");
                return;
            }

            if (this._EVENT == "update")
            {
                if (NhanVienDAO.Instance.Update(
                    this._PHONGBAN,
                    this._CHUCVU,
                    this._NHANVIEN,
                    cboDepartment.Text,
                    cboPosition.Text,
                    txtFullName.Text,
                    txtGioiTinh.Text,
                    dtpNS.Value,
                    txtPhone.Text,
                    txtEmail.Text,
                    txtAddress.Text))
                {
                    if (this._USER == null)
                    {
                        var result = MessageBox.Show("Thêm thông tin tài khoản", "", MessageBoxButtons.OKCancel);
                        if (result == DialogResult.OK)
                        {
                            this._EVENT = "add";
                            frmCreateUser f = new frmCreateUser(null, this._NHANVIEN, this._EVENT);
                            this.Opacity = 0;
                            f.ShowDialog();
                        }
                    }

                    else if(this._USER != null)
                    {
                        var result = MessageBox.Show("Cập nhật thông tin tài khoản", "", MessageBoxButtons.OKCancel);
                        if (result == DialogResult.OK)
                        {
                            this._EVENT = "update";
                            frmCreateUser f = new frmCreateUser(this._USER, this._NHANVIEN, this._EVENT);
                            this.Opacity = 0;
                            f.ShowDialog();
                        }
                    }

                    this.Close();
                    return;
                }
                MessageBox.Show("Cập nhật không thành công không thành công");
                return;
            }
        }

        private void cboDepartment_Click(object sender, EventArgs e)
        {
            cboDepartment.DataSource = PhongBanDAO.Instance.GetListPhongBanCustoms();
            cboDepartment.DisplayMember = "TenPB";
        }

        private void cboPosition_Click(object sender, EventArgs e)
        {
            cboPosition.DataSource = ChucVuDAO.Instance.GetListChucVuCustoms();
            cboPosition.DisplayMember = "TenCV";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this._EVENT = "add";
            frmCreateUser f = new frmCreateUser(null, this._NHANVIEN, this._EVENT);
            this.Opacity = 0;
            f.ShowDialog();
            this.Close();
        }
    }
}
