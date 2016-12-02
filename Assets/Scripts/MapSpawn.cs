using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapSpawn : MonoBehaviour {

	public GameObject hexPrefab;
	public GameObject hexBoard;
	public GameObject Road;
	private MeshRenderer meshrend;

	int width  = 14;
	int height = 14;
	int rotation = 0;
	float zOffset = .75f;
	float xOffset = .866f;
	List<GameObject> hexTiles = new List<GameObject>();

	// Use this for initialization
	void Start () {
		for (int x = -7; x < width; x++)
		{
			for (int z = -7; z < height; z++)
			{
				hexPrefab.name = "hex " + x + "," + z;
				float xPos = x * xOffset;
				if (z % 2 == 1 || z % 2 == -1) {
					xPos += (xOffset * .5f);
				}
				rotation = Random.Range (0, 7);
				if ((x == 1 && z == 3) ||
					(x == 2 && z == 1) ||
					(x == 2 && z == 2) ||
					(x == 2 && z == 3) ||
					(x == 2 && z == 4) ||
					(x == 2 && z == 5) ||
					(x == 3 && z == 1) ||
					(x == 3 && z == 2) ||
					(x == 3 && z == 3) ||
					(x == 3 && z == 4) ||
					(x == 3 && z == 5) ||
					(x == 4 && z == 1) ||
					(x == 4 && z == 2) ||
					(x == 4 && z == 3) ||
					(x == 4 && z == 4) ||
					(x == 4 && z == 5) ||
					(x == 5 && z == 2) ||
					(x == 5 && z == 3) ||
					(x == 5 && z == 4)) {
					GameObject hexagon = (GameObject)Instantiate (hexBoard, new Vector3 (xPos, 0.1f, z * zOffset), Quaternion.Euler (new Vector3 (0, rotation * 60, 0)));
					hexagon.name = x + "," + z;
					createRoads (hexagon);
				} else {
					GameObject hexagon = (GameObject)Instantiate (hexPrefab, new Vector3 (xPos, 0, z * zOffset), Quaternion.Euler (new Vector3 (0, rotation * 60, 0)));
					hexagon.name = x + "," + z;
					hexTiles.Add (hexagon);
					hexagon.GetComponent<MeshRenderer> ().enabled = false;
				}
			}
		}
	}
	void createRoads (GameObject hex) {
		GameObject road  = (GameObject)Instantiate (Road, new Vector3 (hex.transform.position.x + .435f, hex.transform.position.y + .05f, hex.transform.position.z), Quaternion.Euler (new Vector3 (0, 0, 0)));
		GameObject road2 = (GameObject)Instantiate (Road, new Vector3 (hex.transform.position.x - .435f, hex.transform.position.y + .05f, hex.transform.position.z), Quaternion.Euler (new Vector3 (0, 0, 0)));
		GameObject road3 = (GameObject)Instantiate (Road, new Vector3 (hex.transform.position.x - .215f, hex.transform.position.y + .05f, hex.transform.position.z + .37f), Quaternion.Euler (new Vector3 (0, 60, 0)));
		GameObject road4 = (GameObject)Instantiate (Road, new Vector3 (hex.transform.position.x + .215f, hex.transform.position.y + .05f, hex.transform.position.z - .37f), Quaternion.Euler (new Vector3 (0, 60, 0)));
		GameObject road5 = (GameObject)Instantiate (Road, new Vector3 (hex.transform.position.x + .215f, hex.transform.position.y + .05f, hex.transform.position.z + .37f), Quaternion.Euler (new Vector3 (0, -60, 0)));
		GameObject road6 = (GameObject)Instantiate (Road, new Vector3 (hex.transform.position.x - .215f, hex.transform.position.y + .05f, hex.transform.position.z - .37f), Quaternion.Euler (new Vector3 (0, -60, 0)));
		road.transform.parent  = hex.transform;
		road2.transform.parent = hex.transform;
		road3.transform.parent = hex.transform;
		road4.transform.parent = hex.transform;
		road5.transform.parent = hex.transform;
		road6.transform.parent = hex.transform;

		return;
	}
}
