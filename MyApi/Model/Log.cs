using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi.Model
{
  public class Log
  {
    [Key]
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string Exception { get; set; }
    public string Description { get; set; }
  }
}
