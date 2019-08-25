using System;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

namespace Editor.Tests.Ui {
    public class RestartBtnConfigTests : UiContextTests {
        private Button _button;
        private GameObject _btn;
        private RestartBtnConfig _btnConfig;

        public override void SetUpScene() {
            base.SetUpScene();

            _btn = new GameObject();
            _btnConfig = _btn.AddComponent<RestartBtnConfig>();
        }

        [Test]
        public void Invoke_ButtonHandler() {
            _contexts.gameState.currentLevel.value = 2;
            
            _button = _btn.AddComponent<Button>();
            _btnConfig.Initialize(_contexts, _uiEntity);
            
            _button.onClick.Invoke();

            Assert.AreEqual(2, _contexts.gameState.currentLevel.value);
            Assert.IsTrue(_contexts.gameState.isLoadingState);
        }

        [Test]
        public void RestartBtnConfig_Initialize_and_has_not_button_component() {
            Assert.Throws<NullReferenceException>(() => _btnConfig.Initialize(_contexts, _uiEntity));
        }
    }
}