public class UpdateSystems : Feature {
    public UpdateSystems(Contexts contexts) {
        Add(new AddEntityIdSystem(contexts));
        Add(new InitGameStatesSystem(contexts));
//        Add(new ResolutionWasChangedLastFrameSystem(contexts));
//        Add(new ResolutionChangedSystem(contexts));
        
        Add(new GameStateFeature(contexts));
        
        Add(new InputGestureSystem(contexts));

        Add(new TouchDownSystem(contexts));
        Add(new TouchMoveSystem(contexts));
        Add(new TouchUpSystem(contexts));
        

        Add(new ShakeSystem(contexts));

        Add(new CollisionFeature(contexts));
        
        Add(new PrepareToGameplayStateSystem(contexts));

        Add(new TimerSystems(contexts));
        Add(new TimersFeature(contexts));

        Add(new UIFeature(contexts));
        Add(new UpdateTimeSystem(contexts));

        Add(new AddViewSystem(contexts));
        Add(new AddUIViewSystem(contexts));

        Add(new UnlinkViewSystem(contexts));
        Add(new UnlinkUIViewSystem(contexts));

        Add(new DestroyNextFrameSystem(contexts));

        Add(new GameEventSystems(contexts));
        Add(new UiEventSystems(contexts));
        Add(new GameStateEventSystems(contexts));
        
        Add(new GameCleanupSystems(contexts));
        Add(new UiCleanupSystems(contexts));
        Add(new InputCleanupSystems(contexts));
    }
}