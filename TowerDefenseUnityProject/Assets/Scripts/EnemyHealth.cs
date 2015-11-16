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
		Destroy(this.gameObject);
	}
}
