using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

namespace Editor.Tests.Ui {
    public class FailedPopupTests : UiContextTests {

        public override void SetUpScene() {
            base.SetUpScene();

            _systems.Add(new ViewEnableEventSystem(_contexts));
            _systems.Add(new ViewEnableRemovedEventSystem(_contexts));

            FailedPopupView popupView = new GameObject().AddComponent<FailedPopupView>();
            
            SetPrivateField("_closedButtons", typeof(FailedPopupView), popupView, new Button[0]);
            
            popupView.Initialize(_contexts, _uiEntity);
            
            _uiEntity.ReplaceUiView(popupView);
        }

        [Test]
        public void FailedPopup_Initialize() {
            Assert.IsTrue(_contexts.ui.isFailedPopup);
        }

        [Test]
        public void Has_ViewEnableListener() {
            Assert.IsTrue(_uiEntity.hasViewEnableListener);
        }

        [Test]
        public void Has_ViewEnableRemovedListener() {
            Assert.IsTrue(_uiEntity.hasViewEnableRemovedListener);
        }

        [Test]
        public void Disabled_after_Initialize() {
            Assert.IsFalse(_uiEntity.isViewEnable);
            Assert.IsFalse(_uiEntity.uiView.value.Enabled);
        }

        [Test]
        public void OnViewEnable() {
            _uiEntity.isViewEnable = true;
            
            _systems.Execute();
            
            Assert.IsTrue(_uiEntity.uiView.value.Enabled);
        }

        [Test]
        public void OnViewEnableRemoved() {
            _uiEntity.isViewEnable = true;
            _uiEntity.isViewEnable = false;
            
            _systems.Execute();
            
            Assert.IsFalse(_uiEntity.uiView.value.Enabled);
        }
    }
}