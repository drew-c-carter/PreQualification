using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Andrew.Web.PreQualification.Models.Interfaces
{
    public interface ICreditApplication
    {
		long ID { get; }
		string FirstName { get; }
		string LastName { get; }
		DateTime DateOfBirth { get; }
		decimal AnnualIncomeGbp { get; }
		bool ResultsComplete { get; } 
		DateTime SubmissionDate { get; }
		string ValidationToken { get; }

		bool IsApplicationComplete();
		decimal GetApplicantAgeMonths(IAgeMonthsCalculator ageCalculator);
		decimal GetApplicantSalary();
    }
}
