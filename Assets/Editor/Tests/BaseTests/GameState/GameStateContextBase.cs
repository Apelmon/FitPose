using NUnit.Framework;

namespace Editor.Tests.Game {
    public class GameStateContextBase : BaseEntitasTests {
        protected GameStateEntity _entity;

        [SetUp]
        public override void SetUpScene() {
            base.SetUpScene();

            _entity = _contexts.gameState.CreateEntity();
        }
    }
}