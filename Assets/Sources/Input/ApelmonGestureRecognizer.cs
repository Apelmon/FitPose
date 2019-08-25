//
// Fingers Gestures
// (c) 2015 Digital Ruby, LLC
// http://www.digitalruby.com
// Source code may be used for personal or commercial projects.
// Source code may NOT be redistributed or sold.
// 

using DigitalRubyShared;

//namespace DigitalRubyShared {
    /// <summary>
    /// A pan gesture detects movement of a touch
    /// </summary>
    public class ApelmonGestureRecognizer : GestureRecognizer {
//        private Vector2 touchPosition;

        protected override void TouchesBegan(System.Collections.Generic.IEnumerable<GestureTouch> touches) {
            UpdateTouchState(GestureRecognizerState.Began);
        }

        protected override void TouchesMoved() {
            UpdateTouchState(GestureRecognizerState.Executing);
        }

        protected override void TouchesEnded() {
            UpdateTouchState(GestureRecognizerState.Ended);
        }

        private void UpdateTouchState(GestureRecognizerState state) {
//            UpdateTouchPosition();
            SetState(state);
        }

//        private void UpdateTouchPosition() {
//            if (CurrentTrackedTouches.Count >= 0) {
//                TouchPosition.Set(CurrentTrackedTouches[0].X, CurrentTrackedTouches[0].Y);
//            }
//        }

//        public Vector2 TouchPosition {
//            get { return touchPosition; }
//            set { touchPosition = value; }
//        }

        /// <summary>
        /// Constructor
        /// </summary>
        public ApelmonGestureRecognizer() {
            MinimumNumberOfTouchesToTrack = 1;
            MaximumNumberOfTouchesToTrack = 1;
//            TouchPosition = Vector2.zero;
        }
    }
//}