using NUnit.Framework;
using DisruptoLib.Entities;
using DisruptoLib.Factories;

namespace HampageClientTests
{
    public class ClientScriptTest
    {
        protected Character _localPlayer;

        [SetUp]
        public void ClientScriptSetUp()
        {
            CharacterFactory.ClearPlayers();

            CharacterFactory.AddPlayer();

            _localPlayer = CharacterFactory.GetLocalPlayerCharacter();
        }
    }
}
