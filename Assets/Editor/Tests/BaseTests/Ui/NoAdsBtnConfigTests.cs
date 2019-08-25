using System;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

namespace Editor.Tests.Ui {
    public class NoAdsBtnConfigTests : UiContextTests {
        private Button _button;
        private GameObject _btn;
        private NoAdsBtnConfig _btnConfig;

        public override void SetUpScene() {
            base.SetUpScene();

            _btn = new GameObject();
            _btnConfig = _btn.AddComponent<NoAdsBtnConfig>();
        }

        [Test]
        public void Invoke_ButtonHandler() {
            _button = _btn.AddComponent<Button>();
            _btnConfig.Initialize(_contexts, _uiEntity);
            
            _button.onClick.Invoke();
            
            // todo show popup with iap
        }

        [Test]
        public void RestartBtnConfig_Initialize_and_has_not_button_component() {
            Assert.Throws<NullReferenceException>(() => _btnConfig.Initialize(_contexts, _uiEntity));
        }

        [Test]
        public void Has_NoAdsBtn_after_Initialize() {
            _button = _btn.AddComponent<Button>();
            _btnConfig.Initialize(_contexts, _uiEntity);
            Assert.IsTrue(_uiEntity.isNoAdsBtn);
        }
    }
}