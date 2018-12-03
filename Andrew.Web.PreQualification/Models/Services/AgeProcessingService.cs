using Andrew.Web.PreQualification.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Andrew.Web.PreQualification.Models.Services
{
	public class AgeProcessingService : IAgeMonthsCalculator
	{
		private DateTime _dob;
		private DateTime _matchDate;

		public AgeProcessingService()
		{
			SetMatchDate(DateTime.Now.Date);
		}

		public void SetBirthdate(DateTime birthDate)
		{
			_dob = birthDate;
		}

		public void SetMatchDate(DateTime matchDate)
		{
			_matchDate = matchDate;
		}

		public decimal GetAge()
		{
			int inMonthSwitch = _matchDate.Day < _dob.Day ? -1 : 0;
			return ((_matchDate.Year - _dob.Year) * 12) + (_matchDate.Month - _dob.Month) + inMonthSwitch;
		}

	}
}
