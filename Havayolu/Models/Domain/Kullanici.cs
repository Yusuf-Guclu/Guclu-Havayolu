using System.ComponentModel.DataAnnotations;

namespace Havayolu.Models.Domain
{
    public class Kullanici
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        public string adi { get; set; }

        [Required]
        public string soyadi { get; set; }

        [Required]
        public string e_posta { get; set; }

        [Required]
        public string telefon { get; set; } //telefon numarası yazarken araya boşluk koyanlar için string, int boşluk kabul etmez.

        [Required]
        [DataType(DataType.Password)]
        public string sifre { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("sifre", ErrorMessage = "Şifreler uyuşmuyor.")]
        public string sifre_tekrar { get; set; }
    }
}
