using System;
using UnityEngine;

// Token: 0x0200046B RID: 1131
public class TextureManagerScript : MonoBehaviour
{
	// Token: 0x06001E8E RID: 7822 RVA: 0x001AC140 File Offset: 0x001AA340
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

	// Token: 0x04003F16 RID: 16150
	public Texture[] UniformTextures;

	// Token: 0x04003F17 RID: 16151
	public Texture[] CasualTextures;

	// Token: 0x04003F18 RID: 16152
	public Texture[] SocksTextures;

	// Token: 0x04003F19 RID: 16153
	public Texture2D PurpleStockings;

	// Token: 0x04003F1A RID: 16154
	public Texture2D GreenStockings;

	// Token: 0x04003F1B RID: 16155
	public Texture2D Base2D;

	// Token: 0x04003F1C RID: 16156
	public Texture2D Overlay2D;
}
