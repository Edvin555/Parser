using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Parser_1a.lv.Models
{
    public class MobilePhone
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public string Url { get; set; }
        public string Store { get; set; }
    }

    public class UpdateDate
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
    }
}