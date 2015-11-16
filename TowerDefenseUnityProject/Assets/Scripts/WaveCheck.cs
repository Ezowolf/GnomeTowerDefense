using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WaveCheck : MonoBehaviour {

	public float waves = 0;
	public Text countText;

	public void SetCountText (){
		countText.text = "Wave: " + waves.ToString();
	}
}
