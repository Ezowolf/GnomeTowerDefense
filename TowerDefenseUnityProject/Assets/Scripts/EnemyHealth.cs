using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {
	public int MyEnemyHealth;
	public bool amIFighting = false;
	private float healthTimer = 0;
	private Animator animator;
	private Animation deathAnimation;
	private FollowWPoint myMoveScript;

	void Start()
	{
		animator = GetComponent<Animator>();
		deathAnimation = GetComponent<Animation>();
		myMoveScript = GetComponent<FollowWPoint>();
	}

	void Update()
	{
		if(MyEnemyHealth<=0)
		{
			EnemyDeath();
		}
		if(amIFighting==true)
		{
		healthTimer+=Time.deltaTime;
		if(healthTimer>=1)
		{
			healthTimer=0;
			MyEnemyHealth= MyEnemyHealth-10;
		}
		}
	}

	void EnemyDeath()
	{
		gameObject.tag = "Untagged";
		gameObject.layer = 0;
		myMoveScript.speed = 0;
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
