using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {
    private Contexts _contexts;

    private void Awake() {
//        Debug.Log("Awake");
    }

    private void Start() {
//        Debug.Log("Start");
    }

    private void OnEnable() {
        _contexts = Contexts.sharedInstance;

//        Debug.Log("Enable");
        SceneManager.sceneLoaded += OnSceneLoadingComplete;
    }

    private void OnDisable() {
//        Debug.Log("Disable");
        SceneManager.sceneLoaded -= OnSceneLoadingComplete;
    }

    private void OnSceneLoadingComplete(Scene scene, LoadSceneMode mode) {
        Debug.Log("Level " + scene.name + " was loaded");
//        Debug.Log(scene.name);
//        Debug.Log(mode);

//        Debug.Log("-----------");
        foreach (var rootGameObject in scene.GetRootGameObjects()) {
            InitView(rootGameObject);
        }

//        _contexts.game.isPushUpdateIcons = true;
    }

    private void InitView(GameObject go) {
        if (!go.activeSelf)
            return;

        var view = go.GetComponent<IView>();

        if (view != null) {
            if (view is IUIView) {
                IUIView uiView = (IUIView) view; 
                var e = _contexts.ui.CreateEntity();
                e.AddUiView(uiView);
                uiView.Initialize(_contexts, e);
            }
            else {
                var e = _contexts.game.CreateEntity();
                e.AddView(view);
                view.Initialize(_contexts, e);
    
                foreach (var component in go.GetComponents<IViewComponent>())
                    component.Initialize(_contexts, e);
            }
        }

        for (var i = 0; i < go.transform.childCount; i++)
            InitView(go.transform.GetChild(i).gameObject);

        _contexts.gameState.SwitchToState(GameStateExtensions.INITIALIZATION);
    }
}