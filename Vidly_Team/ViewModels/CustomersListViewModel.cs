using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly_Team.Models;

namespace Vidly_Team.ViewModel
{
    public class CustomersListViewModel
    {
        public IEnumerable<Customer> Customers { get; set; }
    }
}