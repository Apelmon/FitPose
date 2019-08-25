using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class HumanoidView : UnityView, IAnyPoseValueListener {
    [SerializeField] private HumanoidPoseConfigSO _poseConfig;
    public HumanoidPoseConfigSO PoseConfig {
        get { return _poseConfig; }
    }
    
    [SerializeField] private PoseMode _poseMode;
    public PoseMode PoseMode {
        get { return _poseMode; }
    }

    [SerializeField] private GameObject _body;
    [SerializeField] private GameObject _leftFootPole;
    [SerializeField] private GameObject _leftFootTarget;
    [SerializeField] private GameObject _rightFootPole;
    [SerializeField] private GameObject _rightFootTarget;
    [SerializeField] private GameObject _leftHandPole;
    [SerializeField] private GameObject _leftHandTarget;
    [SerializeField] private GameObject _rightHandPole;
    [SerializeField] private GameObject _rightHandTarget;

    private List<Transform> _points;
    private List<PosePointData> _pointsPoses;
    
    public override void Initialize(Contexts contexts, IEntity entity) {
        base.Initialize(contexts, entity);

        _points = new List<Transform>() {
            _body.transform,
            _leftFootPole.transform,
            _leftFootTarget.transform,
            _rightFootPole.transform,
            _rightFootTarget.transform,
            _leftHandPole.transform,
            _leftHandTarget.transform,
            _rightHandPole.transform,
            _rightHandTarget.transform,
        };

        _pointsPoses = new List<PosePointData>() {
            _poseConfig.Body,
            _poseConfig.LeftFootPole,
            _poseConfig.LeftFootTarget,
            _poseConfig.RightFootPole,
            _poseConfig.RightFootTarget,
            _poseConfig.LeftHandPole,
            _poseConfig.LeftHandTarget,
            _poseConfig.RightHandPole,
            _poseConfig.RightHandTarget
        };
        
        LinkedEntity.AddAnyPoseValueListener(this);
    }

    public void OnAnyPoseValue(GameEntity entity, float value) {
        var direction = value;
        var index = Mathf.Abs(value);

        var pointA = Vector3.zero;
        var pointB = Vector3.zero;

        for (int i = 0; i < _points.Count; i++) {
            var current = _points[i].position;
            pointA = _pointsPoses[i].M;
            pointB = (direction >= 0) ? _pointsPoses[i].R : _pointsPoses[i].L;
            
            var target = Vector3.Lerp(pointA, pointB, index);

            _points[i].position = target;
        }

    }
}
