using Andrew.Web.PreQualification.Models.PreQualModels.CcModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Andrew.Web.PreQualification.Data.Initializers
{
	public static class SeedCards
	{
		public static void Initialize(IServiceProvider serviceProvider)
		{
			using (var context = new PreQualificationContext(
				serviceProvider.GetRequiredService<DbContextOptions<PreQualificationContext>>()))
			{
				//don't re-seed if any present
				if (context.Card.Any())
				{
					return;
				}

				context.Card.AddRange(
					new Card() {
						CardName = "Vanquis",
						Apr = 39.9m,
						MinAgeMonths = 216,
						MaxAgeMonths = 2400,
						MinIncomeGbp = 0,
						MaxIncomeGbp = 29999.99m,
						PromotionalMessage = "Rebuild your credit score with our award winning credit card!"
						
					},
					new Card() {
						CardName="Barclaycard",
						Apr=6.9m,
						MinAgeMonths=216,
						MaxAgeMonths=2400,
						MinIncomeGbp=30000,
						MaxIncomeGbp=Int32.MaxValue,
						PromotionalMessage="Barclaycard was the first provider to offer a credit card in Britain"
					}
				);
				context.SaveChanges();
			}

		}
	}
}
