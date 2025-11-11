using System.ComponentModel.DataAnnotations;

namespace Havayolu.Models.Domain
{
    public class Person
    {
        [Required]
        [Key]
        public int id { get; set; }
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
    }
}
