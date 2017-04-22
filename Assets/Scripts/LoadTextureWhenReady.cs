using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LoadTextureWhenReady : MonoBehaviour {

    //When you spawn your planes, you can set this variable
    //And this script keep trying to load the image until it's successful
    //since the image won't be immediately availabe once you start uploading.


    //will use this to get any textures we already downloaded
    static Dictionary<string, Texture2D> savedTextures;

    public string textureName = "thumb_ma-f6d5e59c16d62a85ef510ce28f106ea7.png"; //just a placeholder
    bool haveLoaded = false;

	// Use this for initialization
	void Start () {

        if (savedTextures == null)
        {
            savedTextures = new Dictionary<string, Texture2D>();
        }

        StartCoroutine(loadWhenReady());
	}
        
	
	// Update is called once per frame
	void Update () {
		
	}


    IEnumerator loadWhenReady()
    {

        //first check if we already downloaded the texture
        if (savedTextures.ContainsKey(textureName))
        {
            applyTexture(savedTextures[textureName]);
        }
        else
        {
            //you need to change this to the URL where you're uploading images
            //this link isn't somewhere you can actually upload images
            string serverImgsLocation = "http://xander-underwhelm.com/thumbs/";

            while (!haveLoaded)
            {
                WWW www = new WWW(serverImgsLocation + textureName);

                yield return www;


                if (www.error == null && www.texture != null)
                {
                    savedTextures[textureName] = www.texture;
                    applyTexture(www.texture);
                    haveLoaded = true;
                }
                else
                {
                    yield return new WaitForSeconds(2);
                }
            }
        }

       
    }

    void applyTexture(Texture2D tex)
    {
        this.GetComponent<Renderer>().material.mainTexture = tex;
    }
}
