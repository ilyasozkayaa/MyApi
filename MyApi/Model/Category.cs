using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi.Model
{
    public class Category
    {
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(50)]
    public string Name { get; set; }

    [StringLength(50)]
    public string Description { get; set; }

    [Required]
    public bool IsActive { get; set; } = true;







    public virtual List<SubCategory> SubCategories { get; set; }
    public virtual List<Adverts> Adverts { get; set; }

    public override string ToString()
    {
      return Name;
    }
  }
}
