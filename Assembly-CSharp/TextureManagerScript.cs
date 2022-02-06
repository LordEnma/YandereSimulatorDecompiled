using System;
using UnityEngine;

// Token: 0x0200046E RID: 1134
public class TextureManagerScript : MonoBehaviour
{
	// Token: 0x06001EA1 RID: 7841 RVA: 0x001AE150 File Offset: 0x001AC350
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

	// Token: 0x04003F41 RID: 16193
	public Texture[] UniformTextures;

	// Token: 0x04003F42 RID: 16194
	public Texture[] CasualTextures;

	// Token: 0x04003F43 RID: 16195
	public Texture[] SocksTextures;

	// Token: 0x04003F44 RID: 16196
	public Texture2D PurpleStockings;

	// Token: 0x04003F45 RID: 16197
	public Texture2D GreenStockings;

	// Token: 0x04003F46 RID: 16198
	public Texture2D Base2D;

	// Token: 0x04003F47 RID: 16199
	public Texture2D Overlay2D;
}
