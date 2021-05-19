using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class Model
    {
        [Key] public int Id { get; set; }
        [Required]
        [MaxLength(64)]
        public string Name { get; set; }

        [Required]
        public string StaticImageUrl { get; set; }
        [Required]
        public string OpenLensUrl { get; set; }
        [Required]
        public string CloseLensUrl { get; set; }
        public string DefaultUsername { get; set; }
        public string DefaultPassword { get; set; }
    }
}