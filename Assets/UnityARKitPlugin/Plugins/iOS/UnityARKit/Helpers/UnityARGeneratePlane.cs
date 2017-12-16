using System;
using System.Collections.Generic;
using UnityEngine.UI;

namespace UnityEngine.XR.iOS
{
	public class UnityARGeneratePlane : MonoBehaviour
	{
		public GameObject planePrefab;
		public GameObject enemyPrefab;        
		private string planeAnchorIdentifier;
		private ARPlaneAnchorGameObject planeAnchor;
        
        private bool floorDetection = false;                
        private int numOfUpdate = 0;
        public Text mainMessage;
        public Text debugMessage;        

		// Use this for initialization
		void Start () {
            mainMessage.text = "Detecting floor";
			UnityARSessionNativeInterface.ARAnchorAddedEvent += AddAnchor;
			//UnityARSessionNativeInterface.ARAnchorUpdatedEvent += UpdateAnchor;
			UnityARUtility.InitializePlanePrefab (planePrefab);
		}

        void Update () {
            debugMessage.text = "Current Position \n" +
                "x = " + Camera.main.transform.position.x.ToString() + "\n" +
				"y = " + Camera.main.transform.position.y.ToString() + "\n" +
				"z = " + Camera.main.transform.position.z.ToString() + "\n";
        }
        
        void OnDestroy()
        {
            GameObject.Destroy (planeAnchor.gameObject);
        }

        void OnGUI()
        {
        }

		public void AddAnchor(ARPlaneAnchor arPlaneAnchor)
		{
            Debug.Log ("Detected Anchor");
            mainMessage.text = "Deteced floor";
            if ( !floorDetection ) {
                GameObject go = UnityARUtility.CreatePlaneInScene (arPlaneAnchor);
                go.AddComponent<DontDestroyOnLoad> ();  //this is so these GOs persist across scene loads
                ARPlaneAnchorGameObject arpag = new ARPlaneAnchorGameObject ();
                arpag.planeAnchor = arPlaneAnchor;
                arpag.gameObject = go;
                planeAnchorIdentifier = arPlaneAnchor.identifier;
                planeAnchor = arpag;


                // Create Enemy
                GameObject enemyInstance = GameObject.Instantiate(enemyPrefab);
                Vector3 enemyPosition = Camera.main.transform.position;
                enemyPosition += new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z);
                enemyInstance.transform.position = enemyPosition;
                Debug.Log (string.Format ("x:{0:0.######} y:{1:0.######} z:{2:0.######}", Camera.main.transform.position.x, Camera.main.transform.position.y,Camera.main.transform.position.z));
                Debug.Log (string.Format ("x:{0:0.######} y:{1:0.######} z:{2:0.######}", enemyPosition.x, enemyPosition.y, enemyPosition.z));                
            }
            floorDetection = true;            
		}

		public void UpdateAnchor(ARPlaneAnchor arPlaneAnchor)
		{
            if ( planeAnchorIdentifier ==  arPlaneAnchor.identifier) {
                numOfUpdate++;
                Debug.Log (numOfUpdate.ToString() + "times updated");
                UnityARUtility.UpdatePlaneWithAnchorTransform (planeAnchor.gameObject, arPlaneAnchor);
                //planeAnchor = arPlaneAnchor;
                planeAnchorIdentifier = arPlaneAnchor.identifier;
			}
		}
	}
}

