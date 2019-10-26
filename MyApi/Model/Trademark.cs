using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi.Model
{
    public class Trademark
    {
    [Key]
    public int Id { get; set; }
    [Required, StringLength(50)]
    public string Name { get; set; }
    [StringLength(50)]
    public string Description { get; set; }

    [Required]
    public bool isActive { get; set; } = true;
    [Required]
    public int SubCategoryId { get; set; }





    [ForeignKey("SubCategoryId")]
    public virtual SubCategory SubCategory { get; set; }

    public virtual List<Models> Models { get; set; }

    public virtual List<Adverts> Adverts { get; set; }

    public override string ToString()
    {
      return Name;
    }
  }

}
