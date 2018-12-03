using Andrew.Web.PreQualification.Models.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Andrew.Web.PreQualification.Tests.Services
{
	[TestClass]
	public class AgeProcessingServiceTests
    {
		[TestMethod]
		public void TestAgeMonthsWithinYear()
		{
			DateTime birthDate = new DateTime(2018, 2, 12);
			DateTime matchDate = new DateTime(2018, 11, 5);

			AgeProcessingService sut = new AgeProcessingService();
			sut.SetBirthdate(birthDate);
			sut.SetMatchDate(matchDate);

			decimal calculatedAge = sut.GetAge();
			Assert.AreEqual(calculatedAge, 8);

		}

		[TestMethod]
		public void TestAgeMonthsWithinYearNotEnoughInMonthToCount()
		{
			DateTime birthDate = new DateTime(2018, 2, 12);
			DateTime matchDate = new DateTime(2018, 11, 5);

			AgeProcessingService sut = new AgeProcessingService();
			sut.SetBirthdate(birthDate);
			sut.SetMatchDate(matchDate);

			decimal calculatedAge = sut.GetAge();
			Assert.AreEqual(calculatedAge, 8);

		}

		[TestMethod]
		public void TestAgeMonthsWithinYearEnoughInMonthToCount()
		{
			DateTime birthDate = new DateTime(2018, 2, 12);
			DateTime matchDate = new DateTime(2018, 11, 20);

			AgeProcessingService sut = new AgeProcessingService();
			sut.SetBirthdate(birthDate);
			sut.SetMatchDate(matchDate);

			decimal calculatedAge = sut.GetAge();
			Assert.AreEqual(calculatedAge, 9);

		}
		[TestMethod]
		public void TestAgeZero()
		{
			DateTime birthDate = new DateTime(2018, 2, 12);
			DateTime matchDate = new DateTime(2018, 2, 20);

			AgeProcessingService sut = new AgeProcessingService();
			sut.SetBirthdate(birthDate);
			sut.SetMatchDate(matchDate);

			decimal calculatedAge = sut.GetAge();
			Assert.AreEqual(calculatedAge, 0);

		}

		[TestMethod]
		public void TestAgeMonthsSpanningYears()
		{
			DateTime birthDate = new DateTime(2017, 2, 12);
			DateTime matchDate = new DateTime(2018, 2, 20);

			AgeProcessingService sut = new AgeProcessingService();
			sut.SetBirthdate(birthDate);
			sut.SetMatchDate(matchDate);

			decimal calculatedAge = sut.GetAge();
			Assert.AreEqual(calculatedAge, 12);
		}

		[TestMethod]
		public void TestAgeMonthsWithDobMonthAfterMatchMonthInDifferentYear()
		{
			DateTime birthDate = new DateTime(2017, 8, 12);
			DateTime matchDate = new DateTime(2018, 2, 20);

			AgeProcessingService sut = new AgeProcessingService();
			sut.SetBirthdate(birthDate);
			sut.SetMatchDate(matchDate);

			decimal calculatedAge = sut.GetAge();
			Assert.AreEqual(calculatedAge, 6);
		}

		[TestMethod]
		public void TestAgeMonthsWithDobMonthAfterMatchMonthInDifferentYearNotIncludingCurrentMonth()
		{
			DateTime birthDate = new DateTime(2017, 8, 12);
			DateTime matchDate = new DateTime(2018, 2, 5);

			AgeProcessingService sut = new AgeProcessingService();
			sut.SetBirthdate(birthDate);
			sut.SetMatchDate(matchDate);

			decimal calculatedAge = sut.GetAge();
			Assert.AreEqual(calculatedAge, 5);
		}

	}
}
