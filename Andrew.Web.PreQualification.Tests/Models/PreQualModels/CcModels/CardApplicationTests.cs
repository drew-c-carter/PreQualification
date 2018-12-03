using System;
using System.Collections.Generic;
using System.Text;
using Andrew.Web.PreQualification.Models.Interfaces;
using Andrew.Web.PreQualification.Models.PreQualModels;
using Andrew.Web.PreQualification.Models.PreQualModels.CcModels;
using Andrew.Web.PreQualification.Models.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Andrew.Web.PreQualification.Tests.Models.PreQualModels.CcModels
{
	[TestClass]
	public class CardApplicationTests
    {
		[TestMethod]
		public void TestCardApplicationSettingIncome()
		{
			decimal incomeToSet = 10000;

			CardApplication sut = CardApplicationTestExtensionMethods.SetupWithDefaultValues().PrepareCardApplicationWithAnnualIncome(incomeToSet);

			Assert.AreEqual(sut.AnnualIncomeGbp, incomeToSet);
		}

		[TestMethod]
		public void TestCardApplicationSettingDob()
		{
			DateTime testingDob = new DateTime(1976, 5, 8);

			CardApplication sut = CardApplicationTestExtensionMethods.SetupWithDefaultValues().PrepareCardApplicationWithDob(testingDob);

			Assert.AreEqual(sut.DateOfBirth, testingDob);
		}


		[TestMethod]
		public void TestCardApplicationComplete()
		{
			DateTime testingDob = new DateTime(1976, 5, 8);

			CardApplication sut = CardApplicationTestExtensionMethods.SetupWithDefaultValues().PrepareCardApplicationWithDob(testingDob).PrepareCardApplicationWithAnnualIncome(30);


			Assert.IsTrue(sut.IsApplicationComplete());
		}

		[TestMethod]
		public void TestCardApplicationInCompleteWithFutureDob()
		{
			DateTime testingDob = DateTime.Now.AddYears(1);

			CardApplication sut = CardApplicationTestExtensionMethods.SetupWithDefaultValues().PrepareCardApplicationWithDob(testingDob).PrepareCardApplicationWithAnnualIncome(30);


			Assert.IsFalse(sut.IsApplicationComplete());
		}

	}

}
