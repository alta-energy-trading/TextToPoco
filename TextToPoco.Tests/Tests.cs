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
            List<IClientCleaner<IDirty, IClean>> cleaners = new List<IClientCleaner<IDirty, IClean>>
            {
                fakeClientCleanerService as IClientCleaner<IDirty, IClean>,
            };

            Assert.Collection<IClientCleaner<IDirty, IClean>>(cleaners,
                c => Assert.True(true));
        }
    }
}
