using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi.Model
{
    public class SubCategory
    {
    [Key]
    public int Id { get; set; }
    [Required, StringLength(50)]
    public string Name { get; set; }
    [Required]
    public int CategoryId { get; set; }

    [StringLength(50)]
    public string Description { get; set; }
    [Required]
    public bool IsActive { get; set; } = true;








    [ForeignKey("CategoryId")]
    public virtual Category Category { get; set; }

    public virtual List<Trademark> Trademarks { get; set; }

    public virtual List<Adverts> Adverts { get; set; }

    public override string ToString()
    {
      return Name;
    }
  }
}
