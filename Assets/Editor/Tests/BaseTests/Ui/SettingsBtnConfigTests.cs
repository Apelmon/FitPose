using System;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

namespace Editor.Tests.Ui {
    public class SettingsBtnConfigTests : UiContextTests {
        private Button _button;
        private GameObject _btn;
        private SettingsBtnConfig _btnConfig;

        public override void SetUpScene() {
            base.SetUpScene();

            _btn = new GameObject();
            _btnConfig = _btn.AddComponent<SettingsBtnConfig>();
        }

        [Test]
        public void Invoke_ButtonHandler() {
            _button = _btn.AddComponent<Button>();
            _btnConfig.Initialize(_contexts, _uiEntity);
            
            _button.onClick.Invoke();
            
            // todo show settings popup
        }

        [Test]
        public void RestartBtnConfig_Initialize_and_has_not_button_component() {
            Assert.Throws<NullReferenceException>(() => _btnConfig.Initialize(_contexts, _uiEntity));
        }
    }
}