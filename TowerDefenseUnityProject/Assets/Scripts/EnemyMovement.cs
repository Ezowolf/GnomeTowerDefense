using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {
	private bool shouldIMove = true;

	void Update () {
		float delta = Time.deltaTime;
		if(shouldIMove==true)
		{
		transform.Translate (new Vector3(-1,0,0) * 3 * delta);
		}
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		Debug.Log(coll.gameObject.tag);
		if(coll.gameObject.tag=="myTrooper")
		{
			shouldIMove = false;
		}
	}
}
