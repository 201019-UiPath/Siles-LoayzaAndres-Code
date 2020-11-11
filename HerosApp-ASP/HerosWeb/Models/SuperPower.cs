using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HerosWeb.Models
{
    public class SuperPower
    {
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [DataType(DataType.MultilineText)] //specifies input should be formatted for multiline text box
        public string Description { get; set; }
    }
}