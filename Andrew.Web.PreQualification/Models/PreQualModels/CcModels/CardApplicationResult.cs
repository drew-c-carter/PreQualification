using Andrew.Web.PreQualification.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Andrew.Web.PreQualification.Models.PreQualModels.CcModels
{
    public class CardApplicationResult
    {
		public long ID { get; set; }
		[ForeignKey("Card")]
		public long CardID { get; set; }
		[ForeignKey("CardApplication")]
		public long ApplicationID { get; set; }
		[Display(Name = "Card")]
		[StringLength(150)]
		public string CardName { get; set; }
		[Display(Name = "APR%")]
		[Column(TypeName = "decimal(18, 6)")]
		public decimal Apr { get; set; }
		[Display(Name = "Provider message")]
		[StringLength(400)]
		public string PromotionalMessage { get; set; }
		public bool Accepted { get; set; }


		public CardApplication CardApplication { get; set; }
		public Card Card { get; set; }

		public CardApplicationResult() { }

		public CardApplicationResult(Card creditProduct, ICreditApplication creditApplication, bool acceptance)
		{
			CardID = creditProduct.ID;
			ApplicationID = creditApplication.ID;
			CardName = creditProduct.CardName;
			Apr = creditProduct.Apr;
			PromotionalMessage = creditProduct.PromotionalMessage;
			Accepted = acceptance;
		}
	}
}
