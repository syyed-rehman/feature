using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Artist
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Artist name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        public string? Name { get; set; }       
    }
}
