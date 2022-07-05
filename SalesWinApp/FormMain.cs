using DataAccess.Repository.CartRepo;
using DataAccess.Repository.MemberRepo;
using SalesWinApp.MemberUI;
using SalesWinApp.OrderUI;
using SalesWinApp.Presenter;
using SalesWinApp.ProductUI;
using System;
using System.Windows.Forms;

namespace SalesWinApp
{
    public partial class FormMain : Form
    {
        public IMemberRepository MemberRepository { get; init; }
        public ICartRepository CartRepository { get; init; }
        public bool IsAdminLogin { get; init; }
        private bool IsMemberLogin { get; set; } = false;
        private MemberPresenter MemberLogin { get; set; }
        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonMemberManagement_Click(object sender, EventArgs e)
        {
            FormMembersManagement formMembersManagement = new FormMembersManagement
            {
                LoginMember = MemberLogin,
                IsAdminLogin = IsAdminLogin,
                IsMemberLogin = IsMemberLogin

            };
            formMembersManagement.Closed += (_, _) => this.Close();
            this.Hide();
            formMembersManagement.Show();
        }

        private void buttonProductManagement_Click(object sender, EventArgs e)
        {
            FormProductsManagement formProductsManagement = new FormProductsManagement()
            {
                IsAdminLogin = true,
                MemberRepository = this.MemberRepository
            };
            formProductsManagement.Closed += (_, _) => this.Close();
            this.Hide();
            formProductsManagement.Show();
        }

        private void buttonOrderManagement_Click(object sender, EventArgs e)
        {
            FormOrdersManagement formOrdersManagement = new FormOrdersManagement
            {
                MemberRepository = this.MemberRepository,
                CartRepository = this.CartRepository,
                IsAdminLogin = this.IsAdminLogin,
                IsMemberLogin = this.IsMemberLogin,
                MemberLogin = this.IsMemberLogin ? this.MemberLogin : null,
            };
            formOrdersManagement.Closed += (_, _) => this.Close();
            this.Hide();
            formOrdersManagement.Show();
        }
    }
}
