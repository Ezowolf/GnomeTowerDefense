using UnityEngine;
using System.Collections;

public class BarackStats : MonoBehaviour {
	public GameObject myTroop;

	// Use this for initialization
	void Start () {
		GameObject mySpawnedTroop = Instantiate(myTroop, this.transform.position, this.transform.rotation) as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
	}
}
