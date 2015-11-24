using UnityEngine;
using System.Collections;

public class FollowWPoint : MonoBehaviour {
	public GameObject[] Waypoints;
	private int currentWaypoint = 0;
	public float speed = 1.0f;
	private Vector3 myPosition;
	private Animator animator;
	private bool amIFacingRight = false;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		myPosition = this.transform.position;
		if(myPosition==Waypoints[currentWaypoint].transform.position)
		{
			if (currentWaypoint == Waypoints.Length-1)
			{
				Destroy(this.gameObject);
			}
			else
			{
				currentWaypoint++;
			}
		}
		transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), Waypoints[currentWaypoint].transform.position, speed * Time.deltaTime);

		if(myPosition.x<Waypoints[currentWaypoint].transform.position.x&&amIFacingRight==false)
		{
			Flip();
			amIFacingRight = true;
		}

		if(myPosition.x>Waypoints[currentWaypoint].transform.position.x&&amIFacingRight==true)
		{
			Flip();
			amIFacingRight = false;
		}


	}
	private void Flip()
	{
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}

