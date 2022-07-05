using DataAccess.Repository.CategoryRepo;
using System;
using System.Windows.Forms;

namespace SalesWinApp.CategoryUI
{
    public partial class FormAddCategory : Form
    {
        public ICategoryRepository CategoryRepository { get; set; }
        public FormAddCategory()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string categoryName = txtCategoryName.Text;
            try
            {
                CategoryRepository.AddCategory(categoryName);
                MessageBox.Show(@"Add Category with the name: " + categoryName + @" successfully!!", @"Add new Category", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Add new Category", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) => Close();
    }
}
