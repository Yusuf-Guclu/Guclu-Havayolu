using System.ComponentModel.DataAnnotations;

namespace Havayolu.Models.Domain
{
    public class Kart
    {
        [Required]
        [Key]
        public int id { get; set; }
        [Required]
        public string kullaniciAdi { get; set; }
        [Required]
        public string kartNumarasi { get; set; }
        [Required]
        public string ayYil { get; set; }
        [Required]
        public string cvv { get; set; }

        public bool onay { get; set; }
    }
}
