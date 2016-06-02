using FlatRent.Entities;
using FlatRent.Web.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlatRent.Web.Helpers
{
    public static class FacilityHelper
    {
        public static async System.Threading.Tasks.Task<MvcHtmlString> CreateMultiSelect(this HtmlHelper html)
        {
            TagBuilder ul = new TagBuilder("<select multiple>");
            IEnumerable<Facility> facilities = await ApiContacter.GetFacilities();
            foreach (string fac in facilities.Select(i => i.Type))
            {
                TagBuilder li = new TagBuilder("option");
                li.SetInnerText(fac);
                ul.InnerHtml += li.ToString();
            }
            return new MvcHtmlString(ul.ToString());
        }
    }
}