using UnityEngine;
using System.Collections;

public class WanderingFloor : MonoBehaviour {


	public float counter = 0;

	public float speed = 0.001f;

	void Update () {
		counter += Time.deltaTime;


		transform.Translate (0, 0, speed * Time.deltaTime);

		if (counter > 5.0f) {


			float angle = Random.Range (-180, 180);
			transform.Rotate (0, angle, 0);
			counter = 0;
		}
	}
}
