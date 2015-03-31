using UnityEngine;
using System.Collections;

public class EventListner : MonoBehaviour 
{

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	void OnEnable()
	{
		Delegates.Handler += OnPowerUp;
	}
	void OnDisable()
	{
		Delegates.Handler -= OnPowerUp;
	}
	void OnPowerUp(bool isPowered)
	{
		print (isPowered);
	}
}
