using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi.Model
{
  public class CustomerAddress
  {
    [Key]
    public int Id { get; set; }

    [Required]
    public int CityId { get; set; }

    [Required]
    public int DistrictId { get; set; }

    [Required]
    public string UserId { get; set; }

    [Required]
    public string Address { get; set; }

    [Required]
    [StringLength(50)]
    public string Title { get; set; }

    public bool ısActive { get; set; } = true;




    [ForeignKey("UserId")]
    public virtual ApplicationUser User { get; set; }
  }
}
