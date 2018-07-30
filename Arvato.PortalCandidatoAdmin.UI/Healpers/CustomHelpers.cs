namespace System.Web.Mvc
{
    public static class CustomHelpers
    {
        public static IHtmlString CustomCheckBox(this HtmlHelper healper, SelectList listaCheckBox, string id)
        {
            TagBuilder tag = new TagBuilder("div");

            foreach (var item in listaCheckBox)
            {

                TagBuilder tagDiv = new TagBuilder("div");
                tagDiv.AddCssClass("checkbox");
                TagBuilder input = new TagBuilder("input");
                input.Attributes.Add("type", "checkbox");
                input.Attributes.Add("id", "checkbox_" + id + "_" + item.Value);
                input.Attributes.Add("value", item.Value);
                if (item.Selected) input.Attributes.Add("checked", "checked");
                TagBuilder label = new TagBuilder("label");
                label.Attributes.Add("for", "checkbox_" + id + "_" + item.Value);
                label.SetInnerText(item.Text);
                tagDiv.InnerHtml = input.ToString() + " " + label.ToString();
                tag.InnerHtml = tag.InnerHtml + tagDiv.ToString();
            }

            return new MvcHtmlString(tag.ToString());
        }

        public static IHtmlString CustomCheckBox(this HtmlHelper healper, SelectList listaCheckBox, string id, object htmlAttributes)
        {
            TagBuilder tag = new TagBuilder("div");

            foreach (var item in listaCheckBox)
            {

                TagBuilder tagDiv = new TagBuilder("div");
                tagDiv.AddCssClass("checkbox");
                TagBuilder input = new TagBuilder("input");
                input.Attributes.Add("type", "checkbox");
                input.Attributes.Add("id", "checkbox_" + id + "_" + item.Value);
                input.Attributes.Add("value", item.Value);
                if (item.Selected) input.Attributes.Add("checked", "checked");
                TagBuilder label = new TagBuilder("label");
                label.Attributes.Add("for", "checkbox_" + id + "_" + item.Value);
                label.SetInnerText(item.Text);
                tagDiv.InnerHtml = input.ToString() + " " + label.ToString();
                tag.InnerHtml = tag.InnerHtml + tagDiv.ToString();
                tagDiv.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
            }

            return new MvcHtmlString(tag.ToString());
        }
    }
}