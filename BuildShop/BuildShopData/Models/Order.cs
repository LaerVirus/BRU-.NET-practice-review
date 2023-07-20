using System;
using System.Collections.Generic;

namespace BuildShopDataAccessLayer
{
    public partial class Order
    {
        public Guid Id { get; set; }
        public string ClientMobilePhone { get; set; } = null!;
        public string PaymentMethod { get; set; } = null!;
    }
}
