using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFCoreTileTests.Entity
{
    public class MaterialSpec
    {
        public double Price { get; set; }
        public int GradeId { get; set; }
        public string Notes { get; set; }


    }
}