using System;
using UnityEngine;

// Token: 0x02000470 RID: 1136
public class TextureManagerScript : MonoBehaviour
{
	// Token: 0x06001EB4 RID: 7860 RVA: 0x001AF86C File Offset: 0x001ADA6C
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

	// Token: 0x04003F71 RID: 16241
	public Texture[] UniformTextures;

	// Token: 0x04003F72 RID: 16242
	public Texture[] CasualTextures;

	// Token: 0x04003F73 RID: 16243
	public Texture[] SocksTextures;

	// Token: 0x04003F74 RID: 16244
	public Texture2D PurpleStockings;

	// Token: 0x04003F75 RID: 16245
	public Texture2D GreenStockings;

	// Token: 0x04003F76 RID: 16246
	public Texture2D Base2D;

	// Token: 0x04003F77 RID: 16247
	public Texture2D Overlay2D;
}
