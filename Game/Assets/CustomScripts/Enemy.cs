using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Enemy : MonoBehaviour
{
	public int health; 
	public int count;
	public int Value;
	Slider Sl;

	public delegate void DeathGold(int amount);
	public static event DeathGold Handler;

	// Use this for initialization
	void Start () 
	{
		Sl = this.GetComponentInChildren<Slider>();
		Sl.maxValue = health;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Sl.value = health;


		if (health == 0)
		{
			Handler(Value);
			Destroy (this.gameObject);
		}
	}
	public void TakeDamage(int d)
	{
		health -= d;
	}
}
