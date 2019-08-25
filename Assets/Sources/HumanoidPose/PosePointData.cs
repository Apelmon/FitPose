using System;
using UnityEngine;

[Serializable]
public class PosePointData {
    public Vector3 L;
    public Vector3 M;
    public Vector3 R;

    public PosePointData(Vector3 _L, Vector3 _M, Vector3 _R) {
        L = _L;
        M = _M;
        R = _R;
    }
}