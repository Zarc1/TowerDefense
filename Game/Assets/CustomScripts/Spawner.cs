using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Spawner : MonoBehaviour {

	public GameObject enemy1;//our enemy prefab
	public float waittime = 6f;//time between spawns
	Transform Target;//target to walk to
	public GameObject GM;

	bool canSpawn = true;
	
	// Use this for initialization
	void Start () 
	{
		Target = GameObject.Find ("Target").transform;//locate the target the hard way cause prefabs are dumb
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (canSpawn == true)//if we can
		{
			Spawn ();//we do
			canSpawn = false;//but thats tiring
			Invoke ("Wait", waittime);//so we take a break
		}
	}
	void Spawn()
	{
		if (GM.GetComponent<RoundManager>().enemiesLeftToSpawn > 0)
		{
			GameObject enemy = Instantiate (enemy1, transform.position, enemy1.transform.rotation) as GameObject;//make a goon
			//enemy.GetComponent<AI_Pather>().speed = 5;//give him speed
			enemy.GetComponent<AI_Pather> ().target = Target;//search for blood
			GM.GetComponent<RoundManager>().enemiesLeftToSpawn --;
		}

	}
	void Wait()//nifty invokes because im not good with coroutines yet
	{
		canSpawn = true;
	}
}
