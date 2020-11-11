using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HerosDB.Models
{
    public class SuperPerson
    {
     public int Id{get; set;}
     [DisplayName("Real Name")]
     public string RealName{get;set;}
     public string Alias { get; set; }
     [DisplayName("Hideout")]
     public string HideOut {get; set;}
     public List<SuperPower> SuperPowers { get; set; }

    }
}