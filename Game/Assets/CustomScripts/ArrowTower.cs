using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ArrowTower : MonoBehaviour 
{
	public int ColliderNumber = 0;//check if collider is populated
	public GameObject arrow;
	public int level = 1;
	bool CanShoot = true;//check if attack is on cooldown
	public float damage = 1;//damage of the turret attack
	public float CoolDown = 1.5f;
	GameObject target;
	
	public List<GameObject> enemies = new List<GameObject>();

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		enemies.Sort (SortMethod);
		ColliderNumber = enemies.Count;
		foreach(GameObject g in enemies)
		{
			if(g)
			{
				if(g.GetComponent<Enemy>().health <= 0)
				{
					enemies.Remove (g);
					ColliderNumber--;
				}
			}
		}
		if ((ColliderNumber > 0) && (CanShoot == true))//if there are enemies and attack isnt on CD
		{
			enemies.Sort (SortMethod);
			Shoot();//call the attack event
			SpawnArrow ();
			this.GetComponent<AudioSource>().Play ();
			CanShoot = false;//set the tower on cooldown
			StartCoroutine ("CD");
		}
	}
	void OnTriggerEnter(Collider c)
	{
		if (c.gameObject.tag == "Enemy")//if an enemy enters the collider
		{
			enemies.Sort (SortMethod);
			//ColliderNumber ++;//raise the count
			if(!enemies.Contains (c.gameObject))
				enemies.Add (c.gameObject);
		}
	}
	void OnTriggerExit (Collider c)
	{
		if (c.gameObject.tag == "Enemy")//if an enemy leaves the collider
		{
			//enemies.Sort (SortMethod);
			//ColliderNumber --;//lower the count
			enemies.Remove (c.gameObject);
		}
	}
	void Shoot()
	{
		target = enemies[0];
		target.SendMessage ("TakeDamage", damage);
	}
	private int SortMethod(GameObject A, GameObject B)
	{
		if (A.GetComponent<AI_Pather>().currentWaypoint < B.GetComponent<AI_Pather>().currentWaypoint) 
			return 1;
		else if (A.GetComponent<AI_Pather>().currentWaypoint > B.GetComponent<AI_Pather>().currentWaypoint) 
			return -1;
		else
			return 0;
	}



	IEnumerator CD()
	{
		yield return new WaitForSeconds(CoolDown);
		CanShoot = true;
	}
	void SpawnArrow()
	{
		GameObject temp = Instantiate (arrow, this.transform.position + new Vector3(0, 1, 0), Quaternion.identity) as GameObject;
		temp.GetComponent<Arrow>().SetTarget (target.transform);
	}
}
