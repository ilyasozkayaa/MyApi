using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi.Model
{
    public class Adverts
    {
    [Key]
    public int Id { get; set; }

    [StringLength(200), Required(ErrorMessage = "Başlık alanı doldurulmalıdır")]
    public string Title { get; set; }

    [DataType(DataType.Html)]
    [Required(ErrorMessage = "Açıklama alanı doldurulmalıdır")]
    public string Description { get; set; }

    [Required]
    public int View { get; set; } = 0;

    [DefaultValue(false)]
    public bool IsConfirmed { get; set; } = false;

    [DefaultValue(false)]
    public bool IsSold { get; set; } = false;

    [DefaultValue(false)]
    public bool IsDeleted { get; set; } = false;

    public int BidsCount { get; set; } = 0;

    [Required]
    public bool Warranty { get; set; } = false;

    [Required]
    public DateTime ReleaseDate { get; set; } = System.DateTime.Now;

    [Required]
    public int CategoryId { get; set; }

    [Required]
    public int SubCategoryId { get; set; }

    [Required]
    public int TrademarkId { get; set; }

    [Required]
    public int ModelId { get; set; }

    [Required]
    public int ColorId { get; set; }

    [Required]
    public int ImagesId { get; set; }

    [Required]
    public string UserId { get; set; }







    [ForeignKey("SubCategoryId")]
    public virtual SubCategory SubCategory { get; set; }

    [ForeignKey("TrademarkId")]
    public virtual Trademark Trademark { get; set; }

    [ForeignKey("ModelId")]
    public virtual Models Model { get; set; }

    [ForeignKey("ColorId")]
    public virtual Color Color { get; set; }

    [ForeignKey("ImagesId")]
    public virtual Images Images { get; set; }

    [ForeignKey("CategoryId")]
    public virtual Category Category { get; set; }

    [ForeignKey("UserId")]
    public virtual ApplicationUser User { get; set; }

  }
}
