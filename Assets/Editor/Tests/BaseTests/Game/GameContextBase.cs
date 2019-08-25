using NUnit.Framework;

namespace Editor.Tests.Game {
    public class GameContextBase : BaseEntitasTests {
        protected GameEntity _entity;

        [SetUp]
        public override void SetUpScene() {
            base.SetUpScene();

            _entity = _contexts.game.CreateEntity();
        }
    }
}