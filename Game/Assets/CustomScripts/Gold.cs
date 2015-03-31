using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Gold : MonoBehaviour 
{
	public int goldAmount = 5000;//starting gold
	Text text;//UI text to display gold

	// Use this for initialization
	void Start () 
	{
		text = this.GetComponent<Text>();//so we can edit the component in the script
		text.text = "Gold: " + goldAmount.ToString ();//initial display
	}
	void OnEnable()
	{
		Enemy.Handler += AddGold;//subscribe to the enemy death event
	}
	void OnDisable()
	{
		Enemy.Handler -= AddGold;//unsubscribe
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void AddGold(int g)//add amount g to total gold and display new value
	{
		goldAmount += g;
		text.text = "Gold: " + goldAmount.ToString ();
	}
	public void LoseGold(int g)//subtract amount g from total gold and display new value
	{
		goldAmount -= g;
		text.text = "Gold: " + goldAmount.ToString ();
	}
}
