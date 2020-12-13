using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Expenditures.Models.Category
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}