using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Editor.Tests.Timers {
    public class TimerTests : TimerContextTests {
        public override void SetUpScene() {
            base.SetUpScene();

            _systems.Add(new TimerSystems(_contexts));
        }

        [Test]
        public void Create_Timer() {
            float time = 2.4f;
            _entity.AddTimer(time);
            
            Assert.AreEqual(time, _entity.timer.value);
        }

        [Test]
        public void decrease_timer() {
            float time = 2.4f;
            _entity.AddTimer(time);
            
            _contexts.input.ReplaceDeltaTime(0.1f);
            _systems.Execute();

            float newTime = time - _contexts.input.deltaTime.value;
            Assert.AreEqual(newTime, _entity.timer.value);
        }

        [TestCase(0.1f, 0.3f, true)]
        [TestCase(1.1f, 0.1f, false)]
        [TestCase(-2.1f, 0.1f, true)]
        public void mark_timer_completed_when_timer_less_or_equal_0(float time, float deltaTime, bool completed) {
            _entity.AddTimer(time);
            
            _contexts.input.ReplaceDeltaTime(deltaTime);
            _systems.Execute();
            
            Assert.AreEqual(completed, _entity.isCompleted);
            Assert.AreEqual(!completed, _entity.hasTimer);
        }

        [TestCase(0.0f, true)]
        [TestCase(1.0f, false)]
        [TestCase(-1.0f, true)]
        public void cleanup_destroy_entity_after_mark_completed(float time, bool completed) {
            _entity.AddTimer(time);
            
            _contexts.input.ReplaceDeltaTime(0.3f);
            _systems.Execute();
            _systems.Cleanup();

            Assert.AreEqual(!completed, _entity.isEnabled);
        }

        [Test]
        public void react_system_with_completed_mark() {
            _entity.AddTimer(0.1f);

            _contexts.input.ReplaceDeltaTime(0.3f);
            _systems.Add(new TimerTestSystem(_contexts));
            _systems.Execute();
            
            Assert.IsFalse(_entity.isCompleted);
            Assert.AreEqual(10.0f, _entity.timer.value);
        }
    }
}