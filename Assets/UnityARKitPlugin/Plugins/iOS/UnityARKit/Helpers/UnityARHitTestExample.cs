using System;
using System.Collections.Generic;
using UnityEngine.UI;

namespace UnityEngine.XR.iOS
{
	public class UnityARHitTestExample : MonoBehaviour
	{
		public Transform m_HitTransform;
        public Text text;
        
        bool HitTestWithResultType (ARPoint point, ARHitTestResultType resultTypes)
        {
            List<ARHitTestResult> hitResults = UnityARSessionNativeInterface.GetARSessionNativeInterface ().HitTest (point, resultTypes);
            if (hitResults.Count > 0) {
                foreach (var hitResult in hitResults) {
                    text.text = "Got hit!";                    
                    m_HitTransform.position = UnityARMatrixOps.GetPosition (hitResult.worldTransform);
                    m_HitTransform.rotation = UnityARMatrixOps.GetRotation (hitResult.worldTransform);
                    Debug.Log (string.Format ("x:{0:0.######} y:{1:0.######} z:{2:0.######}", m_HitTransform.position.x, m_HitTransform.position.y, m_HitTransform.position.z));
                    return true;
                }
            } else {
                text.text = "Not hit!";
            }
            return false;
        }
		
		// Update is called once per frame
		void Update () {
			// if (Input.touchCount > 0 && m_HitTransform != null)
			// {
			// 	var touch = Input.GetTouch(0);
			// 	if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved)
			// 	{
			// 		var screenPosition = Camera.main.ScreenToViewportPoint(touch.position);
			// 		ARPoint point = new ARPoint {
			// 			x = screenPosition.x,
			// 			y = screenPosition.y
			// 		};
            //         if (HitTestWithResultType (point, ARHitTestResultType.ARHitTestResultTypeExistingPlane))
            //         {
            //             return;
            //         }
			// 	}
			// }
		}

	
	}
}
