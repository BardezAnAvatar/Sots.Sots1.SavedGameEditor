using System.IO;
using Bardez.Project.SwordOfTheStars.IO.Pathfinding;
using Bardez.Project.SwordOfTheStars.IO.Pathfinding.Steam;
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
            var pathfinder = new Pathfinder(new SteamPathfinder(new AcfManifestParserBuilder()));

            //act
            var path = pathfinder.DeriveSotsPath();

            //assert
            path.Should().NotBeNull("because the path should be retrieved");
            path.Should().Contain("Sword of the Stars", "because that's a pretty iniversal path for SotS");
            //TODO: I want to set up different (build?) configurations that have different config values,
            //  so I can check for a working path on a development machine, and not expect on on test server.
            Directory.Exists(path).Should().BeTrue("because a dev machine shoulg have the game installed");
        }
    }
}
