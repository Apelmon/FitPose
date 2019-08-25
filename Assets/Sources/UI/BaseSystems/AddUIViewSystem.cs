using System.Collections.Generic;
using DesperateDevs.Utils;
using Entitas;
using UnityEngine;

public class AddUIViewSystem : ReactiveSystem<UiEntity> {
    private Contexts _contexts;
    private RectTransform _root;

    public AddUIViewSystem(Contexts contexts) : base(contexts.ui) {
        _contexts = contexts;
        
        var _viewRoot = GameObject.Find("Canvas");
//        _root = (_viewRoot == null) ? new GameObject("ViewRoot").transform : _viewRoot.transform;
        _root = (RectTransform)_viewRoot?.transform;
    }

    protected override ICollector<UiEntity> GetTrigger(IContext<UiEntity> context) {
        return context.CreateCollector(UiMatcher.Asset.Added());
    }
    
    protected override bool Filter(UiEntity entity) {
        return entity.hasAsset || !entity.hasUiView;
    }

    protected override void Execute(List<UiEntity> entities) {
        foreach (var entity in entities) {
            var assetName = entity.asset.value;
            var parent = entity.hasUIParent ? entity.uIParent.value : null;
            var view = entity.isPooled
                ? getViewFromObjectPool(assetName, parent)
                : instantiateView(assetName, parent);

            view.name = assetName;
            view.Initialize(_contexts, entity);
            entity.AddUiView(view);
            
//            if (viewObject == null)
//                throw new NullReferenceException(string.Format("{0} not found!", asset));
        
//            viewObject.transform.SetParent(_root);

//            LoadInterfaces(_contexts, entity, viewObject);
            
            entity.RemoveAsset();
        }
    }
    
    IUIView getViewFromObjectPool(string assetName, IUIView parent = null)
    {
        var e = _contexts.ui.GetEntityWithUiObjectPool(assetName);
        if (e == null)
        {
            e = _contexts.ui.CreateEntity();
            e.AddUiObjectPool(assetName, new ObjectPool<IUIView>(() => instantiateView(assetName, parent)));
        }

        var view = e.uiObjectPool.value.Get();
        view.rectTransform.SetParent(parent?.rectTransform);
        return view;
    }

    IUIView instantiateView(string assetName, IUIView parent = null)
    {
        var prefab = Resources.Load<GameObject>(assetName);
        var gameObject = Object.Instantiate(prefab, parent?.rectTransform);
        return gameObject.GetComponent<IUIView>();
    }

    private void LoadInterfaces(Contexts contexts, UiEntity entity, object obj) {
        GameObject viewObject = (GameObject) obj;

        var view = viewObject.GetComponent<IUIView>();
        if (view != null) {
            view.Initialize(contexts, entity);
            entity.AddUiView(view);
        }
    }
}