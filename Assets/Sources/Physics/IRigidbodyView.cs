using UnityEngine;

public interface IRigidbodyView {
    bool IsSleeping { get; }
    bool IsKinematic { get; set; }
    Vector3 CenterOfMass { get; set; }
    float Drag { get; set; }
    float AngularDrag { get; set; }
    void MovePosition(Vector3 value);
    void MoveRotation(Quaternion value);
}