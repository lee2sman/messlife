﻿using UnityEngine;
using System;
using System.Collections;

public class replaceFloorTile : MonoBehaviour {

	public GameObject floor;



	void Update()
	{
		
	}

	static string s_dataUrlPrefix = "data:image/png;base64,";
	public void ReceiveImage(string dataUrl)
	{
		if (dataUrl.StartsWith(s_dataUrlPrefix))
		{
			byte[] pngData = System.Convert.FromBase64String(dataUrl.Substring(s_dataUrlPrefix.Length));



			// Create a new Texture (or use some old one?)
			Texture2D tex = new Texture2D(1, 1); // does the size matter?
			if (tex.LoadImage(pngData))
			{




				Renderer renderer = floor.GetComponent<Renderer>();

				renderer.material.mainTexture = tex;





			}
			else
			{
				Debug.LogError("could not decode image");
			}
		}
		else
		{
			Debug.LogError("Error getting image:" + dataUrl);
		}
	}
}