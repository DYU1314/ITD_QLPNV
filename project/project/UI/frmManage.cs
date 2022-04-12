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
    public partial class frmManage : Form
    {
        private ACCOUNT _USER;

        public ACCOUNT USER { get => _USER; set => _USER = value; }

        private String _EVENT = null;

        public frmManage(ACCOUNT user)
        {
            InitializeComponent();
            this._USER = user;
            LoadForm();
        }

        private void LoadForm()
        {
            VisibleControl(false);
        }

        private void VisibleControl(bool v)
        {
            dgvDepartment.Visible = v;
            dgvPosition.Visible = v;
            dgvStaff.Visible = v;

            txtSearch.Visible = v;
        }

        private void txtSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
        }

        private void LoadDataGridView(DataGridView dgv)
        {
            if (dgvDepartment.Visible == true)
            {
                dgv.DataSource = PhongBanDAO.Instance.GetListPhongBanCustoms();
                dgv.Columns["Id"].Visible = false;
                dgv.Columns["MaPB"].HeaderText = "Mã Phòng Ban";
                dgv.Columns["TenPB"].HeaderText = "Phòng Ban";
                return;
            }

            if (dgvPosition.Visible == true)
            {
                dgv.DataSource = ChucVuDAO.Instance.GetListChucVuCustoms();
                dgv.Columns["Id"].Visible = false;
                dgv.Columns["MaCV"].HeaderText = "Mã Chức Vụ";
                dgv.Columns["TenCV"].HeaderText = "Chức Vụ";
                return;
            }

            if (dgvStaff.Visible == true)
            {
                dgv.DataSource = NhanVienDAO.Instance.GetListNhanVienCustoms();
                dgv.Columns["Id"].Visible = false;
                dgv.Columns["TenPB"].HeaderText = "Phòng Ban";
                dgv.Columns["TenCV"].HeaderText = "Chức Vụ";
                dgv.Columns["UserName"].HeaderText = "Tài Khoản";
                dgv.Columns["MaNV"].HeaderText = "Mã Nhân Viên";
                dgv.Columns["TenNV"].HeaderText = "Họ Tên";
                dgv.Columns["GioiTinh"].HeaderText = "Giới Tính";
                dgv.Columns["NgaySinh"].HeaderText = "Ngày Sinh";
                dgv.Columns["SoDienThoai"].HeaderText = "Số Điện Thoại";
                dgv.Columns["DiaChi"].HeaderText = "Địa Chỉ";
            }
        }

        private void btnDepartment_Click(object sender, EventArgs e)
        {
            VisibleControl(false);
            dgvDepartment.Visible = true;
            LoadDataGridView(dgvDepartment);
        }


        private void btnPosition_Click(object sender, EventArgs e)
        {
            VisibleControl(false);
            dgvPosition.Visible = true;
            txtSearch.Visible = true;
            LoadDataGridView(dgvPosition);
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            VisibleControl(false);
            dgvStaff.Visible = true;
            txtSearch.Visible = true;
            LoadDataGridView(dgvStaff);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this._EVENT = "add";
            if (dgvDepartment.Visible == true)
            {
                frmDepartment f = new frmDepartment(null, this._EVENT);
                this.Opacity = 0.9;
                f.ShowDialog();
                LoadDataGridView(dgvDepartment);
                this.Opacity = 1;
                return;
            }

            if (dgvPosition.Visible == true)
            {
                frmPosition f = new frmPosition(null, this._EVENT);
                this.Opacity = 0.9;
                f.ShowDialog();
                LoadDataGridView(dgvPosition);
                this.Opacity = 1;
                return;
            }

            if (dgvStaff.Visible == true)
            {
                frmStaff f = new frmStaff(null, null, null, null, this._EVENT);
                this.Opacity = 0.9;
                f.ShowDialog();
                LoadDataGridView(dgvStaff);
                this.Opacity = 1;
                return;
            }

            MessageBox.Show("Chưa chọn bản nhập liệu");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            this._EVENT = "update";
            if (dgvDepartment.Visible == true)
            {
                PHONG_BAN p = new PHONG_BAN();

                if (dgvDepartment.Rows.Count > 0)
                {
                    if (dgvDepartment.SelectedCells[0].OwningRow.Cells["Id"].Value != null)
                    {
                        int id = (int)dgvDepartment.SelectedCells[0].OwningRow.Cells["Id"].Value;
                        p = PhongBanDAO.Instance.GetPhongBanById(id);
                    }
                }

                if (p == null)
                {
                    MessageBox.Show("Chưa chọn đối tượng cập nhật");
                    return;
                }

                frmDepartment f = new frmDepartment(p, this._EVENT);
                this.Opacity = 0.9;
                f.ShowDialog();
                LoadDataGridView(dgvDepartment);
                this.Opacity = 1;
                return;
            }

            if (dgvPosition.Visible == true)
            {
                CHUC_VU c = new CHUC_VU();

                if (dgvPosition.Rows.Count > 0)
                {
                    if (dgvPosition.SelectedCells[0].OwningRow.Cells["Id"].Value != null)
                    {
                        int id = (int)dgvPosition.SelectedCells[0].OwningRow.Cells["Id"].Value;
                        c = ChucVuDAO.Instance.GetChucVuById(id);
                    }
                }

                if (c == null)
                {
                    MessageBox.Show("Chưa chọn đối tượng cập nhật");
                    return;
                }

                frmPosition f = new frmPosition(c, this._EVENT);
                this.Opacity = 0.9;
                f.ShowDialog();
                LoadDataGridView(dgvPosition);
                this.Opacity = 1;
                return;
            }

            if (dgvStaff.Visible == true)
            {
                NHAN_VIEN nv = new NHAN_VIEN();
                PHONG_BAN pb = new PHONG_BAN();
                CHUC_VU cv = new CHUC_VU();
                ACCOUNT user = new ACCOUNT();

                if (dgvStaff.Rows.Count > 0)
                {
                    if (dgvStaff.SelectedCells[0].OwningRow.Cells["Id"].Value != null)
                    {
                        int id = (int)dgvStaff.SelectedCells[0].OwningRow.Cells["Id"].Value;
                        nv = NhanVienDAO.Instance.GetNhanVienById(id);
                    }

                    if (dgvStaff.SelectedCells[0].OwningRow.Cells["TenPB"].Value != null)
                    {
                        string tenpb = dgvStaff.SelectedCells[0].OwningRow.Cells["TenPB"].Value.ToString();
                        pb = PhongBanDAO.Instance.GetPhongBanByName(tenpb);
                    }
                    else
                    {
                        pb = null;
                    }

                    if (dgvStaff.SelectedCells[0].OwningRow.Cells["TenCV"].Value != null)
                    {
                        string tencv = dgvStaff.SelectedCells[0].OwningRow.Cells["TenCV"].Value.ToString();
                        cv = ChucVuDAO.Instance.GetChucVuByName(tencv);
                    }
                    else
                    {
                        cv = null;
                    }

                    if (dgvStaff.SelectedCells[0].OwningRow.Cells["UserName"].Value != null)
                    {
                        string username = dgvStaff.SelectedCells[0].OwningRow.Cells["UserName"].Value.ToString();
                        user = UserDAO.Instance.GetUserByUserName(username);
                    }
                    else
                    {
                        user = null;
                    }
                }

                if (nv == null)
                {
                    MessageBox.Show("Chưa chọn đối tượng cập nhật");
                    return;
                }

                frmStaff f = new frmStaff(user, pb, cv, nv, this._EVENT);
                this.Opacity = 0.9;
                f.ShowDialog();
                LoadDataGridView(dgvStaff);
                this.Opacity = 1;
                return;
            }

            MessageBox.Show("Chưa chọn bản nhập liệu");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvDepartment.Visible == true)
            {
                int id = 0;
                if (dgvDepartment.Rows.Count > 0)
                {
                    if (dgvDepartment.SelectedCells[0].OwningRow.Cells["Id"].Value != null)
                    {
                        id = (int)dgvDepartment.SelectedCells[0].OwningRow.Cells["Id"].Value;
                    }
                }

                if (id == 0)
                {
                    MessageBox.Show("Chưa chọn đối tượng để xóa");
                    return;
                }

                if (PhongBanDAO.Instance.Dalete(id))
                {
                    LoadDataGridView(dgvDepartment);
                    return;
                }
                MessageBox.Show("Xóa không thành công");
                return;
            }

            if (dgvPosition.Visible == true)
            {
                int id = 0;
                if (dgvPosition.Rows.Count > 0)
                {
                    if (dgvPosition.SelectedCells[0].OwningRow.Cells["Id"].Value != null)
                    {
                        id = (int)dgvPosition.SelectedCells[0].OwningRow.Cells["Id"].Value;
                    }
                }

                if (id == 0)
                {
                    MessageBox.Show("Chưa chọn đối tượng để xóa");
                    return;
                }

                if (ChucVuDAO.Instance.Dalete(id))
                {
                    LoadDataGridView(dgvPosition);
                    return;
                }
                MessageBox.Show("Xóa không thành công");
                return;
            }

            if (dgvStaff.Visible == true)
            {
                int id = 0;
                if (dgvStaff.Rows.Count > 0)
                {
                    if (dgvStaff.SelectedCells[0].OwningRow.Cells["Id"].Value != null)
                    {
                        id = (int)dgvStaff.SelectedCells[0].OwningRow.Cells["Id"].Value;
                    }
                }

                if (id == 0)
                {
                    MessageBox.Show("Chưa chọn đối tượng để xóa");
                    return;
                }

                if (NhanVienDAO.Instance.Dalete(id))
                {
                    LoadDataGridView(dgvStaff);
                    return;
                }
                MessageBox.Show("Xóa không thành công");
                return;
            }

            MessageBox.Show("Chưa chọn bản nhập liệu");
        }
    }
}
