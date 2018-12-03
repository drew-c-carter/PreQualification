using Andrew.Web.PreQualification.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Andrew.Web.PreQualification.Models.PreQualModels
{
	public class CreditProduct : ICreditProduct
	{
		public virtual int MinAgeMonths { get; set; }
		public virtual int MaxAgeMonths { get; set; }
		public virtual decimal MinIncomeGbp { get; set; }
		public virtual decimal MaxIncomeGbp { get; set; }

		public bool MeetsCriteria(ICreditApplication creditApplication, IAgeMonthsCalculator ageCalculator)
		{
			decimal ageInMonths = creditApplication.GetApplicantAgeMonths(ageCalculator);
			if (ageInMonths < MinAgeMonths || ageInMonths > MaxAgeMonths)
			{
				return false;
			}
			decimal incomeGbp = creditApplication.GetApplicantSalary();
			if (incomeGbp < MinIncomeGbp || incomeGbp > MaxIncomeGbp)
			{
				return false;
			}
			else
			{
				return true;
			}
		}
	}
}
