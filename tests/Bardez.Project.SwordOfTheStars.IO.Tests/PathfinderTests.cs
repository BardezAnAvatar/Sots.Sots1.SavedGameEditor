using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bardez.Project.SwordOfTheStars.IO.Tests
{
    [TestClass]
    public class PathfinderTests
    {
        [TestMethod]
        public void DeriveSotsPath_Works()
        {
            //arrange
            var pathfinder = new Pathfinder();

            //act
            var path = pathfinder.DeriveSotsPath();

            //assert
            path.Should().NotBeNull("because the path should be retrieved.");
        }
    }
}
