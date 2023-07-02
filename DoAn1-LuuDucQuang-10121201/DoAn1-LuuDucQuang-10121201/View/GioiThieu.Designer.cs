
namespace DoAn1_LuuDucQuang_10121201.View
{
    partial class GioiThieu
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.login = new System.Windows.Forms.Button();
            this.regestry = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(632, 124);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(-8, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(637, 46);
            this.label2.TabIndex = 1;
            this.label2.Text = "mỹ phẩm cho cửa hàng mỹ phẩm";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(123, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(347, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ứng dụng quản lý";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DoAn1_LuuDucQuang_10121201.Properties.Resources.banner;
            this.pictureBox1.Location = new System.Drawing.Point(1, 130);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(632, 285);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // login
            // 
            this.login.Location = new System.Drawing.Point(95, 469);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(113, 44);
            this.login.TabIndex = 2;
            this.login.Text = "Đăng Nhập";
            this.login.UseVisualStyleBackColor = true;
            this.login.Click += new System.EventHandler(this.login_Click);
            // 
            // regestry
            // 
            this.regestry.Location = new System.Drawing.Point(250, 469);
            this.regestry.Name = "regestry";
            this.regestry.Size = new System.Drawing.Size(113, 44);
            this.regestry.TabIndex = 3;
            this.regestry.Text = "Đăng Ký";
            this.regestry.UseVisualStyleBackColor = true;
            this.regestry.Click += new System.EventHandler(this.regestry_Click);
            // 
            // exit
            // 
            this.exit.Location = new System.Drawing.Point(395, 469);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(122, 44);
            this.exit.TabIndex = 4;
            this.exit.Text = "Thoát";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // frmGioiThieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 569);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.regestry);
            this.Controls.Add(this.login);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Name = "frmGioiThieu";
            this.Text = "GioiThieu";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button login;
        private System.Windows.Forms.Button regestry;
        private System.Windows.Forms.Button exit;
    }
}