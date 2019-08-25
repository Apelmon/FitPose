using Entitas;

public sealed class UpdatePoseSystem : IExecuteSystem {

    readonly Contexts _contexts;
    
    public UpdatePoseSystem(Contexts contexts) {
        _contexts = contexts;
    }
    
    public void Execute() {
            
    }
}