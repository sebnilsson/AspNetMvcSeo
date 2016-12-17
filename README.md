# ASP.NET MVC SEO

Tools for handling SEO-related values in ASP.NET MVC-controllers and views.

## Attributes
The following attributes are available for your Controller-actions:

- `[SeoLinkCanonical]`: Sets the value for canonical link
- `[SeoMetaDescription]`: Sets the meta-description
- `[SeoMetaKeywords]`: Sets the meta-keywords
- `[SeoMetaRobotsIndex]`: Sets the value for a meta-tag which tells Robots how to index
- `[SeoMetaRobotsNoIndex]`: Sets the value for a meta-tag which tells Robots not to index
- `[SeoTitle]`: Sets the page-title

You can use the attributes like this:

```
[SeoTitle("Listing items")]
[SeoMetaDescription("List of the company's product-items")]
public ActionResult List()
{
    var list = GetList();
    
    if (list.Any())
    {
        Seo.PageTitle += $" (Total: {list.Count})";
    }
    else
    {
        Seo.MetaRobotsNoIndex = true;
    }

    return View(model);
}
```

## Controllers
Making your Controllers inherit from `SeoController` gives you a `Seo`-object to use in your Controller-actions:

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

## Views
You can access the `Seo`-property in the Views if you configure your `Web.config` to use the type
`SeoWebViewPage` as `pageBaseType`:

```
<configuration>
    <!-- ... -->
    <system.web.webPages.razor>
        <!-- ... -->
        <pages pageBaseType="AspNetMvcSeo.SeoWebViewPage">
    <!-- ... -->
```
This will enable you to set SEO-related values in Views:


```
@{
    Seo.MetaRobotsNoIndex = true; // Always block Robots from indexing this View
}
```

## HtmlHelper-extensions
Multiple `HtmlHelper`-extensions are available:

- `Html.LinkCanonical()`: Renders the HTML-tag for canonical link
- `Html.SeoMetaDescription()`: Renders the HTML-tag for the meta-description
- `Html.SeoMetaKeywords()`: Renders the HTML-tag for the meta-keywords
- `Html.SeoMetaRobotsIndex()`: Renders the HTML-tag for the meta-tag which tells Robots how to index
- `Html.SeoMetaRobotsNoIndex()`: Renders the HTML-tag for for the meta-tag which tells Robots not to index
- `Html.SeoTitle()`: Renders the HTML-tag for the page-title 

```
<head>
    @Html.Title()
    
    @Html.LinkCanonical()
    @Html.MetaDescription()
    @Html.MetaKeywords()
    @Html.MetaRobotsIndex()
</head>
```


## Model-binding
Registering `SeoModelFilterAttribute` for certain controllers, or application-wide through `GlobalFilters.Filters` you can implement the `ISeoModel`-interface and its `PopulateSeo`-method, to specify how a `Model`-class propulates its SEO-values:

```
GlobalFilters.Filters.Add(new SeoModelFilterAttribute()); // Optional step for application startup
```

```
public class CustomModel : ISeoModel
{
    public bool IsPrivate { get; set; }
    
    public string Title { get; set; }

    public void OnHandleSeoValues(SeoHelper seo)
    {
        seo.MetaRobotsNoIndex = this.IsPrivate;
        seo.Title = $"Page for '{this.Title}'";
    }
}
```