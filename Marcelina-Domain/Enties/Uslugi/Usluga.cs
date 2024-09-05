﻿using System.ComponentModel.DataAnnotations;

namespace Marcelina_Domain.Uslugi
{
    public class Usluga
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }
        public string? Price { get; set; }
        public string? Category { get; set; }
    }
}