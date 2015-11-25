using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LivesCounter : MonoBehaviour {
	public int baseHealth = 100;
	public Text countBHealth;
	public Text gameOverText;
	
	void Start () {
		countBHealth.text = "Lives: "+baseHealth;
		gameOverText.text = "";
	}

	void Update () {
	
	}

	public void EnemyInBase(){
		baseHealth = baseHealth -5;
		countBHealth.text = "Lives: "+baseHealth;
		if(baseHealth<=0)
		{
			Time.timeScale = 0;
			baseHealth = 0;
			gameOverText.text = "GAME OVER";
		}
	}
}
