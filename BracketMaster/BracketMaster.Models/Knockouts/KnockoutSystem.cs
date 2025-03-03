using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Models
{
    [Table("KnockoutSystems")]
    public class KnockoutSystem : Entity, IKnockoutSystem
    {
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }

        // This part is needed to be overriten in all of the Knockout Logic classes
        public virtual void StartKnockout()
        {
            //throw new NotImplementedException();
        }
    }
}
