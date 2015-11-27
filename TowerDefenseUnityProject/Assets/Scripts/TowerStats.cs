using UnityEngine;
using System.Collections.Generic;
using System.Collections;
[System.Serializable]
public class MyLevelStats
{
   public GameObject graphic;
   public float myRange;
   public int myHealth = 1;
   public int myUpgradeCost;
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

    private AudioSource source;
    public AudioClip shootingSound;

	public GameObject canvasTower;
	
	void Awake () {
		canvasTower = this.transform.Find ("Canvas").gameObject;
		
	}

    void Start()
	{
		layerMask = LayerMask.GetMask("Enemy");
        source = GetComponent<AudioSource>();
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
        TowerAnimationScript AnimatedGnome = GetComponentInChildren<TowerAnimationScript>();
		if(myRadius!=null)
		{
            if (AnimatedGnome.transform.position.x > myRadius.transform.position.x && AnimatedGnome.amIFacingRight == true)
            {
                AnimatedGnome.Flip();
            }
            if (AnimatedGnome.transform.position.x < myRadius.transform.position.x && AnimatedGnome.amIFacingRight == false)
            {
                AnimatedGnome.Flip();
            }
            AnimatedGnome.ShootingAnimation();
        timer += Time.deltaTime;
		}
        else
        {
        AnimatedGnome.IdleAnimation();
        }

		if (timer >= currentLevel.myFiringInterval)
		{
			if(myRadius!=null)
			{
                source.PlayOneShot(shootingSound);
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
			if (GameObject.Find ("GoldCounter").GetComponent<GoldCounter>().Gold >= currentLevel.myUpgradeCost)
			{
				GameObject.Find ("GoldCounter").GetComponent<GoldCounter>().Gold -= currentLevel.myUpgradeCost;
				CurrentLevel = levels[currentLevelIndex + 1];
			}
        }
    }

	public void ShowTowerUI () 
	{
		Debug.Log ("OpenUI");
		if (canvasTower.activeInHierarchy == true) {
			canvasTower.SetActive (false);
			Debug.Log ("false");
		} else {
			canvasTower.SetActive(true);
			Debug.Log ("true");
		}
	}
}
