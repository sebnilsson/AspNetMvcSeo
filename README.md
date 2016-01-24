# ASP.NET MVC SEO

Tools for SEO in ASP.NET MVC.

## Attributes
The following attributes are available for you Controller-actions:

- `[SeoLinkCanonical]`: Sets a canonical link
- `[SeoMetaDescription]`: Sets a meta-description
- `[SeoMetaKeywords]`: Sets meta-keywords
- `[SeoMetaIndex]`: Sets if a tag for index or no index
- `[SeoPageTitleAttribute]`

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
