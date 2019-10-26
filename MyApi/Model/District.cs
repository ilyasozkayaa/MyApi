using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi.Model
{
  public class District
  {
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public int CityId { get; set; }




    [ForeignKey("CityId")]
    public virtual City City { get; set; }
  }
}
