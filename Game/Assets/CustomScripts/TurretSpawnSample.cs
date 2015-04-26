using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TurretSpawnSample : MonoBehaviour 
{
	public GameObject OrcTower;//the orc tower
	public GameObject WatchTower;//the guard tower
	GameObject hitSphere;//local reference for raycasted hit
	public GameObject p;//UI panel to open
	public GameObject goldobj;//UI element with gold script


	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{

	}
	public void Pressed(GameObject g)
	{
		hitSphere = g.gameObject;//make raycast hit local reference 
		p.SetActive (true);//open UI panel
	}
	void SpawnMagic()//spawn orc/magic tower
	{
		if (hitSphere)//make sure spawn location exists 
		{
			if (goldobj.GetComponentInChildren<Gold>().goldAmount >= 2)//make sure we have enough gold
			{
				GameObject NewOrc = Instantiate (OrcTower, hitSphere.transform.position, Quaternion.identity) as GameObject;//new instance of turret
				Destroy (hitSphere.transform.gameObject);//replaces the sphere
				p.SetActive (false);//deactivate the UI
				goldobj.GetComponentInChildren<Gold>().LoseGold (2);//call the lose gold function
			}
		}
	}
	void SpawnArrow()//spawn guard/arrow tower
	{
		if (hitSphere)//make sure spawn location exists 
		{
			if (goldobj.GetComponentInChildren<Gold>().goldAmount >= 1)//make sure we have enough gold
			{
				GameObject NewWatch = Instantiate (WatchTower, hitSphere.transform.position, Quaternion.identity) as GameObject;//new instance of turret
				Destroy (hitSphere.transform.gameObject);//replaces the sphere
				p.SetActive (false);//deactivate the UI
				goldobj.GetComponentInChildren<Gold>().LoseGold (1);//call the lose gold function
			}
		}
	}
}
