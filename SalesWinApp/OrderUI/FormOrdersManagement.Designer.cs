
using System.ComponentModel;
using System.Windows.Forms;

namespace SalesWinApp.OrderUI
{
    partial class FormOrdersManagement
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.dgvOrderList = new System.Windows.Forms.DataGridView();
            this.lableOrderId = new System.Windows.Forms.Label();
            this.txtOrderID = new System.Windows.Forms.TextBox();
            this.lbOrderDate = new System.Windows.Forms.Label();
            this.txtOrderDate = new System.Windows.Forms.TextBox();
            this.lableOrderAmount = new System.Windows.Forms.Label();
            this.txtOrderTotal = new System.Windows.Forms.TextBox();
            this.groupBoxFilterOrders = new System.Windows.Forms.GroupBox();
            this.buttonFilterOrders = new System.Windows.Forms.Button();
            this.endDate = new System.Windows.Forms.DateTimePicker();
            this.lbEndDate = new System.Windows.Forms.Label();
            this.startDate = new System.Windows.Forms.DateTimePicker();
            this.lbStartDate = new System.Windows.Forms.Label();
            this.lbMember = new System.Windows.Forms.Label();
            this.txtMemberName = new System.Windows.Forms.TextBox();
            this.buttonExport = new System.Windows.Forms.Button();
            this.groupBoxOrderDetails = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderList)).BeginInit();
            this.groupBoxFilterOrders.SuspendLayout();
            this.groupBoxOrderDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvOrderList
            // 
            this.dgvOrderList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrderList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderList.Location = new System.Drawing.Point(20, 260);
            this.dgvOrderList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvOrderList.Name = "dgvOrderList";
            this.dgvOrderList.ReadOnly = true;
            this.dgvOrderList.RowHeadersWidth = 51;
            this.dgvOrderList.RowTemplate.Height = 25;
            this.dgvOrderList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrderList.Size = new System.Drawing.Size(1043, 336);
            this.dgvOrderList.TabIndex = 0;
            this.dgvOrderList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrderList_CellDoubleClick);
            // 
            // lableOrderId
            // 
            this.lableOrderId.AutoSize = true;
            this.lableOrderId.Location = new System.Drawing.Point(6, 46);
            this.lableOrderId.Name = "lableOrderId";
            this.lableOrderId.Size = new System.Drawing.Size(66, 20);
            this.lableOrderId.TabIndex = 1;
            this.lableOrderId.Text = "Order ID";
            // 
            // txtOrderID
            // 
            this.txtOrderID.Enabled = false;
            this.txtOrderID.Location = new System.Drawing.Point(79, 39);
            this.txtOrderID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtOrderID.Name = "txtOrderID";
            this.txtOrderID.Size = new System.Drawing.Size(209, 27);
            this.txtOrderID.TabIndex = 2;
            // 
            // lbOrderDate
            // 
            this.lbOrderDate.AutoSize = true;
            this.lbOrderDate.Location = new System.Drawing.Point(315, 46);
            this.lbOrderDate.Name = "lbOrderDate";
            this.lbOrderDate.Size = new System.Drawing.Size(83, 20);
            this.lbOrderDate.TabIndex = 3;
            this.lbOrderDate.Text = "Order Date";
            // 
            // txtOrderDate
            // 
            this.txtOrderDate.Enabled = false;
            this.txtOrderDate.Location = new System.Drawing.Point(404, 39);
            this.txtOrderDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtOrderDate.Name = "txtOrderDate";
            this.txtOrderDate.Size = new System.Drawing.Size(208, 27);
            this.txtOrderDate.TabIndex = 4;
            // 
            // lableOrderAmount
            // 
            this.lableOrderAmount.AutoSize = true;
            this.lableOrderAmount.Location = new System.Drawing.Point(6, 99);
            this.lableOrderAmount.Name = "lableOrderAmount";
            this.lableOrderAmount.Size = new System.Drawing.Size(42, 20);
            this.lableOrderAmount.TabIndex = 5;
            this.lableOrderAmount.Text = "Total";
            // 
            // txtOrderTotal
            // 
            this.txtOrderTotal.Enabled = false;
            this.txtOrderTotal.Location = new System.Drawing.Point(79, 99);
            this.txtOrderTotal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtOrderTotal.Name = "txtOrderTotal";
            this.txtOrderTotal.Size = new System.Drawing.Size(209, 27);
            this.txtOrderTotal.TabIndex = 6;
            // 
            // groupBoxFilterOrders
            // 
            this.groupBoxFilterOrders.Controls.Add(this.buttonFilterOrders);
            this.groupBoxFilterOrders.Controls.Add(this.endDate);
            this.groupBoxFilterOrders.Controls.Add(this.lbEndDate);
            this.groupBoxFilterOrders.Controls.Add(this.startDate);
            this.groupBoxFilterOrders.Controls.Add(this.lbStartDate);
            this.groupBoxFilterOrders.Location = new System.Drawing.Point(651, 51);
            this.groupBoxFilterOrders.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBoxFilterOrders.Name = "groupBoxFilterOrders";
            this.groupBoxFilterOrders.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBoxFilterOrders.Size = new System.Drawing.Size(404, 176);
            this.groupBoxFilterOrders.TabIndex = 7;
            this.groupBoxFilterOrders.TabStop = false;
            this.groupBoxFilterOrders.Text = "Filter Orders";
            // 
            // buttonFilterOrders
            // 
            this.buttonFilterOrders.Location = new System.Drawing.Point(276, 137);
            this.buttonFilterOrders.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonFilterOrders.Name = "buttonFilterOrders";
            this.buttonFilterOrders.Size = new System.Drawing.Size(106, 31);
            this.buttonFilterOrders.TabIndex = 4;
            this.buttonFilterOrders.Text = "&Filter Orders";
            this.buttonFilterOrders.UseVisualStyleBackColor = true;
            this.buttonFilterOrders.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // endDate
            // 
            this.endDate.Location = new System.Drawing.Point(88, 78);
            this.endDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.endDate.Name = "endDate";
            this.endDate.Size = new System.Drawing.Size(294, 27);
            this.endDate.TabIndex = 3;
            this.endDate.Value = new System.DateTime(2021, 6, 29, 17, 4, 20, 0);
            // 
            // lbEndDate
            // 
            this.lbEndDate.AutoSize = true;
            this.lbEndDate.Location = new System.Drawing.Point(12, 85);
            this.lbEndDate.Name = "lbEndDate";
            this.lbEndDate.Size = new System.Drawing.Size(70, 20);
            this.lbEndDate.TabIndex = 2;
            this.lbEndDate.Text = "End Date";
            // 
            // startDate
            // 
            this.startDate.Location = new System.Drawing.Point(88, 31);
            this.startDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.startDate.Name = "startDate";
            this.startDate.Size = new System.Drawing.Size(294, 27);
            this.startDate.TabIndex = 1;
            this.startDate.Value = new System.DateTime(2021, 6, 29, 17, 4, 20, 0);
            // 
            // lbStartDate
            // 
            this.lbStartDate.AutoSize = true;
            this.lbStartDate.Location = new System.Drawing.Point(6, 33);
            this.lbStartDate.Name = "lbStartDate";
            this.lbStartDate.Size = new System.Drawing.Size(76, 20);
            this.lbStartDate.TabIndex = 0;
            this.lbStartDate.Text = "Start Date";
            // 
            // lbMember
            // 
            this.lbMember.AutoSize = true;
            this.lbMember.Location = new System.Drawing.Point(315, 102);
            this.lbMember.Name = "lbMember";
            this.lbMember.Size = new System.Drawing.Size(65, 20);
            this.lbMember.TabIndex = 5;
            this.lbMember.Text = "Member";
            // 
            // txtMemberName
            // 
            this.txtMemberName.Enabled = false;
            this.txtMemberName.Location = new System.Drawing.Point(404, 92);
            this.txtMemberName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMemberName.Name = "txtMemberName";
            this.txtMemberName.Size = new System.Drawing.Size(208, 27);
            this.txtMemberName.TabIndex = 6;
            // 
            // buttonExport
            // 
            this.buttonExport.Location = new System.Drawing.Point(533, 604);
            this.buttonExport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(119, 30);
            this.buttonExport.TabIndex = 5;
            this.buttonExport.Text = "Export Data";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // groupBoxOrderDetails
            // 
            this.groupBoxOrderDetails.Controls.Add(this.txtOrderID);
            this.groupBoxOrderDetails.Controls.Add(this.lableOrderId);
            this.groupBoxOrderDetails.Controls.Add(this.lbOrderDate);
            this.groupBoxOrderDetails.Controls.Add(this.txtMemberName);
            this.groupBoxOrderDetails.Controls.Add(this.txtOrderDate);
            this.groupBoxOrderDetails.Controls.Add(this.lbMember);
            this.groupBoxOrderDetails.Controls.Add(this.lableOrderAmount);
            this.groupBoxOrderDetails.Controls.Add(this.txtOrderTotal);
            this.groupBoxOrderDetails.Location = new System.Drawing.Point(12, 51);
            this.groupBoxOrderDetails.Name = "groupBoxOrderDetails";
            this.groupBoxOrderDetails.Size = new System.Drawing.Size(632, 176);
            this.groupBoxOrderDetails.TabIndex = 8;
            this.groupBoxOrderDetails.TabStop = false;
            this.groupBoxOrderDetails.Text = "Order Details";
            // 
            // FormOrdersManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 652);
            this.Controls.Add(this.groupBoxOrderDetails);
            this.Controls.Add(this.buttonExport);
            this.Controls.Add(this.groupBoxFilterOrders);
            this.Controls.Add(this.dgvOrderList);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormOrdersManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Orders Management";
            this.Load += new System.EventHandler(this.frmOrdersManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderList)).EndInit();
            this.groupBoxFilterOrders.ResumeLayout(false);
            this.groupBoxFilterOrders.PerformLayout();
            this.groupBoxOrderDetails.ResumeLayout(false);
            this.groupBoxOrderDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dgvOrderList;
        private Label lableOrderId;
        private TextBox txtOrderID;
        private Label lbOrderDate;
        private TextBox txtOrderDate;
        private Label lableOrderAmount;
        private TextBox txtOrderTotal;
        private GroupBox groupBoxFilterOrders;
        private Button buttonFilterOrders;
        private DateTimePicker endDate;
        private Label lbEndDate;
        private DateTimePicker startDate;
        private Label lbStartDate;
        private Label lbMember;
        private TextBox txtMemberName;
        private Button buttonExport;
        private GroupBox groupBoxOrderDetails;
    }
}