###Features

- Create simple pagination handling for items in ASP.NET core for  MicrosoftEntityFramework and Simple list of items
- Based on a page and the number of items you will get:
	- Total of items from that result
	- Current page requested
	- Numer of results requested
	- Pages, the total of pages fot that result
	- Previous page number
	- Next page number
	- Validate if the current page has a previous or a nect page

NuGet installation
PM> Install-Package DbContextPagination
https://www.nuget.org/packages/DbContextPagination


###How to use with DbContext

```chsarp
var provider = new DbContextPaginationProvider<Product>(dbContext);

var input = new PaginationProviderInput<Product>
{
	RequestedPage = 3,
	ResultsPerPage = 25
};

var page = provider.Get(input);
```

###How to use with a List<T>

```chsarp
var items = _dataProvider.GetProducts();

var provider = new SimplePaginationProvider<Product>();

var input = new SimplePaginationProviderInput<Product>
{
	RequestedPage = 1,
	ResultsPerPage = 3,
	Items = items,
};

var page = provider.Get(input);
```

### Filtering with Lambda Expressions
```csharp
var input = new PaginationProviderInput<Product>
{
	RequestedPage = 1,
	ResultsPerPage = 3,
	Items = products,
	Where = i => i.Price > 150 // Write your where statements here
};
```

### Sorting with Lambda Expressions
```csharp
var input = new PaginationProviderInput<Product>
{
	RequestedPage = 1,
	ResultsPerPage = 3,
	Items = products,
	Where = i => i.Price > 150,
	OrderBy = sorting => sorting.OrderBy(i => i.Description).ThenBy(i => i.Price) // Use OrdeBy, Then, OrderByDescent
};
```