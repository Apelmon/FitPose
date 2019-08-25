using NUnit.Framework;

namespace Editor.Tests.Ui {
    public class UiContextTests : BaseEntitasTests {
        protected UiEntity _uiEntity;
        
        [SetUp]
        public override void SetUpScene() {
            base.SetUpScene();

            _uiEntity = _contexts.ui.CreateEntity();
        }

//        [TearDown]
//        public void ClearData() {
//            if (_uiEntity.isEnabled) 
//                _uiEntity.Destroy();
//        }
    }
}