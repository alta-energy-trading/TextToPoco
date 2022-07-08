using Microsoft.EntityFrameworkCore;
using TextToPoco.Core;

namespace CsvToPoco.Tests.Fakes
{
    public class FakeDbContext : DbContext, IDbContext
    {
    }
}
