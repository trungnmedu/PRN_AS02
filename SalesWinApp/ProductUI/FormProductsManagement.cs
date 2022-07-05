using AutoMapper;
using BusinessObject;
using DataAccess.Repository.CartRepo;
using DataAccess.Repository.MemberRepo;
using DataAccess.Repository.OrderDetailRepo;
using DataAccess.Repository.ProductRepo;
using SalesWinApp.MemberUI;
using SalesWinApp.OrderUI;
using SalesWinApp.Presenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SalesWinApp.ProductUI
{
    public partial class FormProductsManagement : Form
    {
        public bool IsAdminLogin { get; init; }
        public bool IsMemberLogin { get; init; }
        public MemberPresenter MemberLogin { get; init; }
        public IMemberRepository MemberRepository { get; init; }

        private readonly IProductRepository productRepository = new ProductRepository();
        public ICartRepository CartRepository { get; init; } = new CartRepository();

        private BindingSource source;


        private IEnumerable<Product> dataSource;
        private IEnumerable<Product> searchAndApplyFilterProductResults;

        private readonly IMapper mapper;
        private readonly IOrderDetailRepository orderDetailRepository = new OrderDetailRepository();

        public FormProductsManagement()
        {
            InitializeComponent();
            var config = new MapperConfiguration(config => { config.AddProfile(new MappingProfileConfiguration()); });
            mapper = config.CreateMapper();
        }

        private IEnumerable<ProductPresenter> TransformProductToProductPresenters(IEnumerable<Product> listProducts)
        {
            return listProducts.Select(product => mapper.Map<Product, ProductPresenter>(product));
        }

        private void AddAdminMenu(MenuStrip mainMenu)
        {
            ToolStripMenuItem menuManagement = new ToolStripMenuItem("&Management");
            ToolStripMenuItem menuMemberMng = new ToolStripMenuItem("&Member Management");
            ToolStripMenuItem menuOrderMng = new ToolStripMenuItem("&Order Management");
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
                menuOrderMng
            });

            menuMemberMng.ShortcutKeys = (Keys.Control) | Keys.M;
            menuOrderMng.ShortcutKeys = (Keys.Control) | Keys.O;

            menuMemberMng.Click += menuMemberMng_Click;
            menuOrderMng.Click += menuOrderMng_Click;
            menuExit.Click += menuExit_Click;
        }

        private void AddMemberMenu(MenuStrip mainMenu)
        {
            // Main Menu
            ToolStripMenuItem menuOrderMng = new ToolStripMenuItem("My &Order");
            ToolStripMenuItem menuProfile = new ToolStripMenuItem("My &Profile");
            ToolStripMenuItem menuExit = new ToolStripMenuItem("&Exit");

            // Main Menu
            mainMenu.Items.AddRange(new ToolStripItem[]
            {
                menuOrderMng,
                menuProfile,
                menuExit
            });
            menuOrderMng.Click += menuOrderMng_Click;
            menuProfile.Click += menuProfile_Click;
            menuExit.Click += menuExit_Click;
        }

        private void CreateMainMenu()
        {
            MenuStrip mainMenu = new MenuStrip();
            this.Controls.Add(mainMenu);
            this.MainMenuStrip = mainMenu;

            if (IsAdminLogin)
            {
                AddAdminMenu(mainMenu);
            }

            if (IsMemberLogin)
            {
                AddMemberMenu(mainMenu);
            }
        }

        private void frmProductsManagement_Load(object sender, EventArgs e)
        {
            txtProductID.Enabled = false;
            txtProductName.Enabled = false;
            txtCategory.Enabled = false;
            txtWeight.Enabled = false;
            txtUnitPrice.Enabled = false;
            txtUnitsInStock.Enabled = false;
            buttonLoad.Enabled = true;
            if (IsMemberLogin)
            {
                this.Text = @"Product Lists";
            }

            buttonDelete.Visible = IsAdminLogin;
            buttonNew.Visible = IsAdminLogin;
            buttonViewCart.Visible = IsMemberLogin;

            CreateMainMenu();
            RefreshLoadFullProductList();
            RefreshBiddingProductListDisplay();
        }

        private void ViewCart()
        {
            FormViewCart frmViewCart = new FormViewCart
            {
                LoginMember = this.IsMemberLogin ? this.MemberLogin : null,
                IsAdminLogin = this.IsAdminLogin,
                IsMemberLogin = this.IsMemberLogin,
                MemberRepository = this.MemberRepository,
                CartRepository = this.CartRepository
            };
            frmViewCart.Closed += (_, _) => this.Close();
            Hide();
            frmViewCart.Show();
        }

        private void menuProfile_Click(object sender, EventArgs e)
        {
            FormMemberDetails formMemberDetails = new FormMemberDetails
            {
                Text = @"Member Details",
                MemberInfo = MemberLogin,
                IsAdminLogin = IsAdminLogin,
                IsMemberLogin = IsMemberLogin,
                InsertOrUpdate = false,
                MemberRepository = this.MemberRepository,
                CartRepository = this.CartRepository
            };
            formMemberDetails.Closed += (_, _) => this.Show();
            this.Hide();
            formMemberDetails.Show();
        }

        private void menuExit_Click(object sender, EventArgs e) => Close();

        private void menuOrderMng_Click(object sender, EventArgs e)
        {
            FormOrdersManagement frmOrdersManagement = new FormOrdersManagement
            {
                IsMemberLogin = this.IsMemberLogin,
                IsAdminLogin = this.IsAdminLogin,
                MemberLogin = this.IsMemberLogin ? this.MemberLogin : null,
                CartRepository = this.CartRepository,
                MemberRepository = this.MemberRepository
            };
            frmOrdersManagement.Closed += (_, _) => this.Close();
            this.Hide();
            frmOrdersManagement.Show();
        }

        private void menuMemberMng_Click(object sender, EventArgs e)
        {
            FormMembersManagement formMembersManagement = new FormMembersManagement
            {
                LoginMember = this.MemberLogin,
            };
            formMembersManagement.Closed += (_, _) => this.Close();
            this.Hide();
            formMembersManagement.Show();
        }

        private void RefreshBiddingProductListDisplay()
        {
            try
            {
                txtProductID.DataBindings.Clear();
                txtProductName.DataBindings.Clear();
                txtCategory.DataBindings.Clear();
                txtWeight.DataBindings.Clear();
                txtUnitPrice.DataBindings.Clear();
                txtUnitsInStock.DataBindings.Clear();
                source = new BindingSource();
                source.DataSource = TransformProductToProductPresenters(dataSource);

                if (source.List.Count > 0)
                {
                    txtProductID.DataBindings.Add("Text", source, "ProductId");
                    txtProductName.DataBindings.Add("Text", source, "ProductName");
                    txtCategory.DataBindings.Add("Text", source, "CategoryName");
                    txtWeight.DataBindings.Add("Text", source, "Weight");
                    txtUnitPrice.DataBindings.Add("Text", source, "UnitPrice");
                    txtUnitsInStock.DataBindings.Add("Text", source, "UnitsInStock");
                }

                dataGridViewProductList.DataSource = source;
                buttonDelete.Enabled = dataSource != null && dataSource.Any() && IsAdminLogin;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Load Product List", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshLoadFullProductList()
        {
            var productResult = productRepository.GetProductsList();
            var productList = (from product in productResult orderby product.ProductName descending select product)
                .ToList();
            if (IsMemberLogin)
            {
                productList = (from product in productList where product.UnitsInStock > 0 select product).ToList();
            }

            dataSource = productList;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                RefreshBiddingProductListDisplay();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Load Products List", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsAdminLogin)
                {
                    FormProductDetail frmProductDetail = new FormProductDetail
                    {
                        ProductRepository = this.productRepository,
                        InsertOrUpdate = true,
                        IsAdminLogin = IsAdminLogin,
                        IsMemberLogin = IsMemberLogin,
                        LoginMember = IsMemberLogin ? MemberLogin : null,
                        Text = @"Add new Product"
                    };

                    if (frmProductDetail.ShowDialog() == DialogResult.OK)
                    {
                        RefreshLoadFullProductList();
                        RefreshBiddingProductListDisplay();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Add Product");
            }
        }

        private ProductPresenter GetCurrentProductInfo()
        {
            try
            {
                return new ProductPresenter()
                {
                    ProductId = int.Parse(txtProductID.Text),
                    ProductName = txtProductName.Text,
                    CategoryName = txtCategory.Text,
                    Weight = txtWeight.Text,
                    UnitPrice = decimal.Parse(txtUnitPrice.Text),
                    UnitsInStock = int.Parse(txtUnitsInStock.Text)
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Get Product Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                ProductPresenter productPresenter = GetCurrentProductInfo();
                if (MessageBox.Show($@"Do you really want to delete the product: " +
                                    $@"Product ID: {productPresenter.ProductId}" +
                                    $@"Product Name: {productPresenter.ProductName}" +
                                    $@"Category: {productPresenter.CategoryName}" +
                                    $@"Weight: {productPresenter.Weight}" +
                                    $@"Unit Price: {productPresenter.UnitPrice}" +
                                    $@"Units In Stock: {productPresenter.UnitsInStock}", @"Delete member",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    orderDetailRepository.DeleteByProduct(productPresenter.ProductId);
                    productRepository.Delete(productPresenter.ProductId);
                    RefreshLoadFullProductList();
                    RefreshBiddingProductListDisplay();
                    MessageBox.Show(@"Delete successfully!!", @"Delete Product", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Delete Product", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HandleSearchByKeyword()
        {
            String keyword = textBoxSearchKeyword.Text.Trim();
            searchAndApplyFilterProductResults = dataSource;
            if (string.IsNullOrEmpty(keyword))
            {
                return;
            }

            if (radioByName.Checked)
            {
                searchAndApplyFilterProductResults = dataSource.Where(product => product.ProductName.ToLower().Contains(keyword.ToLower()));
                return;
            }

            if (radioByID.Checked)
            {
                bool isValidProductId = int.TryParse(keyword, out int productId);
                if (!isValidProductId)
                {
                    MessageBox.Show(@"Product ID must be a number. Try again!", @"Search product");
                }
                else
                {
                    searchAndApplyFilterProductResults = dataSource.Where(product => product.ProductId == productId).ToList();
                }
            }
        }

        private void HandleApplyFilterProduct()
        {
            try
            {
                if (radioFilterByUnitPrice.Checked)
                {
                    bool isApplyMinUnitPrice = decimal.TryParse(textBoxFilterFrom.Text, out decimal minUnitPrice);
                    bool isApplyMaxUnitPrice = decimal.TryParse(textBoxFilterTo.Text, out decimal maxUnitPrice);
                    if ((isApplyMaxUnitPrice && isApplyMinUnitPrice) && (minUnitPrice > maxUnitPrice))
                    {
                        (minUnitPrice, maxUnitPrice) = (maxUnitPrice, minUnitPrice);
                    }

                    if (isApplyMinUnitPrice)
                    {
                        searchAndApplyFilterProductResults =
                            searchAndApplyFilterProductResults.Where(product => product.UnitPrice >= minUnitPrice);
                    }

                    if (isApplyMaxUnitPrice)
                    {
                        searchAndApplyFilterProductResults =
                            searchAndApplyFilterProductResults.Where(product => product.UnitPrice <= maxUnitPrice);
                    }
                }

                if (radioFiilterByUnitsInStock.Checked)
                {
                    bool isApplyMinUnitInStock = decimal.TryParse(textBoxFilterFrom.Text, out decimal minUnitInStock);
                    bool isApplyMaxUnitInStock = decimal.TryParse(textBoxFilterTo.Text, out decimal maxUnitInStock);
                    if ((isApplyMaxUnitInStock && isApplyMinUnitInStock) && (minUnitInStock > maxUnitInStock))
                    {
                        (minUnitInStock, maxUnitInStock) = (maxUnitInStock, minUnitInStock);
                    }

                    if (isApplyMinUnitInStock)
                    {
                        searchAndApplyFilterProductResults =
                            searchAndApplyFilterProductResults.Where(product => product.UnitsInStock >= minUnitInStock);
                    }

                    if (isApplyMaxUnitInStock)
                    {
                        searchAndApplyFilterProductResults =
                            searchAndApplyFilterProductResults.Where(product => product.UnitsInStock <= maxUnitInStock);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Search Product", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HandleSearchAndApplyFilterProducts()
        {
            try
            {
                RefreshLoadFullProductList();
                HandleSearchByKeyword();
                HandleApplyFilterProduct();
                if (searchAndApplyFilterProductResults.Any())
                {
                    dataSource = searchAndApplyFilterProductResults;
                    RefreshBiddingProductListDisplay();
                }
                else
                {
                    MessageBox.Show(@"No result found!", @"Search Product", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, @"Search Product");
            }
        }

        private void ClearSearch()
        {
            textBoxSearchKeyword.Text = String.Empty;
            textBoxFilterFrom.Text = String.Empty;
            textBoxFilterTo.Text = String.Empty;
            RefreshLoadFullProductList();
            RefreshBiddingProductListDisplay();
        }

        private void btnSearch_Click(object sender, EventArgs e) => HandleSearchAndApplyFilterProducts();
        private void btnFilter_Click(object sender, EventArgs e) => HandleSearchAndApplyFilterProducts();

        private void dgvProductList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (IsAdminLogin)
                {
                    ProductPresenter productPresenter = GetCurrentProductInfo();

                    FormProductDetail formProductDetail = new FormProductDetail
                    {
                        LoginMember = this.MemberLogin,
                        ProductRepository = this.productRepository,
                        InsertOrUpdate = false,
                        ProductInfo = productPresenter,
                        Text = @"Update Product Info"
                    };

                    if (formProductDetail.ShowDialog() == DialogResult.OK)
                    {
                        RefreshLoadFullProductList();
                        RefreshBiddingProductListDisplay();
                    }
                }
                if(IsMemberLogin)
                {
                    ProductPresenter productPresenter = GetCurrentProductInfo();
                    FormProductDetail frmProductDetail = new FormProductDetail
                    {
                        ProductRepository = this.productRepository,
                        InsertOrUpdate = false,
                        ProductInfo = productPresenter,
                        LoginMember = this.MemberLogin,
                        CartRepository = this.CartRepository,
                        Text = @"Add To Cart"
                    };

                    if (frmProductDetail.ShowDialog() == DialogResult.OK)
                    {
                        RefreshLoadFullProductList();
                        RefreshBiddingProductListDisplay();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Get Product Detail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void buttonClearSearch_Click(object sender, EventArgs e) => ClearSearch();

        private void buttonViewCart_Click(object sender, EventArgs e) => ViewCart();
    }
}