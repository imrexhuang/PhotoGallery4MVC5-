using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace photoGallery.Utility
{
    public static class Utility4photoGallery
    {

        public static MvcHtmlString bootstrapActionLink(this HtmlHelper htmlHelper, string linkText, string Title, string actionName, string controllerName, string glyphicon, object routeValues = null, object htmlAttributes = null)
        {
            //Exemple of result:
            //<a href="@Url.Action("Edit", new { id = Model.id_rod })">
            //  <i class="glyphicon glyphicon-pencil"></i>
            //  <span>Edit</span>
            //</a>

            var builderI = new TagBuilder("i");
            builderI.MergeAttribute("class", "glyphicon " + glyphicon);
            if (!string.IsNullOrEmpty(Title))
            {
                builderI.MergeAttribute("Title", Title);
            }
            string iTag = builderI.ToString(TagRenderMode.Normal);

            string spanTag = "";
            if (!string.IsNullOrEmpty(linkText))
            {
               
                var builderSPAN = new TagBuilder("span");
                builderSPAN.InnerHtml = " " + linkText;
                spanTag = builderSPAN.ToString(TagRenderMode.Normal);
            }

            //Create the "a" tag that wraps
            var builderA = new TagBuilder("a");

            var requestContext = HttpContext.Current.Request.RequestContext;
            var uh = new UrlHelper(requestContext);

            builderA.MergeAttribute("href", uh.Action(actionName, controllerName, routeValues));

            if (htmlAttributes != null)
            {
                IDictionary<string, object> attributes = new RouteValueDictionary(htmlAttributes);
                builderA.MergeAttributes(attributes);
            }

            builderA.InnerHtml = iTag + spanTag;

            return new MvcHtmlString(builderA.ToString(TagRenderMode.Normal));
        }

        public static MvcHtmlString bootstrapActionLinkAuthorized(this HtmlHelper htmlHelper, string linkText, string Title, string actionName, string controllerName, string glyphicon, string allowRole, object routeValues = null, object htmlAttributes = null)
        {

            var builderI = new TagBuilder("i");
            builderI.MergeAttribute("class", "glyphicon " + glyphicon);
            if (!string.IsNullOrEmpty(Title))
            {
                builderI.MergeAttribute("Title", Title);
            }
            string iTag = builderI.ToString(TagRenderMode.Normal);

            string spanTag = "";
            if (!string.IsNullOrEmpty(linkText))
            {

                var builderSPAN = new TagBuilder("span");
                builderSPAN.InnerHtml = " " + linkText;
                spanTag = builderSPAN.ToString(TagRenderMode.Normal);
            }

            //Create the "a" tag that wraps
            var builderA = new TagBuilder("a");

            var requestContext = HttpContext.Current.Request.RequestContext;
            var uh = new UrlHelper(requestContext);

            builderA.MergeAttribute("href", uh.Action(actionName, controllerName, routeValues));

            if (htmlAttributes != null)
            {
                IDictionary<string, object> attributes = new RouteValueDictionary(htmlAttributes);
                builderA.MergeAttributes(attributes);
            }

            builderA.InnerHtml = iTag + spanTag;
       

            if (string.IsNullOrWhiteSpace(allowRole) == false)
            {
                var roles = new List<string>() { allowRole };
                if (allowRole.Contains(","))
                {
                    roles = allowRole.Split(',').ToList();
                }
                if (roles.Any(role => HttpContext.Current.User.IsInRole(role)))
                {
                    return new MvcHtmlString(builderA.ToString(TagRenderMode.Normal));
                }
            }

            return MvcHtmlString.Empty;
        }

        /// <summary>
        /// Actions the link authorized.
        /// ASP.NET MVC 實戰訓練營 精華版 老師範例程式碼
        /// https://skilltree.my/events/2019/11/30/practical-asp-dot-net-mvc-essential-batch-2
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="linkText">連結文字</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <param name="allowRole">允許的群組（可用逗點分隔）</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString ActionLinkAuthorized(this HtmlHelper htmlHelper, string linkText, string actionName,
            string controllerName, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes,
            string allowRole)
        {
            if (string.IsNullOrWhiteSpace(allowRole) == false)
            {
                var roles = new List<string>() { allowRole };
                if (allowRole.Contains(","))
                {
                    roles = allowRole.Split(',').ToList();
                }
                if (roles.Any(role => HttpContext.Current.User.IsInRole(role)))
                {
                    return htmlHelper.ActionLink(linkText, actionName, controllerName, routeValues, htmlAttributes);
                }
            }

            return MvcHtmlString.Empty;
        }

    }
}