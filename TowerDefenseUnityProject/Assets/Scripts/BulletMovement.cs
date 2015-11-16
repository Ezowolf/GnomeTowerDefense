using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour
{
	public Vector2 targetPosition;
	public float speed;
	public int myPower;
	private Rigidbody2D myRB;

	void Start()
	{
		myRB = GetComponent<Rigidbody2D>();
	}

    void Update()
    {
		Vector2 myPos = transform.position;
        transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), targetPosition, speed * Time.deltaTime);
		if(myRB.velocity.x == 0 && myPos==targetPosition)
		{
			Destroy(this.gameObject);
		}
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
			coll.gameObject.GetComponent<EnemyHealth>().MyEnemyHealth=coll.gameObject.GetComponent<EnemyHealth>().MyEnemyHealth-myPower;
            Destroy(this.gameObject);
        }
    }
}
