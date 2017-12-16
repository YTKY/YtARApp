using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAttackController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//　コライダのIsTriggerのチェックを外し物理的な衝突をさせる場合
	void OnCollisionEnter(Collision col) {
		Destroy(gameObject);
		Material mat = col.gameObject.GetComponent<Renderer> ().material;
	
		if (mat.color == Color.red) {
			Destroy (col.gameObject);
		} else {
			mat.color = Color.red;
		}
	}



}
