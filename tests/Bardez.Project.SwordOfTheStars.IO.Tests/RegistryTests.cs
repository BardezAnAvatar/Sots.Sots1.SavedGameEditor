using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bardez.Project.SwordOfTheStars.IO.Tests
{
    [TestClass]
    public class RegistryTests
    {
        [TestMethod]
        public void ReadSotsPath_Works()
        {
            //act
            var path = Registry.ReadSotsPath();

            //assert
            path.Should().NotBeNull("because the psth should be retrieved.");
        }
    }
}
