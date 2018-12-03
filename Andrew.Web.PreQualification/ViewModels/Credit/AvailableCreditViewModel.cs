using Andrew.Web.PreQualification.Data.Interfaces.CcInterfaces;
using Andrew.Web.PreQualification.Models.PreQualModels.CcModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Andrew.Web.PreQualification.ViewModels.Credit
{
    public class AvailableCreditViewModel
    {

		public CardApplication application { get; set; }

		public List<CardApplicationResult> applicationResults { get; set; } = new List<CardApplicationResult>();

	}
}
