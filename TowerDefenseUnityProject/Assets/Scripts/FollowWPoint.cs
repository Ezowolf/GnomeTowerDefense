using UnityEngine;
using System.Collections;

public class FollowWPoint : MonoBehaviour {
	public GameObject[] Waypoints;
	private int currentWaypoint = 0;
	public float speed = 1.0f;
	private Vector3 myPosition;
	private Animator animator;
	private bool amIFacingRight = false;
	public bool amITowerBuster = false;
	private LayerMask layerMask;
	// Use this for initialization
	void Start () {
		gameObject.tag = "Untagged";
		gameObject.layer = 0;
		animator = GetComponent<Animator>();
		layerMask = LayerMask.GetMask("Tower");
	}
	
	// Update is called once per frame
	void Update () {
		Collider2D myRadius = Physics2D.OverlapCircle(transform.position,3F, layerMask);
		myPosition = this.transform.position;

		if(myPosition==Waypoints[currentWaypoint].transform.position)
		{
			if(gameObject.tag=="Untagged")
			{
				gameObject.tag = "Enemy";
				gameObject.layer = 8;

			}
			if (currentWaypoint == Waypoints.Length-1)
			{
				GameObject.Find ("HealthObj").GetComponent<LivesCounter> ().EnemyInBase();
				Destroy(this.gameObject);
			}
			else
			{
				currentWaypoint++;
			}
		}
		
		if(myRadius!=null&&amITowerBuster)
		{
			Debug.Log("!!!");
			transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), myRadius.transform.position, speed * Time.deltaTime);
		}
		else
		{
		transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), Waypoints[currentWaypoint].transform.position, speed * Time.deltaTime);
		}

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

