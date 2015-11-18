using UnityEngine;
using System.Collections;

public class MoveToTheLeft : MonoBehaviour {
    [SerializeField]
    private int movementSpeed = 3;
	public bool shouldIMove = true;
	public bool amITowerBuster = false;
	private LayerMask layerMask;

	// Use this for initialization
	void Start () {
		layerMask = LayerMask.GetMask("Tower");
	
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.black;
		if(amITowerBuster)
		Gizmos.DrawWireSphere(transform.position, 3F);
	}

	// Update is called once per frame
	void Update () {
		Collider2D myRadius = Physics2D.OverlapCircle(transform.position,3F, layerMask);
		if(myRadius!=null&&amITowerBuster)
		{
			transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), myRadius.transform.position, 3F * Time.deltaTime);
		}
		else if(shouldIMove==true)
		{
        transform.Translate(new Vector3(-1, 0, 0) * movementSpeed * Time.deltaTime);
		}

    }

	void OnTriggerEnter2D(Collider2D triggerColl)
	{
		Debug.Log("rawr");
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if(coll.gameObject.tag=="myTrooper")
		{
			shouldIMove = false;
		}
	}
}
