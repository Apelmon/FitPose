using NUnit.Framework;

namespace Editor.Tests.Input {
    public class InputContextTests : BaseEntitasTests {
        private InputEntity _entity;

        [SetUp]
        public override void SetUpScene() {
            base.SetUpScene();

            _entity = _contexts.input.CreateEntity();
        }
    }
}