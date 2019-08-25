using System;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Editor.Tests.Ui {
    public class FailedPopupAdsTests : UiContextTests {
        private TextMeshProUGUI _titleText;
        private FailedPopupAdsView _fpaView;

        public override void SetUpScene() {
            base.SetUpScene();

            _fpaView = new GameObject().AddComponent<FailedPopupAdsView>();
            
            SetPrivateField("_closedButtons", typeof(FailedPopupAdsView), _fpaView, new Button[0]);

            _titleText = new GameObject().AddComponent<TextMeshProUGUI>();
            SetPrivateField("_titleText", _fpaView, _titleText);
            
            _fpaView.Initialize(_contexts, _uiEntity);
            
            _uiEntity.ReplaceUiView(_fpaView);
        }
        
        [Test]
        public void FailedPopupAds_Initialize() {
            Assert.IsTrue(_contexts.ui.isFailedPopupAds);
        }
        
        [Test]
        public void Disabled_after_Initialize() {
            Assert.IsFalse(_uiEntity.isViewEnable);
            Assert.IsFalse(_uiEntity.uiView.value.Enabled);
        }

        [Test]
        public void Set_level_number_to_stage_text() {
            int levelNum = 92;

            _systems.Add(new AnyCurrentLevelEventSystem(_contexts));
            _contexts.gameState.ReplaceCurrentLevel(levelNum);
            
            _systems.Execute();
            
            Assert.AreEqual("Stage " + levelNum + "\nContinue?", _titleText.text);
        }

        [Test]
        public void Throws_null_exception_about_text_null() {
            SetPrivateField("_titleText", _fpaView, null);

            Assert.Throws<ArgumentNullException>(() => _fpaView.OnAnyCurrentLevel(null, 10));
        } 
    }
}