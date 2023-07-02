
namespace DoAn1_LuuDucQuang_10121201.View
{
    partial class QLTaiKhoan
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
            this.txtQLpass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtQLuser = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDeleteAccount = new System.Windows.Forms.Button();
            this.dgvqltk = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboQuyen = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvqltk)).BeginInit();
            this.SuspendLayout();
            // 
            // txtQLpass
            // 
            this.txtQLpass.Location = new System.Drawing.Point(149, 78);
            this.txtQLpass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtQLpass.Name = "txtQLpass";
            this.txtQLpass.Size = new System.Drawing.Size(222, 22);
            this.txtQLpass.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(43, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 18);
            this.label2.TabIndex = 15;
            this.label2.Text = "Mật Khẩu";
            // 
            // txtQLuser
            // 
            this.txtQLuser.Location = new System.Drawing.Point(149, 44);
            this.txtQLuser.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtQLuser.Name = "txtQLuser";
            this.txtQLuser.Size = new System.Drawing.Size(222, 22);
            this.txtQLuser.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(43, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 18);
            this.label1.TabIndex = 12;
            this.label1.Text = "Tài Khoản";
            // 
            // btnDeleteAccount
            // 
            this.btnDeleteAccount.BackColor = System.Drawing.Color.Tomato;
            this.btnDeleteAccount.Enabled = false;
            this.btnDeleteAccount.FlatAppearance.BorderSize = 0;
            this.btnDeleteAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteAccount.Image = global::DoAn1_LuuDucQuang_10121201.Properties.Resources.delete;
            this.btnDeleteAccount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteAccount.Location = new System.Drawing.Point(349, 158);
            this.btnDeleteAccount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDeleteAccount.Name = "btnDeleteAccount";
            this.btnDeleteAccount.Size = new System.Drawing.Size(83, 35);
            this.btnDeleteAccount.TabIndex = 7;
            this.btnDeleteAccount.Text = "Xoá";
            this.btnDeleteAccount.UseVisualStyleBackColor = false;
            this.btnDeleteAccount.Click += new System.EventHandler(this.btnDeleteAccount_Click);
            // 
            // dgvqltk
            // 
            this.dgvqltk.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvqltk.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvqltk.Location = new System.Drawing.Point(455, 44);
            this.dgvqltk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvqltk.Name = "dgvqltk";
            this.dgvqltk.RowHeadersWidth = 51;
            this.dgvqltk.RowTemplate.Height = 24;
            this.dgvqltk.Size = new System.Drawing.Size(480, 388);
            this.dgvqltk.TabIndex = 9;
            this.dgvqltk.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvqltk_CellClick);
            this.dgvqltk.SelectionChanged += new System.EventHandler(this.dgvqltk_SelectionChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Image = global::DoAn1_LuuDucQuang_10121201.Properties.Resources.add;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(125, 158);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(85, 35);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.Goldenrod;
            this.btnEdit.Enabled = false;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Image = global::DoAn1_LuuDucQuang_10121201.Properties.Resources.edit;
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(234, 158);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(92, 35);
            this.btnEdit.TabIndex = 6;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(43, 111);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 18);
            this.label4.TabIndex = 19;
            this.label4.Text = "Quyền";
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.LimeGreen;
            this.btnNew.FlatAppearance.BorderSize = 0;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = global::DoAn1_LuuDucQuang_10121201.Properties.Resources._new;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(7, 158);
            this.btnNew.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(111, 35);
            this.btnNew.TabIndex = 4;
            this.btnNew.Text = "Làm mới";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(693, 10);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(241, 23);
            this.txtSearch.TabIndex = 8;
            this.txtSearch.Text = "Nhập tài khoản muốn tìm";
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(612, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 17);
            this.label3.TabIndex = 22;
            this.label3.Text = "Tìm kiếm";
            // 
            // cboQuyen
            // 
            this.cboQuyen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboQuyen.FormattingEnabled = true;
            this.cboQuyen.ItemHeight = 16;
            this.cboQuyen.Location = new System.Drawing.Point(149, 112);
            this.cboQuyen.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cboQuyen.Name = "cboQuyen";
            this.cboQuyen.Size = new System.Drawing.Size(222, 24);
            this.cboQuyen.TabIndex = 24;
            this.cboQuyen.SelectedIndexChanged += new System.EventHandler(this.cboQuyen_SelectedIndexChanged);
            // 
            // QLTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(948, 443);
            this.Controls.Add(this.cboQuyen);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtQLpass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtQLuser);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDeleteAccount);
            this.Controls.Add(this.dgvqltk);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "QLTaiKhoan";
            this.Text = "QLTaiKhoan";
            this.Load += new System.EventHandler(this.QLTaiKhoan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvqltk)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtQLpass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtQLuser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDeleteAccount;
        private System.Windows.Forms.DataGridView dgvqltk;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboQuyen;
    }
}