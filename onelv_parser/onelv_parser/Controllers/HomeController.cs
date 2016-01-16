using HtmlAgilityPack;
using onelv_parser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace onelv_parser.Controllers
{
    public class HomeController : Controller
    {

        //public const int pageCount = 2;
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }

        
        [HttpPost]
        public ActionResult Search(string searchString)

        {
            //Response.BufferOutput = true;
           // Response.Redirect("http://www.1a.lv");

          
            string url = "http://www.1a.lv/telefoni_plansetdatori/mobilie_telefoni/mobile_phones";
            var html1 = new HtmlDocument();
            html1.LoadHtml(new WebClient().DownloadString(url));
            var headRoot = html1.DocumentNode;

            var p = headRoot.Descendants("div").Where(n => n.GetAttributeValue("class", "").Equals("w2")).First()
                   .Descendants("li").Where(n => n.GetAttributeValue("class", "").Equals("visible-on-small-resolution")).Last();
            int pageCount = int.Parse(p.InnerText);

            var list = new List<MobilePhone>();

            for (int i = 1; i < (pageCount + 1); i++)
            {
                url = "http://www.1a.lv/telefoni_plansetdatori/mobilie_telefoni/mobile_phones";
                url = url + "/" + i.ToString();

                var html = new HtmlDocument();
                html.LoadHtml(new WebClient().DownloadString(url));
                var root = html.DocumentNode;

                var parents = root.Descendants("div").Where(n => n.GetAttributeValue("class", "").Equals("area")).ToArray();
                                                     //.ToList().Descendants("a").First();
                

                foreach (var parent in parents)
                {
                    var phone = new MobilePhone();
                    var brand = parent.Descendants("div").Where(n => n.GetAttributeValue("class", "").Equals("p-content")).First().Descendants("a").First();
                    var href = brand.GetAttributeValue("href", "");

                    var price = parent.Descendants("div").Where(n => n.GetAttributeValue("class", "").Equals("p-info")).First().Descendants("span").First();

                    href = "http://www.1a.lv" + href;
                    phone.Price = decimal.Parse(price.InnerText.ToString().Replace("." , ","))/100;
                    phone.Name = brand.InnerText.ToString();
                    phone.Url = href.ToString();
                    phone.Store = "www.1a.lv";
                    list.Add(phone);

                }
            


                

            }

            list = list.OrderBy(i => i.Price).ToList();
            if (!string.IsNullOrEmpty(searchString))
            {
                list = list.Where(i => i.Name.ToLower().Contains(searchString.ToLower())).ToList();
            }

           // ViewBag.brand = list;


            return View(list);
        }
	}
}