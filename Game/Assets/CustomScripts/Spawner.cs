using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject enemy1;
	public float waittime = 6f;
	Transform Target;
	int counter = 0;

	bool canSpawn = true;
	
	// Use this for initialization
	void Start () 
	{
		Target = GameObject.Find ("Target").transform;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (canSpawn == true)
		{
			Spawn ();
			canSpawn = false;
			Invoke ("Wait", waittime);
		}
	}
	void Spawn()
	{
		GameObject enemy = Instantiate (enemy1, transform.position, enemy1.transform.rotation) as GameObject;
		enemy.GetComponent<AI_Pather>().speed = 5;
		enemy.GetComponent<AI_Pather> ().target = Target;
		enemy.GetComponent<Enemy>().count = counter;
		counter++;

	}
	void Wait()
	{
		canSpawn = true;
	}
}
