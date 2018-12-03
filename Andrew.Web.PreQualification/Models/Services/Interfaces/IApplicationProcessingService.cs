using Andrew.Web.PreQualification.Models.PreQualModels.CcModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Andrew.Web.PreQualification.Models.Services.Interfaces
{
    public interface IApplicationProcessingService
    {
		Task ProcessApplication(CardApplication creditApplication);

	}
}
