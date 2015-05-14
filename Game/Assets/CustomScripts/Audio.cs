using UnityEngine;
using System.Collections;

public class Audio : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void AudioP()
	{
		if (!this.GetComponent<AudioSource>().isPlaying)
		{
			this.GetComponent<AudioSource>().Play ();
		}
	}
}
