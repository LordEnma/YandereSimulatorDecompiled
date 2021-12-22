using System;
using UnityEngine;

// Token: 0x0200046B RID: 1131
public class TextureManagerScript : MonoBehaviour
{
	// Token: 0x06001E8C RID: 7820 RVA: 0x001ABC8C File Offset: 0x001A9E8C
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

	// Token: 0x04003F0F RID: 16143
	public Texture[] UniformTextures;

	// Token: 0x04003F10 RID: 16144
	public Texture[] CasualTextures;

	// Token: 0x04003F11 RID: 16145
	public Texture[] SocksTextures;

	// Token: 0x04003F12 RID: 16146
	public Texture2D PurpleStockings;

	// Token: 0x04003F13 RID: 16147
	public Texture2D GreenStockings;

	// Token: 0x04003F14 RID: 16148
	public Texture2D Base2D;

	// Token: 0x04003F15 RID: 16149
	public Texture2D Overlay2D;
}
