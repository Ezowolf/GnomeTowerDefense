using UnityEngine;
using System.Collections;

public class BarackStats : MonoBehaviour {
	public GameObject myTroop;
	private Vector3 spawnPos1;
	private Vector3 spawnPos2;
	public int myLevel = 1;

	// Use this for initialization
	void Start () {
		spawnPos1 = new Vector3(this.transform.position.x, this.transform.position.y-1,this.transform.position.z);
		spawnPos2 = new Vector3(this.transform.position.x-1, this.transform.position.y-1,this.transform.position.z);
		SpawnTroops();
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.childCount<1)
		{
			StartCoroutine(SpawnTroopsTimer());
		}
	}
	void SpawnTroops()
	{
		if(transform.childCount<1)
		{
			GameObject mySpawnedTroop = Instantiate(myTroop, spawnPos1, this.transform.rotation) as GameObject;
			mySpawnedTroop.transform.parent = transform;
		if(myLevel==2)
		{
			GameObject mySpawnedTroop2 = Instantiate(myTroop, spawnPos2, this.transform.rotation) as GameObject;
			mySpawnedTroop2.transform.parent = transform;
		}
		}
	}

	public void UpgradeMe()
	{

		if(myLevel==1&&GameObject.Find ("GoldCounter").GetComponent<GoldCounter>().Gold >= 200)
		{
			GameObject.Find ("GoldCounter").GetComponent<GoldCounter>().Gold = GameObject.Find ("GoldCounter").GetComponent<GoldCounter>().Gold - 200;
			myLevel=2;
			foreach (Transform child in transform) {
				GameObject.Destroy(child.gameObject);
			}
			SpawnTroops();

		}
	}

	void OnMouseUp()
	{
		UpgradeMe();
	}

	IEnumerator SpawnTroopsTimer()
	{
		yield return new WaitForSeconds(10-myLevel);
		SpawnTroops();
	}
}
