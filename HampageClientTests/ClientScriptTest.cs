using System.Threading;
using NUnit.Framework;
using DisruptoLib.Entities;
using DisruptoLib.Factories;

namespace HampageClientTests
{
    public class ClientScriptTest
    {
        protected ThreadLocal<Character>  _localPlayer;

        [SetUp]
        public void ClientScriptSetUp()
        {
            CharacterFactory.ClearPlayers();

            CharacterFactory.AddPlayer();

            _localPlayer = new ThreadLocal<Character>(() =>
            {
                return CharacterFactory.GetLocalPlayerCharacter();
            });

            // _localPlayer = CharacterFactory.GetLocalPlayerCharacter();
        }
    }
}
