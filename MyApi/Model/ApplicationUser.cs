using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi.Model
{
  public class ApplicationUser : IdentityUser
  {
    public int Point { get; set; }
    public bool IsActive { get; set; } = true;




    public virtual List<CustomerAddress> CustomerAddresses { get; set; }
    public virtual List<Adverts> Adverts { get; set; }
  }
}
