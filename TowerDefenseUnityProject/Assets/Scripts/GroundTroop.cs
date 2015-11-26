using UnityEngine;
using System.Collections;

public class GroundTroop : MonoBehaviour {
	public int myHealth = 35;
	private int layerMask;
	private Vector2 myStartingPosition;
	private Vector2 theTargetPosition;
	private bool amIFighting = false;
	private float healthTimer = 0;
	public int myPower = 2;
	private float radiusChange = 2F;
	private float rangeChange = 0.3F;
	private Vector2 myTarget;
	private bool foundTarget;
	private bool iHaveToReturn;
	private GameObject whoKilledMe;
	public GameObject whoAmIFighting;
	private Animator animator;
	private Animation deathAnimation;

	void Start () {
		layerMask = LayerMask.GetMask("Enemy");
		myStartingPosition = this.transform.position;
		animator = GetComponent<Animator>();
		deathAnimation = GetComponent<Animation>();
	}

	void Update () {
		Vector2 myPos = this.transform.position;
		Collider2D myRadius = Physics2D.OverlapCircle(myStartingPosition,radiusChange, layerMask);
		Collider2D myRange = Physics2D.OverlapCircle(this.transform.position,rangeChange, layerMask);

		if (myStartingPosition == myPos)
		{
			iHaveToReturn = false;
			amIFighting = false;
			foundTarget = false;
			radiusChange = 2F;
			rangeChange = 0.3F;
		}
		else
		{
			radiusChange = 0F;
		}

		if(myRadius!=null&&myRadius.GetComponent<EnemyHealth>().amIFighting==false&&myPos==myStartingPosition&&foundTarget==false)
		{
			myTarget = myRadius.transform.position;
			foundTarget = true;
		}
		if(foundTarget)
		{
		transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), myTarget, 5F*Time.deltaTime);
		animator.SetBool("amIWalking",true);
		}
		if(iHaveToReturn)
		{
			transform.position = myStartingPosition;
		}
		if(myRange!=null&&foundTarget)
		{
			foundTarget = false;
			amIFighting = true;

			myRange.gameObject.GetComponent<EnemyHealth>().amIFighting = true;
			myRange.gameObject.GetComponent<EnemyHealth>().troopImFighting = this.gameObject;
			rangeChange = 0;
		}


		if(amIFighting == true)
		{
			animator.SetBool("amIFighting",true);
			animator.SetBool("amIWalking",false);
			healthTimer+=Time.deltaTime;
			if(healthTimer>=1)
			{
				healthTimer=0;
				myHealth--;
			}
		}
		else
		{
			animator.SetBool("amIFighting",false);
		}
		if(myHealth<=0&&animator.GetBool("amIDead")==false)
		{
			TroopDeath();
		}
	}

	void TroopDeath()
	{
		if(whoAmIFighting!=null)
		whoAmIFighting.GetComponent<EnemyHealth>().amIFighting = false;
		gameObject.tag = "Untagged";
		gameObject.layer = 0;
		StartCoroutine(DeathDestroy());
		animator.SetBool("amIDead",true);
	}
	
	IEnumerator DeathDestroy()
	{
		yield return new WaitForSeconds(deathAnimation.clip.length);
		Destroy(this.gameObject);
	}

	public void iKillled()
	{
		amIFighting = false;
		iHaveToReturn = true;
	}
}
