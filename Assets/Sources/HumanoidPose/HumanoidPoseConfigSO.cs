using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Humanoid Pose Config")]
public class HumanoidPoseConfigSO : ScriptableObject {
    public PosePointData Body {
        get { return _Body; }
    }

    public PosePointData LeftFootPole {
        get { return _LeftFootPole; }
    }

    public PosePointData LeftFootTarget {
        get { return _LeftFootTarget; }
    }

    public PosePointData RightFootPole {
        get { return _RightFootPole; }
    }

    public PosePointData RightFootTarget {
        get { return _RightFootTarget; }
    }

    public PosePointData LeftHandPole {
        get { return _LeftHandPole; }
        set { _LeftHandPole = value; }
    }

    public PosePointData LeftHandTarget {
        get { return _LeftHandTarget; }
    }

    public PosePointData RightHandPole {
        get { return _RightHandPole; }
    }

    public PosePointData RightHandTarget {
        get { return _RightHandTarget; }
    }

    [SerializeField] private PosePointData _Body = new PosePointData(
        Vector3.zero, 
        new Vector3(0.0f, -0.03f, 0.0f), 
        Vector3.zero 
        );
    [SerializeField] private PosePointData _LeftFootPole = new PosePointData(
        Vector3.zero, 
        new Vector3(-0.07f, 0.27f, 0.2f), 
        Vector3.zero 
    );
    [SerializeField] private PosePointData _LeftFootTarget = new PosePointData(
        Vector3.zero, 
        new Vector3(-0.1f, 0.07f, 0.0f), 
        Vector3.zero 
    );
    [SerializeField] private PosePointData _RightFootPole = new PosePointData(
        Vector3.zero, 
        new Vector3(0.07f, 0.27f, 0.2f), 
        Vector3.zero 
    );
    [SerializeField] private PosePointData _RightFootTarget = new PosePointData(
        Vector3.zero, 
        new Vector3(0.1f, 0.07f, 0.0f), 
        Vector3.zero 
    );
    [SerializeField] private PosePointData _LeftHandPole = new PosePointData(
        Vector3.zero, 
        new Vector3(-0.12f, 0.52f, -0.1f), 
        Vector3.zero 
    );
    [SerializeField] private PosePointData _LeftHandTarget = new PosePointData(
        Vector3.zero, 
        new Vector3(-0.15f, 0.35f, 0.0f), 
        Vector3.zero 
    );
    [SerializeField] private PosePointData _RightHandPole = new PosePointData(
        Vector3.zero, 
        new Vector3(0.12f, 0.52f, -0.1f), 
        Vector3.zero 
    );
    [SerializeField] private PosePointData _RightHandTarget = new PosePointData(
        Vector3.zero, 
        new Vector3(0.15f, 0.35f, 0.0f), 
        Vector3.zero 
    );
    
//    [SerializeField] private Vector3 _Body = new Vector3(0.0f, -0.03f, 0.0f);

//    [Header("Left Foot Pole")]
//    [SerializeField] private Vector3 _LeftFootPoleL;
//    [SerializeField] private Vector3 _LeftFootPoleM = new Vector3(-0.07f, 0.27f, 0.2f);
//    [SerializeField] private Vector3 _LeftFootPoleR;
    
//    [Header("Left Foot Target")]
//    [SerializeField] private Vector3 _LeftFootTargetL;
//    [SerializeField] private Vector3 _LeftFootTargetM = new Vector3(-0.1f, 0.07f, 0.0f);
//    [SerializeField] private Vector3 _LeftFootTargetR;
    
//    [Header("Right Foot Pole")]
//    [SerializeField] private Vector3 _RightFootPoleL;
//    [SerializeField] private Vector3 _RightFootPoleM = new Vector3(0.07f, 0.27f, 0.2f);
//    [SerializeField] private Vector3 _RightFootPoleR;
    
//    [Header("Right Foot Target")]
//    [SerializeField] private Vector3 _RightFootTargetL;
//    [SerializeField] private Vector3 _RightFootTargetM = new Vector3(0.1f, 0.07f, 0.0f);
//    [SerializeField] private Vector3 _RightFootTargetR;
    
//    [Header("Left Hand Pole")]
//    [SerializeField] private Vector3 _LeftHandPoleL;
//    [SerializeField] private Vector3 _LeftHandPoleM = new Vector3(-0.12f, 0.52f, -0.1f);
//    [SerializeField] private Vector3 _LeftHandPoleR;
    
//    [Header("Left Hand Target")]
//    [SerializeField] private Vector3 _LeftHandTargetL;
//    [SerializeField] private Vector3 _LeftHandTargetM = new Vector3(-0.15f, 0.35f, 0.0f);
//    [SerializeField] private Vector3 _LeftHandTargetR;
    
//    [Header("Right Hand Pole")]
//    [SerializeField] private Vector3 _RightHandPoleL;
//    [SerializeField] private Vector3 _RightHandPoleM = new Vector3(0.12f, 0.52f, -0.1f);
//    [SerializeField] private Vector3 _RightHandPoleR;
    
//    [Header("Right Hand Target")]
//    [SerializeField] private Vector3 _RightHandTargetL;
//    [SerializeField] private Vector3 _RightHandTargetM = new Vector3(0.15f, 0.35f, 0.0f);
//    [SerializeField] private Vector3 _RightHandTargetR;
}
