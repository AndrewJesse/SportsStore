using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using SportsStore.Models.ViewModels;

namespace SportsStore.Infrastructure {
    [HtmlTargetElement("div", Attributes = "page-model")] 
    public class PageLinkTagHelper : TagHelper { 
        private IUrlHelperFactory urlHelperFactory; 
        public PageLinkTagHelper(IUrlHelperFactory helperFactory) { 
            urlHelperFactory = helperFactory; 
        } 
        [ViewContext]
        [HtmlAttributeNotBound] 
        public ViewContext? ViewContext { get; set; }
        public PagingInfo? PageModel { get; set; }
        public string? PageAction { get; set; }

        // This method processes the TagHelperContext and TagHelperOutput for custom pagination functionality.
        public override void Process(TagHelperContext context,
            TagHelperOutput output)
        {
            // Ensure both ViewContext and PageModel are not null.
            if (ViewContext != null && PageModel != null)
            {
                // Create an IUrlHelper instance using the urlHelperFactory.
                IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);

                // Initialize a new TagBuilder for the "div" element.
                TagBuilder result = new TagBuilder("div");

                // Iterate through each page in the PageModel.
                for (int i = 1; i <= PageModel.TotalPages; i++)
                {
                    // Create a new TagBuilder for the "a" element (anchor tag).
                    TagBuilder tag = new TagBuilder("a");

                    // Set the "href" attribute of the anchor tag to the appropriate URL.
                    tag.Attributes["href"] = urlHelper.Action(PageAction,
                        new { productPage = i });

                    // Set the inner HTML of the anchor tag to the page number.
                    tag.InnerHtml.Append(i.ToString());

                    // Append the anchor tag to the "div" element.
                    result.InnerHtml.AppendHtml(tag);
                }

                // Set the output content to the generated "div" element.
                output.Content.AppendHtml(result.InnerHtml);
            }
        }

    }
}