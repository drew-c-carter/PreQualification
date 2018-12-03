using Andrew.Web.PreQualification.Data.Interfaces.CcInterfaces;
using Andrew.Web.PreQualification.Models.PreQualModels.CcModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Andrew.Web.PreQualification.Data.Repositories
{
	public class CardRepository : ICardRepository, IDisposable
	{
		private PreQualificationContext _context;
		private bool _disposed = false;

		public CardRepository(PreQualificationContext context)
		{
			_context = context;
		}

		public Task<List<Card>> GetCards()
		{
			return _context.Card.ToListAsync();
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
