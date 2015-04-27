using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour 
{
	Transform target;
	// Use this for initialization
	void Start () 
	{
		StartCoroutine ("Kill");
	}
	
	// Update is called once per frame
	void Update () 
	{
		Fly ();
	}


	IEnumerator Kill()
	{
		yield return new WaitForSeconds(.2f);
		Destroy (this.gameObject);
	}
	void Fly()
	{
		transform.Translate(Vector3.forward * 15 * Time.deltaTime);
	}
	public void SetTarget(Transform t)
	{
		transform.LookAt (t.position);
	}
}
