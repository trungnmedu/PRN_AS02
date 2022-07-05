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

        private BindingSource source;
        private BindingSource citySource;
        private BindingSource countrySource;
        private bool search;
        private bool filter;
        private IEnumerable<Member> dataSource;
        private IEnumerable<Member> searchResults;
        private IEnumerable<Member> filterResult;
        private IEnumerable<string> countryList;
        private Dictionary<string, IEnumerable<string>> cityDictionary;
        private readonly IMapper mapper;
        private readonly IOrderRepository orderRepository = new OrderRepository();
        private readonly IOrderDetailRepository orderDetailRepository = new OrderDetailRepository();

        public FormMembersManagement()
        {
            InitializeComponent();
            mapper = new MapperConfiguration(config => { config.AddProfile(new MappingProfileConfiguration()); }).CreateMapper();
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
            btnDelete.Enabled = false;
            txtMemberID.Enabled = false;
            txtMemberName.Enabled = false;
            txtEmail.Enabled = false;
            txtCompanyName.Enabled = false;
            txtPassword.Enabled = false;
            txtCity.Enabled = false;
            txtCountry.Enabled = false;
            btnNew.Enabled = false;
            dgvMemberList.Enabled = false;
            btnLoad.Enabled = true;
            grSearch.Enabled = false;
            grFilter.Enabled = false;
            CreateMainMenu();
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

        private MemberPresenter GetMemberInfo()
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
        private void LoadMemberList()
        {
            try
            {
                IEnumerable<MemberPresenter> presentSource = filter ? filterResult.Select(member => mapper.Map<Member, MemberPresenter>(member)) : dataSource.Select(member => mapper.Map<Member, MemberPresenter>(member));
                source = new BindingSource();
                source.DataSource = presentSource;
                if (!filter)
                {
                    countryList = from member in dataSource
                                  where !string.IsNullOrEmpty(member.Country.Trim())
                                  orderby member.Country ascending
                                  select member.Country;
                    countryList = countryList.Distinct().AsEnumerable();
                    countryList = countryList.Prepend("All");
                    cityDictionary = new Dictionary<string, IEnumerable<string>>();
                    foreach (var country in countryList.AsEnumerable().ToList())
                    {
                        var cityList = from member in dataSource
                                       where !string.IsNullOrEmpty(member.City.Trim()) && (member.Country.Equals(country))
                                       orderby member.City ascending
                                       select member.City;
                        cityList = cityList.Prepend("All");
                        cityList = cityList.Distinct();

                        cityDictionary.Add(country, cityList);
                    }

                    if (dataSource.Any())
                    {
                        countrySource = new BindingSource();
                        countrySource.DataSource = countryList;
                        cboCountry.DataSource = null;
                        cboCountry.DataSource = countrySource;

                        cboSearchCity.DataBindings.Clear();
                    }
                }

                txtMemberID.DataBindings.Clear();
                txtMemberName.DataBindings.Clear();
                txtEmail.DataBindings.Clear();
                txtCompanyName.DataBindings.Clear();
                txtPassword.DataBindings.Clear();
                txtCity.DataBindings.Clear();
                txtCountry.DataBindings.Clear();
                
                if (presentSource.Any())
                {
                    txtMemberID.DataBindings.Add("Text", source, "MemberId");
                    txtMemberName.DataBindings.Add("Text", source, "Fullname");
                    txtEmail.DataBindings.Add("Text", source, "Email");
                    txtCompanyName.DataBindings.Add("Text", source, "CompanyName");
                    txtPassword.DataBindings.Add("Text", source, "Password");
                    txtCity.DataBindings.Add("Text", source, "City");
                    txtCountry.DataBindings.Add("Text", source, "Country");
                }

                dgvMemberList.DataSource = null;
                dgvMemberList.DataSource = source;
                btnDelete.Enabled = dataSource?.Count() > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Load Member List");
            }
        }

        private void LoadFullList()
        {
            search = false;
            filter = false;
            var members = memberRepository.GetMembersList();
            dataSource = from member in members
                             orderby member.Fullname descending
                             select member;
            searchResults = filterResult = dataSource;
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            btnNew.Enabled = true;
            dgvMemberList.Enabled = true;
            btnLoad.Enabled = true;
            grSearch.Enabled = true;
            grFilter.Enabled = true;
            LoadFullList();
            LoadMemberList();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FormMemberDetails frmMemberDetails = new FormMemberDetails
            {
                MemberRepository = this.memberRepository,
                InsertOrUpdate = true,
                Text = @"Add new member"
            };

            if (frmMemberDetails.ShowDialog() == DialogResult.OK)
            {
                LoadFullList();
                LoadMemberList();
                source.Position = source.Count - 1;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                MemberPresenter memberPresenter = GetMemberInfo();
                Member member = mapper.Map<Member>(memberPresenter);
                if (member.MemberId == LoginMember.MemberId)
                {
                    MessageBox.Show(@"You can't delete yourself!!", @"Delete member", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (MessageBox.Show($@"Do you really want to delete the member: " +
                    $@"Member ID: {member.MemberId}" +
                    $@"Member Name: {member.Fullname}" +
                    $@"Email: {member.Email}" +
                    $@"City: {member.City}" +
                    $@"Country: {member.Country}", @"Delete member", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        IEnumerable<Order> orders = orderRepository.GetAllOrder().Where(order => order.MemberId == member.MemberId);
                        foreach (var order in orders)
                        {
                            orderDetailRepository.DeleteOrderDetails(order.OrderId);
                            orderRepository.DeleteOrder(order.OrderId);
                        }
                        memberRepository.DeleteMember(member.MemberId);
                        search = false;
                        LoadFullList();
                        LoadMemberList();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Delete Member", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvMemberList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            MemberPresenter memberPresenter = GetMemberInfo();

            FormMemberDetails formMemberDetails = new FormMemberDetails
            {
                MemberRepository = this.memberRepository,
                InsertOrUpdate = false,
                MemberInfo = memberPresenter,
                Text = @"Update member info"
            };

            if (formMemberDetails.ShowDialog() == DialogResult.OK)
            {
                LoadFullList();
                LoadMemberList();
                source.Position = source.Count - 1;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string searchValue = txtSearchValue.Text;
                if (radioByID.Checked)
                {
                    int searchId = int.Parse(searchValue);
                    Member member = memberRepository.GetMember(searchId);
                    if (member != null)
                    {
                        IEnumerable<Member> searchResult = new List<Member>() { member };
                        dataSource = searchResult;
                        this.searchResults = searchResult;
                        this.filterResult = searchResult;
                        filter = false;
                        search = true;
                        LoadMemberList();
                    }
                    else
                    {
                        MessageBox.Show(@"No result found!", @"Search member", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else if (radioByName.Checked)
                {
                    string searchName = searchValue;
                    IEnumerable<Member> searchResult = memberRepository.SearchMember(searchName).AsEnumerable().ToList();
                    if (searchResult.Any())
                    {
                        this.filterResult = this.searchResults = dataSource = searchResult;
                        search = filter = false;
                        LoadMemberList();
                    }
                    else
                    {
                        MessageBox.Show(@"No result found!", @"Search member", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Search member", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cboCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboCountry.DataSource != null)
                {
                    string country = cboCountry.SelectedItem.ToString();
                    if (!string.IsNullOrEmpty(country))
                    {
                        IEnumerable<Member> searchResult = memberRepository.SearchMemberByCountry(country, search ? this.searchResults : this.dataSource).ToList();

                        if (searchResult.Any())
                        {
                            cboSearchCity.DataBindings.Clear();

                            IEnumerable<string> cityList = new List<string>();
                            if (country.Equals("All"))
                            {
                                var keys = cityDictionary.Keys;
                                foreach (var key in keys)
                                {
                                    cityDictionary.TryGetValue(key, out var cities);
                                    if (cities == null)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        cities = cities.ToList();
                                    }
                                    if (cities.Any())
                                    {
                                        foreach (var city in cities)
                                        {
                                            cityList = cityList.Concat(new List<string>() { city });
                                        }
                                    }
                                }
                            }
                            else
                            {
                                cityDictionary.TryGetValue(country, out cityList);
                            }

                            cityList = cityList?.Distinct();

                            citySource = new BindingSource();
                            citySource.DataSource = cityList;
                            cboSearchCity.DataSource = null;
                            cboSearchCity.DataSource = citySource;

                            filterResult = searchResult;
                            filter = true;
                            LoadMemberList();
                        }
                        else
                        {
                            MessageBox.Show(@"No result found!", @"Search member", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Search member", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboSearchCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboSearchCity.DataSource != null)
                {
                    string city = cboSearchCity.SelectedItem.ToString();
                    string country = cboCountry.Text;

                    if (!string.IsNullOrEmpty(city) && !string.IsNullOrEmpty(country))
                    {
                        IEnumerable<Member> searchResult = memberRepository.SearchMemberByCity(country, city, search ? this.searchResults : this.dataSource).ToList();

                        if (searchResult.Any())
                        {
                            filter = true;
                            filterResult = searchResult;
                            LoadMemberList();
                        }
                        else
                        {
                            MessageBox.Show(@"No result found!", @"Search member", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Search member", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
