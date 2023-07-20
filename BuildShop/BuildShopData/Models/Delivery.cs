using System;
using System.Collections.Generic;

namespace BuildShopDataAccessLayer
{
    public partial class Delivery
    {
        public Guid OrderedId { get; set; }
        public string Address { get; set; } = null!;

        public virtual Order Ordered { get; set; } = null!;
    }
}
