using Entitas;
using Entitas.Unity;
using UnityEngine;

public class CameraView : UnityView, ICamera {
    [SerializeField] private Camera _camera;
    [SerializeField] private LayerMask _layerMask;
    private float _prevFOV = -1;
    private float _tweenTime;
    private float _tweenDelay;

    public override void Initialize(Contexts contexts, IEntity entity) {
        base.Initialize(contexts, entity);

        _camera = GetComponent<Camera>();

        LinkedEntity.isMainCamera = true;
        LinkedEntity.AddCamera(this);
        LinkedEntity.AddPosition(Position);

        AddDefaultListeners();
    }

    public GameEntity ScreenPointToRay(Vector3 point) {
        RaycastHit hit;
        Ray ray = _camera.ScreenPointToRay(point);
        GameEntity _entity = null;

        if (Physics.Raycast(ray, out hit)) {
            if (hit.collider.gameObject.GetEntityLink() != null) {
                _entity = (GameEntity) hit.collider.gameObject.GetEntityLink().entity;
            }
        }

        return _entity;
    }

    public Vector3 ScreenPointToWorld(Vector3 point) {
        Ray ray = _camera.ScreenPointToRay(point);
        RaycastHit hit;
        Physics.Raycast(ray, out hit, 20, _layerMask);
        return (hit.collider != null) ? hit.point : Vector3.zero;
    }
}