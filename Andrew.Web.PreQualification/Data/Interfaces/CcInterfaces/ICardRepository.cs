using Andrew.Web.PreQualification.Models.PreQualModels.CcModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Andrew.Web.PreQualification.Data.Interfaces.CcInterfaces
{
    public interface ICardRepository : IDisposable
	{
		Task<List<Card>> GetCards();
	}
}
