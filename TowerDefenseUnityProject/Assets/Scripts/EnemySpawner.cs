using UnityEngine;
using System.Collections;

public class EnemySpawner : WaveCheck {
	[SerializeField]
	private GameObject[] enemyPrefabs;
	private float timer = 0;
	[SerializeField]
	private float SpawnInterval;
	int enemies = 4;
	float x;
	float y;

	void Update () {
		timer += Time.deltaTime;
		SetCountText ();
	}

	public void SpawnEnemies () {
		enemies = enemies + 2;
		Debug.Log (Mathf.Round(timer));
		if (timer >= SpawnInterval) {
			waves = waves + 1;
			timer = 0;
			for (int i = 0; i < enemies; i++) {
				int randomIndex = Random.Range (0, enemyPrefabs.Length);
				GameObject enemy = enemyPrefabs[randomIndex];
				x = Random.Range (5.0f, 10.0f);
				y = Random.Range (1.0f, 5.0f);
				Instantiate (enemy, new Vector2 (x,y), Quaternion.identity);
			}
		}
	}
}
