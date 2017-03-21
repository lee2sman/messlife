using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnWall : MonoBehaviour {
	[SerializeField] private GameObject WallUnit;
	private GameObject _wallUnit;

	// Use this for initialization
	void Start () {
		_wallUnit = Instantiate(WallUnit, new Vector3 (0, 1.0f, 4.0f), Quaternion.identity);
	}



}
