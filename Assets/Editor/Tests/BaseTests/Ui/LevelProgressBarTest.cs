using System;
using System.Reflection;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Editor.Tests.Ui
{
    public class LevelProgressBarTest : UiContextTests {
        private LevelProgressBarView _barView;
        private TextMeshProUGUI _label01;
        private TextMeshProUGUI _label02;
        private Image _fillImage;

        public override void SetUpScene() {
            base.SetUpScene();
            
            _systems.Add(new ViewEnableEventSystem(_contexts));
            _systems.Add(new ViewEnableRemovedEventSystem(_contexts));
            
            _barView = new GameObject().AddComponent<LevelProgressBarView>();
            _barView.Initialize(_contexts, _uiEntity);
            
            _label01 = new GameObject().AddComponent<TextMeshProUGUI>();
            _label02 = new GameObject().AddComponent<TextMeshProUGUI>();
            _fillImage = new GameObject().AddComponent<Image>();

            SetPrivateField("_label01", _barView, _label01);
            SetPrivateField("_label02",_barView, _label02);
            SetPrivateField("_fillImage", _barView, _fillImage);
            
            _uiEntity.ReplaceUiView(_barView);
        }

        [Test]
        public void LevelProgressBar_Initialize() {
            Assert.AreEqual(true, _contexts.ui.isLevelProgressBar);
        }

        [Test]
        public void Disabled_after_Initialize() {
            Assert.IsFalse(_uiEntity.isViewEnable);
            Assert.IsFalse(_uiEntity.uiView.value.Enabled);
        }

        [Test]
        public void Has_ViewEnable_listeners() {
            Assert.AreEqual(true, _uiEntity.hasViewEnableListener);
            Assert.AreEqual(true, _uiEntity.hasViewEnableRemovedListener);
        }

        [Test]
        public void Set_ViewEnable_to_true() {
            _uiEntity.isViewEnable = true;
            
            _systems.Execute();
            
            Assert.AreEqual(true, _uiEntity.uiView.value.Enabled);
            Assert.AreEqual(true, _uiEntity.isViewEnable);
        }

        [Test]
        public void Update_labels_after_change_Level_entity_event() {
            int levelNum = 5;

            _systems.Add(new AnyCurrentLevelEventSystem(_contexts));
            
            _contexts.gameState.ReplaceCurrentLevel(levelNum);
            _systems.Execute();
            
            Assert.AreEqual(levelNum.ToString(), _label01.text);
            Assert.AreEqual((levelNum + 1).ToString(), _label02.text);
        }

        [Test]
        public void Set_ViewEnable_to_false() {
            _uiEntity.isViewEnable = true;
            _uiEntity.isViewEnable = false;
            
            _systems.Execute();
            
            Assert.AreEqual(false, _uiEntity.uiView.value.Enabled);
            Assert.AreEqual(false, _uiEntity.isViewEnable);
        }

        [Test]
        public void Update_Number_Labels() {
            int currentLevel = 3;
            
            _barView.OnAnyCurrentLevel(null, currentLevel);
            
            Assert.AreEqual(currentLevel.ToString(), _label01.text);
            Assert.AreEqual((currentLevel + 1).ToString(), _label02.text);
        }

        [Test]
        public void Throws_Exception_when_label01_null() {
            int currentLevel = 3;
            
            FieldInfo label01Field = _barView.GetType().GetField("_label01", BindingFlags.Instance | BindingFlags.NonPublic|BindingFlags.Public); 
            label01Field.SetValue(_barView, null);

            Assert.Throws<ArgumentNullException>(() => _barView.OnAnyCurrentLevel(null, currentLevel));
        }

        [Test]
        public void Throws_Exception_when_label02_null() {
            int currentLevel = 3;
            
            FieldInfo label02Field = _barView.GetType().GetField("_label02", BindingFlags.Instance | BindingFlags.NonPublic|BindingFlags.Public); 
            label02Field.SetValue(_barView, null);

            Assert.Throws<ArgumentNullException>(() => _barView.OnAnyCurrentLevel(null, currentLevel));
        }

        [Test]
        public void Throws_Exception_when_fill_image_null() {
            FieldInfo fillImageField = _barView.GetType().GetField("_fillImage", BindingFlags.Instance | BindingFlags.NonPublic|BindingFlags.Public); 
            fillImageField.SetValue(_barView, null);

            Assert.Throws<ArgumentNullException>(() => _barView.UpdateProgress(0.44f));
        }

        [Test]
        public void Set_Progress_To_Quarter() {
            float progress = 0.33f;
            
            _barView.UpdateProgress(progress);
            
            Assert.AreEqual(progress, _fillImage.fillAmount);
        }

        [Test]
        public void Set_Progress_To_0_if_value_less_then_0() {
            float progress = -0.33f;
            
            _barView.UpdateProgress(progress);
            
            Assert.AreEqual(0f, _fillImage.fillAmount);
        }

        [Test]
        public void Set_Progress_To_1_if_value_more_then_1() {
            float progress = 1.33f;
            
            _barView.UpdateProgress(progress);
            
            Assert.AreEqual(1f, _fillImage.fillAmount);
        }
    }
}
