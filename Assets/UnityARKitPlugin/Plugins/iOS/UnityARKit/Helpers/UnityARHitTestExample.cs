using System;
using System.Collections.Generic;
using UnityEngine.UI;

namespace UnityEngine.XR.iOS
{
	public class UnityARHitTestExample : MonoBehaviour
	{
		public Transform m_HitTransform;
        public Text text;

		public GameObject bullet;
		public Transform muzzle;
		public float speed;
        
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
				// 玉を発射
				if (Application.isEditor)
				{
						if (Input.GetMouseButtonUp(0))
						{
					Shot ();
				}
				}
				else
				{
					if (Input.touchCount > 0)
					{
						Touch touch = Input.GetTouch(0);
						if (touch.phase == TouchPhase.Ended)
						{
						Shot ();
						}	
					}
				}   
		}


		void Shot() {        
			GameObject bulletInstance = GameObject.Instantiate(bullet, muzzle.position, muzzle.rotation);
			Vector3 force;
			force = bulletInstance.transform.forward * speed;        
			bulletInstance.GetComponent<Rigidbody> ().AddForce (force);
			Destroy(bulletInstance, 5);
		}

	}
}

