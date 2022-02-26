using System;
using UnityEngine;

// Token: 0x02000470 RID: 1136
public class TextureManagerScript : MonoBehaviour
{
	// Token: 0x06001EB1 RID: 7857 RVA: 0x001AF144 File Offset: 0x001AD344
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

	// Token: 0x04003F5A RID: 16218
	public Texture[] UniformTextures;

	// Token: 0x04003F5B RID: 16219
	public Texture[] CasualTextures;

	// Token: 0x04003F5C RID: 16220
	public Texture[] SocksTextures;

	// Token: 0x04003F5D RID: 16221
	public Texture2D PurpleStockings;

	// Token: 0x04003F5E RID: 16222
	public Texture2D GreenStockings;

	// Token: 0x04003F5F RID: 16223
	public Texture2D Base2D;

	// Token: 0x04003F60 RID: 16224
	public Texture2D Overlay2D;
}
