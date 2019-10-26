using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi.Model
{
  public class Bids
  {
    [Key]
    public int Id { get; set; }

    [Required]
    public string SenderUserID { get; set; }

    [Required]
    public string RecipientUserId { get; set; }

    [Required]
    public int AdvertsId { get; set; }

    [Required]
    public DateTime BidDate { get; set; } = System.DateTime.Now;

    [Required]
    public double Amount { get; set; }

    [Required]
    public string Not { get; set; }
    //public bool IsConfirmed { get; set; }

  }
}
