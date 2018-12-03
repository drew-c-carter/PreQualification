using Andrew.Web.PreQualification.Data.Interfaces.CcInterfaces;
using Andrew.Web.PreQualification.Models.PreQualModels.CcModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Andrew.Web.PreQualification.Data.Repositories
{
    public class CardApplicationResultRepository : ICardApplicationResultRepository, IDisposable
    {
		private PreQualificationContext _context;
		private bool _disposed = false;

		public CardApplicationResultRepository(PreQualificationContext context)
		{
			this._context = context;
		}

		public IQueryable<CardApplicationResult> GetByApplication(long applicationId)
		{
			return _context.CardApplicationResult.Where(a => a.ApplicationID == applicationId && a.Accepted);
		}

		public void InsertApplicationResult(CardApplicationResult result)
		{
			_context.CardApplicationResult.Add(result);
		}




		public async Task Save()
		{
			await _context.SaveChangesAsync();
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		public virtual void Dispose(bool disposing)
		{
			if (!this._disposed)
			{
				if (disposing)
				{
					_context.Dispose();
				}
			}
			this._disposed = true;
		}

	}
}
