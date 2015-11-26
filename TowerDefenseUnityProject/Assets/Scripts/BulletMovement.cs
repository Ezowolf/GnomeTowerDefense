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
		if(targetPosition.x>transform.position.x)
		{
			FlipX();
		}
		if(targetPosition.y>transform.position.y)
		{
			FlipY();
		}
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

	private void FlipX()
	{
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	private void FlipY()
	{
		Vector3 theScale = transform.localScale;
		theScale.y *= -1;
		transform.localScale = theScale;
	}
}
