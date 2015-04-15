using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Enemy : MonoBehaviour
{
	public int health; //hp
	public int Value; //gold worth when killed
	Slider Sl; // UI slider hp bar

	/*Gold on enemy death event/delegate system*/
	public delegate void DeathGold(int amount);
	public static event DeathGold Handler;

	// Use this for initialization
	void Start () 
	{
		Sl = this.GetComponentInChildren<Slider>();//reference the slider
		Sl.maxValue = health;//set max value to starting enemy hp
	}
	
	// Update is called once per frame
	void Update () 
	{
		Sl.value = health;//change slider to reflect current hp
	}
	public void TakeDamage(int d)//method subscribed to a tower dmg event
	{
		health -= d;//lose the appropriate amount of hp
		if (health == 0)//if enemy is dead
		{
			Handler(Value);//broadcast event
			this.GetComponent<AudioSource>().Play ();
			this.GetComponentInChildren<Renderer>().enabled = false;
			GetComponentInChildren<Canvas>().enabled = false;
			StartCoroutine ("Death");
		}
	}
	IEnumerator Death()
	{
		yield return new WaitForSeconds (.7f);
		Destroy (this.gameObject);//he died
	}
}
