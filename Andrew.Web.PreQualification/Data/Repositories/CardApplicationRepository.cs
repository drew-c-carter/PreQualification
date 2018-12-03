using Andrew.Web.PreQualification.Data.Interfaces.CcInterfaces;
using Andrew.Web.PreQualification.Models.PreQualModels.CcModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Andrew.Web.PreQualification.Data.Repositories
{
	public class CardApplicationRepository : ICardApplicationRepository, IDisposable
	{
		private PreQualificationContext _context;
		private bool _disposed = false;

		public CardApplicationRepository(PreQualificationContext context)
		{
			this._context = context;
		}

		public Task<CardApplication> GetApplication(long id)
		{
			return _context.CardApplication.FindAsync(id);
		}

		public void InsertApplication(CardApplication cardApplication)
		{
			_context.CardApplication.Add(cardApplication);
		}
		
		public void UpdateApplication(CardApplication cardApplication)
		{
			_context.Entry(cardApplication).State = EntityState.Modified;
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
