using UnityEngine;
using System.Collections;

public class MoveToTheLeft : MonoBehaviour {
    [SerializeField]
    private int movementSpeed = 3;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(-1, 0, 0) * movementSpeed * Time.deltaTime);
    }
}
