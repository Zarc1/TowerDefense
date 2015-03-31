using UnityEngine;

using System.Collections;

public class MagicTower : MonoBehaviour 
{
	int ColliderNumber = 0;//check if collider is populated
	bool CanShoot = true;//check if attack is on cooldown
	int damage = 5;//damage of the turret attack
	float CDR = 6f;//rate of attack cooldown

	public delegate void TowerAttack(int dmg);//delegate of teh attack
	public static event TowerAttack TA;//the event to subscribe to

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		if ((ColliderNumber > 0) && (CanShoot == true))//if there are enemies and attack isnt on CD
		{
			print ("attacked");
			TA(damage);//call the attack event
			CanShoot = false;//set the tower on cooldown
			Invoke ("CooldownTimer", CDR);//call the cooldown refresh after th appropriate time
		}
	}
	void OnTriggerEnter (Collider c)
	{
		if (c.gameObject.tag == "Enemy")//if an enemy enters the collider
		{
			ColliderNumber ++;//raise the count
			TA += c.gameObject.GetComponent<Enemy>().TakeDamage;//subscribe the enemy to the event
		}
	}
	void OnTriggerExit (Collider c)
	{
		if (c.gameObject.tag == "Enemy")//if an enemy leaves the collider
		{
			ColliderNumber --;//lower the count
			TA -= c.gameObject.GetComponent<Enemy>().TakeDamage;//unsubscribe the enemy to the event
		}
	}
	void CooldownTimer()
	{
		CanShoot = true;
	}
}
