using UnityEngine;

public class TextureManagerScript : MonoBehaviour
{
	public Texture[] UniformTextures;

	public Texture[] CasualTextures;

	public Texture[] SocksTextures;

	public Texture2D PurpleStockings;

	public Texture2D GreenStockings;

	public Texture2D Base2D;

	public Texture2D Overlay2D;

	public Texture2D MergeTextures(Texture2D BackgroundTex, Texture2D TopTex)
	{
		Texture2D texture2D = new Texture2D(1024, 1024);
		Color32[] pixels = BackgroundTex.GetPixels32();
		Color32[] pixels2 = TopTex.GetPixels32();
		for (int i = 0; i < pixels2.Length; i++)
		{
			if (pixels2[i].a != 0)
			{
				pixels[i] = pixels2[i];
			}
		}
		texture2D.SetPixels32(pixels);
		texture2D.Apply();
		return texture2D;
	}
}
