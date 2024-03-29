﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DigitalRubyShared
{
    [AddComponentMenu("Fingers Gestures/Component/Fingers One Touch Scale Axis", 3)]
    public class FingersOneTouchScaleAxisComponentScript : MonoBehaviour
    {
        [Tooltip("Threshold that a one touch scale can move (in units) in the wrong direction before being reset")]
        [Range(0.0f, 1.0f)]
        public float AxisThresholdUnits = 0.15f;

        [Tooltip("Zoom speed on x axis, can be negative to invert")]
        [Range(-10.0f, 10.0f)]
        public float ZoomSpeedX = 1.0f;

        [Tooltip("Zoom speed on y axis, can be negative to invert")]
        [Range(-10.0f, 10.0f)]
        public float ZoomSpeedY = 1.0f;

        [Tooltip("Transform to scale, defaults to transform that this script is on")]
        public Transform TransformToScale;

        [Tooltip("The view that must be touched to scale on x axis, null for anywhere")]
        public GameObject XAxisTransformDragView;

        [Tooltip("The view that must be touched to scale on y axis, null for anywhere")]
        public GameObject YAxisTransformDragView;

        /// <summary>
        /// X axis one touch scale gesture
        /// </summary>
        public OneTouchScaleGestureRecognizer XAxisScaleGesture { get; private set; }

        /// <summary>
        /// Y axis one touch scale gesture
        /// </summary>
        public OneTouchScaleGestureRecognizer YAxisScaleGesture { get; private set; }

        private void XAxisStateUpdated(GestureRecognizer r)
        {
            if (TransformToScale == null)
            {
                return;
            }
            else if (r.State == GestureRecognizerState.Began)
            {
                // if moved too much up/down, reset gesture
                float vertUnits = DeviceInfo.PixelsToUnits(r.DistanceY);
                if (vertUnits > 0.15f)
                {
                    r.Reset();
                }
                else
                {
                    // reset y axis gesture, we only want one scale direction at a time
                    YAxisScaleGesture.Reset();
                }
            }
            else if (r.State == GestureRecognizerState.Executing)
            {
                Vector3 scale = TransformToScale.localScale;
                scale.x *= XAxisScaleGesture.ScaleMultiplierX;
                TransformToScale.localScale = scale;
            }
        }

        private void YAxisStateUpdated(GestureRecognizer r)
        {
            if (TransformToScale == null)
            {
                return;
            }
            else if (r.State == GestureRecognizerState.Began)
            {
                // if moved too much left/right, reset gesture
                float horizUnits = DeviceInfo.PixelsToUnits(r.DistanceX);
                if (horizUnits > 0.15f)
                {
                    r.Reset();
                }
                else
                {
                    // reset x axis gesture, we only want one scale direction at a time
                    XAxisScaleGesture.Reset();
                }
            }
            else if (r.State == GestureRecognizerState.Executing)
            {
                Vector3 scale = TransformToScale.localScale;
                scale.y *= YAxisScaleGesture.ScaleMultiplierY;
                TransformToScale.localScale = scale;
            }
        }

        private void Update()
        {
            XAxisScaleGesture.ZoomSpeed = ZoomSpeedX;
            YAxisScaleGesture.ZoomSpeed = ZoomSpeedY;
            XAxisScaleGesture.PlatformSpecificView = XAxisTransformDragView;
            YAxisScaleGesture.PlatformSpecificView = YAxisTransformDragView;
            TransformToScale = (TransformToScale == null ? transform : TransformToScale);
        }

        private void OnEnable()
        {
            XAxisScaleGesture = new OneTouchScaleGestureRecognizer();
            XAxisScaleGesture.StateUpdated += XAxisStateUpdated;
            YAxisScaleGesture = new OneTouchScaleGestureRecognizer();
            YAxisScaleGesture.StateUpdated += YAxisStateUpdated;
            XAxisScaleGesture.AllowSimultaneousExecution(YAxisScaleGesture);
            FingersScript.Instance.AddGesture(XAxisScaleGesture);
            FingersScript.Instance.AddGesture(YAxisScaleGesture);
        }

        private void OnDisable()
        {
            FingersScript.Instance.RemoveGesture(XAxisScaleGesture);
            FingersScript.Instance.RemoveGesture(YAxisScaleGesture);
        }
    }
}
