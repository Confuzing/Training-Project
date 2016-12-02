using UnityEngine;
using System.Collections;

public class MouseOver : MonoBehaviour {

	bool selected = false;

	void OnMouseOver()
	{
		if (!selected)
			this.GetComponent<MeshRenderer> ().enabled = true; //!(this.GetComponent<MeshRenderer> ().enabled);
	}

	void OnMouseExit()
	{
		if(!selected)
			this.GetComponent<MeshRenderer> ().enabled = false;
	}
		
	void OnMouseClick()
	{
		if (!selected) {
			this.GetComponent<MeshRenderer> ().enabled = true;
			Debug.Log ("True onclick");
		}
		selected = !selected;
	}
}
