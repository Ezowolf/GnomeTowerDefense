using UnityEngine;
using System.Collections;

public class GroundTroop : MonoBehaviour {
	private int myHealth = 5;
	private int layerMask;
	private Vector3 myStartingPosition;
	// Use this for initialization
	void Start () {
		layerMask = LayerMask.GetMask("Enemy");
		myStartingPosition = this.transform.position;
		Debug.Log(myStartingPosition);
	}
	
	// Update is called once per frame
	void Update () {
		Collider2D myRadius = Physics2D.OverlapCircle(transform.position,2F, layerMask);
		if(myRadius != null)
		{

		Debug.Log(myRadius);
		}
	}
}
