using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreCounter : MonoBehaviour {

	public float score = 0;
	public Text countScore;


	void Update () {
		ScoreCount ();
	}

	public void ScoreCount (){
		countScore.text = "Score: " + score.ToString ();
	}
}
