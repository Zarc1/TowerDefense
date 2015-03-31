using UnityEngine;
using System.Collections;

public class ArrowTower : MonoBehaviour 
{
	bool HasTarget;
	GameObject Target;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	void OnTriggerEnter(Collider c)
	{
		Target = c.gameObject;
		HasTarget = true;
	}
}
