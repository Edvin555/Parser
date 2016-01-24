using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Parser_1a.lv.Models
{
    public class Search
    {
   
   
        [Required(ErrorMessage = "Field is required")]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
       // [RegularExpression(@"(?!.*<[^>]+).*", ErrorMessage = "Sorry html tags are not allowed")]
        [Display(Name = "query string")]
        [AllowHtml]
        public string SearchString {get; set;}
    }
}
    
