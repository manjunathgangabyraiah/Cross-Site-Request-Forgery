using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace BusinessLayer
{
	[ValidateAntiForgeryToken]
	public class Employee
	{
		public int ID { get; set; }

		public string Name { get; set; }
		public string Gender { get; set; }


		[Required]


		[StringLength(30, ErrorMessage = "The {0} must be atleast {2} characters long.", MinimumLength = 6)]
		public string City { get; set; }
		[Required]
		public DateTime? DateOfBirth { get; set; }


	}


	public class CustomValidationclass : ValidationAttribute
	{
		public static ValidationResult Compare(string value)
		{

			if (value == "Chicago")
				return ValidationResult.Success;
			else
				return new ValidationResult("the value is not good");
		}
	}

}