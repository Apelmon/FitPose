using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

namespace Editor.Tests.Ui {
    public class StartMenuViewTests : UiContextTests {
        private StartMenuView _smView;

        public override void SetUpScene() {
            base.SetUpScene();

            _smView = new GameObject().AddComponent<StartMenuView>();
            
            SetPrivateField("_closedButtons", typeof(StartMenuView), _smView, new Button[0]);
            
            _smView.Initialize(_contexts, _uiEntity);
            
            _uiEntity.ReplaceUiView(_smView);
        }

        [Test]
        public void StartMenuView_Initialize() {
            Assert.IsTrue(_uiEntity.isStartMenu);
        }

        [Test]
        public void Enabled_after_Initialize() {
            Assert.IsFalse(_uiEntity.isViewEnable);
            Assert.IsFalse(_uiEntity.uiView.value.Enabled);
        }
    }
}