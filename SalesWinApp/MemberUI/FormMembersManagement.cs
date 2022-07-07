using AutoMapper;
using BusinessObject;
using DataAccess.Repository.CartRepo;
using DataAccess.Repository.MemberRepo;
using DataAccess.Repository.OrderDetailRepo;
using DataAccess.Repository.OrderRepo;
using SalesWinApp.OrderUI;
using SalesWinApp.Presenter;
using SalesWinApp.ProductUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SalesWinApp.MemberUI
{
    public partial class FormMembersManagement : Form
    {
        public bool IsAdminLogin { get; init; }
        public bool IsMemberLogin { get; init; }
        public MemberPresenter LoginMember { get; init; }
        readonly IMemberRepository memberRepository = new MemberRepository();
        private readonly ICartRepository cartRepository = new CartRepository();
        private readonly IOrderRepository orderRepository = new OrderRepository();
        private readonly IOrderDetailRepository orderDetailRepository = new OrderDetailRepository();
        private BindingSource membersBindingSource;
        private BindingSource cityFilter;
        private BindingSource countryFilter;
        private readonly IMapper mapper;
        private IEnumerable<MemberPresenter> originalMembersResult;
        private IEnumerable<MemberPresenter> searchAndApplyFilterMembersResult;

        public FormMembersManagement()
        {
            InitializeComponent();
            mapper = new MapperConfiguration(config => { config.AddProfile(new MappingProfileConfiguration()); })
                .CreateMapper();
        }

        private void CreateMainMenu()
        {
            MenuStrip mainMenu = new MenuStrip();
            this.Controls.Add(mainMenu);
            this.MainMenuStrip = mainMenu;

            ToolStripMenuItem menuManagement = new ToolStripMenuItem("&Management");
            ToolStripMenuItem menuProductManagement = new ToolStripMenuItem("&Product Management");
            ToolStripMenuItem menuOrderManagement = new ToolStripMenuItem("&Order Management");
            ToolStripMenuItem menuExit = new ToolStripMenuItem("&Exit");

            // Main Menu
            mainMenu.Items.AddRange(new ToolStripItem[]
            {
                menuManagement,
                menuExit
            });

            // Menu Management
            menuManagement.DropDownItems.AddRange(new ToolStripItem[]
            {
                menuProductManagement,
                menuOrderManagement
            });

            menuProductManagement.ShortcutKeys = (Keys.Control) | Keys.P;
            menuOrderManagement.ShortcutKeys = (Keys.Control) | Keys.O;

            menuProductManagement.Click += menuProductMng_Click;
            menuOrderManagement.Click += menuOrderMng_Click;
            menuExit.Click += menuExit_Click;
        }

        private void frmMemberManagement_Load(object sender, EventArgs e)
        {
            try
            {
                btnDelete.Enabled = false;
                txtMemberID.Enabled = false;
                txtMemberName.Enabled = false;
                txtEmail.Enabled = false;
                txtCompanyName.Enabled = false;
                txtPassword.Enabled = false;
                txtCity.Enabled = false;
                txtCountry.Enabled = false;
                btnNew.Enabled = true;
                dgvMemberList.Enabled = false;
                btnLoad.Enabled = true;
                grSearch.Enabled = false;
                grFilter.Enabled = false;
                CreateMainMenu();
                LoadFullListMembers();
                RefreshBiddingMemberListDisplay();
                ExtractAndBindingMemberFilter();
            }
            catch (Exception exception)
            {
                btnNew.Enabled = false;
                MessageBox.Show(exception.Message, @"Member Management");
            }

        }

        private void menuExit_Click(object sender, EventArgs e) => Close();

        private void menuOrderMng_Click(object sender, EventArgs e)
        {
            FormOrdersManagement formOrdersManagement = new FormOrdersManagement
            {
                MemberLogin = this.LoginMember,
                IsAdminLogin = IsAdminLogin,
                IsMemberLogin = IsMemberLogin,
                CartRepository = this.cartRepository,
                MemberRepository = this.memberRepository
            };
            formOrdersManagement.Closed += (_, _) => this.Close();
            this.Hide();
            formOrdersManagement.Show();
        }

        private void menuProductMng_Click(object sender, EventArgs e)
        {
            FormProductsManagement frmProductsManagement = new FormProductsManagement()
            {
                MemberLogin = this.LoginMember,
                IsAdminLogin = IsAdminLogin,
                IsMemberLogin = IsMemberLogin,
                MemberRepository = this.memberRepository,
                CartRepository = this.cartRepository
            };
            frmProductsManagement.Closed += (_, _) => this.Close();
            this.Hide();
            frmProductsManagement.Show();
        }

        private MemberPresenter GetCurrentMemberDetails()
        {
            try
            {
                return new MemberPresenter
                {
                    MemberId = int.Parse(txtMemberID.Text),
                    Fullname = txtMemberName.Text,
                    Email = txtEmail.Text,
                    CompanyName = txtCompanyName.Text,
                    Password = txtPassword.Text,
                    City = txtCity.Text,
                    Country = txtCountry.Text
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Get Member Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void ClearCurrentMemberDisplay()
        {
            txtMemberID.DataBindings.Clear();
            txtMemberID.Clear();
            txtMemberName.DataBindings.Clear();
            txtMemberName.Clear();
            txtEmail.DataBindings.Clear();
            txtEmail.Clear();
            txtCompanyName.DataBindings.Clear();
            txtCompanyName.Clear();
            txtPassword.DataBindings.Clear();
            txtPassword.Clear();
            txtCity.DataBindings.Clear();
            txtCity.Clear();
            txtCountry.DataBindings.Clear();
            txtCountry.Clear();
        }
        private void RefreshBiddingMemberListDisplay()
        {
            try
            {
                ClearCurrentMemberDisplay();
                if (membersBindingSource?.Count > 0)
                {
                    txtMemberID.DataBindings.Add("Text", membersBindingSource, "MemberId");
                    txtMemberName.DataBindings.Add("Text", membersBindingSource, "Fullname");
                    txtEmail.DataBindings.Add("Text", membersBindingSource, "Email");
                    txtCompanyName.DataBindings.Add("Text", membersBindingSource, "CompanyName");
                    txtPassword.DataBindings.Add("Text", membersBindingSource, "Password");
                    txtCity.DataBindings.Add("Text", membersBindingSource, "City");
                    txtCountry.DataBindings.Add("Text", membersBindingSource, "Country");

                    dgvMemberList.DataSource = membersBindingSource;
                    dgvMemberList.Enabled = true;
                    btnDelete.Enabled = true;
                }
                else
                {
                    dgvMemberList.DataSource = null;
                    dgvMemberList.Enabled = false;
                    btnDelete.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Load Member List");
            }
        }

        private void LoadFullListMembers()
        {
            IEnumerable<MemberPresenter> members = memberRepository.GetMembersList()
                .Select(member => mapper.Map<Member, MemberPresenter>(member)).ToList();
            originalMembersResult = members;
            membersBindingSource = new BindingSource();
            membersBindingSource.DataSource = members;
            if (members.Any())
            {
                grFilter.Enabled = true;
                grSearch.Enabled = true;
            }
            else
            {
                grFilter.Enabled = false;
                grSearch.Enabled = false; 
            }
        }

        private void ExtractAndBindingMemberFilter()
        {
            if (!originalMembersResult.Any())
            {
                grFilter.Enabled = false;
                comboBoxFilterCity.DataSource = null;
                comboBoxFilterCountry.DataSource = null;
                return;
            }

            cityFilter = new BindingSource();
            List<String> listCityFilterValue = originalMembersResult.Select(member => member.City).Distinct().ToList();
            listCityFilterValue.Insert(0, "");
            cityFilter.DataSource = listCityFilterValue;
            comboBoxFilterCity.DataSource = cityFilter;

            countryFilter = new BindingSource();
            List<String> listCountryFilterValue = originalMembersResult.Select(member => member.Country).Distinct().ToList();
            listCountryFilterValue.Insert(0, "");
            countryFilter.DataSource = listCountryFilterValue;
            comboBoxFilterCountry.DataSource = countryFilter;
        }

        private void DeleteOrderAndOrderDetailsActionAfterDeletedMemberByMemberId(int memberId)
        {
            IEnumerable<Order> orders = orderRepository.GetAllOrder().Where(order => order.MemberId == memberId);
            foreach (Order order in orders)
            {
                orderDetailRepository.DeleteOrderDetails(order.OrderId);
                orderRepository.DeleteOrder(order.OrderId);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            btnNew.Enabled = true;
            dgvMemberList.Enabled = true;
            btnLoad.Enabled = true;
            grSearch.Enabled = true;
            grFilter.Enabled = true;
            LoadFullListMembers();
            RefreshBiddingMemberListDisplay();
            ExtractAndBindingMemberFilter();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FormMemberDetails formMemberDetails = new FormMemberDetails
            {
                MemberRepository = this.memberRepository,
                InsertOrUpdate = true,
                Text = @"Add new member"
            };

            if (formMemberDetails.ShowDialog() == DialogResult.OK)
            {
                LoadFullListMembers();
                RefreshBiddingMemberListDisplay();
                ExtractAndBindingMemberFilter();
                membersBindingSource.Position = membersBindingSource == null ? 0 : membersBindingSource.List.Count - 1;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                MemberPresenter currentMemberDetails = GetCurrentMemberDetails();
                Member member = mapper.Map<MemberPresenter, Member>(currentMemberDetails);
                String textConfirmBeforeDeleteAction = $@"Do you really want to delete the member" +
                                                       Environment.NewLine + $@"Member ID: {member.MemberId}" +
                                                       Environment.NewLine + $@"Member Name: {member.Fullname}" +
                                                       Environment.NewLine + $@"Email: {member.Email}" +
                                                       Environment.NewLine + $@"City: {member.City}" +
                                                       Environment.NewLine + $@"Country: {member.Country}";
                DialogResult stateConfirmedDeleteAction = MessageBox.Show(textConfirmBeforeDeleteAction,
                    @"Delete member", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (stateConfirmedDeleteAction == DialogResult.Yes)
                {
                    DeleteOrderAndOrderDetailsActionAfterDeletedMemberByMemberId(member.MemberId);
                    memberRepository.DeleteMember(member.MemberId);
                    LoadFullListMembers();
                    RefreshBiddingMemberListDisplay();
                    ExtractAndBindingMemberFilter();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Delete Member", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvMemberList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            MemberPresenter memberPresenter = GetCurrentMemberDetails();
            FormMemberDetails formMemberDetails = new FormMemberDetails
            {
                MemberRepository = this.memberRepository,
                InsertOrUpdate = false,
                MemberInfo = memberPresenter,
                Text = @"Update member info"
            };

            if (formMemberDetails.ShowDialog() == DialogResult.OK)
            {
                LoadFullListMembers();
                RefreshBiddingMemberListDisplay();
                ExtractAndBindingMemberFilter();
                membersBindingSource.Position = membersBindingSource.Count - 1;
            }
        }

        private void handleSearchMembersByKeyword()
        {
            String searchKeyword = txtSearchValue.Text.Trim();
            bool isApplySearch = searchKeyword.Length > 0;
            if (!isApplySearch)
            {
                searchAndApplyFilterMembersResult = originalMembersResult;
                return;
            }

            if (radioByID.Checked)
            {
                bool isValidMemberIdFormat = int.TryParse(searchKeyword, out int memberId);
                if (isValidMemberIdFormat)
                {
                    searchAndApplyFilterMembersResult =
                        originalMembersResult.Where(member => member.MemberId == memberId);
                }
                else
                {
                    throw new FormatException("Member ID must be a number. Try again!");
                }
            }

            if (radioByName.Checked)
            {
                searchAndApplyFilterMembersResult = originalMembersResult.Where(member =>
                    member.Fullname.ToLower().Contains(searchKeyword.ToLower()));
            }
        }

        private void handleApplyFilterMembersByCity()
        {
            string currentSelectedCity = comboBoxFilterCity.Text;
            if (currentSelectedCity?.Length == 0)
            {
                return;
            }
            searchAndApplyFilterMembersResult =  searchAndApplyFilterMembersResult.Where(member => member.City.Equals(currentSelectedCity));
        }

        private void handleApplyFilterMembersByCountry()
        {
            string currentSelectedCountry = comboBoxFilterCountry.Text;

            if (currentSelectedCountry?.Length == 0)
            {
                return;
            }
            searchAndApplyFilterMembersResult = searchAndApplyFilterMembersResult.Where(member => member.Country.Equals(currentSelectedCountry));
        }

        private void handleApplyFilterMembers()
        {
            handleApplyFilterMembersByCountry();
            handleApplyFilterMembersByCity();
        }

        private void handleSearchAndApplyFilterMembers()
        {
            try
            {
                LoadFullListMembers();
                if (!originalMembersResult.Any())
                {
                    return;
                }
                handleSearchMembersByKeyword();
                handleApplyFilterMembers();
                if (searchAndApplyFilterMembersResult.Any())
                {
                    membersBindingSource = new BindingSource();
                    membersBindingSource.DataSource = searchAndApplyFilterMembersResult;
                    RefreshBiddingMemberListDisplay();
                }
                else
                {
                    MessageBox.Show(@"No result match!", @"Search Member", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (FormatException formatException)
            {
                MessageBox.Show(formatException.Message, @"Search Member", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            handleSearchAndApplyFilterMembers();
        }

        private void cboCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            handleSearchAndApplyFilterMembers();
        }

        private void cboSearchCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            handleSearchAndApplyFilterMembers();
        }
    }
}