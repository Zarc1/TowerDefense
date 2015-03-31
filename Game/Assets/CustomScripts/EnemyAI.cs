using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour 
{
	GameObject target;
	// Use this for initialization
	void Start () 
	{
		target = GameObject.Find ("Target");//pathfinding destination
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Vector3.Distance (target.transform.position, this.transform.position) < 3f)//if we reach our target
			Destroy (this.gameObject);//destroy
		/*Logic here for lose condition*/
	}
}
