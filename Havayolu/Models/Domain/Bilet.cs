using System.ComponentModel.DataAnnotations;

namespace Havayolu.Models.Domain
{
    public class Bilet
    {
        [Required]
        [Key]
        public int id { get; set; }


        [Required]
        public int kullaniciId { get; set; }
        [Required]
        public string adi { get; set; }
        [Required]
        public string soyadi { get; set; }


        public int ucusId { get; set; }
        [Required]
        public string ucusTuru { get; set; }
        [Required]
        public string nereden { get; set; }
        [Required]
        public string nereye { get; set; }
        [Required]
        public DateTime gidisTarihi { get; set; }
        public DateTime? donusTarihi { get; set; }
        [Required]
        public int fiyat { get; set; }
        [Required]
        public int yetiskin { get; set; }
        [Required]
        public int cocuk { get; set; }
        [Required]
        public int bebek { get; set; }
    }
}
