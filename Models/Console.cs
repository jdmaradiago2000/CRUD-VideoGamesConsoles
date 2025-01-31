﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CRUD_VideoGamesConsoles.Models
{
    public class Console
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ConsoleID { get; set; }

        public string Name { get; set; }

        public int BrandID { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Teraflops { get; set; }

        [ForeignKey("BrandID")]
        public virtual Brand Brand { get; set; }
    }
}
