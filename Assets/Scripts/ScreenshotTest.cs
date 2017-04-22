using UnityEngine;
using System.Collections;

public class ScreenshotTest : MonoBehaviour {

	bool screenShotRequested = false;

	void Update () {
		if(Input.GetKeyDown(KeyCode.S))
			StartCoroutine(Run());
	}


	IEnumerator Run() {
		yield return new WaitForEndOfFrame();

		Texture2D tex = new Texture2D(Screen.width, Screen.height);
		tex.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
		tex.Apply();

		// to test the texture
		//renderer.material.mainTexture = tex;

		// to save it as file, not available in webplayer
		//System.IO.File.WriteAllBytes(Application.streamingAssetsPath+"/png.png", tex.EncodeToPNG());

		Debug.Log ("made it");
		Application.ExternalCall("screenshot", System.Convert.ToBase64String(tex.EncodeToPNG())); // THIS SHOULD BE ABLE TO BE REPLACED WITH WWWForm SO THAT IT CAN BE TESTED IN EDITOR AND BUILDS 

	}
}