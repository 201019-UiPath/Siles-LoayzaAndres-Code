using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HerosWeb.Models
{
	public class SuperHero
	{
		[Required] //specifies this property is required to be set for input validation
		[DisplayName("Real Name")]
		[DataType(DataType.Text)]
		public string RealName { get; set; }
		[Required]
		//[StringLength(10, ErrorMessage = "Alias should be 2-10 characters", MinimumLength =2)] //max length of string
		[RegularExpression(@"^[a-zA-Z]{2,10}$", ErrorMessage ="Alias should be 2-10 alphabetical letters")] //specifies regex for input validation
		public string Alias { get; set; }
		[DisplayName("Hideout")]
		public string HideOut { get; set; }

		public List<SuperPower> SuperPowers { get; set; }
	}
}
