using System;
using UnityEngine;

// Token: 0x02000478 RID: 1144
public class TextureManagerScript : MonoBehaviour
{
	// Token: 0x06001EEE RID: 7918 RVA: 0x001B59B0 File Offset: 0x001B3BB0
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

	// Token: 0x0400402F RID: 16431
	public Texture[] UniformTextures;

	// Token: 0x04004030 RID: 16432
	public Texture[] CasualTextures;

	// Token: 0x04004031 RID: 16433
	public Texture[] SocksTextures;

	// Token: 0x04004032 RID: 16434
	public Texture2D PurpleStockings;

	// Token: 0x04004033 RID: 16435
	public Texture2D GreenStockings;

	// Token: 0x04004034 RID: 16436
	public Texture2D Base2D;

	// Token: 0x04004035 RID: 16437
	public Texture2D Overlay2D;
}
