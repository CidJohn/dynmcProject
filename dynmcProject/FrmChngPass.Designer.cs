namespace dynmcProject
{
    partial class FrmChngPass
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
            this.txtOldPass = new System.Windows.Forms.TextBox();
            this.txtNewPass = new System.Windows.Forms.TextBox();
            this.txtConfirmPass = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.userName = new System.Windows.Forms.Label();
            this.userType = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.charMax8 = new System.Windows.Forms.Label();
            this.oneNum = new System.Windows.Forms.Label();
            this.oneUpCase = new System.Windows.Forms.Label();
            this.oneSimble = new System.Windows.Forms.Label();
            this.oneLowCase = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtOldPass
            // 
            this.txtOldPass.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOldPass.Location = new System.Drawing.Point(24, 180);
            this.txtOldPass.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtOldPass.Name = "txtOldPass";
            this.txtOldPass.Size = new System.Drawing.Size(325, 30);
            this.txtOldPass.TabIndex = 0;
            // 
            // txtNewPass
            // 
            this.txtNewPass.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewPass.Location = new System.Drawing.Point(24, 257);
            this.txtNewPass.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNewPass.Name = "txtNewPass";
            this.txtNewPass.Size = new System.Drawing.Size(325, 30);
            this.txtNewPass.TabIndex = 1;
            this.txtNewPass.TextChanged += new System.EventHandler(this.txtNewPass_TextChanged);
            // 
            // txtConfirmPass
            // 
            this.txtConfirmPass.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmPass.Location = new System.Drawing.Point(24, 351);
            this.txtConfirmPass.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtConfirmPass.Name = "txtConfirmPass";
            this.txtConfirmPass.Size = new System.Drawing.Size(325, 30);
            this.txtConfirmPass.TabIndex = 2;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(24, 412);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(139, 62);
            this.btnSubmit.TabIndex = 3;
            this.btnSubmit.Text = "&Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(220, 412);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(131, 62);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(471, 51);
            this.label1.TabIndex = 5;
            this.label1.Text = "CHANGE PASSWORD";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 143);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 22);
            this.label2.TabIndex = 6;
            this.label2.Text = "Old Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 230);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 22);
            this.label3.TabIndex = 7;
            this.label3.Text = "New Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(20, 324);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(158, 22);
            this.label4.TabIndex = 8;
            this.label4.Text = "Confirm Password";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(421, 91);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 22);
            this.label5.TabIndex = 9;
            this.label5.Text = "Username:";
            // 
            // userName
            // 
            this.userName.AutoSize = true;
            this.userName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userName.Location = new System.Drawing.Point(515, 91);
            this.userName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(51, 22);
            this.userName.TabIndex = 10;
            this.userName.Text = "name";
            // 
            // userType
            // 
            this.userType.AutoSize = true;
            this.userType.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userType.Location = new System.Drawing.Point(515, 127);
            this.userType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.userType.Name = "userType";
            this.userType.Size = new System.Drawing.Size(48, 22);
            this.userType.TabIndex = 12;
            this.userType.Text = " type";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(421, 127);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 22);
            this.label7.TabIndex = 11;
            this.label7.Text = "UserType:";
            // 
            // charMax8
            // 
            this.charMax8.AutoSize = true;
            this.charMax8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.charMax8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.charMax8.Location = new System.Drawing.Point(419, 180);
            this.charMax8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.charMax8.Name = "charMax8";
            this.charMax8.Size = new System.Drawing.Size(25, 23);
            this.charMax8.TabIndex = 13;
            this.charMax8.Text = "...";
            // 
            // oneNum
            // 
            this.oneNum.AutoSize = true;
            this.oneNum.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.oneNum.ForeColor = System.Drawing.SystemColors.ControlText;
            this.oneNum.Location = new System.Drawing.Point(419, 324);
            this.oneNum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.oneNum.Name = "oneNum";
            this.oneNum.Size = new System.Drawing.Size(25, 23);
            this.oneNum.TabIndex = 14;
            this.oneNum.Text = "...";
            // 
            // oneUpCase
            // 
            this.oneUpCase.AutoSize = true;
            this.oneUpCase.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.oneUpCase.ForeColor = System.Drawing.SystemColors.ControlText;
            this.oneUpCase.Location = new System.Drawing.Point(419, 223);
            this.oneUpCase.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.oneUpCase.Name = "oneUpCase";
            this.oneUpCase.Size = new System.Drawing.Size(25, 23);
            this.oneUpCase.TabIndex = 15;
            this.oneUpCase.Text = "...";
            // 
            // oneSimble
            // 
            this.oneSimble.AutoSize = true;
            this.oneSimble.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.oneSimble.ForeColor = System.Drawing.SystemColors.ControlText;
            this.oneSimble.Location = new System.Drawing.Point(419, 368);
            this.oneSimble.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.oneSimble.Name = "oneSimble";
            this.oneSimble.Size = new System.Drawing.Size(25, 23);
            this.oneSimble.TabIndex = 16;
            this.oneSimble.Text = "...";
            // 
            // oneLowCase
            // 
            this.oneLowCase.AutoSize = true;
            this.oneLowCase.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.oneLowCase.ForeColor = System.Drawing.SystemColors.ControlText;
            this.oneLowCase.Location = new System.Drawing.Point(419, 272);
            this.oneLowCase.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.oneLowCase.Name = "oneLowCase";
            this.oneLowCase.Size = new System.Drawing.Size(25, 23);
            this.oneLowCase.TabIndex = 17;
            this.oneLowCase.Text = "...";
            // 
            // FrmChngPass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1072, 501);
            this.Controls.Add(this.oneLowCase);
            this.Controls.Add(this.oneSimble);
            this.Controls.Add(this.oneUpCase);
            this.Controls.Add(this.oneNum);
            this.Controls.Add(this.charMax8);
            this.Controls.Add(this.userType);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.userName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtConfirmPass);
            this.Controls.Add(this.txtNewPass);
            this.Controls.Add(this.txtOldPass);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmChngPass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmChngPass";
            this.Load += new System.EventHandler(this.FrmChngPass_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtOldPass;
        private System.Windows.Forms.TextBox txtNewPass;
        private System.Windows.Forms.TextBox txtConfirmPass;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label userName;
        private System.Windows.Forms.Label userType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label charMax8;
        private System.Windows.Forms.Label oneNum;
        private System.Windows.Forms.Label oneUpCase;
        private System.Windows.Forms.Label oneSimble;
        private System.Windows.Forms.Label oneLowCase;
    }
}