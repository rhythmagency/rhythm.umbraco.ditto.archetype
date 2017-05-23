# Introduction

A library of tools for working with [Umbraco Ditto](http://umbraco-ditto.readthedocs.io/en/latest/) and [Umbraco Archetype](https://our.umbraco.org/projects/backoffice-extensions/archetype/).
It primarily contains a set of Ditto processors used to decorate classes and properties and assist with Ditto mapping operations related to Archetype data.

Refer to the [generated documentation](docs/generated.md) for more details.

# Installation

Install with NuGet. Search for "Rhythm.Umbraco.Ditto.Archetype".

# Overview

## Ditto Processors

Here are the available Ditto processors:

* **DittoArchetypeAttribute** Allows for mapping of Archetype properties.
* **DittoMixedArchetypeAttribute** Combines the DittoArchetype and DocTypeFactory processors, which is useful when implementing widgets with Archetype. This allows for each Archetype fieldset to map to a different C# class.

The following code sample shows how to use both `DittoMixedArchetypeAttribute`:

```c#
namespace Sample
{
    using Our.Umbraco.Ditto;
    using Rhythm.Umbraco.Ditto.Archetype;
    using System.Collections.Generic;
    public class PageModel
    {
        // First, get the value of the Archetype property.
        [UmbracoProperty(Order = 0)]
        // Then, convert that Archetype model into a collection of widgets.
        [DittoMixedArchetype(Order = 1)]
        public IEnumerable<IWidget> MainContent { get; set; }
    }
}
```

Note that by convention the "Attribute" suffix is omitted when the attribute is used.
Also be aware that there is no `IWidget` interface (the above code is for demonstration purposes only).

# Maintainers

To create a new release to NuGet, see the [NuGet documentation](docs/nuget.md).