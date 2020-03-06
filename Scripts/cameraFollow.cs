using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour {

	public Transform target;
	public Transform camera;
	public Vector3 offset;

	// Update is called once per frame
	void LateUpdate () {
		camera.position = target.position + offset;
	}
}
