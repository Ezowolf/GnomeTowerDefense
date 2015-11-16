using UnityEngine;
using System.Collections;

public class TowerUI : RotationFixer {
	[SerializeField]
	private GameObject UpgradePad;

	void Update() {
		
		if (Input.GetButtonDown ("Fire1")) {
			Vector3 p = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 10.0f));
			Instantiate (UpgradePad, new Vector3 (p.x, p.y, 0.0f), Quaternion.identity);

		} else if (Input.GetButtonDown ("Fire2")) {
			UpgradePad = GameObject.FindGameObjectWithTag("TowerUI");
			UpgradePad.SetActive(false);
		} else if (Input.GetKeyDown (KeyCode.Space)){
			UpgradePad.SetActive(true);
			Destroy(GameObject.Find("UpgradePad(Clone)"));
		}
	}
}
