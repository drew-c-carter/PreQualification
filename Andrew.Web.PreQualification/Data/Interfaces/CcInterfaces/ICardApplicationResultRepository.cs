using Andrew.Web.PreQualification.Models.PreQualModels.CcModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Andrew.Web.PreQualification.Data.Interfaces.CcInterfaces
{
    public interface ICardApplicationResultRepository : IDisposable
    {
		IQueryable<CardApplicationResult> GetByApplication(long applicationId);

		void InsertApplicationResult(CardApplicationResult result);
		
		Task Save();
	}
}
