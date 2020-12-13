using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Expenditures.Models
{
    public class TransactionPostModel
    {
        public int? Id { get; set; }
        public decimal Value { get; set; }
        [MaxLength(24,ErrorMessage = "Max length is 24 symbols")]
        public string Description { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}