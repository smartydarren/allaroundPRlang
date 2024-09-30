using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using ConsoleProject.Models;

namespace ConsoleAppLearning.LearnConcepts.Data
{
    [Table("Master_Product")]
    internal class Master_Product
    {
        public int Id { get; set; }
        public string Product { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        [ForeignKey("CreatedBy")]
        public Users? CreUser { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public int? UpdatedBy { get; set; }

        public bool Enabled { get; set; }

        public string? createdUsername { get; set; }
    }
}
