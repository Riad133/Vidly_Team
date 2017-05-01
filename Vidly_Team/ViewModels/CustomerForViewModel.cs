using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly_Team.Models;

namespace Vidly_Team.ViewModels
{
    public class CustomerForViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}