using DigitalRubyShared;
using Entitas;
using UnityEngine;

public sealed class InputGestureSystem : IInitializeSystem, IExecuteSystem, ITearDownSystem {
    readonly Contexts _contexts;
    private ApelmonGestureRecognizer _gesture;

    private bool IsPointerUp { get; set; }
    private bool IsPointerMove { get; set; }
    private bool IsPointerDown { get; set; }

    private Vector2 _touchCoords;
    private bool _touchExist = false;

    public InputGestureSystem(Contexts contexts) {
        _contexts = contexts;
    }

    public void Initialize() {
        _gesture = new ApelmonGestureRecognizer();
        _gesture.MinimumNumberOfTouchesToTrack = 1;
        _gesture.MaximumNumberOfTouchesToTrack = 1;
        
        FingersScript.Instance.AddGesture(_gesture);
    }

    public void Execute() {
        UpdatePointers();

        var input = _contexts.input;

        input.isPointerDown = IsPointerDown;
        input.isPointerMove = IsPointerMove;
        input.isPointerUp = IsPointerUp;

        if (input.isPointerDown || input.isPointerMove || input.isPointerUp) {
            UpdateTouchCoords();
            input.ReplacePointerPosition(ScreenToWorldPoint());
        }

//        if (input.isPointerDown) {
//            Debug.Log("Down -> " + input.pointerDownEntity.pointerPosition.value);
//        }
//
//        if (input.isPointerMove) {
//            Debug.Log("Move -> " + input.pointerMoveEntity.pointerPosition.value);
//        }
//
//        if (input.isPointerUp) {
//            Debug.Log("Up   -> " + input.pointerUpEntity.pointerPosition.value);
//        }
    }

    private void UpdateTouchCoords() {
        if (_gesture.CurrentTrackedTouches.Count > 0) {
            _touchCoords.Set(_gesture.CurrentTrackedTouches[0].X, _gesture.CurrentTrackedTouches[0].Y);
        }
    }

    private void UpdatePointers() {
        if (_gesture == null) {
            return;
        }

        if (!IsPointerUp) {
            IsPointerDown = _gesture.State == GestureRecognizerState.Began;
            IsPointerMove = _gesture.State == GestureRecognizerState.Executing;
        }

        if (_gesture.State == GestureRecognizerState.Began ||
            _gesture.State == GestureRecognizerState.Executing) {
            _touchExist = true;
        }

        if (_gesture.State != GestureRecognizerState.Began &&
            _gesture.State != GestureRecognizerState.Executing &&
            _touchExist) {
            IsPointerUp = true;
            _touchExist = false;
        }
        else {
            IsPointerUp = false;
        }
    }

    private Vector3 ScreenToWorldPoint() {
//        var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//Debug.Log(_touchCoords);
//        var pos = Camera.main.ScreenToWorldPoint(_touchCoords);
//        pos.z = 0;
//Debug.Log(Camera.main.ScreenToViewportPoint(_touchCoords));
//        var pos = GetWorldPositionOnPlane(_touchCoords, 0.0f);
//        var pos = Camera.main.ScreenToViewportPoint(_touchCoords);
        var pos = _touchCoords;
        return pos;
    }
    
    public Vector3 GetWorldPositionOnPlane(Vector3 screenPosition, float y) {
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        UnityEngine.Plane xy = new UnityEngine.Plane(Vector3.up, new Vector3(0, y, 0));
        float distance;
        xy.Raycast(ray, out distance);
        return ray.GetPoint(distance);
    }

    public void TearDown() {
        var gestures = FingersScript.Instance.Gestures;
        while (gestures.Count > 0) {
            FingersScript.Instance.RemoveGesture(gestures[gestures.Count - 1]);
        }
    }
}