using NUnit.Framework;

namespace Editor.Tests.Timers {
    public class TimerContextTests : BaseEntitasTests {
        protected TimerEntity _entity;

        [SetUp]
        public override void SetUpScene() {
            base.SetUpScene();

            _entity = _contexts.timer.CreateEntity();
        }
    }
}