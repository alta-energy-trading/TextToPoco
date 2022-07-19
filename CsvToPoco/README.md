## CsvToPoco
A dotnet library for importing from CSV to a database  

See how `CsvToPoco` fits in to Alta's development landscape in the [app graph](https://github.com/alta-energy-trading/Documentation/blob/main/AppFlowAndDependency.pdf)

### Installation  

#### Package Manager Console  
`PM> Install-Package CsvToPoco`  

### Getting Started  

#### Register services  
```
using CsvToPoco.Extensions  

public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureServices((hostContext, services) =>
        {
            ...
            services.AddCsvToPoco();
            ...
        });
    }
}
```

#### Prerequisites 
The DbContext in the client app needs to implement (the empty) IDbContext  
`public class MyAppContext : DbContext, IDbContext`  

If your project has a seperate core project that you want to keep free of unnecessary dependencies, there is a core project, [CsvToPoco](https://github.com/alta-energy-trading/TextToPoco/CsvToPoco) where the required interfaces are defined  
`PM> Install-Package TextToPoco`  

#### Using CsvToPoco
The recommended usage is to get the CsvToPoco.Importer service using dependency injection, either constructor injection  
```
public class DependantService
{
    private readonly ITextToPoco _csvToPoco;

    public DependantService(ITextToPoco csvToPoco)
    {
        _csvToPoco = csvToPoco;
    }
}
```  
or using a scope and service provider   
```
using (var scope = _services.CreateScope())
{
    var csvToPoco = scope.ServiceProvider.GetRequiredService<ITextToPoco>();
}
```  

CsvToPoco requires you to subscribe to the warnings event
`csvToPoco.Warning += CsvToPoco_Warning;`  

Create a `CsvToPocoArgs` object to configure the CSV reader, and pass it to the `Run` method
```
CsvToPocoArgs args = new CsvToPocoArgs
{
    Stream = new FileStream(e.FullPath, FileMode.Open),
    Delimiter = "|",
    HasHeaders = false,                     // Has a header row
    Keys = new List<string>                 // List of primary keys, used to merge by
    {
        nameof(MyObject.PrimaryKey1),
        nameof(MyObject.PrimaryKey2)
    },
    PersistAction = PersistActionEnum.Merge // Merge, Replace (for batches, use Alta.Utility.DbContextExtensions.Truncate and then Add), Add or None,
    ClassMap = new MyObjectClassMap()       // CsvHelper class map
};

var records = csvToPoco.Run<MyObject>(context, args);
```   

##### Large Files
To avoid reading large files into memory, use an overload of `Run` that takes an int batch size.

```
// Returns the result in batches
foreach(var batch in csvToPoco.Run<MyObject>(context, args, 500000))
{
    //each batch needs to be read into memory in the client
    var tempList = batch.ToList();

    // do something with this batch
    ...
}
```

The CSV to POCO mapping can be configured using [CsvHelper attributes](https://joshclose.github.io/CsvHelper/examples/configuration/attributes/)  
```
using CsvHelper.Configuration.Attributes;

public class MyObject
{
    [Ignore]
    public DateTime Updated { get; set; }
    [Name("their_key")]
    public string PrimaryKey1 { get; set; }
    [Name("their_secondary_key")]
    public string PrimaryKey2 { get; set; }
}
```  
Or you can create a ClassMap and pass it with the CsvToPocoArgs object

The records can then be further transformed using [PocoLoco](https://github.com/alta-energy-trading/PocoLoco)  

Runs synchronously  