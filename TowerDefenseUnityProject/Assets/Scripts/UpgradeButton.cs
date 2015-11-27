using UnityEngine;
using System.Collections;

public class UpgradeButton : MonoBehaviour {
	[SerializeField]
	private GameObject theTower;

	void OnMouseUp()
	{
		TowerStats StatsToModify = theTower.GetComponent<TowerStats>();
		theTower.GetComponent<TowerStats>().UpgradeMe();
		Debug.Log ("SINTERKLAAS");
	}
}
