using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class School
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Camera> Cameras { get; set; }
    }
}