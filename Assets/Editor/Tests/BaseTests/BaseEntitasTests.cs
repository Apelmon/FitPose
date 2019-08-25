using System;
using System.Reflection;
using Entitas;
using UnityEditor;

namespace Editor.Tests {
    public abstract class BaseEntitasTests {
        protected Contexts _contexts;
        protected Systems _systems;

        public virtual void SetUpScene() {
            _contexts = new Contexts();
//            _contexts = Contexts.sharedInstance;
            Contexts.sharedInstance = _contexts;
            _systems = new Systems();

            _contexts.gameState.SetCurrentLevel(0);

            if (!_contexts.config.hasGameConfig) {
                ScriptableGameConfig gameConfigSO =
                    AssetDatabase.LoadAssetAtPath<ScriptableGameConfig>("Assets/Sources/Config/GameConfig.asset");
                _contexts.config.SetGameConfig(gameConfigSO);
            }
        }

        protected void SetPrivateField(string fieldName, object obj, object value) {
            FieldInfo fieldInfo = obj.GetType()
                .GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic);
            fieldInfo.SetValue(obj, value);
        }

        protected void SetPropertyField(string fieldName, object obj, object value) {
            FieldInfo fieldInfo = obj.GetType()
                .GetField(fieldName, BindingFlags.Instance | BindingFlags.GetProperty);
            fieldInfo.SetValue(obj, value);
        }

        protected void SetPrivateField(string fieldName, Type type, object obj, object value) {
            FieldInfo fieldInfo = null;

            while (type != null) {
                fieldInfo = type.GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic);

                if (fieldInfo != null) break;

                type = type.BaseType;
            }

            if (fieldInfo == null) {
                throw new Exception("Field '" + fieldInfo + "' not found in type hierarchy.");
            }

            fieldInfo.SetValue(obj, value);
        }
    }
}