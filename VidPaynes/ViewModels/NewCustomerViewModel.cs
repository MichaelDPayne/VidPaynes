using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidPaynes.Models;

namespace VidPaynes.ViewModels
{
    public class NewCustomerViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }

        public Customers Customer { get; set; }
    }
}