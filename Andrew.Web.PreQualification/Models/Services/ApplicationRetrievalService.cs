using Andrew.Web.PreQualification.Data.Interfaces.CcInterfaces;
using Andrew.Web.PreQualification.Models.PreQualModels.CcModels;
using Andrew.Web.PreQualification.Models.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Andrew.Web.PreQualification.Models.Services
{
	public class ApplicationRetrievalService : IApplicationRetrievalService
	{
		private ICardApplicationRepository _cardApplicationRepository;

		public ApplicationRetrievalService(ICardApplicationRepository cardApplicationRepository)
		{
			_cardApplicationRepository = cardApplicationRepository;
		}

		public async Task<CardApplication> RetrieveApplication(long id, string verificationToken)
		{
			var cardApplication = await _cardApplicationRepository.GetApplication((long)id);
			if (cardApplication == null)
			{
				throw new ArgumentException("Application does not exist.");
			}

			if (string.IsNullOrWhiteSpace(cardApplication.ValidationToken) || cardApplication.ValidationToken != verificationToken)
			{
				cardApplication = null;
				throw new AccessViolationException("Unauthorised request.");
			}
			return cardApplication;
		}
	}
}
