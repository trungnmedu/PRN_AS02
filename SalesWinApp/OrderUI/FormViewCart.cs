using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BusinessObject;
using DataAccess.Repository.CartRepo;
using DataAccess.Repository.MemberRepo;
using DataAccess.Repository.OrderDetailRepo;
using DataAccess.Repository.OrderRepo;
using DataAccess.Repository.ProductRepo;
using SalesWinApp.MemberUI;
using SalesWinApp.Presenter;
using SalesWinApp.ProductUI;

namespace SalesWinApp.OrderUI
{
    public partial class FormViewCart : Form
    {
        public MemberPresenter LoginMember { get; init; }
        public bool IsAdminLogin { get; init; }
        public bool IsMemberLogin { get; init; }
        public IMemberRepository MemberRepository { get; init; }
        public ICartRepository CartRepository { get; init; }
        private readonly IOrderRepository orderRepository = new OrderRepository();


        BindingSource source;
        public FormViewCart()
        {
            InitializeComponent();

        }
        private void CreateMainMenu()
        {
            MenuStrip mainMenu = new MenuStrip();
            Controls.Add(mainMenu);
            MainMenuStrip = mainMenu;

            ToolStripMenuItem menuOrder = new ToolStripMenuItem("&Order Product");
            ToolStripMenuItem menuProfile = new ToolStripMenuItem("My &Profile");
            ToolStripMenuItem menuExit = new ToolStripMenuItem("&Exit");

            // Main Menu
            mainMenu.Items.AddRange(new ToolStripItem[]
            {
                        menuOrder,
                        menuExit
            });

            menuOrder.Click += menuOrder_Click;
            menuProfile.Click += menuProfile_Click;
            menuExit.Click += menuExit_Click;

        }
        private void menuOrder_Click(object sender, EventArgs e)
        {
            FormProductsManagement frmProductsManagement = new FormProductsManagement
            {
                MemberLogin = LoginMember,
                IsAdminLogin = IsAdminLogin,
                IsMemberLogin = IsMemberLogin,
                MemberRepository = MemberRepository,
                CartRepository = CartRepository
            };
            frmProductsManagement.Closed += (_, _) => Close();
            Hide();
            frmProductsManagement.Show();
        }
        private void menuExit_Click(object sender, EventArgs e) => Close();
        private void menuProfile_Click(object sender, EventArgs e)
        {
            FormMemberDetails frmMemberDetails = new FormMemberDetails
            {
                Text = @"Member Details",
                MemberInfo = LoginMember,
                InsertOrUpdate = false,
                IsAdminLogin = IsAdminLogin,
                IsMemberLogin = IsMemberLogin,
                MemberRepository = MemberRepository
            };
            frmMemberDetails.Closed += (_, _) => Close();
            Hide();
            frmMemberDetails.Show();
        }
        private void LoadCart()
        {
            try
            {
                Dictionary<int, CartProduct> cart = CartRepository.GetCart();
                if (cart == null || cart.Count == 0)
                {
                    buttonRemoveFromCart.Enabled = false;
                    textBoxProductName.DataBindings.Clear();
                    textBoxProductName.Text = string.Empty;
                    textBoxProductPrice.DataBindings.Clear();
                    textBoxProductPrice.Text = string.Empty;
                    textBoxProductQuantity.DataBindings.Clear();
                    textBoxProductQuantity.Text = string.Empty;
                    textBoxProductTotal.DataBindings.Clear();
                    textBoxProductTotal.Text = string.Empty;
                    dataGridViewCart.DataSource = null;
                    buttonCheckOut.Enabled = false;
                }
                else
                {
                    decimal orderTotal = 0;

                    IProductRepository productRepository = new ProductRepository();

                    IEnumerable<CartPresenter> cartPresenters = new List<CartPresenter>();

                    foreach (var cartItem in cart)
                    {
                        CartPresenter cartPresenter = new CartPresenter
                        {
                            ProductName = productRepository.GetProduct(cartItem.Key).ProductName,
                            Price = cartItem.Value.Price,
                            Quantity = cartItem.Value.Quantity,
                            Total = cartItem.Value.Price * cartItem.Value.Quantity
                        };
                        orderTotal += cartItem.Value.Price * cartItem.Value.Quantity;
                        cartPresenters = cartPresenters.Append(cartPresenter);
                    }

                    source = new BindingSource();
                    source.DataSource = cartPresenters;

                    textBoxProductName.DataBindings.Clear();
                    textBoxProductPrice.DataBindings.Clear();
                    textBoxProductQuantity.DataBindings.Clear();
                    textBoxProductTotal.DataBindings.Clear();

                    textBoxProductName.DataBindings.Add("Text", source, "ProductName");
                    textBoxProductPrice.DataBindings.Add("Text", source, "Price");
                    textBoxProductQuantity.DataBindings.Add("Text", source, "Quantity");
                    textBoxProductTotal.DataBindings.Add("Text", source, "Total");

                    lableOrderTotal.Text = $@"Order Total: {orderTotal}";

                    dataGridViewCart.DataSource = null;
                    dataGridViewCart.DataSource = source;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"View Cart", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void frmViewCart_Load(object sender, EventArgs e)
        {
            CreateMainMenu();
            LoadCart();
        }

        private void btnRemoveFromCart_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(@"Do you really want to delete the cart item:" +
                $@"Product Name: {textBoxProductName.Text}" +
                $@"Price: {textBoxProductPrice.Text}" +
                $@"Quantity: {textBoxProductQuantity.Text}" +
                $@"Total: {textBoxProductTotal.Text}?", @"Remove From Cart", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    IProductRepository productRepository = new ProductRepository();
                    CartRepository.RemoveFromCart(productRepository.GetProduct(textBoxProductName.Text).ProductId);
                    LoadCart();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Remove From Cart", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private CartPresenter GetCartItem()
        {
            CartPresenter cartPresenter = null;
            try
            {
                cartPresenter = new CartPresenter
                {
                    ProductName = textBoxProductName.Text,
                    Price = decimal.Parse(textBoxProductPrice.Text),
                    Quantity = int.Parse(textBoxProductQuantity.Text),
                    Total = decimal.Parse(textBoxProductTotal.Text)
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Get Cart Item", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return cartPresenter;
        }
        private void dgvCart_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            CartPresenter cartItem = GetCartItem();

            FormViewCartDetails frmViewCartDetails = new FormViewCartDetails
            {
                CartRepository = CartRepository,
                CartPresenter = cartItem
            };

            if (frmViewCartDetails.ShowDialog() == DialogResult.OK)
            {
                LoadCart();
            }
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            Dictionary<int, CartProduct> cart = CartRepository.GetCart();

            IProductRepository productRepository = new ProductRepository();
            IOrderDetailRepository orderDetailRepository = new OrderDetailRepository();
            MemberPresenter member = LoginMember;

            DateTime dateTime = DateTime.Today;

            if (cart is { Count: > 0 })
            {
                try
                {
                    var order = new Order
                    {
                        MemberId = member.MemberId,
                        OrderDate = dateTime,
                    };
                    Order insertedOrder = orderRepository.AddOrder(order);

                    foreach (var cartItem in cart)
                    {
                        decimal unitPrice = productRepository.GetProduct(cartItem.Key).UnitPrice;
                        decimal price = decimal.Parse(textBoxProductPrice.Text);
                        decimal discount = (unitPrice - price) / unitPrice;
                        OrderDetail orderDetail = new OrderDetail
                        {
                            OrderId = insertedOrder.OrderId,
                            ProductId = cartItem.Key,
                            UnitPrice = productRepository.GetProduct(cartItem.Key).UnitPrice,
                            Quantity = cartItem.Value.Quantity,
                            Discount = Convert.ToDouble(discount)
                        };
                        orderDetailRepository.AddOrderDetail(orderDetail);
                        Product product = productRepository.GetProduct(cartItem.Key);
                        product.UnitsInStock = product.UnitsInStock - cartItem.Value.Quantity;
                        productRepository.Update(product);
                    }
                    MessageBox.Show(@"Check out successfully!", @"Check out", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CartRepository.DeleteCart();
                    FormProductsManagement frmProductsManagement = new FormProductsManagement
                    {
                        MemberLogin = LoginMember,
                        IsAdminLogin = IsAdminLogin,
                        IsMemberLogin = IsMemberLogin,
                        MemberRepository = MemberRepository,
                        CartRepository = CartRepository,
                    };
                    frmProductsManagement.Closed += (_, _) => Close();
                    Hide();
                    frmProductsManagement.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, @"Check out", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
