using UnityEngine;

public interface ICamera {
    GameEntity ScreenPointToRay(Vector3 point);
    Vector3 ScreenPointToWorld(Vector3 point);
}