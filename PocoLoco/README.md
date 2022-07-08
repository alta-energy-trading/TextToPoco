## PocoLoco
A dotnet library for transforming entities  

See how `PocoLoco` fits in to Alta's development landscape in the [app graph](https://github.com/alta-energy-trading/Documentation/blob/main/AppFlowAndDependency.pdf)

### Installation  

#### Package Manager Console  
`PM> Install-Package PocoLoco`  

### Getting Started  

#### Register services  
```
using PocoLoco.Extensions  

public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureServices((hostContext, services) =>
        {
            ...
            services.AddPocoLoco();
            ...
        });
    }
}
```

#### Prerequisites 
The DbContext in the client app needs to implement (the empty) IDbContext  
`public class MyAppContext : DbContext, IDbContext`  

#### Using PocoLoco
The recommended usage is to get the PocoLoco.Cleaner service using dependency injection, either constructor injection  
```
public class DependantService
{
    private readonly IPocoLocoCleaner _pocoLoco;

    public DependantService(IPocoLocoCleaner pocoLoco)
    {
        _pocoLoco = pocoLoco;
    }
}
```  
or using a scope and service provider   
```
using (var scope = _services.CreateScope())
{
    var pocoLoco = scope.ServiceProvider.GetRequiredService<IPocoLocoCleaner>();
}
```  

Create a class that implements `IClientCleaner`  
```
public class MyClientCleaner : IClientCleaner
{
    // list of primary keys to merge by
    public List<string> Keys { get; set; }

    // list of properties that should be updated during a merge
    // leave as null to merge as normal
    // this is useful when you add a field that you don't want to be updated by external data
    // by specifying the includes, rather than excludes, you won't have to keep updating the list
    public List<string> PropertiesToInclude { get; set; }

    // optionally inject any necessary services
    public MyClientCleaner(IReferenceDataService referenceData) 
    {
        _referenceData = referenceData;

        // implement list of primary keys to merge by
        Keys = new List<string> {
            nameof(MyObject.PrimaryKey1),
            nameof(MyObject.PrimaryKey2)
        };
    }

    protected readonly IReferenceDataService _referenceData;

    // implement clean method
    public async Task<IEnumerable<TTarget>> Clean<TSource, TTarget>(TSource d) where TTarget : class
    {
        var dirty = d as MyObject;

        // get anything needed from dependencies
        var source = await _referenceData.GetSourceAsync("PVM");
        var clean = new CleanObject();

        clean.IdSource = source.Id;
        clean.Name = dirty.Curve;
        clean.ExternalId = source.Name + dirty.Curve.Replace(" ", string.Empty);
        clean.ContractCode = "CODE" + source.Name + dirty.Curve.Replace(" ", string.Empty);

        return new List<TTarget> { clean as TTarget };
    }
}
```   

Pass the implementation to the `Clean` method to get the transformed entities
```
var myClientCleaner = new MyClientCleaner(dependency);

pocoLoco.Clean<MyObject, MyCleanObject>(context, records, myClientCleaner);
```

Optionally pass a PersistAction to the `Clean` method
If you pass in `PersistActionEnum.None` (the data is not saved) or `PersistActionEnum.Replace` (the data is bulk deleted then bulk inserted), there is no need to instantiate the list of keys in the client cleaner  
```
pocoLoco.Clean<MyObject, MyCleanObject>(context, records, myClientCleaner, PersistActionEnum.None); // Replace, Merge, or None
```

Runs synchronously  