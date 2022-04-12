namespace project.UI
{
    partial class frmListPermission
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvListPhep = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDuyet = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnTuChoi = new System.Windows.Forms.Button();
            this.btnChuaDuyet = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListPhep)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.dgvListPhep);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1032, 454);
            this.panel1.TabIndex = 0;
            // 
            // dgvListPhep
            // 
            this.dgvListPhep.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListPhep.Location = new System.Drawing.Point(3, 57);
            this.dgvListPhep.Name = "dgvListPhep";
            this.dgvListPhep.Size = new System.Drawing.Size(1026, 394);
            this.dgvListPhep.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(404, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Danh Sach Phép";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(3, 7);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(243, 20);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.Text = "-- Mã nhân viên";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel2.Controls.Add(this.txtSearch);
            this.panel2.Location = new System.Drawing.Point(12, 472);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(252, 35);
            this.panel2.TabIndex = 1;
            // 
            // btnDuyet
            // 
            this.btnDuyet.Location = new System.Drawing.Point(21, 5);
            this.btnDuyet.Name = "btnDuyet";
            this.btnDuyet.Size = new System.Drawing.Size(224, 23);
            this.btnDuyet.TabIndex = 0;
            this.btnDuyet.Text = "Danh Sách Chưa Duyệt";
            this.btnDuyet.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel3.Controls.Add(this.btnTuChoi);
            this.panel3.Controls.Add(this.btnDuyet);
            this.panel3.Controls.Add(this.btnChuaDuyet);
            this.panel3.Location = new System.Drawing.Point(270, 472);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(774, 35);
            this.panel3.TabIndex = 2;
            // 
            // btnTuChoi
            // 
            this.btnTuChoi.Location = new System.Drawing.Point(527, 5);
            this.btnTuChoi.Name = "btnTuChoi";
            this.btnTuChoi.Size = new System.Drawing.Size(224, 23);
            this.btnTuChoi.TabIndex = 2;
            this.btnTuChoi.Text = "Danh sách đã duyệt";
            this.btnTuChoi.UseVisualStyleBackColor = true;
            // 
            // btnChuaDuyet
            // 
            this.btnChuaDuyet.Location = new System.Drawing.Point(276, 5);
            this.btnChuaDuyet.Name = "btnChuaDuyet";
            this.btnChuaDuyet.Size = new System.Drawing.Size(224, 23);
            this.btnChuaDuyet.TabIndex = 1;
            this.btnChuaDuyet.Text = "Danh sách bị từ chố";
            this.btnChuaDuyet.UseVisualStyleBackColor = true;
            // 
            // frmListPermission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1056, 519);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmListPermission";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DANH SÁCH PHÉP";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListPhep)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvListPhep;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnDuyet;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnTuChoi;
        private System.Windows.Forms.Button btnChuaDuyet;
    }
}