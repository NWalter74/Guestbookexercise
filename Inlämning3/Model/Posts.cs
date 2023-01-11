using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inlämning3.Model
{
    public class Posts
    {
        [Key]       //creates an ID value automatically
        public int Id { get; set; }

        [Required]
        public string Namn { get; set; }
        public string Rubrik { get; set; }
        public string Inlägg { get; set; }
    }
}
