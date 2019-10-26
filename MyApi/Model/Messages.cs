using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi.Model
{
    public class Messages
    {
    [Key]
    public int Id { get; set; }
    [Required, MaxLength(50)]
    public string SenderUserId { get; set; }
    [Required, MaxLength(50)]
    public string ReceipentUserId { get; set; }
    [Required]
    public DateTime SendDate { get; set; }
    [Required, MaxLength(250)]
    public string MessageContent { get; set; }
    [Required]
    public bool IsRead { get; set; }
    [Required]
    public int AdvertsId { get; set; }
  }
}
