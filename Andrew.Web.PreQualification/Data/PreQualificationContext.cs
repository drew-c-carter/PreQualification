using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Andrew.Web.PreQualification.Models.PreQualModels.CcModels;
using Microsoft.EntityFrameworkCore.Design;

namespace Andrew.Web.PreQualification.Data
{
    public class PreQualificationContext : DbContext
    {
        public PreQualificationContext (DbContextOptions<PreQualificationContext> options)
            : base(options)
        {
        }

		public DbSet<Andrew.Web.PreQualification.Models.PreQualModels.CcModels.CardApplication> CardApplication { get; set; }

        public DbSet<Andrew.Web.PreQualification.Models.PreQualModels.CcModels.Card> Card { get; set; }

        public DbSet<Andrew.Web.PreQualification.Models.PreQualModels.CcModels.CardApplicationResult> CardApplicationResult { get; set; }
    }
	
}
