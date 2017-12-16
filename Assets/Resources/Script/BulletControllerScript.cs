using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControllerScript : MonoBehaviour {
	public GameObject bullet;
	public Transform muzzle;
	public float speed;
 
    void Start () {
    }
 
   
    void Shot() {        
        GameObject bulletInstance = GameObject.Instantiate(bullet, muzzle.position, muzzle.rotation);
        Vector3 force;
        force = bulletInstance.transform.forward * speed;        
        bulletInstance.GetComponent<Rigidbody> ().AddForce (force);
        Destroy(bulletInstance, 5);
    }
 
	// Update is called once per frame
	void Update () {
        if (Input.touchCount > 0 ){
            Shot();        
		}
	}
}
