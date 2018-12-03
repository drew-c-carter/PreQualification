using Andrew.Web.PreQualification.Data.Interfaces.CcInterfaces;
using Andrew.Web.PreQualification.Models.Interfaces;
using Andrew.Web.PreQualification.Models.PreQualModels.CcModels;
using Andrew.Web.PreQualification.Models.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Andrew.Web.PreQualification.Models.Services
{
    public class ApplicationProcessingService : IApplicationProcessingService
	{
		private ICardRepository _cardRepository;
		private ICardApplicationResultRepository _cardApplicationResultRepository;
		private ICardApplicationRepository _applicationRepository;
		private IAgeMonthsCalculator _ageCalculator;

		public ApplicationProcessingService(ICardRepository cardRepository, ICardApplicationResultRepository cardApplicationResultRepository, ICardApplicationRepository applicationRepository , IAgeMonthsCalculator ageCalculator)
		{
			_cardRepository = cardRepository;
			_cardApplicationResultRepository = cardApplicationResultRepository;
			_applicationRepository = applicationRepository;
			_ageCalculator = ageCalculator;
		}


		public async Task ProcessApplication(CardApplication creditApplication)
		{
			
			_applicationRepository.InsertApplication(creditApplication);
			await _applicationRepository.Save();
			
			

			var availableCards = _cardRepository.GetCards().Result;
			foreach(Card product in availableCards)
			{
				bool acceptance = product.MeetsCriteria(creditApplication, _ageCalculator);
				
				CardApplicationResult result = new CardApplicationResult(product,creditApplication,acceptance);
				_cardApplicationResultRepository.InsertApplicationResult(result);
			}
			await _cardApplicationResultRepository.Save();
			//set to results complete
			creditApplication.ResultsComplete = true;
			_applicationRepository.UpdateApplication(creditApplication as CardApplication);
			await _applicationRepository.Save();
			//return products.AsEnumerable();
		}


    }
}
