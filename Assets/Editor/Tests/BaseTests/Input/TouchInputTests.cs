using System.Collections;
using Entitas;
using NUnit.Framework;
using UnityEngine.TestTools;

namespace Editor.Tests.Input {
    public class TouchInputTests : InputContextTests {
        private int _gamePlayingUpdateCounter = 0;
        public override void SetUpScene() {
            base.SetUpScene();

            _gamePlayingUpdateCounter = 0;
            _contexts.gameState.GetGroup(GameStateMatcher.GameplayState).OnEntityUpdated +=
                OnOnEntityUpdated;
            _contexts.gameState.GetGroup(GameStateMatcher.GameplayState).OnEntityAdded +=
                OnOnEntityUpdated;

            _systems.Add(new PrepareToGameplayStateSystem(_contexts));
        }

        private void OnOnEntityUpdated(IGroup<GameStateEntity> @group, GameStateEntity entity, int index, IComponent component) {
            _gamePlayingUpdateCounter++;
        }

        [Test]
        public void start_game_after_pointer_down_in_start_menu() {
            _contexts.input.isPointerDown = true;
            _contexts.gameState.isWaitInputState = true;
            
            _systems.Execute();
            
            Assert.IsTrue(_contexts.gameState.isGameplayState);
        }

        [Test]
        public void idle_start_menu() {
            _systems.Execute();
            
            Assert.IsFalse(_contexts.gameState.isGameplayState);
        }

        [Test]
        public void one_time_action() {
            _contexts.gameState.isWaitInputState = true;
            
            // todo finish this test late
            _contexts.input.isPointerDown = true;
            _systems.Execute();
            _contexts.input.isPointerDown = true;
            _systems.Execute();
            
            
            Assert.AreEqual(1, _gamePlayingUpdateCounter);
        }

        private void OnOnEntityUpdated(IGroup<GameStateEntity> @group, GameStateEntity entity, int index, IComponent previouscomponent, IComponent newcomponent) {
            _gamePlayingUpdateCounter++;
        }
    }
}