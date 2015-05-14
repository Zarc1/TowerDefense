using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NexusHP : MonoBehaviour 
{
	public float hp = 100;
	public GameObject display;
	// Use this for initialization
	void Start () 
	{
		SetText ();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	public void SetText()
	{
		display.GetComponent<Text>().text = "Nexus HP: " + hp;
		if(hp <= 0)
			Application.LoadLevel ("Main2");
	}
}
