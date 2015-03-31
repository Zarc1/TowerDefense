using UnityEngine;
using System.Collections;
using Pathfinding;//including the pathfinding library

public class AI_Pather : MonoBehaviour 
{
	public Transform target;//where we want our enemy to go;
	Path path;//reference to our path
	int currentWaypoint;//our position amongst total waypoint on drawn path

	public int speed = 10;//speed to walk

	CharacterController cc;//character controller on the object

	// Use this for initialization
	void Start () 
	{
		Seeker seeker = GetComponent<Seeker> ();//setting local tag for seeker component
		seeker.StartPath (transform.position, target.position, OnPathComplete);//draw the path
		cc = GetComponent<CharacterController> ();//setting local tag for character controller component
	}

	public void OnPathComplete(Path p)//called once path is drawn
	{
		if (!p.error)//see if a path could be drawn
		{
			path = p;
			currentWaypoint = 0;//set current waypoint to 0
		}
		else//otherwise error
			Debug.Log (p.error);
	}
	void FixedUpdate()
	{
		if (path == null)
			return;
		if (currentWaypoint >= path.vectorPath.Count)//end of the path
			return;

		Vector3 direction = (path.vectorPath [currentWaypoint] - transform.position).normalized * speed;//direction to move our enemy based on waypoint position, normalized to alwasy return as 1
		if (GetComponent<CharacterController>() != null)
			cc.SimpleMove (direction);//move in that direction

		if (Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]) <2f )//check to see how close we are to the next waypoint
		{
			currentWaypoint++;//incremement the waypoint count
		}
		if (currentWaypoint < path.vectorPath.Count)//if we arent at the player yet
		{
			Vector3 LookVector = new Vector3 (path.vectorPath [currentWaypoint].x, transform.position.y, path.vectorPath [currentWaypoint].z);//set a vector to be the next waypoint at the enemies same y level
			transform.LookAt (LookVector);//have enemy look at that vector
		}
	}
}
