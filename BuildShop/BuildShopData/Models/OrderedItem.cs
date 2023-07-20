using System;
using System.Collections.Generic;

namespace BuildShopDataAccessLayer
{
    public partial class OrderedItem
    {
        public Guid OrderId { get; set; }
        public int Item { get; set; }

        public virtual Order Order { get; set; } = null!;
    }
}
