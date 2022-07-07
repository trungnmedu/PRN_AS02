using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using AutoMapper;
using BusinessObject;
using DataAccess.Repository.CartRepo;
using DataAccess.Repository.MemberRepo;
using DataAccess.Repository.OrderRepo;
using ExcelLibrary;
using SalesWinApp.MemberUI;
using SalesWinApp.Presenter;
using SalesWinApp.ProductUI;

namespace SalesWinApp.OrderUI
{
    public partial class FormOrdersManagement : Form
    {
        public MemberPresenter MemberLogin { get; init; }
        public bool IsAdminLogin { get; init; }
        public bool IsMemberLogin { get; init; }
        public IMemberRepository MemberRepository { get; init; }
        public ICartRepository CartRepository { get; init; }
        private readonly IOrderRepository orderRepository = new OrderRepository();
        private IEnumerable<OrderPresenter> orderPresenters = new List<OrderPresenter>();


        private BindingSource source;
        private readonly IMapper mapper;
        public FormOrdersManagement()
        {
            InitializeComponent();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfileConfiguration());
            });
            mapper = config.CreateMapper();
        }

        private void CreateAdminMainMenu(MenuStrip mainMenu)
        {
            ToolStripMenuItem menuManagement = new ToolStripMenuItem("&Management");
            ToolStripMenuItem menuMemberMng = new ToolStripMenuItem("&Member Management");
            ToolStripMenuItem menuProductMng = new ToolStripMenuItem("&Product Management");
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
                menuMemberMng,
                menuProductMng
            });

            menuMemberMng.ShortcutKeys = (Keys.Control) | Keys.M;
            menuProductMng.ShortcutKeys = (Keys.Control) | Keys.O;

            menuMemberMng.Click += menuMemberMng_Click;
            menuProductMng.Click += menuProductMng_Click;
            menuExit.Click += menuExit_Click;
        }
        
        private void CreateMemberMainMenu(MenuStrip mainMenu)
        {
            ToolStripMenuItem menuOrder = new ToolStripMenuItem("&Order Product");
            ToolStripMenuItem menuProfile = new ToolStripMenuItem("My &Profile");
            ToolStripMenuItem menuExit = new ToolStripMenuItem("&Exit");

            // Main Menu
            mainMenu.Items.AddRange(new ToolStripItem[]
            {
                menuOrder,
                menuProfile,
                menuExit
            });
            menuOrder.Click += menuOrder_Click;
            menuProfile.Click += menuProfile_Click;
            menuExit.Click += menuExit_Click;
        }
        private void CreateMainMenu()
        {
            MenuStrip mainMenu = new MenuStrip();
            Controls.Add(mainMenu);
            MainMenuStrip = mainMenu;

            if (IsAdminLogin)
            {
                CreateAdminMainMenu(mainMenu);
            }

            if (IsMemberLogin)
            {
                CreateMemberMainMenu(mainMenu);
            }
        }

        private void menuMemberMng_Click(object sender, EventArgs e)
        {
            FormMembersManagement formMembersManagement = new FormMembersManagement
            {
                LoginMember = IsMemberLogin ? MemberLogin : null,
                IsAdminLogin = IsAdminLogin,
                IsMemberLogin = IsMemberLogin,
            };
            formMembersManagement.Closed += (_, _) => Close();
            Hide();
            formMembersManagement.Show();
        }
        private void menuProductMng_Click(object sender, EventArgs e)
        {
            FormProductsManagement formProductsManagement = new FormProductsManagement
            {
                MemberRepository = MemberRepository,
                CartRepository = CartRepository,
                IsAdminLogin = IsAdminLogin,
                IsMemberLogin = IsMemberLogin,
                MemberLogin = IsMemberLogin ? MemberLogin : null,
            };
            formProductsManagement.Closed += (_, _) => Close();
            Hide();
            formProductsManagement.Show();
        }
        private void menuExit_Click(object sender, EventArgs e) => Close();

        private void menuOrder_Click(object sender, EventArgs e)
        {
            FormProductsManagement formProductsManagement = new FormProductsManagement
            {
                IsAdminLogin = IsAdminLogin,
                IsMemberLogin = IsMemberLogin,
                MemberLogin = IsMemberLogin ? MemberLogin : null,
                MemberRepository = MemberRepository,
                CartRepository = CartRepository
            };
            formProductsManagement.Closed += (_, _) => Close();
            Hide();
            formProductsManagement.Show();
        }
        private void menuProfile_Click(object sender, EventArgs e)
        {
            FormMemberDetails formMemberDetails = new FormMemberDetails
            {
                Text = @"Member Details",
                MemberInfo = IsMemberLogin ? MemberLogin : null,
                InsertOrUpdate = false,
                IsAdminLogin = IsAdminLogin,
                IsMemberLogin = IsMemberLogin,
                MemberRepository = MemberRepository,
                CartRepository = CartRepository
            };
            formMemberDetails.Closed += (_, _) => Close();
            Hide();
            formMemberDetails.Show();
        }

        private void LoadOrder()
        {
            source = new BindingSource();
            source.DataSource = orderPresenters;

            txtOrderID.DataBindings.Clear();
            txtOrderDate.DataBindings.Clear();
            txtOrderTotal.DataBindings.Clear();
            txtMemberName.DataBindings.Clear();

            txtOrderID.DataBindings.Add("Text", source, "OrderID");
            txtOrderDate.DataBindings.Add("Text", source, "OrderDate");
            txtOrderTotal.DataBindings.Add("Text", source, "OrderTotal");
            txtMemberName.DataBindings.Add("Text", source, "MemberName");

            dgvOrderList.DataSource = null;
            dgvOrderList.DataSource = source;
        }
        private void frmOrdersManagement_Load(object sender, EventArgs e)
        {
            try
            {
                CreateMainMenu();

                startDate.Value = DateTime.Today;
                startDate.Format = DateTimePickerFormat.Custom;
                startDate.CustomFormat = @"dd/MM/yyyy";

                endDate.Value = DateTime.Today;
                endDate.Format = DateTimePickerFormat.Custom;
                endDate.CustomFormat = @"dd/MM/yyyy";
                
                
                IEnumerable<Order> orders = orderRepository.GetAllOrder().ToList();
                if (!orders.Any())
                {
                    MessageBox.Show(@"No order found!", @"Order Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (IsMemberLogin)
                {
                    orders = orders.Where(order => order.MemberId == MemberLogin.MemberId);
                }

                orderPresenters = orders.Select(order => mapper.Map<Order, OrderPresenter>(order));
                LoadOrder();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Load Orders List", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private OrderPresenter GetOrder()
        {
            OrderPresenter orderPresenter;
            try
            {
                orderPresenter = new OrderPresenter
                {
                    OrderId = int.Parse(txtOrderID.Text),
                    MemberName = txtMemberName.Text,
                    OrderDate = DateTime.Parse(txtOrderDate.Text),
                    OrderTotal = decimal.Parse(txtOrderTotal.Text)
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orderPresenter;
        }
        private void dgvOrderList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FormOrderDetails frmOrderDetails = new FormOrderDetails
            {
                IsAdminLogin = IsAdminLogin,
                IsMemberLogin = IsMemberLogin,
                MemberLogin = IsMemberLogin ? MemberLogin : null,
                OrderPresenter = GetOrder(),
            };
            frmOrderDetails.ShowDialog();
            LoadOrder();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime searchStartDate = startDate.Value;
                DateTime searchEndDate = endDate.Value;
                if (DateTime.Compare(searchStartDate, searchEndDate) > 0)
                {
                    (searchStartDate, searchEndDate) = (searchEndDate, searchStartDate);
                    startDate.Value = searchStartDate;
                    endDate.Value = searchEndDate;
                }
                List<Order> orders = orderRepository.GetAllOrderFilterByDate(searchStartDate, searchEndDate).ToList();
                
                if (orders.Any())
                {
                    orderPresenters = orders.Select(orderItem => mapper.Map<Order, OrderPresenter>(orderItem));
                    LoadOrder();
                }
                else
                {
                    MessageBox.Show(@"No order found!", @"Order Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Search Orders", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private DataTable CreateDataTable<T>()
        {
            DataTable dataTable = new DataTable();

            PropertyInfo[] propertyInfos = typeof(T).GetProperties();

            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                Type propertyType = propertyInfo.PropertyType.IsGenericType ? propertyInfo.PropertyType.GetGenericArguments()[0] : propertyInfo.PropertyType;
                DataColumn dataColumn = new DataColumn(propertyInfo.Name, propertyType);
                if (propertyInfo.CanRead)
                {
                    dataTable.Columns.Add(dataColumn);
                }
            }
            return dataTable;
        }
        private DataTable ToDataTable<T>(IEnumerable<T> items)
        {
            
            var table = CreateDataTable<T>();
            PropertyInfo[] propertyInfos = typeof(T).GetProperties();

            foreach (var item in items)
            {
                var dataRow = table.NewRow();

                for (int property = 0; property < table.Columns.Count; property++)
                {
                    if (propertyInfos[property].CanRead)
                    {
                        dataRow[property] = propertyInfos[property].GetValue(item, null) ?? "VALUE";
                    }
                }
                table.Rows.Add(dataRow);
            }
            return table;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                var tableOfData = ToDataTable(orderPresenters);
                DataSet ds = new DataSet();
                ds.Tables.Add(tableOfData);
                DataSetHelper.CreateWorkbook("Report.xls", ds);

                string path = Environment.CurrentDirectory + "\\";
                var p = new Process();
                p.StartInfo = new ProcessStartInfo(path + "Report.xls")
                {
                    UseShellExecute = true
                };
                p.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Export data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
