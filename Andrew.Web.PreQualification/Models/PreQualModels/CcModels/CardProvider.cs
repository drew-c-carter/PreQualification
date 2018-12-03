using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Andrew.Web.PreQualification.Models.PreQualModels.CcModels
{
    public class CardProvider
    {
		public long ID { get; set; }
		[Display(Name = "Card Provider")]
		[StringLength(150)]
		public string Name { get; set; }

		public ICollection<Card> Cards { get; set; }
    }
}
