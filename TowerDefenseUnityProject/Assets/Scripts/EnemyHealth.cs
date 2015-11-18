using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {
	public int MyEnemyHealth;
	public bool amIFighting = false;
	private float healthTimer = 0;


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
			MyEnemyHealth= MyEnemyHealth-5;
			//Debug.Log("Enemy health: "+MyEnemyHealth);
		}
		}
	}

	void EnemyDeath()
	{
		GameObject.Find ("GoldCounter").GetComponent<GoldCounter>().Gold += 10;
		GameObject.Find ("ScoreCounter").GetComponent<ScoreCounter> ().score += 100;
		Destroy(this.gameObject);
	}
	
}
