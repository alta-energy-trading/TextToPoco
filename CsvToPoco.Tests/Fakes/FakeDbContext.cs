using Microsoft.EntityFrameworkCore;
using CsvToPoco;

namespace CsvToPoco.Tests.Fakes
{
    public class FakeDbContext : DbContext, IDbContext
    {
    }
}
