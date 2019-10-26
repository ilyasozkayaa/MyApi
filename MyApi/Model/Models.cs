using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi.Model
{
    public class Models
    {
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }

    [StringLength(50)]
    public string Description { get; set; }

    [Required]
    public bool isActive { get; set; } = true;

    public int TrademarkId { get; set; }





    [ForeignKey("TrademarkId")]
    public virtual Trademark Trademark { get; set; }

    public virtual List<Adverts> Adverts { get; set; }

    public override string ToString()
    {
      return Name;
    }
  }
}
