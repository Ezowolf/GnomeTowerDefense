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
           		Instantiate (towerMPrefab, new Vector3(this.transform.position.x,this.transform.position.y+1,this.transform.position.z), Quaternion.identity);
			}
        }
        else
        {
            TowerStats StatsToModify = theTower.GetComponent<TowerStats>();
            MyLevelStats nextLevel = StatsToModify.UpgradingCheck();
            if(nextLevel != null)
            {
				theTower.GetComponent<TowerStats>().ShowTowerUI();
            }
        }
    }
}
