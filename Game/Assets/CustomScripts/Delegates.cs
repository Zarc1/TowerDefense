using UnityEngine;
using System.Collections;

public class Delegates : MonoBehaviour 
{
	public delegate void PowerUpHandler(bool isPowered);
	public static event PowerUpHandler Handler;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI()
	{
		if (GUI.Button (new Rect(5, 5, 150, 40), "Click me, fool"))
		{
			if (Handler != null)
				Handler(true);
		}
		if (GUI.Button (new Rect(5, 50, 150, 40), "Click me, fool"))
		{
			if (Handler != null)
				Handler(false);
		}
		    
				

	}
}
