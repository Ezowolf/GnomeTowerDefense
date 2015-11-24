using UnityEngine;
using System.Collections;

public class EnemySpawner : WaveCheck {
	[SerializeField]
	private GameObject[] enemyPrefabs;
	private float timer = 0;
	[SerializeField]
	private float SpawnInterval;
	int enemies = 0;
	public float x;
	public float y;

	public float minX;
	public float maxX;

	public float minY;
	public float maxY;

	void Update () {
		timer += Time.deltaTime;
		SetCountText ();
	}

	public void SpawnEnemies () {
		enemies = enemies + 1;
		//Debug.Log (Mathf.Round(timer));
		if (timer >= SpawnInterval) {
			waves++;
			timer = 0;
			for (int i = 0; i < enemies; i++) {
				int randomIndex = Random.Range (0, enemyPrefabs.Length);
				GameObject enemy = enemyPrefabs[randomIndex];
				x = Random.Range (minX, maxX);
				y = Random.Range (minY, maxY);
				Instantiate (enemy, new Vector2 (x,y), Quaternion.identity);
			}
		}

		if (waves >= 2) {
			enemies = enemies + 3;
		}
	}
}
