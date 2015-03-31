using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Gold : MonoBehaviour 
{
	public int goldAmount = 5000;
	Text text;

	// Use this for initialization
	void Start () 
	{
		text = this.GetComponent<Text>();
		text.text = "Gold: " + goldAmount.ToString ();
	}
	void OnEnable()
	{
		Enemy.Handler += AddGold;
	}
	void OnDisable()
	{
		Enemy.Handler -= AddGold;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void AddGold(int g)
	{
		goldAmount += g;
		text.text = "Gold: " + goldAmount.ToString ();
	}
	public void LoseGold(int g)
	{
		goldAmount -= g;
		text.text = "Gold: " + goldAmount.ToString ();
	}
}
