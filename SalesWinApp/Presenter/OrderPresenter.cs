using System;
using System.ComponentModel;

namespace SalesWinApp.Presenter
{
    public class OrderPresenter
    {
        [DisplayName("Order ID")]
        public int OrderId { get; set; }

        [DisplayName("Member Name")]
        public string MemberName { get; set; }

        private DateTime orderDate;
        [DisplayName("Order Date")]
        public DateTime OrderDate {
            get => orderDate.Date;
            set => orderDate = value;
        }

        private decimal orderTotal;
        [DisplayName("Order Total")]
        public decimal OrderTotal {
            get => Math.Round(orderTotal, 2);
            set => orderTotal = value;
        }
    }
}
