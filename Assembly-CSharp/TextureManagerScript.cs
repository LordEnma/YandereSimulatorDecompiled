using System;
using UnityEngine;

// Token: 0x02000477 RID: 1143
public class TextureManagerScript : MonoBehaviour
{
	// Token: 0x06001EE6 RID: 7910 RVA: 0x001B4838 File Offset: 0x001B2A38
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

	// Token: 0x04004011 RID: 16401
	public Texture[] UniformTextures;

	// Token: 0x04004012 RID: 16402
	public Texture[] CasualTextures;

	// Token: 0x04004013 RID: 16403
	public Texture[] SocksTextures;

	// Token: 0x04004014 RID: 16404
	public Texture2D PurpleStockings;

	// Token: 0x04004015 RID: 16405
	public Texture2D GreenStockings;

	// Token: 0x04004016 RID: 16406
	public Texture2D Base2D;

	// Token: 0x04004017 RID: 16407
	public Texture2D Overlay2D;
}
