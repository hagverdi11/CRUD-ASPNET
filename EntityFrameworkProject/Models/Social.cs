using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkProject.Models
{
    public class Social : BaseEntity
    {
        [Required (ErrorMessage = "Name can not be empty")]
        [StringLength(50, ErrorMessage ="Max size 50")]
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
