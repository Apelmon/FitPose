using Entitas.Unity;
using UnityEngine;

public static class EntitasUnityHelpers {
    public static bool GetEntity(this GameObject go, out GameEntity entity) {
        entity = null;
        var view = go.GetComponent<IView>();
        if (view == null || view.gameObject == null || view.gameObject.GetEntityLink() == null ||
            !view.gameObject.GetEntityLink().entity.isEnabled) return false;
//        if (view == null || view.Entity == null || !view.Entity.isEnabled) return false;
        entity = view.gameObject.GetEntityLink().entity as GameEntity;
        return true;
    }
}