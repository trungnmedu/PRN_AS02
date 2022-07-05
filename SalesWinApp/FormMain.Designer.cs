
namespace SalesWinApp
{
    partial class FormMain
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
            this.buttonMemberManagement = new System.Windows.Forms.Button();
            this.buttonProductManagement = new System.Windows.Forms.Button();
            this.buttonOrderManagement = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonMemberManagement
            // 
            this.buttonMemberManagement.Location = new System.Drawing.Point(48, 45);
            this.buttonMemberManagement.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonMemberManagement.Name = "buttonMemberManagement";
            this.buttonMemberManagement.Size = new System.Drawing.Size(144, 71);
            this.buttonMemberManagement.TabIndex = 1;
            this.buttonMemberManagement.Text = "&Member Management";
            this.buttonMemberManagement.UseVisualStyleBackColor = true;
            this.buttonMemberManagement.Click += new System.EventHandler(this.buttonMemberManagement_Click);
            // 
            // buttonProductManagement
            // 
            this.buttonProductManagement.Location = new System.Drawing.Point(233, 45);
            this.buttonProductManagement.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonProductManagement.Name = "buttonProductManagement";
            this.buttonProductManagement.Size = new System.Drawing.Size(144, 71);
            this.buttonProductManagement.TabIndex = 2;
            this.buttonProductManagement.Text = "&Product Management";
            this.buttonProductManagement.UseVisualStyleBackColor = true;
            this.buttonProductManagement.Click += new System.EventHandler(this.buttonProductManagement_Click);
            // 
            // buttonOrderManagement
            // 
            this.buttonOrderManagement.Location = new System.Drawing.Point(413, 45);
            this.buttonOrderManagement.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonOrderManagement.Name = "buttonOrderManagement";
            this.buttonOrderManagement.Size = new System.Drawing.Size(144, 71);
            this.buttonOrderManagement.TabIndex = 3;
            this.buttonOrderManagement.Text = "&Order Management";
            this.buttonOrderManagement.UseVisualStyleBackColor = true;
            this.buttonOrderManagement.Click += new System.EventHandler(this.buttonOrderManagement_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 157);
            this.Controls.Add(this.buttonOrderManagement);
            this.Controls.Add(this.buttonProductManagement);
            this.Controls.Add(this.buttonMemberManagement);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FStore Management";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonMemberManagement;
        private System.Windows.Forms.Button buttonProductManagement;
        private System.Windows.Forms.Button buttonOrderManagement;
    }
}