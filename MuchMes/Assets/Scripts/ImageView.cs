using UnityEngine;
using System.Collections;
using System;

public class ImageView : MonoBehaviour {

	public float unitSize = 2;
	Texture2D loadedTexture;
    SpriteRenderer sprRenderer;

    Sprite defaultSprite = null;

    void Awake()
    {
        sprRenderer = this.GetComponent<SpriteRenderer>();
        defaultSprite = sprRenderer.sprite;
    }

	void Start () {
		loadedTexture = new Texture2D(4, 4, TextureFormat.DXT1, false);
	}

    public void UpdatePicture(string url)
    {
        sprRenderer.sprite = defaultSprite;
        StartCoroutine(WaitForRequest(url));
    }
	
	IEnumerator WaitForRequest(String url)
	{
        //url = "http://www.adam.lifemakesuslaugh.com/images/me.png";
		WWW www = new WWW(url);

		yield return www;

		if (www.error == null)
		{
			www.LoadImageIntoTexture(loadedTexture);

			// Crop the image to make it square.
			int width, height;
			int x = 0;
			int y = 0;
			width = Math.Min(loadedTexture.width, loadedTexture.height);
			height = Math.Min(loadedTexture.width, loadedTexture.height);
			if (width < loadedTexture.width)
				x = (loadedTexture.width - width) / 2;
			if (height < loadedTexture.height)
				y = (loadedTexture.height - height) / 2;

			float pixelsToUnit = (width / unitSize);
			sprRenderer.sprite = Sprite.Create(loadedTexture, new Rect(x, y, width, height), new Vector2(0.5f, 0.5f), pixelsToUnit);
		} else {
			Debug.Log("WWW Error: "+ www.error);
		}    
	}
}
