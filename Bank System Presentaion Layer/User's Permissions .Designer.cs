namespace Bank_System_Presentaion_Layer
{
    partial class User_s_Permissions
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
            this.checkBoxAllPermissions = new System.Windows.Forms.CheckBox();
            this.checkBoxAddClients = new System.Windows.Forms.CheckBox();
            this.checkBoxUpdateClients = new System.Windows.Forms.CheckBox();
            this.checkBoxDeleteClients = new System.Windows.Forms.CheckBox();
            this.checkBoxManageUsers = new System.Windows.Forms.CheckBox();
            this.checkBoxTransactions = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkBoxAllPermissions
            // 
            this.checkBoxAllPermissions.AutoSize = true;
            this.checkBoxAllPermissions.Location = new System.Drawing.Point(24, 78);
            this.checkBoxAllPermissions.Name = "checkBoxAllPermissions";
            this.checkBoxAllPermissions.Size = new System.Drawing.Size(121, 20);
            this.checkBoxAllPermissions.TabIndex = 0;
            this.checkBoxAllPermissions.Text = "All Permissions";
            this.checkBoxAllPermissions.UseVisualStyleBackColor = true;
            this.checkBoxAllPermissions.CheckedChanged += new System.EventHandler(this.checkBoxAllPermissions_CheckedChanged);
            // 
            // checkBoxAddClients
            // 
            this.checkBoxAddClients.AutoSize = true;
            this.checkBoxAddClients.Location = new System.Drawing.Point(195, 78);
            this.checkBoxAddClients.Name = "checkBoxAddClients";
            this.checkBoxAddClients.Size = new System.Drawing.Size(97, 20);
            this.checkBoxAddClients.TabIndex = 1;
            this.checkBoxAddClients.Text = "Add Clients";
            this.checkBoxAddClients.UseVisualStyleBackColor = true;
            // 
            // checkBoxUpdateClients
            // 
            this.checkBoxUpdateClients.AutoSize = true;
            this.checkBoxUpdateClients.Location = new System.Drawing.Point(24, 142);
            this.checkBoxUpdateClients.Name = "checkBoxUpdateClients";
            this.checkBoxUpdateClients.Size = new System.Drawing.Size(117, 20);
            this.checkBoxUpdateClients.TabIndex = 2;
            this.checkBoxUpdateClients.Text = "Update Clients";
            this.checkBoxUpdateClients.UseVisualStyleBackColor = true;
            // 
            // checkBoxDeleteClients
            // 
            this.checkBoxDeleteClients.AutoSize = true;
            this.checkBoxDeleteClients.Location = new System.Drawing.Point(195, 142);
            this.checkBoxDeleteClients.Name = "checkBoxDeleteClients";
            this.checkBoxDeleteClients.Size = new System.Drawing.Size(112, 20);
            this.checkBoxDeleteClients.TabIndex = 3;
            this.checkBoxDeleteClients.Text = "Delete Clients";
            this.checkBoxDeleteClients.UseVisualStyleBackColor = true;
            // 
            // checkBoxManageUsers
            // 
            this.checkBoxManageUsers.AutoSize = true;
            this.checkBoxManageUsers.Location = new System.Drawing.Point(24, 196);
            this.checkBoxManageUsers.Name = "checkBoxManageUsers";
            this.checkBoxManageUsers.Size = new System.Drawing.Size(118, 20);
            this.checkBoxManageUsers.TabIndex = 4;
            this.checkBoxManageUsers.Text = "Manage Users";
            this.checkBoxManageUsers.UseVisualStyleBackColor = true;
            // 
            // checkBoxTransactions
            // 
            this.checkBoxTransactions.AutoSize = true;
            this.checkBoxTransactions.Location = new System.Drawing.Point(195, 196);
            this.checkBoxTransactions.Name = "checkBoxTransactions";
            this.checkBoxTransactions.Size = new System.Drawing.Size(107, 20);
            this.checkBoxTransactions.TabIndex = 5;
            this.checkBoxTransactions.Text = "Transactions";
            this.checkBoxTransactions.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightBlue;
            this.button1.Location = new System.Drawing.Point(63, 275);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(188, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Add Permissions";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // User_s_Permissions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.NavajoWhite;
            this.ClientSize = new System.Drawing.Size(321, 344);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBoxTransactions);
            this.Controls.Add(this.checkBoxManageUsers);
            this.Controls.Add(this.checkBoxDeleteClients);
            this.Controls.Add(this.checkBoxUpdateClients);
            this.Controls.Add(this.checkBoxAddClients);
            this.Controls.Add(this.checkBoxAllPermissions);
            this.Name = "User_s_Permissions";
            this.Text = "User_s_Permissions";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxAllPermissions;
        private System.Windows.Forms.CheckBox checkBoxAddClients;
        private System.Windows.Forms.CheckBox checkBoxUpdateClients;
        private System.Windows.Forms.CheckBox checkBoxDeleteClients;
        private System.Windows.Forms.CheckBox checkBoxManageUsers;
        private System.Windows.Forms.CheckBox checkBoxTransactions;
        private System.Windows.Forms.Button button1;
    }
}