using System;
using UnityEngine;

// Token: 0x0200046F RID: 1135
public class TextureManagerScript : MonoBehaviour
{
	// Token: 0x06001EA8 RID: 7848 RVA: 0x001AE608 File Offset: 0x001AC808
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

	// Token: 0x04003F4A RID: 16202
	public Texture[] UniformTextures;

	// Token: 0x04003F4B RID: 16203
	public Texture[] CasualTextures;

	// Token: 0x04003F4C RID: 16204
	public Texture[] SocksTextures;

	// Token: 0x04003F4D RID: 16205
	public Texture2D PurpleStockings;

	// Token: 0x04003F4E RID: 16206
	public Texture2D GreenStockings;

	// Token: 0x04003F4F RID: 16207
	public Texture2D Base2D;

	// Token: 0x04003F50 RID: 16208
	public Texture2D Overlay2D;
}
