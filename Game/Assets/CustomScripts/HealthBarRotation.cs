using UnityEngine;
using System.Collections;

public class HealthBarRotation : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	void LateUpdate()
	{
		if (transform.rotation != Quaternion.Euler(54f, 0, 0))//if for some reason its not this value
			transform.rotation = Quaternion.Euler(54f, 0, 0);//make it this value (facing the camera, as the hp bar exists in world space)
	}
}
