using UnityEngine;
using System.Collections;

public class GroundTroop : MonoBehaviour {
	private int myHealth = 5;
	private int layerMask;
	private Vector3 myStartingPosition;
	private Vector3 theTargetPosition;
	private bool amIFighting = false;
	private float healthTimer = 0;
	// Use this for initialization
	void Start () {
		layerMask = LayerMask.GetMask("Enemy");
		myStartingPosition = this.transform.position;
	}

	void Update () {
		if(myHealth <= 0)
		{
			TroopDeath();
		}

		Collider2D myRadius = Physics2D.OverlapCircle(myStartingPosition,2F, layerMask);
		if(myRadius != null&&amIFighting==false)
		{
			theTargetPosition = myRadius.transform.position;
			transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), theTargetPosition, 3F * Time.deltaTime);
			if(this.transform.position == theTargetPosition)
			{
				amIFighting = true;
			}
		}
		if(amIFighting == true)
		{
			healthTimer+=Time.deltaTime;
			if(healthTimer>=1)
			{
				healthTimer=0;
				myHealth--;
				Debug.Log(myHealth);
			}
		}
	}

	void TroopDeath()
	{
		Destroy(this.gameObject);
	}
}
