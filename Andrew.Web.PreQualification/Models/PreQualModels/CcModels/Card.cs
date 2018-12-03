using Andrew.Web.PreQualification.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Andrew.Web.PreQualification.Models.PreQualModels.CcModels
{
	public class Card : CreditProduct
	{
		public long ID { get; set; }
		[Display(Name = "Card")]
		[StringLength(150)]
		public string CardName { get; set; }
		[Display(Name = "APR%")]
		[Column(TypeName = "decimal(18, 6)")]
		public decimal Apr { get; set; }
		[Display(Name = "Message from card provider")]
		[StringLength(400)]
		public string PromotionalMessage { get; set; }
		public override int MinAgeMonths { get; set; }
		public override int MaxAgeMonths { get; set; }
		[Column(TypeName = "decimal(18, 2)")]
		public override decimal MinIncomeGbp { get; set; }
		[Column(TypeName = "decimal(18, 2)")]
		public override decimal MaxIncomeGbp { get; set; }


	}
}
