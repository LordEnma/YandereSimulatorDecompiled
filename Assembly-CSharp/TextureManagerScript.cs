using System;
using UnityEngine;

// Token: 0x0200046D RID: 1133
public class TextureManagerScript : MonoBehaviour
{
	// Token: 0x06001E99 RID: 7833 RVA: 0x001ACAC0 File Offset: 0x001AACC0
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

	// Token: 0x04003F2A RID: 16170
	public Texture[] UniformTextures;

	// Token: 0x04003F2B RID: 16171
	public Texture[] CasualTextures;

	// Token: 0x04003F2C RID: 16172
	public Texture[] SocksTextures;

	// Token: 0x04003F2D RID: 16173
	public Texture2D PurpleStockings;

	// Token: 0x04003F2E RID: 16174
	public Texture2D GreenStockings;

	// Token: 0x04003F2F RID: 16175
	public Texture2D Base2D;

	// Token: 0x04003F30 RID: 16176
	public Texture2D Overlay2D;
}
