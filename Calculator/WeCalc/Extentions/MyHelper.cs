using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WeCalc.Extentions
{
    public static class MyHelper
    {
        public static MvcHtmlString ListerFlat(this HtmlHelper<string> html, string[] items)
        {
            var ul = new TagBuilder("ul");
            foreach (var item in items)
            {
                var li = new TagBuilder("li");
                li.InnerHtml = item;

                ul.InnerHtml += li;
            }
            
            return MvcHtmlString.Create(ul.ToString());
        } 
    }
}