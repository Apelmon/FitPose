using System;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

namespace Editor.Tests.Ui {
    public class ContinueAdsBtnConfigTests : UiContextTests {
        private Button _button;
        private GameObject _continueBtn;
        private ContinueAdsBtnConfig _continueAdsBtnConfig;

        public override void SetUpScene() {
            base.SetUpScene();

            _continueBtn = new GameObject();
            _continueAdsBtnConfig = _continueBtn.AddComponent<ContinueAdsBtnConfig>();
        }

        [Test]
        public void Invoke_ButtonHandler() {
            _button = _continueBtn.AddComponent<Button>();
            _continueAdsBtnConfig.Initialize(_contexts, _uiEntity);
            
            _button.onClick.Invoke();
            
            // todo invoke event to show ads
        }

        [Test]
        public void RestartBtnConfig_Initialize_and_has_not_button_component() {
            Assert.Throws<NullReferenceException>(() => _continueAdsBtnConfig.Initialize(_contexts, _uiEntity));
        }
    }
}