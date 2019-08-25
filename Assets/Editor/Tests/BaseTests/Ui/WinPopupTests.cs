using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

namespace Editor.Tests.Ui {
    public class WinPopupTests : UiContextTests {
        private WinPopupView _wpView;

        public override void SetUpScene() {
            base.SetUpScene();

            _wpView = new GameObject().AddComponent<WinPopupView>();
            SetPrivateField("_closedButtons", typeof(WinPopupView), _wpView, new Button[0]);
            _wpView.Initialize(_contexts, _uiEntity);
            
            _uiEntity.ReplaceUiView(_wpView);
        }

        [Test]
        public void WinPopup_Initialize() {
            Assert.IsTrue(_uiEntity.isWinPopup);
        }

        [Test]
        public void Disabled_after_Initialize() {
            Assert.IsFalse(_uiEntity.isViewEnable);
            Assert.IsFalse(_uiEntity.uiView.value.Enabled);
        }
    }
}