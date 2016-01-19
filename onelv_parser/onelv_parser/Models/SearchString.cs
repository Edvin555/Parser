using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace onelv_parser.Models
{
    public class SearchString
    {
        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [RegularExpression(@"(?!.*<[^>]*).*", ErrorMessage = "Sorry html tags are not allowed")]
        public string searchString { get; set; }
    }
}