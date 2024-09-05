using System.ComponentModel.DataAnnotations;

namespace Marcelina_Domain.Enties.Szkolenia
{
    public class Szkolenie
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }
        public string? Price { get; set; }
        public string? Category { get; set; }
    }
}