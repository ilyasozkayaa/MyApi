using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi.Model
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Bu alan zorunludur!")]
        public string UserName { get; set; }
        [Required(ErrorMessage ="Bu alan zorunludur!")]
        public string Password { get; set; }
    }
}
