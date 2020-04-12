using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopAspBack.Models
{
    public class SellEntryDetail
    {
        [Key]
        public int ItemId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string ItemName { get; set; }
        [Required]
        [Column(TypeName = "int")]
        public int Quantity { get; set; }
        [Required]
        [Column(TypeName = "money")]
        public int SellingPrice { get; set; }
    }
}
