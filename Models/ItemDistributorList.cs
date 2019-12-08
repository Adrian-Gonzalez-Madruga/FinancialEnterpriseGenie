using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialEnterpriseGenie.Models
{
    public class ItemDistributorList
    {
        public ICollection<Distributor> DistributorId { get; set; }
        public ICollection<Item> ItemId { get; set; }
        public int Quantity { get; set; }
    }
}
