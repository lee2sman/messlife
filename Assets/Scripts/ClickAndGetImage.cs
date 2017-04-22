/*+
 * Copyright 2016, Gregg Tavares.
 * All rights reserved.
 *
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions are
 * met:
 *
 *     * Redistributions of source code must retain the above copyright
 * notice, this list of conditions and the following disclaimer.
 *     * Redistributions in binary form must reproduce the above
 * copyright notice, this list of conditions and the following disclaimer
 * in the documentation and/or other materials provided with the
 * distribution.
 *     * Neither the name of Gregg Tavares. nor the names of its
 * contributors may be used to endorse or promote products derived from
 * this software without specific prior written permission.
 *
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
 * "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
 * LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR
 * A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT
 * OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
 * SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT
 * LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
 * DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY
 * THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
 * (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
 * OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 */
using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;

public class ClickAndGetImage : MonoBehaviour {
	[SerializeField] private GameObject WallUnit; 
	[SerializeField] private GameObject FloorUnit;
	private GameObject _wallUnit;
	private GameObject _floorUnit;
	char Keypressed = '\0';

	public RawImage currentlyLoadedImageCanvasDisplay;



    void Update ()
    {

      if (Input.GetKeyUp(KeyCode.I))
		{
            CreateWall();
        }
		

		if(Input.GetKeyUp(KeyCode.F))
		{
			ReplaceFloor ();
		}

	

		if (Input.GetKeyUp (KeyCode.S)) {
			//TakeScreenshot ();
		}


    }

    public void CreateWall()
    {

        GetImage.GetImageFromUserAsync(gameObject.name, "ReceiveImage");
        Keypressed = 'I';
    }

	public void ReplaceFloor()
	{
		GetImage.GetImageFromUserAsync(gameObject.name, "ReceiveImage");
		Keypressed = 'F';
	}


public void TakeScreenshot()
	{

		Application.ExternalCall ("MessageToBrowser", "saveScreenshot");
		Debug.LogError("Screenshot happens");
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
				Renderer renderer;
				switch (Keypressed) {
				case 'I':
					//instantiate wall unit here - for use in browser with webGL
					var angle = Quaternion.LookRotation(this.gameObject.transform.position);
					//angle *= Quaternion.Euler (0, 0, 90);
					_wallUnit = Instantiate(WallUnit, this.gameObject.transform.position + transform.forward*2 + transform.up, angle); //if image loaded, then instantiate a wallUnity
					_wallUnit.GetComponent<Rigidbody> ().velocity = (transform.forward * 5) + (transform.up * 5);
					// _wallUnit.GetComponent<Rigidbody> ().AddTorque (new Vector3 (1, 0, 1));
					// render and wrap begins here
					renderer = _wallUnit.GetComponent<Renderer>();
					renderer.material.mainTexture = tex;


					break;
				case 'F':
					
						// render and wrap begins here
					renderer = FloorUnit.GetComponent<Renderer>();
					renderer.material.mainTexture = tex;
					break;
				}


                

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


