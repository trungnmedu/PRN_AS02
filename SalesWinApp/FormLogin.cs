using AutoMapper;
using BusinessObject;
using DataAccess.Repository.CartRepo;
using DataAccess.Repository.MemberRepo;
using SalesWinApp.Presenter;
using SalesWinApp.ProductUI;
using System;
using System.Windows.Forms;

namespace SalesWinApp
{
    public partial class FormLogin : Form
    {
        private readonly IMemberRepository memberRepository = new MemberRepository();
        private readonly ICartRepository cartRepository = new CartRepository();
        private readonly IMapper mapper;
        private bool isAdminLogin;
        private bool isMemberLogin;
        public FormLogin()
        {
            InitializeComponent();
            mapper = new MapperConfiguration(
                (config) =>
                {
                    config.AddProfile(new MappingProfileConfiguration());
                }
            ).CreateMapper();
        }

        private void CheckLogin()
        {
            try
            {
                string loginEmail = textBoxEmail.Text;
                string loginPassword = txtPassword.Text;

                isAdminLogin = memberRepository.IsAdminLogin(loginEmail, loginPassword);
                if (isAdminLogin)
                {
                    FormMain frmMain = new FormMain
                    {
                        IsAdminLogin = this.isAdminLogin,
                        MemberRepository = memberRepository,
                        CartRepository = this.cartRepository
                    };
                    frmMain.Closed += (_, _) => this.Close();
                    Hide();
                    frmMain.Show();
                    return;
                }

                Member member = memberRepository.Login(loginEmail, loginPassword);
                isMemberLogin = member != null;
                if (isMemberLogin)
                {
                    MemberPresenter memberLogin = mapper.Map<MemberPresenter>(member);
                    FormProductsManagement formProductsManagement = new FormProductsManagement()
                    {
                        MemberLogin = memberLogin,
                        IsMemberLogin = true,
                        MemberRepository = memberRepository,
                        CartRepository = this.cartRepository
                    };
                    formProductsManagement.Closed += (_, _) => this.Close();
                    this.Hide();
                    formProductsManagement.Show();
                    return;
                }


                if (MessageBox.Show(@"Login failed email or password not correct!", @"Login", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Cancel)
                {
                    Close();
                }

            }
            catch (Exception)
            {
                MessageBox.Show(@"System busy can't login. Try again!", @"Login failed.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            CheckLogin();
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
