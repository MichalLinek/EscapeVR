using System.Collections;
using System.Collections.Generic;
using UnityEngine;

	public class TouchpadMovement : MonoBehaviour
    {
        public Transform forwardDirection;
        OVRPlayerController oVPC;
        // Use this for initialization
        void Start()
        {
            oVPC = GetComponent<OVRPlayerController>();
            OVRTouchpad.Create();
            OVRTouchpad.TouchHandler += HandleTouchHandler;
        }

        void HandleTouchHandler(object sender, System.EventArgs e)
        {
            OVRTouchpad.TouchArgs touchArgs = (OVRTouchpad.TouchArgs)e;
            OVRTouchpad.TouchEvent touchEvent = touchArgs.TouchType;
            /*if(touchArgs.TouchType == OVRTouchpad.TouchEvent.SingleTap)
            {
                //TODO: Insert code here to handle a single tap.  Note that there are other TouchTypes you can check for like directional swipes, but double tap is not currently implemented I believe.
            }*/

            switch (touchEvent)
            {
                //case OVRTouchpad.TouchEvent.SingleTap:
                //    //Do something for Single Tap
                //    break;

                //case OVRTouchpad.TouchEvent.Left:
                //    oVPC.UpdateMovement(Vector3.left);
                //    break;

                //case OVRTouchpad.TouchEvent.Right:
                //    oVPC.UpdateMovement(Vector3.right);
                //    break;

                //case OVRTouchpad.TouchEvent.Up:
                //    oVPC.UpdateMovement(Vector3.forward);
                //    break;

                //case OVRTouchpad.TouchEvent.Down:
                //    //oVPC.UpdateMovement(Vector3.back);
                //    break;
            }
        }
    }
