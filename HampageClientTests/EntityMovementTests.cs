using HampageClient;
using FluentAssertions;
using NUnit.Framework;
using DisruptoLib;

namespace HampageClientTests
{
    public class EntityMovementTests : ClientScriptTest
    {
        [Test]
        public void EntityWithDestinationMovesTowardIt()
        {
            _localPlayer.Speed = 1;

            _localPlayer.Position = new Point(0, 0);

            _localPlayer.Destination = new Point(1, 0);

            HeartBeat.PhysicsLoop();

            _localPlayer.Position.X.Should().Be(1);
        }

        [Test]
        public void EntityMovesTowardDestinationBehind()
        {
            _localPlayer.Speed = 3;

            _localPlayer.Position = new Point(10, 3);

            _localPlayer.Destination = new Point(1, 3);

            HeartBeat.PhysicsLoop();

            _localPlayer.Position.X.Should().Be(7);
            _localPlayer.Position.Y.Should().Be(3);
        }

        [Test]
        public void EntityMovesToDestinationOnTwoDifferentAxes()
        {
            _localPlayer.Speed = 4;

            _localPlayer.Position = new Point(5, 4);

            _localPlayer.Destination = new Point(7, 0);

            HeartBeat.PhysicsLoop();

            _localPlayer.Position.X.Should().Be(6);
            _localPlayer.Position.Y.Should().Be(1);
        }

        [Test]
        public void EntityDoesNotMoveIfDestinationIsPosition()
        {
            _localPlayer.Speed = 200;

            _localPlayer.Position = new Point(13, 12);

            _localPlayer.Destination = new Point(13, 12);

            HeartBeat.PhysicsLoop();

            _localPlayer.Position.X.Should().Be(13);
            _localPlayer.Position.Y.Should().Be(12);
        }
    }
}
