using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Andrew.Web.PreQualification.Models.Interfaces
{
    public interface ICreditProduct
    {
		Boolean MeetsCriteria(ICreditApplication creditApplication, IAgeMonthsCalculator ageCalculator);
    }
}
