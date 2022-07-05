
namespace SalesWinApp.ProductUI
{
    partial class FormProductsManagement
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
            this.groupBoxFilter = new System.Windows.Forms.GroupBox();
            this.buttonFilter = new System.Windows.Forms.Button();
            this.textBoxFilterTo = new System.Windows.Forms.TextBox();
            this.lbTo = new System.Windows.Forms.Label();
            this.textBoxFilterFrom = new System.Windows.Forms.TextBox();
            this.lbFrom = new System.Windows.Forms.Label();
            this.radioFiilterByUnitsInStock = new System.Windows.Forms.RadioButton();
            this.radioFilterByUnitPrice = new System.Windows.Forms.RadioButton();
            this.groupBoxSearch = new System.Windows.Forms.GroupBox();
            this.buttonClearSearch = new System.Windows.Forms.Button();
            this.radioByName = new System.Windows.Forms.RadioButton();
            this.radioByID = new System.Windows.Forms.RadioButton();
            this.textBoxSearchKeyword = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lableSearchProduct = new System.Windows.Forms.Label();
            this.dataGridViewProductList = new System.Windows.Forms.DataGridView();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonNew = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.lableUnitsInStock = new System.Windows.Forms.Label();
            this.lableUnitPrice = new System.Windows.Forms.Label();
            this.lableWeight = new System.Windows.Forms.Label();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.lableCategory = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.lableMemberName = new System.Windows.Forms.Label();
            this.txtProductID = new System.Windows.Forms.TextBox();
            this.lableProductID = new System.Windows.Forms.Label();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.txtUnitPrice = new System.Windows.Forms.TextBox();
            this.txtUnitsInStock = new System.Windows.Forms.TextBox();
            this.groupBoxProductDetails = new System.Windows.Forms.GroupBox();
            this.buttonViewCart = new System.Windows.Forms.Button();
            this.groupBoxFilter.SuspendLayout();
            this.groupBoxSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProductList)).BeginInit();
            this.groupBoxProductDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxFilter
            // 
            this.groupBoxFilter.Controls.Add(this.buttonFilter);
            this.groupBoxFilter.Controls.Add(this.textBoxFilterTo);
            this.groupBoxFilter.Controls.Add(this.lbTo);
            this.groupBoxFilter.Controls.Add(this.textBoxFilterFrom);
            this.groupBoxFilter.Controls.Add(this.lbFrom);
            this.groupBoxFilter.Controls.Add(this.radioFiilterByUnitsInStock);
            this.groupBoxFilter.Controls.Add(this.radioFilterByUnitPrice);
            this.groupBoxFilter.Location = new System.Drawing.Point(579, 34);
            this.groupBoxFilter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBoxFilter.Name = "groupBoxFilter";
            this.groupBoxFilter.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBoxFilter.Size = new System.Drawing.Size(512, 119);
            this.groupBoxFilter.TabIndex = 43;
            this.groupBoxFilter.TabStop = false;
            this.groupBoxFilter.Text = "Filter";
            // 
            // buttonFilter
            // 
            this.buttonFilter.Location = new System.Drawing.Point(382, 73);
            this.buttonFilter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonFilter.Name = "buttonFilter";
            this.buttonFilter.Size = new System.Drawing.Size(91, 31);
            this.buttonFilter.TabIndex = 18;
            this.buttonFilter.Text = "&Filter";
            this.buttonFilter.UseVisualStyleBackColor = true;
            this.buttonFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // textBoxFilterTo
            // 
            this.textBoxFilterTo.Location = new System.Drawing.Point(297, 26);
            this.textBoxFilterTo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxFilterTo.Name = "textBoxFilterTo";
            this.textBoxFilterTo.Size = new System.Drawing.Size(199, 27);
            this.textBoxFilterTo.TabIndex = 15;
            // 
            // lbTo
            // 
            this.lbTo.AutoSize = true;
            this.lbTo.Location = new System.Drawing.Point(266, 32);
            this.lbTo.Name = "lbTo";
            this.lbTo.Size = new System.Drawing.Size(25, 20);
            this.lbTo.TabIndex = 4;
            this.lbTo.Text = "To";
            // 
            // textBoxFilterFrom
            // 
            this.textBoxFilterFrom.Location = new System.Drawing.Point(55, 25);
            this.textBoxFilterFrom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxFilterFrom.Name = "textBoxFilterFrom";
            this.textBoxFilterFrom.Size = new System.Drawing.Size(197, 27);
            this.textBoxFilterFrom.TabIndex = 14;
            // 
            // lbFrom
            // 
            this.lbFrom.AutoSize = true;
            this.lbFrom.Location = new System.Drawing.Point(6, 33);
            this.lbFrom.Name = "lbFrom";
            this.lbFrom.Size = new System.Drawing.Size(43, 20);
            this.lbFrom.TabIndex = 2;
            this.lbFrom.Text = "From";
            // 
            // radioFiilterByUnitsInStock
            // 
            this.radioFiilterByUnitsInStock.AutoSize = true;
            this.radioFiilterByUnitsInStock.Location = new System.Drawing.Point(191, 80);
            this.radioFiilterByUnitsInStock.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radioFiilterByUnitsInStock.Name = "radioFiilterByUnitsInStock";
            this.radioFiilterByUnitsInStock.Size = new System.Drawing.Size(119, 24);
            this.radioFiilterByUnitsInStock.TabIndex = 17;
            this.radioFiilterByUnitsInStock.Text = "Units In Stock";
            this.radioFiilterByUnitsInStock.UseVisualStyleBackColor = true;
            // 
            // radioFilterByUnitPrice
            // 
            this.radioFilterByUnitPrice.AutoSize = true;
            this.radioFilterByUnitPrice.Checked = true;
            this.radioFilterByUnitPrice.Location = new System.Drawing.Point(55, 80);
            this.radioFilterByUnitPrice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radioFilterByUnitPrice.Name = "radioFilterByUnitPrice";
            this.radioFilterByUnitPrice.Size = new System.Drawing.Size(93, 24);
            this.radioFilterByUnitPrice.TabIndex = 16;
            this.radioFilterByUnitPrice.TabStop = true;
            this.radioFilterByUnitPrice.Text = "Unit Price";
            this.radioFilterByUnitPrice.UseVisualStyleBackColor = true;
            // 
            // groupBoxSearch
            // 
            this.groupBoxSearch.Controls.Add(this.buttonClearSearch);
            this.groupBoxSearch.Controls.Add(this.radioByName);
            this.groupBoxSearch.Controls.Add(this.radioByID);
            this.groupBoxSearch.Controls.Add(this.textBoxSearchKeyword);
            this.groupBoxSearch.Controls.Add(this.btnSearch);
            this.groupBoxSearch.Controls.Add(this.lableSearchProduct);
            this.groupBoxSearch.Location = new System.Drawing.Point(19, 34);
            this.groupBoxSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBoxSearch.Name = "groupBoxSearch";
            this.groupBoxSearch.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBoxSearch.Size = new System.Drawing.Size(527, 119);
            this.groupBoxSearch.TabIndex = 42;
            this.groupBoxSearch.TabStop = false;
            this.groupBoxSearch.Text = "Search";
            // 
            // buttonClearSearch
            // 
            this.buttonClearSearch.Location = new System.Drawing.Point(297, 76);
            this.buttonClearSearch.Name = "buttonClearSearch";
            this.buttonClearSearch.Size = new System.Drawing.Size(94, 29);
            this.buttonClearSearch.TabIndex = 17;
            this.buttonClearSearch.Text = "Clear";
            this.buttonClearSearch.UseVisualStyleBackColor = true;
            this.buttonClearSearch.Click += new System.EventHandler(this.buttonClearSearch_Click);
            // 
            // radioByName
            // 
            this.radioByName.AutoSize = true;
            this.radioByName.Checked = true;
            this.radioByName.Location = new System.Drawing.Point(434, 74);
            this.radioByName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radioByName.Name = "radioByName";
            this.radioByName.Size = new System.Drawing.Size(90, 24);
            this.radioByName.TabIndex = 12;
            this.radioByName.TabStop = true;
            this.radioByName.Text = "By Name";
            this.radioByName.UseVisualStyleBackColor = true;
            // 
            // radioByID
            // 
            this.radioByID.AutoSize = true;
            this.radioByID.Location = new System.Drawing.Point(434, 34);
            this.radioByID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radioByID.Name = "radioByID";
            this.radioByID.Size = new System.Drawing.Size(65, 24);
            this.radioByID.TabIndex = 11;
            this.radioByID.TabStop = true;
            this.radioByID.Text = "By ID";
            this.radioByID.UseVisualStyleBackColor = true;
            // 
            // textBoxSearchKeyword
            // 
            this.textBoxSearchKeyword.Location = new System.Drawing.Point(100, 29);
            this.textBoxSearchKeyword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxSearchKeyword.Name = "textBoxSearchKeyword";
            this.textBoxSearchKeyword.PlaceholderText = "Enter product name or ID...";
            this.textBoxSearchKeyword.Size = new System.Drawing.Size(291, 27);
            this.textBoxSearchKeyword.TabIndex = 10;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(100, 74);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(86, 31);
            this.btnSearch.TabIndex = 13;
            this.btnSearch.Text = "&Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lableSearchProduct
            // 
            this.lableSearchProduct.AutoSize = true;
            this.lableSearchProduct.Location = new System.Drawing.Point(15, 36);
            this.lableSearchProduct.Name = "lableSearchProduct";
            this.lableSearchProduct.Size = new System.Drawing.Size(67, 20);
            this.lableSearchProduct.TabIndex = 16;
            this.lableSearchProduct.Text = "Keyword";
            // 
            // dataGridViewProductList
            // 
            this.dataGridViewProductList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewProductList.ColumnHeadersHeight = 29;
            this.dataGridViewProductList.Location = new System.Drawing.Point(19, 454);
            this.dataGridViewProductList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridViewProductList.Name = "dataGridViewProductList";
            this.dataGridViewProductList.ReadOnly = true;
            this.dataGridViewProductList.RowHeadersWidth = 51;
            this.dataGridViewProductList.RowTemplate.Height = 25;
            this.dataGridViewProductList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewProductList.Size = new System.Drawing.Size(1072, 343);
            this.dataGridViewProductList.TabIndex = 41;
            this.dataGridViewProductList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductList_CellDoubleClick);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(966, 401);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(125, 31);
            this.buttonDelete.TabIndex = 9;
            this.buttonDelete.Text = "&Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // buttonNew
            // 
            this.buttonNew.Location = new System.Drawing.Point(522, 401);
            this.buttonNew.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonNew.Name = "buttonNew";
            this.buttonNew.Size = new System.Drawing.Size(125, 31);
            this.buttonNew.TabIndex = 8;
            this.buttonNew.Text = "&New";
            this.buttonNew.UseVisualStyleBackColor = true;
            this.buttonNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(19, 401);
            this.buttonLoad.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(125, 31);
            this.buttonLoad.TabIndex = 7;
            this.buttonLoad.Text = "&Load";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // lableUnitsInStock
            // 
            this.lableUnitsInStock.AutoSize = true;
            this.lableUnitsInStock.Location = new System.Drawing.Point(722, 142);
            this.lableUnitsInStock.Name = "lableUnitsInStock";
            this.lableUnitsInStock.Size = new System.Drawing.Size(98, 20);
            this.lableUnitsInStock.TabIndex = 36;
            this.lableUnitsInStock.Text = "Units In Stock";
            // 
            // lableUnitPrice
            // 
            this.lableUnitPrice.AutoSize = true;
            this.lableUnitPrice.Location = new System.Drawing.Point(364, 141);
            this.lableUnitPrice.Name = "lableUnitPrice";
            this.lableUnitPrice.Size = new System.Drawing.Size(72, 20);
            this.lableUnitPrice.TabIndex = 34;
            this.lableUnitPrice.Text = "Unit Price";
            // 
            // lableWeight
            // 
            this.lableWeight.AutoSize = true;
            this.lableWeight.Location = new System.Drawing.Point(15, 137);
            this.lableWeight.Name = "lableWeight";
            this.lableWeight.Size = new System.Drawing.Size(56, 20);
            this.lableWeight.TabIndex = 32;
            this.lableWeight.Text = "Weight";
            // 
            // txtWeight
            // 
            this.txtWeight.Enabled = false;
            this.txtWeight.Location = new System.Drawing.Point(100, 134);
            this.txtWeight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(210, 27);
            this.txtWeight.TabIndex = 4;
            // 
            // lableCategory
            // 
            this.lableCategory.AutoSize = true;
            this.lableCategory.Location = new System.Drawing.Point(751, 72);
            this.lableCategory.Name = "lableCategory";
            this.lableCategory.Size = new System.Drawing.Size(69, 20);
            this.lableCategory.TabIndex = 29;
            this.lableCategory.Text = "Category";
            // 
            // txtProductName
            // 
            this.txtProductName.Enabled = false;
            this.txtProductName.Location = new System.Drawing.Point(474, 62);
            this.txtProductName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(210, 27);
            this.txtProductName.TabIndex = 2;
            // 
            // lableMemberName
            // 
            this.lableMemberName.AutoSize = true;
            this.lableMemberName.Location = new System.Drawing.Point(364, 65);
            this.lableMemberName.Name = "lableMemberName";
            this.lableMemberName.Size = new System.Drawing.Size(104, 20);
            this.lableMemberName.TabIndex = 27;
            this.lableMemberName.Text = "Product Name";
            // 
            // txtProductID
            // 
            this.txtProductID.Enabled = false;
            this.txtProductID.Location = new System.Drawing.Point(100, 59);
            this.txtProductID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtProductID.Name = "txtProductID";
            this.txtProductID.Size = new System.Drawing.Size(210, 27);
            this.txtProductID.TabIndex = 1;
            // 
            // lableProductID
            // 
            this.lableProductID.AutoSize = true;
            this.lableProductID.Location = new System.Drawing.Point(15, 62);
            this.lableProductID.Name = "lableProductID";
            this.lableProductID.Size = new System.Drawing.Size(79, 20);
            this.lableProductID.TabIndex = 25;
            this.lableProductID.Text = "Product ID";
            // 
            // txtCategory
            // 
            this.txtCategory.Enabled = false;
            this.txtCategory.Location = new System.Drawing.Point(826, 65);
            this.txtCategory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(210, 27);
            this.txtCategory.TabIndex = 3;
            // 
            // txtUnitPrice
            // 
            this.txtUnitPrice.Enabled = false;
            this.txtUnitPrice.Location = new System.Drawing.Point(474, 134);
            this.txtUnitPrice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUnitPrice.Name = "txtUnitPrice";
            this.txtUnitPrice.Size = new System.Drawing.Size(210, 27);
            this.txtUnitPrice.TabIndex = 5;
            // 
            // txtUnitsInStock
            // 
            this.txtUnitsInStock.Enabled = false;
            this.txtUnitsInStock.Location = new System.Drawing.Point(826, 135);
            this.txtUnitsInStock.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUnitsInStock.Name = "txtUnitsInStock";
            this.txtUnitsInStock.Size = new System.Drawing.Size(210, 27);
            this.txtUnitsInStock.TabIndex = 6;
            // 
            // groupBoxProductDetails
            // 
            this.groupBoxProductDetails.Controls.Add(this.txtProductName);
            this.groupBoxProductDetails.Controls.Add(this.txtUnitsInStock);
            this.groupBoxProductDetails.Controls.Add(this.lableProductID);
            this.groupBoxProductDetails.Controls.Add(this.txtUnitPrice);
            this.groupBoxProductDetails.Controls.Add(this.txtProductID);
            this.groupBoxProductDetails.Controls.Add(this.txtCategory);
            this.groupBoxProductDetails.Controls.Add(this.lableMemberName);
            this.groupBoxProductDetails.Controls.Add(this.lableCategory);
            this.groupBoxProductDetails.Controls.Add(this.txtWeight);
            this.groupBoxProductDetails.Controls.Add(this.lableWeight);
            this.groupBoxProductDetails.Controls.Add(this.lableUnitPrice);
            this.groupBoxProductDetails.Controls.Add(this.lableUnitsInStock);
            this.groupBoxProductDetails.Location = new System.Drawing.Point(19, 160);
            this.groupBoxProductDetails.Name = "groupBoxProductDetails";
            this.groupBoxProductDetails.Size = new System.Drawing.Size(1072, 217);
            this.groupBoxProductDetails.TabIndex = 44;
            this.groupBoxProductDetails.TabStop = false;
            this.groupBoxProductDetails.Text = "Product Details";
            // 
            // buttonViewCart
            // 
            this.buttonViewCart.Location = new System.Drawing.Point(522, 403);
            this.buttonViewCart.Name = "buttonViewCart";
            this.buttonViewCart.Size = new System.Drawing.Size(125, 29);
            this.buttonViewCart.TabIndex = 45;
            this.buttonViewCart.Text = "View Cart";
            this.buttonViewCart.UseVisualStyleBackColor = true;
            this.buttonViewCart.Click += new System.EventHandler(this.buttonViewCart_Click);
            // 
            // FormProductsManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 821);
            this.Controls.Add(this.buttonViewCart);
            this.Controls.Add(this.groupBoxProductDetails);
            this.Controls.Add(this.groupBoxFilter);
            this.Controls.Add(this.groupBoxSearch);
            this.Controls.Add(this.dataGridViewProductList);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonNew);
            this.Controls.Add(this.buttonLoad);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormProductsManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Products Management";
            this.Load += new System.EventHandler(this.frmProductsManagement_Load);
            this.groupBoxFilter.ResumeLayout(false);
            this.groupBoxFilter.PerformLayout();
            this.groupBoxSearch.ResumeLayout(false);
            this.groupBoxSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProductList)).EndInit();
            this.groupBoxProductDetails.ResumeLayout(false);
            this.groupBoxProductDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBoxFilter;
        private System.Windows.Forms.GroupBox groupBoxSearch;
        private System.Windows.Forms.RadioButton radioByName;
        private System.Windows.Forms.RadioButton radioByID;
        private System.Windows.Forms.TextBox textBoxSearchKeyword;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lableSearchProduct;
        private System.Windows.Forms.DataGridView dataGridViewProductList;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonNew;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Label lableUnitsInStock;
        private System.Windows.Forms.Label lableUnitPrice;
        private System.Windows.Forms.Label lableWeight;
        private System.Windows.Forms.TextBox txtWeight;
        private System.Windows.Forms.Label lableCategory;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label lableMemberName;
        private System.Windows.Forms.TextBox txtProductID;
        private System.Windows.Forms.Label lableProductID;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.TextBox txtUnitPrice;
        private System.Windows.Forms.TextBox txtUnitsInStock;
        private System.Windows.Forms.Button buttonFilter;
        private System.Windows.Forms.TextBox textBoxFilterTo;
        private System.Windows.Forms.Label lbTo;
        private System.Windows.Forms.TextBox textBoxFilterFrom;
        private System.Windows.Forms.Label lbFrom;
        private System.Windows.Forms.RadioButton radioFiilterByUnitsInStock;
        private System.Windows.Forms.RadioButton radioFilterByUnitPrice;
        private System.Windows.Forms.GroupBox groupBoxProductDetails;
        private System.Windows.Forms.Button buttonClearSearch;
        private System.Windows.Forms.Button buttonViewCart;
    }
}