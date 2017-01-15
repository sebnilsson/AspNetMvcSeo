# ASP.NET MVC SEO

Helpers for handling the SEO-data for a web-application.

Provides a `SeoHelper`-class which is easily accessible in Controller-Actions, Views and through ActionFilterAttributes.

## SeoHelper

The `SeoHelper`-class exposes multiple properties to get or set multiple SEO-related data.

- `LinkCanonical`: Gets or sets the canonical link for a web-page. Can be set as absolute URL (`https://example.com/section/page.html`), 
as a relative URL (`/section/page.html`) or using ASP.NET's app-relative URL-format (`~/section.page.html`).
**Relative URLs will automatically get converted to absolute URLs.**
- `MetaDescription`: Gets or sets the meta-description for a web-page.
- `MetaKeywords`: Gets or sets the meta-keywords for a web-page.
- `MetaRobotsIndex`: Gets or sets how robots should index a web-page. The available settings are:
  - `IndexNoFollow`
  - `NoIndexFollow`
  - `NoIndexNoFollow`
- `MetaRobotsNoIndex`: Gets or sets that a web-page should not be indexed by robots.
- `PageTitle`: Gets or sets the title for a web-page.
- `SectionTitle`: Gets or sets the title for a section.
- `Title`: Gets the combined title from `PageTitle` and `SectionTitle`, using the `TitleFormat` for structure.
- `TitleFormat`: Gets or sets the format for the title. Default value is `{0} - {1}`,
where `{0}` is the value from `PageTitle` and `{1}` is the value from `SectionTitle`.

### Access in Controller-Actions

To easily access the `SeoHelper`-object inside Controllers, it has to inherit from `SeoController`, which makes a `Seo`-object available:

```
public ActionResult Edit()
{
    var model = GetModel();
    
    Seo.PageTitle = $"Edit {model.Name}";
    Seo.LinkCanonical = Url.Action("Action", "Controller", new { Id = model.Id });
    Seo.MetaRobotsNoIndex = model.IsPrivate;
    
    return View(model);
}
```

### Access in Views

To easily access the `SeoHelper`-object inside Views, the configuration for `pageBaseType` must be set to `SeoWebViewPage` in the `Web.config`
inside the `Views`-directory:

```
<configuration>
    <!-- ... -->
    <system.web.webPages.razor>
        <!-- ... -->
        <pages pageBaseType="AspNetMvcSeo.SeoWebViewPage">
    <!-- ... -->
```

This makes a `Seo`-object available inside the Views:

```
@{
    Layout = null;
    Seo.MetaRobotsNoIndex = true; // Always block Robots from indexing this View
}
```

## ActionFilterAttributes

The following action-filter-attributes are available for Controllers and Controller-actions:

- `[SeoLinkCanonical]`: Sets the value for canonical link
- `[SeoMetaDescription]`: Sets the meta-description
- `[SeoMetaKeywords]`: Sets the meta-keywords
- `[SeoMetaRobotsIndex]`: Sets the value for a meta-tag which tells Robots how to index
- `[SeoMetaRobotsNoIndex]`: Sets the value for a meta-tag which tells Robots not to index
- `[SeoPageTitle]`: Sets the page-title
- `[SeoSectionTitle]`: Sets the page-title for the section

Examples of attribute-usage:

```
[SeoSectionTitle("Website name")]
public class InfoController : SeoController
{
    [SeoPageTitle("Listing items")]
    [SeoMetaDescription("List of the company's product-items")]
    public ActionResult List()
    {
        var list = GetList();
        
        if (list.Any())
        {
            Seo.PageTitle += $" (Total: {list.Count})";
            Seo.LinkCanonical = "~/pages/list.html";
        }
        else
        {
            Seo.MetaRobotsNoIndex = true;
        }

        return View(model);
    }
}
```

**If the `SeoSectionTitle`-attribute is used in a controller the text from the `GlobalFilterCollection` will be overridden.**

## HtmlHelper-extensions

The following `HtmlHelper`-extensions are available to render HTML-tags containing SEO-data:

- `Html.SeoLinkCanonical()`: Renders the HTML-tag for canonical link
- `Html.SeoMetaDescription()`: Renders the HTML-tag for the meta-description
- `Html.SeoMetaKeywords()`: Renders the HTML-tag for the meta-keywords
- `Html.SeoMetaRobotsIndex()`: Renders the HTML-tag for the meta-tag which tells Robots how to index
- `Html.SeoTitle()`: Renders the HTML-tag for the page-title, with combined values of section-title and page-title

**Individual tags will not be rendered if there is no valid data for them in the `SeoHelper`.**

```
<head>
    @Html.SeoTitle()
    
    @Html.SeoLinkCanonical()
    @Html.SeoMetaDescription()
    @Html.SeoMetaKeywords()
    @Html.SeoMetaRobotsIndex()
</head>
```

## Titles

The value for `Title` in the `SeoHelper` is a combination of `PageTitle` and `SectionTitle`. If both values are set they will be combined into one text
formatted from the set `TitleFormat`, which from the default format looks like this: `Page title-text - Section title-text`.
If only one of the values are set, that value will be used without any format.

### Default website-title

To set a default website-title, which can be overridden if needed, the use of `GlobalFilterCollection` can be used together with the `SeoSectionTitle`-attribute:

```
public static class FilterConfig
{
    public static void RegisterGlobalFilters(GlobalFilterCollection filters)
    {
        filters.Add(new SeoSectionTitleAttribute("Website name"));
    }
}
```