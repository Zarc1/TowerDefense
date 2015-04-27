using UnityEngine;

using System.Collections;
using System.Collections.Generic;

public class MagicTower : MonoBehaviour 
{
	public int ColliderNumber = 0;//check if collider is populated
	bool CanShoot = true;//check if attack is on cooldown
	int damage = 5;//damage of the turret attack
	float CDR = 6f;//rate of attack cooldown
	ParticleSystem p;

	public List<GameObject> enemies = new List<GameObject>();

	// Use this for initialization
	void Start () 
	{
		p = this.GetComponentInChildren<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		ColliderNumber = enemies.Count;
		foreach(GameObject g in enemies)
		{
			if(g)
			{
				if(g.GetComponent<Enemy>().health == 0)
				{
					enemies.Remove (g);
					ColliderNumber--;
				}
			}
		}


		if ((ColliderNumber > 0) && (CanShoot == true))//if there are enemies and attack isnt on CD
		{
			print ("attacked");
			Shoot();//call the attack event
			p.Play ();
			this.GetComponent<AudioSource>().Play ();
			CanShoot = false;//set the tower on cooldown
			Invoke ("CooldownTimer", CDR);//call the cooldown refresh after th appropriate time
		}
	}
	void OnTriggerEnter (Collider c)
	{
		if (c.gameObject.tag == "Enemy")//if an enemy enters the collider
		{
			//ColliderNumber ++;//raise the count
			if(!enemies.Contains (c.gameObject))
				enemies.Add (c.gameObject);
		}
	}
	void OnTriggerExit (Collider c)
	{
		if (c.gameObject.tag == "Enemy")//if an enemy leaves the collider
		{
			//ColliderNumber --;//lower the count
			enemies.Remove (c.gameObject);
		}
	}
	void CooldownTimer()
	{
		CanShoot = true;

	}
	void Shoot()
	{
		foreach(GameObject g in enemies)
		{
			if(g)
			{
				g.SendMessage ("TakeDamage", damage);
			}
		}
	}
}
