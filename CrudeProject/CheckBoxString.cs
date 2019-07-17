using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace CrudeProject
{
    public static class CheckBoxString
    {
        public static MvcHtmlString CheckBoxStringFor<TModel>(this HtmlHelper<TModel> html, Expression<Func<TModel, string>> expression)
        {
            // get the name of the property
            string[] propertyNameParts = expression.Body.ToString().Split('.');
            string propertyName = propertyNameParts.Last();

            // get the value of the property
            Func<TModel, string> compiled = expression.Compile();
            string booleanStr = compiled(html.ViewData.Model);

            // convert it to a boolean
            bool isChecked = false;
            Boolean.TryParse(booleanStr, out isChecked);

            TagBuilder checkbox = new TagBuilder("input");
            checkbox.MergeAttribute("id", propertyName);
            checkbox.MergeAttribute("name", propertyName);
            checkbox.MergeAttribute("type", "checkbox");
            checkbox.MergeAttribute("value", "true");
            if (isChecked)
                checkbox.MergeAttribute("checked", "checked");

            TagBuilder hidden = new TagBuilder("input");
            hidden.MergeAttribute("name", propertyName);
            hidden.MergeAttribute("type", "hidden");
            hidden.MergeAttribute("value", "false");

            return MvcHtmlString.Create(checkbox.ToString(TagRenderMode.SelfClosing) + hidden.ToString(TagRenderMode.SelfClosing));
        }

        public static MvcHtmlString CheckBoxIntFor<TModel>(this HtmlHelper<TModel> html, Expression<Func<TModel, int>> expression, object htmlAttributes)
        {
            // get the name of the property
            string[] propertyNameParts = expression.Body.ToString().Split('.');

            // create name and id for the control
            string controlId = String.Join("_", propertyNameParts.Skip(1));
            string controlName = String.Join(".", propertyNameParts.Skip(1));

            // get the value of the property
            Func<TModel, int> compiled = expression.Compile();
            int booleanSbyte = compiled(html.ViewData.Model);

            // convert it to a boolean
            bool isChecked = booleanSbyte == 1;

            // build input element
            TagBuilder checkbox = new TagBuilder("input");
            checkbox.MergeAttribute("id", controlId);
            checkbox.MergeAttribute("name", controlName);
            checkbox.MergeAttribute("type", "checkbox");

            if (isChecked)
            {
                checkbox.MergeAttribute("checked", "checked");
                checkbox.MergeAttribute("value", "1");
            }
            else
            {
                checkbox.MergeAttribute("value", "0");
            }
            SetStyle(checkbox, htmlAttributes);

            // script to handle changing selection
            string script = "<script>" +
                                "$('#" + controlId + "').change(function () { " +
                                    "if ($('#" + controlId + "').is(':checked')) " +
                                        "$('#" + controlId + "').val('1'); " +
                                    "else " +
                                        "$('#" + controlId + "').val('0'); " +
                                "}); " +
                            "</script>";

            return MvcHtmlString.Create(checkbox.ToString(TagRenderMode.SelfClosing) + script);
        }

        private static void SetStyle(TagBuilder control, object htmlAttributes)
        {
            if (htmlAttributes == null)
                return;

            // get htmlAttributes
            Type t = htmlAttributes.GetType();
            PropertyInfo classInfo = t.GetProperty("class");
            PropertyInfo styleInfo = t.GetProperty("style");
            string cssClasses = classInfo?.GetValue(htmlAttributes)?.ToString();
            string style = styleInfo?.GetValue(htmlAttributes)?.ToString();

            if (!string.IsNullOrEmpty(style))
                control.MergeAttribute("style", style);
            if (!string.IsNullOrEmpty(cssClasses))
                control.AddCssClass(cssClasses);
        }
    }
}