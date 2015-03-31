using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TurretSpawnSample : MonoBehaviour 
{
	public GameObject OrcTower;
	public GameObject WatchTower;
	GameObject hitSphere;
	public GameObject p;
	public GameObject goldobj;


	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButtonDown(0)) 
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(ray,out hit))
			{
				if (hit.transform.tag == "SpawnSpot1")
				{
					hitSphere = hit.transform.gameObject;
					print (hitSphere.name);
					p.SetActive (true);
				}	
			}
		}
	}
	void SpawnMagic()
	{
		if (hitSphere)
		{
			if (goldobj.GetComponentInChildren<Gold>().goldAmount >= 2000)
			{
				GameObject NewOrc = Instantiate (OrcTower, hitSphere.transform.position, hitSphere.transform.rotation) as GameObject;
				Destroy (hitSphere.transform.gameObject);
				p.SetActive (false);
				goldobj.GetComponentInChildren<Gold>().LoseGold (2000);
			}
		}
	}
	void SpawnArrow()
	{
		if (hitSphere)
		{
			if (goldobj.GetComponentInChildren<Gold>().goldAmount >= 1000)
			{
				GameObject NewWatch = Instantiate (WatchTower, hitSphere.transform.position, hitSphere.transform.rotation) as GameObject;
				Destroy (hitSphere.transform.gameObject);
				p.SetActive (false);
				goldobj.GetComponentInChildren<Gold>().LoseGold (1000);
			}
		}
	}
}
