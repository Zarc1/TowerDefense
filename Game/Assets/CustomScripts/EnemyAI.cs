using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour 
{
	GameObject target;
	GameObject GM;
	// Use this for initialization
	void Start () 
	{
		GM = GameObject.Find ("GameManager");
		target = GameObject.Find ("Target");//pathfinding destination
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Vector3.Distance (target.transform.position, this.transform.position) < 3f)//if we reach our target
		{
			if(this.GetComponentInChildren<Renderer>().enabled == true)
			{
				GM.GetComponent<NexusHP>().hp -= this.GetComponent<Enemy>().health * 4f;
				GM.GetComponent<NexusHP>().SetText ();
				GM.GetComponent<RoundManager>().EnemyDeath ();
				Destroy (this.gameObject);//destroy
			}
		}
		/*Logic here for lose condition*/
	}
}
