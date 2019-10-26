using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi.Model
{
  public class Images
  {
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(30)]
    public string Image1 { get; set; }

    [Required]
    [StringLength(30)]
    public string Image2 { get; set; }

    [Required]
    [StringLength(30)]
    public string Image3 { get; set; }
  }
}
