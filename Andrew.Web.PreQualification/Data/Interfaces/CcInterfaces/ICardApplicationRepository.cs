using Andrew.Web.PreQualification.Models.PreQualModels.CcModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Andrew.Web.PreQualification.Data.Interfaces.CcInterfaces
{
    public interface ICardApplicationRepository : IDisposable
    {
		Task<CardApplication> GetApplication(long id);
		void InsertApplication(CardApplication cardApplication);
		void UpdateApplication(CardApplication cardApplication);
		Task Save();
    }
}
