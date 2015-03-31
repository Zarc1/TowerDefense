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
		if (Input.GetMouseButtonDown(0)) //onclick
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//raycast
			RaycastHit hit;
			if(Physics.Raycast(ray,out hit))
			{
				if (hit.transform.tag == "SpawnSpot1")//if it hit a spawn sphere
				{
					hitSphere = hit.transform.gameObject;//make raycast hit local reference 
					print (hitSphere.name);//debug
					p.SetActive (true);//open UI panel
				}	
			}
		}
	}
	void SpawnMagic()//spawn orc/magic tower
	{
		if (hitSphere)//make sure spawn location exists 
		{
			if (goldobj.GetComponentInChildren<Gold>().goldAmount >= 2000)//make sure we have enough gold
			{
				GameObject NewOrc = Instantiate (OrcTower, hitSphere.transform.position, hitSphere.transform.rotation) as GameObject;//new instance of turret
				Destroy (hitSphere.transform.gameObject);//replaces the sphere
				p.SetActive (false);//deactivate the UI
				goldobj.GetComponentInChildren<Gold>().LoseGold (2000);//call the lose gold function
			}
		}
	}
	void SpawnArrow()//spawn guard/arrow tower
	{
		if (hitSphere)//make sure spawn location exists 
		{
			if (goldobj.GetComponentInChildren<Gold>().goldAmount >= 1000)//make sure we have enough gold
			{
				GameObject NewWatch = Instantiate (WatchTower, hitSphere.transform.position, hitSphere.transform.rotation) as GameObject;//new instance of turret
				Destroy (hitSphere.transform.gameObject);//replaces the sphere
				p.SetActive (false);//deactivate the UI
				goldobj.GetComponentInChildren<Gold>().LoseGold (1000);//call the lose gold function
			}
		}
	}
}
