using UnityEngine;
using System.Collections;

public class ClickAction : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Ray toMouse = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit rhInfo;
			bool didHit = Physics.Raycast (toMouse, out rhInfo, 500.0f);
			if (didHit) {
				Debug.Log (rhInfo.collider.name);
				//rhInfo.collider.gameObject.transform.Rotate (new Vector3 (180, 0, 0));
				//rhInfo.collider.GetComponent<MeshRenderer>().enabled = !(rhInfo.collider.GetComponent<MeshRenderer>().enabled);
				Debug.Log(rhInfo.collider.GetComponent<MeshRenderer>().enabled);
				StartCoroutine(objectflip (rhInfo));
			}else
				Debug.Log ("Update Called");
		}
	}

	IEnumerator objectflip (RaycastHit rhInfo)
	{
		Vector3 moveDistance = new Vector3 (0f, 0.01f, 0f);
		for (int i = 1; i <= 50; i++) {
			rhInfo.collider.gameObject.transform.position += moveDistance;
			yield return new WaitForSecondsRealtime (0.01f);
		}
		for (int i = 1; i <= 50; i++) {
			yield return new WaitForSecondsRealtime (0.01f);
			rhInfo.collider.gameObject.transform.position -= moveDistance;
		}
	}
}