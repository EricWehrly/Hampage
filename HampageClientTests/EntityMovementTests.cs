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
            _localPlayer.Value.Speed = 1;

            _localPlayer.Value.Position = new Point(0, 0);

            _localPlayer.Value.Destination = new Point(1, 0);

            HeartBeat.PhysicsLoop();

            _localPlayer.Value.Position.X.Should().Be(1);
        }

        [Test]
        public void EntityMovesTowardDestinationBehind()
        {
            _localPlayer.Value.Speed = 3;

            _localPlayer.Value.Position = new Point(10, 3);

            _localPlayer.Value.Destination = new Point(1, 3);

            HeartBeat.PhysicsLoop();

            _localPlayer.Value.Position.X.Should().Be(7);
            _localPlayer.Value.Position.Y.Should().Be(3);
        }

        [Test]
        public void EntityMovesToDestinationOnTwoDifferentAxes()
        {
            _localPlayer.Value.Speed = 4;

            _localPlayer.Value.Position = new Point(5, 4);

            _localPlayer.Value.Destination = new Point(7, 0);

            HeartBeat.PhysicsLoop();

            _localPlayer.Value.Position.X.Should().Be(6);
            _localPlayer.Value.Position.Y.Should().Be(1);
        }

        [Test]
        public void EntityDoesNotMoveIfDestinationIsPosition()
        {
            _localPlayer.Value.Speed = 200;

            _localPlayer.Value.Position = new Point(13, 12);

            _localPlayer.Value.Destination = new Point(13, 12);

            HeartBeat.PhysicsLoop();

            _localPlayer.Value.Position.X.Should().Be(13);
            _localPlayer.Value.Position.Y.Should().Be(12);
        }
    }
}
