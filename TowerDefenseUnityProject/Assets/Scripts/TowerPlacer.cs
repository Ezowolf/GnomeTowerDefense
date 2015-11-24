using UnityEngine;
using System.Collections;

public class TowerPlacer : MonoBehaviour {
    [SerializeField]
    private GameObject towerMPrefab;
    private GameObject theTower;

	private bool canIPlaceTower()
    {
        return theTower == null;
    }

    void OnMouseUp()
    {
        if (canIPlaceTower () == true) 
		{
			if (GameObject.Find ("GoldCounter").GetComponent<GoldCounter> ().Gold >= 100)
			{
				GameObject.Find ("GoldCounter").GetComponent<GoldCounter> ().Gold -= 100;
				theTower = (GameObject)
           		Instantiate (towerMPrefab, this.transform.position, Quaternion.identity);
			}
        }
        else
        {
            TowerStats StatsToModify = theTower.GetComponent<TowerStats>();
            MyLevelStats nextLevel = StatsToModify.UpgradingCheck();
            if(nextLevel != null)
            {
                //theTower.GetComponent<TowerStats>().UpgradeMe();
				theTower.GetComponent<TowerStats>().ShowTowerUI();
            }
        }
    }
}
