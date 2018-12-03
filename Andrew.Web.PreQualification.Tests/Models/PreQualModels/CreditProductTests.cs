using System;
using System.Collections.Generic;
using System.Text;
using Andrew.Web.PreQualification.Models.Interfaces;
using Andrew.Web.PreQualification.Models.PreQualModels;
using Andrew.Web.PreQualification.Models.PreQualModels.CcModels;
using Andrew.Web.PreQualification.Models.Services;
using Andrew.Web.PreQualification.Tests.Models.PreQualModels.CcModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Andrew.Web.PreQualification.Tests.Models.PreQualModels
{
	[TestClass]
	public class CreditProductTests
    {
		

		[TestMethod]
		public void TestMatchCriteriaFalseWhenAgeUnder()
		{
			ICreditApplication creditApplication = CardApplicationTestExtensionMethods.SetupWithDefaultValues().PrepareCardApplicationWithDob(DateTime.Now.Date).PrepareCardApplicationWithAnnualIncome(5);
			IAgeMonthsCalculator ageMonthsCalculator = new AgeProcessingService();
			
			CreditProduct sut = new CreditProduct() { MinAgeMonths=12, MaxAgeMonths=100, MinIncomeGbp=1, MaxIncomeGbp=30 };

			Assert.IsFalse(sut.MeetsCriteria(creditApplication,ageMonthsCalculator));
		}

		[TestMethod]
		public void TestMatchCriteriaTrueWhenAgeWithin()
		{
			IAgeMonthsCalculator ageCalculator = new AgeProcessingService();
			ICreditApplication creditApplication = CardApplicationTestExtensionMethods.SetupWithDefaultValues().PrepareCardApplicationWithDob(DateTime.Now.Date.AddYears(-2)).PrepareCardApplicationWithAnnualIncome(5);
			
			CreditProduct sut = new CreditProduct() { MinAgeMonths = 12, MaxAgeMonths = 100, MinIncomeGbp = 1, MaxIncomeGbp = 30 };

			Assert.IsTrue(sut.MeetsCriteria(creditApplication, ageCalculator));
		}

		[TestMethod]
		public void TestMatchCriteriaFalseWhenAgeOver()
		{
			IAgeMonthsCalculator ageCalculator = new AgeProcessingService();
			ICreditApplication creditApplication = CardApplicationTestExtensionMethods.SetupWithDefaultValues().PrepareCardApplicationWithDob(DateTime.Now.Date.AddYears(-50)).PrepareCardApplicationWithAnnualIncome(5);

			CreditProduct sut = new CreditProduct() { MinAgeMonths = 12, MaxAgeMonths = 100, MinIncomeGbp = 1, MaxIncomeGbp = 30 };

			Assert.IsFalse(sut.MeetsCriteria(creditApplication, ageCalculator));
		}
	}
}
