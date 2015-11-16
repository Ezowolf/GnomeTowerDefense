using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	void Update () {
		float delta = Time.deltaTime;
		transform.Translate (new Vector3(-1,0,0) * 3 * delta);
	}
}
