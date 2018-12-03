using Andrew.Web.PreQualification.Data.Interfaces.CcInterfaces;
using Andrew.Web.PreQualification.Models.PreQualModels.CcModels;
using Andrew.Web.PreQualification.Models.Services.Interfaces;
using Andrew.Web.PreQualification.ViewModels.Credit;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Andrew.Web.PreQualification.Controllers
{
	public class CardApplicationsController : Controller
    {
        private readonly ICardApplicationRepository _cardApplicationRepository;
		private readonly ICardApplicationResultRepository _applicationResultRepository;
		private readonly IApplicationProcessingService _applicationProcessingService;
		private readonly IApplicationRetrievalService _applicationRetrievalService;


		public CardApplicationsController(ICardApplicationRepository cardApplicationRepository, ICardApplicationResultRepository applicationResultRepository, IApplicationProcessingService applicationProcessingService, IApplicationRetrievalService applicationRetrievalService)
        {
			_cardApplicationRepository = cardApplicationRepository;
			_applicationResultRepository = applicationResultRepository;
			_applicationProcessingService = applicationProcessingService;
			_applicationRetrievalService = applicationRetrievalService;
        }

        // GET: CardApplications
        public async Task<IActionResult> Index()
        {
			RedirectToAction("Create");
			return View(new List<CardApplication>());
        }

        // GET: CardApplications/Details/5/validationToken
		[RequireHttps]
        public async Task<IActionResult> Details(long? id, string validationToken)
        {
            if (id == null)
            {
                return NotFound();
            }

			try
			{
				var cardApplication = await _applicationRetrievalService.RetrieveApplication((long)id, validationToken);

				var applicationResults = _applicationResultRepository.GetByApplication(cardApplication.ID).ToList();

				AvailableCreditViewModel viewModel = new AvailableCreditViewModel() { application = cardApplication, applicationResults = applicationResults };

				return View(viewModel);
			}
			catch(ArgumentException inputExcepteption)
			{
				return NotFound();
			}
			catch(AccessViolationException unauthorisedException)
			{
				return Unauthorized();
			}
			catch(Exception unknownException)
			{
				throw new Exception("An unknown error occurred", unknownException);
				return NotFound();
			}

			
        }

        // GET: CardApplications/Create
		[RequireHttps]
        public IActionResult Create()
        {
            return View();
        }

        // POST: CardApplications/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
		[RequireHttps]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,DateOfBirth,AnnualIncomeGbp")] CardApplication cardApplication)
        {
            if (ModelState.IsValid)
            {
				
				await _applicationProcessingService.ProcessApplication(cardApplication);

                return RedirectToAction(nameof(Details), new { id=cardApplication.ID, validationToken = cardApplication.ValidationToken });
            }
            return View(cardApplication);
        }

		#region not required

		/*
        // GET: CardApplications/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

			var cardApplication = await _cardApplicationRepository.GetApplication((long)id);
            if (cardApplication == null)
            {
                return NotFound();
            }
            return View(cardApplication);
        }

        // POST: CardApplications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("ID,FirstName,LastName,DateOfBirth,AnnualIncomeGbp")] CardApplication cardApplication)
        {
            if (id != cardApplication.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
					_cardApplicationRepository.UpdateApplication(cardApplication);
                    await _cardApplicationRepository.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CardApplicationExists(cardApplication.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cardApplication);
        }*/
		#endregion


		private bool CardApplicationExists(long id)
        {
			var cardApplication = _cardApplicationRepository.GetApplication(id).Result;
			return (cardApplication != null);
        }

		protected override void Dispose(bool disposing)
		{
			_cardApplicationRepository.Dispose();
			base.Dispose(disposing);
		}
	}
}
