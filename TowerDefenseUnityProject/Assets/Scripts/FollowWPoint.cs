using UnityEngine;
using System.Collections;

public class FollowWPoint : MonoBehaviour {
	public GameObject[] Waypoints;
	private int currentWaypoint = 0;
	public float speed = 1.0f;
	private Vector3 myPosition;
	private Rigidbody2D m_Rigidbody2D;
	private Animator animator;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		Flip();
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

	}
	private void Flip()
	{
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}

