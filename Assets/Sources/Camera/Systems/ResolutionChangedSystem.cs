using Entitas;
using UnityEngine;

public sealed class ResolutionChangedSystem : IExecuteSystem {

    readonly Contexts _contexts;
    private int _width;
    private int _height;

    public ResolutionChangedSystem(Contexts contexts) {
        _contexts = contexts;
        _width = -1;
        _height = -1;
    }
    
    public void Execute() {
        if (_contexts.game.isMainCamera) {
            if (_width != Screen.width || _height != Screen.height) {
                _width = Screen.width;
                _height = Screen.height;

                _contexts.game.CreateEntity().isResolutionChanged = true;
            }
        }    
    }
}