using UnityEngine;
using System.Collections;

public class RotationFixer: MonoBehaviour {
	void Start() {
		transform.Rotate(-90,0,0);
	}

	public void DestroyObject() {
		Destroy (gameObject);
	}
}