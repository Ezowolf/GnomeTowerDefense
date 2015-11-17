using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GoldCounter : MonoBehaviour {

	public float Gold = 0;
	public Text countGold;

	void Update (){
		GoldCount ();
	}

	public void GoldCount (){
		countGold.text = "Gold: " + Gold.ToString ();
	}
}
