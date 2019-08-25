using Entitas;
using UnityEngine;

public class RigidbodyView : UnityView, IRigidbodyView {
    [SerializeField] private Rigidbody _rigidbody;
    private bool _isSleeping;
    private bool _isKinematic;
    private Vector3 _centerOfMass;
    private float _drag;
    private float _angularDrag;

    public override void Initialize(Contexts contexts, IEntity entity) {
        base.Initialize(contexts, entity);

        _rigidbody = GetComponent<Rigidbody>();
        
        LinkedEntity.AddRigidbody(this);
    }

    public override void OnDestroyed(GameEntity entity) {
        Position = Vector3.zero;
        Rotation = Vector3.zero;
        if (_rigidbody != null) {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = Vector3.zero;
        }
        
        base.OnDestroyed(entity);
    }

    public bool IsSleeping => _rigidbody.IsSleeping();

    public bool IsKinematic {
        get => _rigidbody.isKinematic;
        set => _rigidbody.isKinematic = value;
    }

    public Vector3 CenterOfMass {
        get => _rigidbody.centerOfMass;
        set => _rigidbody.centerOfMass = value;
    }

    public float Drag {
        get => _rigidbody.drag;
        set => _rigidbody.drag = value;
    }

    public float AngularDrag {
        get => _rigidbody.angularDrag;
        set => _rigidbody.angularDrag = value;
    }

    public void MovePosition(Vector3 value) {
        
    }

    public void MoveRotation(Quaternion value) {
        throw new System.NotImplementedException();
    }
}