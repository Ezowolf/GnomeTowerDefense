using UnityEngine;
using System.Collections.Generic;
using System.Collections;
[System.Serializable]
public class MyLevelStats
{
   public GameObject graphic;
   public float myRange;
   public int myHealth = 1;
   public int myCost;
   public float myFiringInterval;  
   public int myShootingPower;
}
public class TowerStats : MonoBehaviour {
    [SerializeField]
    private List<MyLevelStats> levels;
    private MyLevelStats currentLevel;    
    private float timer = 0;

	public GameObject myBullet;
	
	private int layerMask;

	void Start()
	{
		layerMask = LayerMask.GetMask("Enemy");
	}

    void OnEnable()
    {
        CurrentLevel = levels[0];
	}
	void OnDrawGizmos()
	{
		Gizmos.color = Color.black;
		Gizmos.DrawWireSphere(transform.position, currentLevel.myRange);
	}

	void ShootTheEnemy(Vector2 shootHere)
	{
		GameObject myFiredBullet = Instantiate(myBullet, this.transform.position, this.transform.rotation) as GameObject;
		myFiredBullet.GetComponent<BulletMovement>().targetPosition = shootHere;
		myFiredBullet.GetComponent<BulletMovement>().myPower = currentLevel.myShootingPower;
	}
	
    void Update()
    {
		Collider2D myRadius = Physics2D.OverlapCircle(transform.position,currentLevel.myRange, layerMask);

		if(myRadius!=null)
		{
        timer += Time.deltaTime;
		}

		if (timer >= currentLevel.myFiringInterval)
		{
			if(myRadius!=null)
			{
			ShootTheEnemy(myRadius.transform.position);
			}
			timer = 0;
		}
		
		if (currentLevel.myHealth==0)
		{
			Destroy(this.gameObject);
		}
	}
	
	public MyLevelStats CurrentLevel
    {
        get
        {
            return currentLevel;
        }
        set
        {
            currentLevel = value;
            int currentLevelIndex = levels.IndexOf(currentLevel);
            GameObject levelVisualization = levels[currentLevelIndex].graphic;
            for (int counter = 0; counter < levels.Count; counter++)
            {
                if (levelVisualization != null)
                {
                    if (counter == currentLevelIndex)
                    {
                        levels[counter].graphic.SetActive(true);
                    }
                    else
                    {
                        levels[counter].graphic.SetActive(false);
                    }
                }
            }
            
        }
    }

    public MyLevelStats UpgradingCheck()
    {
        int currentLevelIndex = levels.IndexOf(currentLevel);
        int maxLevelIndex = levels.Count - 1;
        if (currentLevelIndex < maxLevelIndex)
        {
            return levels[currentLevelIndex + 1];
        }
        else
        {
            return null;
        }
    }

    public void UpgradeMe()
    {
        int currentLevelIndex = levels.IndexOf(currentLevel);
        if (currentLevelIndex < levels.Count - 1)
        {
            CurrentLevel = levels[currentLevelIndex + 1];
        }
    }
}
