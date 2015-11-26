using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {
	public int MyEnemyHealth;
	public bool amIFighting = false;
	private float healthTimer = 0;
	private Animator animator;
	private Animation deathAnimation;
	private FollowWPoint myMoveScript;
	public float myWalkingSpeedCnt;
	private bool amIDead;
	public GameObject troopImFighting;

	void Start()
	{
		animator = GetComponent<Animator>();
		deathAnimation = GetComponent<Animation>();
		myMoveScript = GetComponent<FollowWPoint>();
		myWalkingSpeedCnt = myMoveScript.speed;
	}

	void Update()
	{
		if(MyEnemyHealth<=0)
		{
			EnemyDeath();
		}
		if(amIFighting==true)
		{
		animator.SetBool("amIFighting",true);
		troopImFighting.GetComponent<GroundTroop>().whoAmIFighting = this.transform.gameObject;
		healthTimer+=Time.deltaTime;
		myMoveScript.speed = 0;
		if(healthTimer>=1)
		{
			healthTimer=0;
			MyEnemyHealth= MyEnemyHealth-15;
		}
		}
		else if(amIDead == false)
		{
			animator.SetBool("amIFighting",false);
			myMoveScript.speed = myWalkingSpeedCnt;
		}
	}

	void EnemyDeath()
	{
		amIDead = true;
		myMoveScript.speed = 0;
		if(amIFighting==true)
		{
			if(troopImFighting!=null)
			troopImFighting.GetComponent<GroundTroop>().iKillled();
		}
		gameObject.tag = "Untagged";
		gameObject.layer = 0;
		animator.SetBool("amIDead",true);
		StartCoroutine(DeathDestroy());
	}

	IEnumerator DeathDestroy()
	{
		yield return new WaitForSeconds(deathAnimation.clip.length);
		GameObject.Find ("GoldCounter").GetComponent<GoldCounter>().Gold += 10;
		GameObject.Find ("ScoreCounter").GetComponent<ScoreCounter> ().score += 100;
		Destroy(this.gameObject);
	}

	
}
