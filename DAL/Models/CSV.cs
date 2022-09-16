using System.ComponentModel.DataAnnotations;
#pragma warning disable

namespace DAL.Models
{
    public class CSV
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string PersonName { get; set; }
        public int Age { get; set; }
        public string Pet1 { get; set; }
        public string Pet1Type { get; set; }
        public string? Pet2 { get; set; }
        public string? Pet2Type { get; set; }
        public string? Pet3 { get; set; }
        public string? Pet3Type { get; set; }
    }
}
