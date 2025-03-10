﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Models
{
    [Table("PreliminarySystems")]
    public class PreliminarySystem : Entity
    {
        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }
    }
}
