using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Andrew.Web.PreQualification.Models.Interfaces
{
    public interface IAgeMonthsCalculator
    {
		void SetBirthdate(DateTime birthDate);
		void SetMatchDate(DateTime matchDate);
		decimal GetAge();
    }
}
