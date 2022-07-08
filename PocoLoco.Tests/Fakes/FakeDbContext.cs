using Microsoft.EntityFrameworkCore;
using TextToPoco.Core;

namespace PocoLoco.Tests.Fakes
{
    public class FakeDbContext : DbContext, IDbContext
    {
    }
}
