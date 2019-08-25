using Entitas;
using UnityEngine;

public interface IView {
    string name { get; set; }
    bool Enabled { get; set; }
    Vector3 Position { get; set; }
    Vector3 Rotation { get; set; }
    Vector3 Scale { get; set; }

    GameObject gameObject { get; }

void Initialize(Contexts contexts, IEntity entity);
}