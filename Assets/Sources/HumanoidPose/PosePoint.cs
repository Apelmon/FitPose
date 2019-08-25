using UnityEngine;

[ExecuteInEditMode]
public class PosePoint : MonoBehaviour
{
    [SerializeField] private PosePointEnum _type;
    
    [HideInInspector] [SerializeField] private Vector3 _lastPosition;
    [HideInInspector] [SerializeField] private PoseMode _lastPoseMode;
    private HumanoidView _view;
    private HumanoidPoseConfigSO _config;
    private bool _updateLastPosition = false;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (_view == null) {
            _view = transform.parent.GetComponent<HumanoidView>();
        }

        if (_config == null) {
            _config = _view.PoseConfig;
        }

        if (_lastPoseMode != _view.PoseMode) {
            _updateLastPosition = true;
        }

        if (_updateLastPosition) {
            _updateLastPosition = false;
            UpdateLastPosition();
        }
    }

    void UpdateLastPosition() {
        switch (_lastPoseMode) {
            case PoseMode.L:
//                _lastPosition = 
                break;
            case PoseMode.M:
                break;
            case PoseMode.R:
                break;
        }
    }
}

public enum PoseMode {
    L,
    M,
    R
}

public enum PosePointEnum {
    None,
    Body,
    LeftFootPose,
    LeftFootTarget,
    RightFootPose,
    RightFootTarget,
    LeftHandPose,
    LeftHandTarget,
    RightHandPose,
    RightHandTarget
}
