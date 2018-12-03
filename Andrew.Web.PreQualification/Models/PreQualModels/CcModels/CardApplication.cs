using Andrew.Web.PreQualification.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Andrew.Web.PreQualification.Models.PreQualModels.CcModels
{
	public class CardApplication : ICreditApplication
	{
		
		public long ID { get; set; }

		[Display(Name = "First Name")]
		[StringLength(150,ErrorMessage ="First Name cannot be longer than 150 characters.",MinimumLength =1)]
		public string FirstName { get; set; }

		[Display(Name = "Last Name")]
		[StringLength(150, ErrorMessage = "Last Name cannot be longer than 150 characters.", MinimumLength = 1)]
		public string LastName { get; set; }

		[Display(Name = "Date Of Birth")]
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
		public DateTime DateOfBirth { get; set; }

		[Display(Name = "Annual Income £")]
		[Column(TypeName = "decimal(18, 2)")]
		public decimal AnnualIncomeGbp { get; set; }

		public bool ResultsComplete { get; set; } = false;

		public DateTime SubmissionDate { get; set; } = DateTime.Now;

		[StringLength(150)]
		public string ValidationToken { get; set; } = Guid.NewGuid().ToString();

		[Display(Name = "Name")]
		public string FullName { get { return FirstName + " " + LastName; } }

		public decimal GetApplicantAgeMonths(IAgeMonthsCalculator ageCalculator)
		{
			ageCalculator.SetMatchDate(DateTime.Now);
			ageCalculator.SetBirthdate(DateOfBirth);
			return ageCalculator.GetAge();
		}

		public decimal GetApplicantSalary()
		{
			return AnnualIncomeGbp;
		}

		public bool IsApplicationComplete()
		{
			return AnnualIncomeGbp != 0 && DateOfBirth <= DateTime.Now;
		}
	}
}
