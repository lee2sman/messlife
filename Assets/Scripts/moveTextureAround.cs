using UnityEngine;
using System.Collections;

public class moveTextureAround : MonoBehaviour {

	private Renderer rend;
	public float scrollSpeed = 0.01F;


	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		float offset = Time.time * scrollSpeed;
		rend.material.SetTextureOffset("_MainTex", new Vector2(0, offset));
	}
}
