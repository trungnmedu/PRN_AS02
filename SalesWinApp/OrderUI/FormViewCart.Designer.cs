
using System.ComponentModel;
using System.Windows.Forms;

namespace SalesWinApp.OrderUI
{
    partial class FormViewCart
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
            this.dataGridViewCart = new System.Windows.Forms.DataGridView();
            this.lableProductName = new System.Windows.Forms.Label();
            this.textBoxProductName = new System.Windows.Forms.TextBox();
            this.lableQuantity = new System.Windows.Forms.Label();
            this.textBoxProductQuantity = new System.Windows.Forms.TextBox();
            this.lableProductPrice = new System.Windows.Forms.Label();
            this.lableTotal = new System.Windows.Forms.Label();
            this.textBoxProductPrice = new System.Windows.Forms.TextBox();
            this.textBoxProductTotal = new System.Windows.Forms.TextBox();
            this.buttonRemoveFromCart = new System.Windows.Forms.Button();
            this.lableOrderTotal = new System.Windows.Forms.Label();
            this.buttonCheckOut = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCart)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewCart
            // 
            this.dataGridViewCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCart.Location = new System.Drawing.Point(14, 247);
            this.dataGridViewCart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridViewCart.MultiSelect = false;
            this.dataGridViewCart.Name = "dataGridViewCart";
            this.dataGridViewCart.ReadOnly = true;
            this.dataGridViewCart.RowHeadersWidth = 51;
            this.dataGridViewCart.RowTemplate.Height = 25;
            this.dataGridViewCart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCart.Size = new System.Drawing.Size(1002, 304);
            this.dataGridViewCart.TabIndex = 0;
            this.dataGridViewCart.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCart_CellDoubleClick);
            // 
            // lableProductName
            // 
            this.lableProductName.AutoSize = true;
            this.lableProductName.Location = new System.Drawing.Point(24, 45);
            this.lableProductName.Name = "lableProductName";
            this.lableProductName.Size = new System.Drawing.Size(104, 20);
            this.lableProductName.TabIndex = 1;
            this.lableProductName.Text = "Product Name";
            // 
            // textBoxProductName
            // 
            this.textBoxProductName.Enabled = false;
            this.textBoxProductName.Location = new System.Drawing.Point(130, 41);
            this.textBoxProductName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxProductName.Name = "textBoxProductName";
            this.textBoxProductName.Size = new System.Drawing.Size(320, 27);
            this.textBoxProductName.TabIndex = 2;
            // 
            // lableQuantity
            // 
            this.lableQuantity.AutoSize = true;
            this.lableQuantity.Location = new System.Drawing.Point(24, 103);
            this.lableQuantity.Name = "lableQuantity";
            this.lableQuantity.Size = new System.Drawing.Size(65, 20);
            this.lableQuantity.TabIndex = 3;
            this.lableQuantity.Text = "Quantity";
            // 
            // textBoxProductQuantity
            // 
            this.textBoxProductQuantity.Enabled = false;
            this.textBoxProductQuantity.Location = new System.Drawing.Point(130, 99);
            this.textBoxProductQuantity.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxProductQuantity.Name = "textBoxProductQuantity";
            this.textBoxProductQuantity.Size = new System.Drawing.Size(320, 27);
            this.textBoxProductQuantity.TabIndex = 4;
            // 
            // lableProductPrice
            // 
            this.lableProductPrice.AutoSize = true;
            this.lableProductPrice.Location = new System.Drawing.Point(661, 48);
            this.lableProductPrice.Name = "lableProductPrice";
            this.lableProductPrice.Size = new System.Drawing.Size(41, 20);
            this.lableProductPrice.TabIndex = 5;
            this.lableProductPrice.Text = "Price";
            // 
            // lableTotal
            // 
            this.lableTotal.AutoSize = true;
            this.lableTotal.Location = new System.Drawing.Point(662, 109);
            this.lableTotal.Name = "lableTotal";
            this.lableTotal.Size = new System.Drawing.Size(42, 20);
            this.lableTotal.TabIndex = 6;
            this.lableTotal.Text = "Total";
            // 
            // textBoxProductPrice
            // 
            this.textBoxProductPrice.Enabled = false;
            this.textBoxProductPrice.Location = new System.Drawing.Point(734, 45);
            this.textBoxProductPrice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxProductPrice.Name = "textBoxProductPrice";
            this.textBoxProductPrice.Size = new System.Drawing.Size(282, 27);
            this.textBoxProductPrice.TabIndex = 7;
            // 
            // textBoxProductTotal
            // 
            this.textBoxProductTotal.Enabled = false;
            this.textBoxProductTotal.Location = new System.Drawing.Point(734, 106);
            this.textBoxProductTotal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxProductTotal.Name = "textBoxProductTotal";
            this.textBoxProductTotal.Size = new System.Drawing.Size(282, 27);
            this.textBoxProductTotal.TabIndex = 8;
            // 
            // buttonRemoveFromCart
            // 
            this.buttonRemoveFromCart.Location = new System.Drawing.Point(451, 195);
            this.buttonRemoveFromCart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonRemoveFromCart.Name = "buttonRemoveFromCart";
            this.buttonRemoveFromCart.Size = new System.Drawing.Size(135, 31);
            this.buttonRemoveFromCart.TabIndex = 9;
            this.buttonRemoveFromCart.Text = "&Remove From Cart";
            this.buttonRemoveFromCart.UseVisualStyleBackColor = true;
            this.buttonRemoveFromCart.Click += new System.EventHandler(this.btnRemoveFromCart_Click);
            // 
            // lableOrderTotal
            // 
            this.lableOrderTotal.AutoSize = true;
            this.lableOrderTotal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lableOrderTotal.Location = new System.Drawing.Point(14, 200);
            this.lableOrderTotal.Name = "lableOrderTotal";
            this.lableOrderTotal.Size = new System.Drawing.Size(96, 20);
            this.lableOrderTotal.TabIndex = 10;
            this.lableOrderTotal.Text = "Order Total: ";
            // 
            // buttonCheckOut
            // 
            this.buttonCheckOut.Location = new System.Drawing.Point(893, 200);
            this.buttonCheckOut.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonCheckOut.Name = "buttonCheckOut";
            this.buttonCheckOut.Size = new System.Drawing.Size(123, 31);
            this.buttonCheckOut.TabIndex = 11;
            this.buttonCheckOut.Text = "&Check Out";
            this.buttonCheckOut.UseVisualStyleBackColor = true;
            this.buttonCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);
            // 
            // FormViewCart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 565);
            this.Controls.Add(this.buttonCheckOut);
            this.Controls.Add(this.lableOrderTotal);
            this.Controls.Add(this.buttonRemoveFromCart);
            this.Controls.Add(this.textBoxProductTotal);
            this.Controls.Add(this.textBoxProductPrice);
            this.Controls.Add(this.lableTotal);
            this.Controls.Add(this.lableProductPrice);
            this.Controls.Add(this.textBoxProductQuantity);
            this.Controls.Add(this.lableQuantity);
            this.Controls.Add(this.textBoxProductName);
            this.Controls.Add(this.lableProductName);
            this.Controls.Add(this.dataGridViewCart);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormViewCart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "View Cart";
            this.Load += new System.EventHandler(this.frmViewCart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dataGridViewCart;
        private Label lableProductName;
        private Label lableQuantity;
        private TextBox textBoxProductQuantity;
        private Label lableProductPrice;
        private Label lableTotal;
        private TextBox textBoxProductPrice;
        private TextBox textBoxProductTotal;
        private Button buttonRemoveFromCart;
        private TextBox textBoxProductName;
        private Label lableOrderTotal;
        private Button buttonCheckOut;
    }
}