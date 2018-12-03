using Andrew.Web.PreQualification.Models.Interfaces;
using Andrew.Web.PreQualification.Models.PreQualModels.CcModels;
using Andrew.Web.PreQualification.Models.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Andrew.Web.PreQualification.Tests.Models.PreQualModels.CcModels
{
    public static class CardApplicationTestExtensionMethods
    {

		public static CardApplication SetupWithDefaultValues()
		{
			CardApplication creditApplication = new CardApplication() { DateOfBirth = System.DateTime.Now.Date, AnnualIncomeGbp = 0 };
			return creditApplication;
		}

		public static CardApplication PrepareCardApplicationWithDob(this CardApplication application, DateTime dob)
		{
			application.DateOfBirth = dob;
			return application;
		}

		public static CardApplication PrepareCardApplicationWithAnnualIncome(this CardApplication application, decimal income)
		{
			application.AnnualIncomeGbp = income;
			return application;
		}

		
	}
}
