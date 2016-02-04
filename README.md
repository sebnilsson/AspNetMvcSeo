# ASP.NET MVC SEO

Tools for SEO in ASP.NET MVC.

## Attributes
The following attributes are available for your Controller-actions:

- `[SeoLinkCanonical]`: Sets the value for canonical link
- `[SeoMetaDescription]`: Sets the meta-description
- `[SeoMetaKeywords]`: Sets the meta-keywords
- `[SeoMetaIndex]`: Sets the value for a meta-tag which tells Robots how to index
- `[SeoMetaRobotsNoIndex]`: Sets the value for a meta-tag which tells Robots not to index
- `[SeoPageTitle]`: Sets the page-title

You can use the attributes like this:

```
[SeoPageTitle("Listing items")]
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
You can access the `Seo`-property in the Views if you configure your `Web.config` for Views to use `SeoWebViewPage` as `pageBaseType`:

```
@{
    Seo.MetaRobotsNoIndex = true; // Always block Robots from indexing this View
}

<head>
    @Html.Title()
    
    @Html.LinkCanonical()
    @Html.MetaDescription()
    @Html.MetaKeywords()
    @Html.MetaRobotsIndex()
</head>
```

You configure it in the `~/Views/Web.config`-file like this:

```
<configuration>
    <!-- ... -->
    <system.web.webPages.razor>
        <!-- ... -->
        <pages pageBaseType="AspNetMvcSeo.SeoWebViewPage">
    <!-- ... -->
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

    public void PopulateSeo(SeoHelper seo)
    {
        seo.MetaRobotsNoIndex = this.IsPrivate;
        seo.PageTitle = $"Page for '{this.Title}'";
    }
}
```
