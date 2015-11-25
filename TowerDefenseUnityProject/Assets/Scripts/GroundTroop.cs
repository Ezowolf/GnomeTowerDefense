using UnityEngine;
using System.Collections;

public class GroundTroop : MonoBehaviour {
	public int myHealth = 25;
	private int layerMask;
	private Vector2 myStartingPosition;
	private Vector2 theTargetPosition;
	private bool amIFighting = false;
	private float healthTimer = 0;
	public int myPower = 2;

	void Start () {
		layerMask = LayerMask.GetMask("Enemy");
		myStartingPosition = this.transform.position;
	}

	void Update () {
		Collider2D myRadius = Physics2D.OverlapCircle(myStartingPosition,2F, layerMask);
		Collider2D myRange = Physics2D.OverlapCircle(this.transform.position,0.5F, layerMask);
		if(myHealth <= 0)
		{
			TroopDeath(myRange.transform.gameObject);
		}

		if(myRadius != null&&amIFighting==false)
		{
			theTargetPosition = myRadius.transform.position;
			transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), theTargetPosition, 3F * Time.deltaTime);
		}

		if(myRange != null&&amIFighting==false)
		{
			amIFighting=true;
			myRange.gameObject.GetComponent<EnemyHealth>().amIFighting = true;
		}

		if(amIFighting == true)
		{
			healthTimer+=Time.deltaTime;
			if(healthTimer>=1)
			{
				healthTimer=0;
				myHealth--;
			}
		}
		if(myRange == null&& amIFighting==true)
		{
			amIFighting=false;
		}

		if(myRange == null&&myRadius == null)
		{
			transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), myStartingPosition, 3F * Time.deltaTime);
		}

	}
	

	public void StopFighting()
	{
		amIFighting = false;
		
	}

	void TroopDeath(GameObject whoKilledMe)
	{
		whoKilledMe.GetComponent<EnemyHealth>().amIFighting = false;
		Destroy(this.gameObject);
	}
}
