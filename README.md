# ASP.NET MVC SEO

Tools for SEO in ASP.NET MVC.

## Attributes
The following attributes are available for your Controller-actions:

- `[SeoLinkCanonical]`: Sets the value for canonical link
- `[SeoMetaDescription]`: Sets the meta-description
- `[SeoMetaKeywords]`: Sets the meta-keywords
- `[SeoMetaIndex]`: Sets the value for a meta-tag which tells Robots how to index
- `[SeoMetaRobotsNoIndex]`: Sets the value for a meta-tag which tells Robots not to index
- `[SeoPageTitleAttribute]`: Sets the page-title

## Controllers
Making your Controllers inherit from `SeoController` gives you a `Seo`-object to use in your Controller-actions:

```
public ActionResult Edit()
{
    var model = GetModel();
    
    this.Seo.PageTitle = $"Edit {model.Name}";
    this.Seo.LinkCanonical = this.Url.Action("Action", "Controller", new { Id = model.Id });
    this.Seo.MetaRobotsNoIndex = model.IsPrivate;
    
    return this.View(model);
}
```

## Views
Making your Views inherit from `SeoWebViewPage` enables you to do this in your Views:

```
@{
    this.Seo.MetaRobotsNoIndex = true; // Always block Robots from indexing this View
}

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

    public void PopulateSeo(SeoHelper seo)
    {
        seo.MetaRobotsNoIndex = this.IsPrivate;
        seo.PageTitle = $"Page for '{this.Title}'";
    }
}
```
