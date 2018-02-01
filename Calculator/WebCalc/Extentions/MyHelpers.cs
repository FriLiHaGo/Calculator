using CalcDB.NHibernate.Repositories;
using CalcDB.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebCalc.Extentions
{
    public static class MyHelpers
    {
        public static MvcHtmlString ListerFlat(this HtmlHelper html, string[] items)
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

        public static MvcHtmlString Submit(this HtmlHelper html, string value)
        {
            var input = new TagBuilder("input");
            input.MergeAttribute("type", "submit");
            input.AddCssClass("btn btn-success");
            if (!string.IsNullOrEmpty(value))
            {
                input.MergeAttribute("value", value);
            }

            return MvcHtmlString.Create(input.ToString());
        }

        public static string GetFIO(this HtmlHelper html, string name)
        {
            var userRepository = new NHUserRepository();
            var user = userRepository.GetByLogin(name);

            return string.Join(" ", user.FirstName, user.LastName);
        }
    }
}