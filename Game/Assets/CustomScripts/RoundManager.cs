using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class RoundManager : MonoBehaviour 
{
	public int roundNumber;
	public int enemiesLeftToSpawn;
	public int enemiesLeft;
	int r = 1;
	public Round CurrentRound;
	public List<Round> Rounds = new List<Round>();
	public GameObject localSpawner;
	public GameObject BeginButton;
	public GameObject REnemies;
	public GameObject RName;

	// Use this for initialization
	void Start () 
	{
		r = 1;

		Round r1 = new Round();
		r1.totalEnemies = 10;
		Rounds.Add (r1);

		Round r2 = new Round();
		r2.totalEnemies = 15;
		Rounds.Add (r2);

		Round r3 = new Round();
		r3.totalEnemies = 25;
		Rounds.Add (r3);

		CurrentRound = Rounds[0];
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	public void BeginRound()
	{
		enemiesLeftToSpawn = CurrentRound.totalEnemies;
		enemiesLeft = enemiesLeftToSpawn;
		RName.GetComponent<Text>().text = "Round: " + r;
		REnemies.GetComponent<Text>().text = "Enemies left: " + enemiesLeft;
		BeginButton.SetActive (false);
	//	localSpawner.GetComponent<Spawner>().enabled = true;
	}
	public void EnemyDeath()
	{
		enemiesLeft --;
		REnemies.GetComponent<Text>().text = "Enemies left: " + enemiesLeft;
		if(enemiesLeft == 0)
		{
			EndRound ();
		}
	}
	void EndRound()
	{
		BeginButton.SetActive (true);
		r++;
		CurrentRound = Rounds[r - 1];
	}
}
