using System;
using System.Collections.Generic;
using TextToPoco.Tests.Fakes;
using Xunit;

namespace TextToPoco.Tests
{
    public class Tests
    {
        [Fact]
        public void Types()
        {
            FakeClientCleanerService fakeClientCleanerService = new FakeClientCleanerService();
            IEnumerable<IClientCleaner> cleaners = new List<IClientCleaner>
            {
                (IClientCleaner)fakeClientCleanerService,
            };
        }
    }
}
