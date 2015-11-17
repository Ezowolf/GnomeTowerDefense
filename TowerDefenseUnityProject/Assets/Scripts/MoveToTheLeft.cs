using UnityEngine;
using System.Collections;

public class MoveToTheLeft : MonoBehaviour {
    [SerializeField]
    private int movementSpeed = 3;
	public bool shouldIMove = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(shouldIMove==true)
		{
        transform.Translate(new Vector3(-1, 0, 0) * movementSpeed * Time.deltaTime);
		}
    }

	void OnCollisionEnter2D(Collision2D coll)
	{
		if(coll.gameObject.tag=="myTrooper")
		{
			shouldIMove = false;
		}
	}
}
