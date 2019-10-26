using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi.Model
{
  public class City
  {
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }




    public virtual List<District> Districts { get; set; }
  }
}
