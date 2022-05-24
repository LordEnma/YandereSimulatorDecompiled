using System;
using UnityEngine;

// Token: 0x02000478 RID: 1144
public class TextureManagerScript : MonoBehaviour
{
	// Token: 0x06001EEF RID: 7919 RVA: 0x001B5E40 File Offset: 0x001B4040
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

	// Token: 0x04004038 RID: 16440
	public Texture[] UniformTextures;

	// Token: 0x04004039 RID: 16441
	public Texture[] CasualTextures;

	// Token: 0x0400403A RID: 16442
	public Texture[] SocksTextures;

	// Token: 0x0400403B RID: 16443
	public Texture2D PurpleStockings;

	// Token: 0x0400403C RID: 16444
	public Texture2D GreenStockings;

	// Token: 0x0400403D RID: 16445
	public Texture2D Base2D;

	// Token: 0x0400403E RID: 16446
	public Texture2D Overlay2D;
}
