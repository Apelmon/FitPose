using System.Collections.Generic;
using DesperateDevs.Utils;
using Entitas;
using Entitas.Unity;
using UnityEngine;

public class AddViewSystem : ReactiveSystem<GameEntity> {
    private Contexts _contexts;
    private Transform _root;

    public AddViewSystem(Contexts contexts) : base(contexts.game) {
        _contexts = contexts;
        
        var _viewRoot = GameObject.Find("ViewRoot");
        _root = (_viewRoot == null) ? new GameObject("ViewRoot").transform : _viewRoot.transform;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
        return context.CreateCollector(GameMatcher.Asset.Added());
    }
    
    protected override bool Filter(GameEntity entity) {
        return entity.hasAsset || !entity.hasView;
    }

    protected override void Execute(List<GameEntity> entities) {
        foreach (var entity in entities) {
            var view = InitView(entity);

            AddViewComponents(view.gameObject, entity);
            
            for (var i = 0; i < view.gameObject.transform.childCount; i++) {
                var go = view.gameObject.transform.GetChild(i).gameObject;
                
                
                if (!go.activeSelf)
                    continue;

                var childView = go.GetComponent<IView>();

                if (childView != null && childView.gameObject != null && childView.gameObject.GetEntityLink() == null) {
                    var e = _contexts.game.CreateEntity();
                    e.AddView(childView);
                    childView.Initialize(_contexts, e);
                    
//                    Debug.Log("add parent -> " + childView.name);

                    AddViewComponents(go, e);
                }
            }
            
            entity.RemoveAsset();
        }
    }

    private void AddViewComponents(GameObject go, GameEntity e) {
        foreach (var component in go.GetComponents<IViewComponent>())
            component.Initialize(_contexts, e);
    }

    private IView InitView(GameEntity entity) {
        var assetName = entity.asset.value;
        var parent = entity.hasParent ? entity.parent.value : null;
        var view = entity.isPooled
            ? getViewFromObjectPool(assetName, parent)
            : instantiateView(assetName, parent);

        view.name = assetName;
        view.Initialize(_contexts, entity);
        entity.AddView(view);
        
//        var go = view.gameObject;

//        for (var i = 0; i < go.transform.childCount; i++)
//            InitGOView(go.transform.GetChild(i).gameObject);
        
        return view;
    }

//    private void InitGOView(GameObject go) {
//        if (!go.activeSelf)
//            return;
//
//        var view = go.GetComponent<IView>();
//
//        if (view != null) {
//            var e = _contexts.game.CreateEntity();
//            e.AddView(view);
//            view.Initialize(_contexts, e);
//
////            foreach (var component in go.GetComponents<IViewComponent>())
////                component.Initialize(_contexts, e);
//        }
//
//        for (var i = 0; i < go.transform.childCount; i++)
//            InitGOView(go.transform.GetChild(i).gameObject);
//    }

    IView getViewFromObjectPool(string assetName, IView parent = null)
    {
        var e = _contexts.game.GetEntityWithObjectPool(assetName);
        if (e == null)
        {
            e = _contexts.game.CreateEntity();
            e.AddObjectPool(assetName, new ObjectPool<IView>(() => instantiateView(assetName, parent)));
        }

        var view = e.objectPool.value.Get();
        view.gameObject.transform.SetParent((parent == null) ? _root : parent.gameObject.transform);
        return view;
    }

    IView instantiateView(string assetName, IView parent = null)
    {
//        Addressables.Instantiate<GameObject> (entity.content.value).Completed += (operation) =>
//        {
//            if (operation.Result != null)
//            {
//                operation.Result.Link (entity);
//                operation.Result.RegisterEventListeners (context, entity);
//                operation.Result.RegisterCoreEmitters (entity.coreEntityId.value);
//                entity.ReplaceView (operation.Result);
//            }
//        };
        
        var prefab = Resources.Load<GameObject>(assetName);
        var gameObject = Object.Instantiate(prefab, (parent == null) ? _root : parent.gameObject.transform);
        return gameObject.GetComponent<IView>();
    }

    private void LoadInterfaces(Contexts contexts, GameEntity entity, object obj) {
        GameObject viewObject = (GameObject) obj;

        var view = viewObject.GetComponent<IView>();
        if (view != null) {
            view.Initialize(contexts, entity);
            entity.AddView(view);
        }
    }
}