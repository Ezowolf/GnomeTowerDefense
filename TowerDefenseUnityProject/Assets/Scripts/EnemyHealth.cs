using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {
	public int MyEnemyHealth;


	void Update()
	{
		if(MyEnemyHealth<=0)
		{
			EnemyDeath();
		}
	}

	void EnemyDeath()
	{
		GameObject.Find ("GoldCounter").GetComponent<GoldCounter>().Gold += 10;
		GameObject.Find ("ScoreCounter").GetComponent<ScoreCounter> ().score += 100;
		Destroy(this.gameObject);
	}
}
